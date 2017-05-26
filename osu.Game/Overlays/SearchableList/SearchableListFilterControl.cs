﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays.SearchableList
{
    public abstract class SearchableListFilterControl<T> : Container
    {
        private const float padding = 10;

        private readonly Box tabStrip;

        public readonly SearchTextBox Search;
        public readonly PageTabControl<T> Tabs;

        protected abstract Color4 BackgroundColour { get; }
        protected abstract T DefaultTab { get; }
        protected virtual Drawable CreateSupplementaryControls() => null;

        protected SearchableListFilterControl()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("BrowseFilterControl only supports enums as the generic type argument");

            RelativeSizeAxes = Axes.X;
            AutoSizeAxes = Axes.Y;

            var controls = CreateSupplementaryControls();
            Container controlsContainer;
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = BackgroundColour,
                    Alpha = 0.9f,
                },
                tabStrip = new Box
                {
                    Anchor = Anchor.BottomLeft,
                    Origin = Anchor.BottomLeft,
                    RelativeSizeAxes = Axes.X,
                    Height = 1,
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Padding = new MarginPadding { Top = padding, Horizontal = SearchableListOverlay.WIDTH_PADDING },
                    Children = new Drawable[]
                    {
                        Search = new FilterSearchTextBox
                        {
                            RelativeSizeAxes = Axes.X,
                        },
                        controlsContainer = new Container
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Margin = new MarginPadding { Top = controls != null ? padding : 0 },
                        },
                        Tabs = new PageTabControl<T>
                        {
                            RelativeSizeAxes = Axes.X,
                        },
                        new Box //keep the tab strip part of autosize, but don't put it in the flow container
                        {
                            RelativeSizeAxes = Axes.X,
                            Height = 1,
                            Colour = Color4.White.Opacity(0),
                        },
                    },
                },
            };

            if (controls != null) controlsContainer.Children = new[] { controls };

            Tabs.Current.Value = DefaultTab;
            Tabs.Current.TriggerChange();
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            tabStrip.Colour = colours.Yellow;
        }

        private class FilterSearchTextBox : SearchTextBox
        {
            protected override Color4 BackgroundUnfocused => backgroundColour;
            protected override Color4 BackgroundFocused => backgroundColour;

            private Color4 backgroundColour;

            [BackgroundDependencyLoader]
            private void load(OsuColour colours)
            {
                backgroundColour = colours.Gray2.Opacity(0.9f);
            }
        }
    }
}
