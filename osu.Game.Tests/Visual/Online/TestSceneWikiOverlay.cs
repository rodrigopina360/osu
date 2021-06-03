// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using NUnit.Framework;
using osu.Game.Online.API;
using osu.Game.Online.API.Requests;
using osu.Game.Online.API.Requests.Responses;
using osu.Game.Overlays;

namespace osu.Game.Tests.Visual.Online
{
    public class TestSceneWikiOverlay : OsuTestScene
    {
        private DummyAPIAccess dummyAPI => (DummyAPIAccess)API;

        private WikiOverlay wiki;

        [SetUp]
        public void SetUp() => Schedule(() => Child = wiki = new WikiOverlay());

        [Test]
        public void TestMainPage()
        {
            setUpWikiResponse(responseMainPage);
            AddStep("Show Main Page", () => wiki.Show());
        }

        [Test]
        public void TestArticlePage()
        {
            setUpWikiResponse(responseArticlePage);
            AddStep("Show Article Page", () => wiki.ShowPage("Interface"));
        }

        private void setUpWikiResponse(APIWikiPage r)
            => AddStep("set up response", () =>
            {
                dummyAPI.HandleRequest = request =>
                {
                    if (!(request is GetWikiRequest getWikiRequest))
                        return false;

                    getWikiRequest.TriggerSuccess(r);
                    return true;
                };
            });

        // From https://osu.ppy.sh/api/v2/wiki/en/Main_Page
        private APIWikiPage responseMainPage => new APIWikiPage
        {
            Title = "Main Page",
            Layout = "main_page",
            Path = "Main_Page",
            Locale = "en",
            Subtitle = null,
            Markdown =
                "---\nlayout: main_page\n---\n\n<!-- Do not add any empty lines inside this div. -->\n\n<div class=\"wiki-main-page__blurb\">\nWelcome to the osu! wiki, a project containing a wide range of osu! related information.\n</div>\n\n<div class=\"wiki-main-page__panels\">\n<div class=\"wiki-main-page-panel wiki-main-page-panel--full\">\n\n# Getting started\n\n[Welcome](/wiki/Welcome) • [Installation](/wiki/Installation) • [Registration](/wiki/Registration) • [Help Centre](/wiki/Help_Centre) • [FAQ](/wiki/FAQ)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# Game client\n\n[Interface](/wiki/Interface) • [Options](/wiki/Options) • [Visual settings](/wiki/Visual_Settings) • [Shortcut key reference](/wiki/Shortcut_key_reference) • [Configuration file](/wiki/osu!_Program_Files/User_Configuration_File) • [Program files](/wiki/osu!_Program_Files)\n\n[File formats](/wiki/osu!_File_Formats): [.osz](/wiki/osu!_File_Formats/Osz_(file_format)) • [.osk](/wiki/osu!_File_Formats/Osk_(file_format)) • [.osr](/wiki/osu!_File_Formats/Osr_(file_format)) • [.osu](/wiki/osu!_File_Formats/Osu_(file_format)) • [.osb](/wiki/osu!_File_Formats/Osb_(file_format)) • [.db](/wiki/osu!_File_Formats/Db_(file_format))\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# Gameplay\n\n[Game modes](/wiki/Game_mode): [osu!](/wiki/Game_mode/osu!) • [osu!taiko](/wiki/Game_mode/osu!taiko) • [osu!catch](/wiki/Game_mode/osu!catch) • [osu!mania](/wiki/Game_mode/osu!mania)\n\n[Beatmap](/wiki/Beatmap) • [Hit object](/wiki/Hit_object) • [Mods](/wiki/Game_modifier) • [Score](/wiki/Score) • [Replay](/wiki/Replay) • [Multi](/wiki/Multi)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# [Beatmap editor](/wiki/Beatmap_Editor)\n\nSections: [Compose](/wiki/Beatmap_Editor/Compose) • [Design](/wiki/Beatmap_Editor/Design) • [Timing](/wiki/Beatmap_Editor/Timing) • [Song setup](/wiki/Beatmap_Editor/Song_Setup)\n\nComponents: [AiMod](/wiki/Beatmap_Editor/AiMod) • [Beat snap divisor](/wiki/Beatmap_Editor/Beat_Snap_Divisor) • [Distance snap](/wiki/Beatmap_Editor/Distance_Snap) • [Menu](/wiki/Beatmap_Editor/Menu) • [SB load](/wiki/Beatmap_Editor/SB_Load) • [Timelines](/wiki/Beatmap_Editor/Timelines)\n\n[Beatmapping](/wiki/Beatmapping) • [Difficulty](/wiki/Beatmap/Difficulty) • [Mapping techniques](/wiki/Mapping_Techniques) • [Storyboarding](/wiki/Storyboarding)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# Beatmap submission and ranking\n\n[Submission](/wiki/Submission) • [Modding](/wiki/Modding) • [Ranking procedure](/wiki/Beatmap_ranking_procedure) • [Mappers' Guild](/wiki/Mappers_Guild) • [Project Loved](/wiki/Project_Loved)\n\n[Ranking criteria](/wiki/Ranking_Criteria): [osu!](/wiki/Ranking_Criteria/osu!) • [osu!taiko](/wiki/Ranking_Criteria/osu!taiko) • [osu!catch](/wiki/Ranking_Criteria/osu!catch) • [osu!mania](/wiki/Ranking_Criteria/osu!mania)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# Community\n\n[Tournaments](/wiki/Tournaments) • [Skinning](/wiki/Skinning) • [Projects](/wiki/Projects) • [Guides](/wiki/Guides) • [osu!dev Discord server](/wiki/osu!dev_Discord_server) • [How you can help](/wiki/How_You_Can_Help!) • [Glossary](/wiki/Glossary)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# People\n\n[The Team](/wiki/People/The_Team): [Developers](/wiki/People/The_Team/Developers) • [Global Moderation Team](/wiki/People/The_Team/Global_Moderation_Team) • [Support Team](/wiki/People/The_Team/Support_Team) • [Nomination Assessment Team](/wiki/People/The_Team/Nomination_Assessment_Team) • [Beatmap Nominators](/wiki/People/The_Team/Beatmap_Nominators) • [osu! Alumni](/wiki/People/The_Team/osu!_Alumni) • [Project Loved Team](/wiki/People/The_Team/Project_Loved_Team)\n\nOrganisations: [osu! UCI](/wiki/Organisations/osu!_UCI)\n\n[Community Contributors](/wiki/People/Community_Contributors) • [Users with unique titles](/wiki/People/Users_with_unique_titles)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# For developers\n\n[API](/wiki/osu!api) • [Bot account](/wiki/Bot_account) • [Brand identity guidelines](/wiki/Brand_identity_guidelines)\n\n</div>\n<div class=\"wiki-main-page-panel\">\n\n# About the wiki\n\n[Sitemap](/wiki/Sitemap) • [Contribution guide](/wiki/osu!_wiki_Contribution_Guide) • [Article styling criteria](/wiki/Article_Styling_Criteria) • [News styling criteria](/wiki/News_Styling_Criteria)\n\n</div>\n</div>\n",
        };

        // From https://osu.ppy.sh/api/v2/wiki/en/Interface
        private APIWikiPage responseArticlePage => new APIWikiPage
        {
            Title = "Interface",
            Layout = "markdown_page",
            Path = "Interface",
            Locale = "en",
            Subtitle = null,
            Markdown =
                "# Interface\n\n![](img/intro-screen.jpg \"Introduction screen\")\n\n## Main Menu\n\n![](img/main-menu.jpg \"Main Menu\")\n\nThe [osu!cookie](/wiki/Glossary#cookie) \\[1\\] pulses according to the [BPM](/wiki/Beatmapping/Beats_per_minute) of any song currently playing on the main menu. In addition, bars will extend out of the osu!cookie in accordance to the song's volume. If no song is playing, it pulses at a slow 60 BPM. The elements of the main menu are as follows:\n\n- \\[2\\] Click Play (`P`) or the logo to switch to the Solo mode song selection screen.\n- \\[3\\] Click Edit (`E`) to open the Editor mode song selection screen.\n- \\[4\\] Click Options (`O`) to go to the Options screen.\n- \\[5\\] Click Exit (`Esc`) to exit osu!.\n- \\[6\\] A random useful tip is displayed below the menu.\n- \\[7\\] In the lower-left is a link to the osu! website, as well as copyright information.\n- \\[8\\] Connection result to [Bancho](/wiki/Glossary#bancho)! In this picture it is not shown, but the connection result looks like a chain link.\n- \\[9\\] In the bottom right are the chat controls for the extended [chat window](/wiki/Chat_Console) (called \"Player List\" here) and the regular chat window (`F9` & `F8`, respectively).\n- \\[10\\] In the upper right is the osu! jukebox which plays the songs in random order. The top shows the song currently playing. The buttons, from left to right, do as follows:\n  - Previous Track\n  - Play\n  - Pause\n  - Stop (the difference between Play and Stop is that Stop will reset the song to the beginning, while Pause simply pauses it)\n  - Next Track\n  - View Song Info. This toggles the top bar showing the song info between being permanent and temporary. When permanent, the info bar will stay visible until it fades out with the rest of the UI. When temporary, it will disappear a little while after a song has been chosen. It will stay hidden until it is toggled again, or another song plays.\n- \\[11\\] The number of beatmaps you have available, how long your osu!client has been running, and your system clock.\n- \\[12\\] Your profile, click on it to display the User Options (see below).\n\n## User Options\n\n![](img/user-options.jpg \"User Options\")\n\nAccess this screen by clicking your profile at the top left of the main menu. You cannot access the Chat Consoles while viewing the user option screen. You can select any item by pressing the corresponding number on the option:\n\n1. `View Profile`: Opens up your profile page in your default web browser.\n2. `Sign Out`: Sign out of your account (after signing out, the [Options](/wiki/Options) sidebar will prompt you to sign in).\n3. `Change Avatar`: Open up the edit avatar page in your default web browser.\n4. `Close`: Close this dialog\n\n## Play Menu\n\n![](img/play-menu.jpg \"Play Menu\")\n\n- Click `Solo` (`P`) to play alone.\n- Click `Multi` (`M`) to play with other people. You will be directed to the [Multi](/wiki/Multi) Lobby (see below).\n- Click `Back` to return to the main menu.\n\n## Multi Lobby\n\n*Main page: [Multi](/wiki/Multi)*\n\n![](img/multi-lobby.jpg \"Multi Lobby\")\n\n![](img/multi-room.jpg \"Multi Host\")\n\n1. Your rank in the match. This is also shown next to your name.\n2. Your profile information.\n3. The jukebox.\n4. Player list - displays player names, their rank (host or player), their [mods](/wiki/Game_modifier) activated (if any, see \\#7), their osu! ranking, and their team (if applicable).\n5. The name of the match and the password settings.\n6. The beatmap selected. It shows the beatmap as it would in the solo song selection screen.\n7. The [mods](/wiki/Game_modifier) that you have activated (see #12), as well as the option to select them. The option marked \"Free Mods\" toggles whether or not players can select their own mods. If yes, they can pick any combination of mods *except for speed-altering mods like [Double Time](/wiki/Game_modifier/Double_Time)*. If no, the host decides what mods will be used. The host can pick speed-altering mods regardless of whether or not Free Mods is turned on.\n8. The team mode and win conditions.\n9. The ready button.\n10. The [chat console](/wiki/Chat_Console).\n11. The leave button.\n12. Where your activated mods appear.\n\n## Song Selection Screen\n\n![](img/song-selection.jpg \"Song Selection\")\n\nYou can identify the current mode selected by either looking at the icon in the bottom left, above Mode, or by looking at the transparent icon in the center of the screen. These are the four you will see:\n\n- ![](/wiki/shared/mode/osu.png) is [osu!](/wiki/Game_mode/osu!)\n- ![](/wiki/shared/mode/taiko.png) is [osu!taiko](/wiki/Game_mode/osu!taiko)\n- ![](/wiki/shared/mode/catch.png) is [osu!catch](/wiki/Game_mode/osu!catch)\n- ![](/wiki/shared/mode/mania.png) is [osu!mania](/wiki/Game_mode/osu!mania)\n\nBefore continuing on, this screen has too many elements to note with easily, noticeable numbers. The subsections below will focus on one part of the screen at a time, starting from the top down and left to right.\n\n### Beatmap Information\n\n![](img/metadata-comparison.jpg)\n\n![](img/beatmap-metadata.jpg)\n\nThis area displays **information on the beatmap difficulty currently selected.** By default, the beatmap whose song is heard in the osu! jukebox is selected when entering the selection screen. In the top left is the ranked status of the beatmap. The title is next. Normally, the romanised title is shown, but if you select `Prefer metadata in original language` in the [Options](/wiki/Options), it will show the Unicode title; this is shown in the upper picture. The beatmapper is also shown, and beatmap information is shown below. From left to right, the values are as follows:\n\n- **Length**: The total length of the beatmap, from start to finish and including breaks. Not to be confused with [drain time](/wiki/Glossary#drain-time).\n- **BPM**: The BPM of the beatmap. If (like in the lower picture) there are two BPMS and one in parentheses, this means that the BPM changes throughout the song. It shows the slowest and fastest BPMs, and the value in parentheses is the BPM at the start of the beatmap.\n- **Objects**: The total amount of [hit objects](/wiki/Hit_Objects) in the beatmap.\n- **Circles**: The total amount of hit circles in the beatmap.\n- **Sliders**: The total amount of sliders in the beatmap.\n- **Spinners**: The total amount of spinners in the beatmap.\n- **OD**: The Overall Difficulty of the beatmap.\n- **HP**: The drain rate of your HP. In osu!, this is how much of an HP loss you receive upon missing a note, how fast the life bar idly drains, and how much HP is received for hitting a note. In osu!mania, this is the same except there is no idle HP drain. In osu!taiko, this determines how slowly the HP bar fills and how much HP is lost when a note is missed. osu!catch is the same as osu!.\n- **Stars**: The star difficulty of the beatmap. This is graphically visible in the beatmap rectangle itself.\n\n### Group and Sort\n\n![](img/beatmap-filters.jpg)\n\nClick on one of the tabs to **sort your song list according to the selected criterion**.\n\n**Group** - Most options organize beatmaps into various expandable groups:\n\n- `No grouping` - Beatmaps will not be grouped but will still be sorted in the order specified by Sort.\n- `By Difficulty` - Beatmaps will be grouped by their star difficulty, rounded to the nearest whole number.\n- `By Artist` - Beatmaps will be grouped by the artist's first character of their name.\n- `Recently Played` - Beatmaps will be grouped by when you last played them.\n- `Collections` - This will show the collections you have created. *Note that this will hide beatmaps not listed in a collection!*\n- `By BPM` - Beatmaps will be grouped according to BPM in multiples of 60, starting at 120.\n- `By Creator` - Beatmaps will be grouped by the beatmap creator's name's first character.\n- `By Date Added` - Beatmaps will be grouped according to when they were added, from today to 4+ months ago.\n- `By Length` - Beatmaps will be grouped according to their length: 1 minute or less, 2 minutes or less, 3, 4, 5, and 10.\n- `By Mode` - Beatmaps will be grouped according to their game mode.\n- `By Rank Achieved` - Beatmaps will be sorted by the highest rank achieved on them.\n- `By Title` - Beatmaps will be grouped by the first letter of their title.\n- `Favourites` - Only beatmaps you have favorited online will be shown.\n- `My Maps` - Only beatmaps you have mapped (that is, whose creator matches your profile name) will be shown.\n- `Ranked Status` - Beatmaps will be grouped by their ranked status: ranked, pending, not submitted, unknown, or loved.\n\nThe first five groupings are available in tabs below Group and Sort.\n\n**Sort** - Sorts beatmaps in a certain order\n\n- `By Artist` - Beatmaps will be sorted alphabetically by the artist's name's first character.\n- `By BPM` - Beatmaps will be sorted lowest to highest by their BPM. For maps with multiple BPMs, the highest will be used.\n- `By Creator` - Beatmaps will be sorted alphabetically by the creator's name's first character.\n- `By Date Added` - Beatmaps will be sorted from oldest to newest by when they were added.\n- `By Difficulty` - Beatmaps will be sorted from easiest to hardest by star difficulty. *Note that this will split apart mapsets!*\n- `By Length` - Beatmaps will be sorted from shortest to longest by length.\n- `By Rank Achieved` - Beatmaps will be sorted from poorest to best by the highest rank achieved on them.\n- `By Title` - Beatmaps will be sorted alphabetically by the first character of their name.\n\n### Search\n\n![](img/search-bar.jpg)\n\n*Note: You cannot have the chat console or the options sidebar open if you want to search; otherwise, anything you type will be perceived as chat text or as an options search query.*\n\nOnly beatmaps that match the criteria of your search will be shown. By default, any search will be matched against the beatmaps' artists, titles, creators, and tags.\n\nIn addition to searching these fields, you can use filters to search through other metadata by combining one of the supported filters with a comparison to a value (for example, `ar=9`).\n\nSupported filters:\n\n- `artist`: Name of the artist\n- `creator`: Name of the beatmap creator\n- `ar`: Approach Rate\n- `cs`: Circle Size\n- `od`: Overall Difficulty\n- `hp`: HP Drain Rate\n- `keys`: Number of keys (osu!mania and converted beatmaps only)\n- `stars`: Star Difficulty\n- `bpm`: Beats per minute\n- `length`: Length in seconds\n- `drain`: Drain Time in seconds\n- `mode`: Mode. Value can be `osu`, `taiko`, `catchthebeat`, or `mania`, or `o`/`t`/`c`/`m` for short.\n- `status`: Ranked status. Value can be `ranked`, `approved`, `pending`, `notsubmitted`, `unknown`, or `loved`, or `r`/`a`/`p`/`n`/`u`/`l` for short.\n- `played`: Time since last played in days\n- `unplayed`: Shows only unplayed maps. A comparison with no set value must be used. The comparison itself is ignored.\n- `speed`: Saved osu!mania scroll speed. Always 0 for unplayed maps or if the [Remember osu!mania scroll speed per beatmap](/wiki/Options#gameplay) option is off\n\nSupported comparisons:\n\n- `=` or `==`: Equal to\n- `!=`: Not equal to\n- `<`: Less than\n- `>`: Greater than\n- `<=`: Less than or equal to\n- `>=`: Greater than or equal to\n\nYou may also enter a beatmap or beatmapset ID in your search to get a single result.\n\n### Rankings\n\n![](img/leaderboards.jpg)\n\n A variety of things can appear in this space:\n\n- A \"Not Submitted\" box denotes a beatmap that has not been uploaded to the osu! site using the Beatmap Submission System or was deleted by the mapper.\n- An \"Update to latest version\" box appears if there is a new version of the beatmap available for download. Click on the button to update.\n  - **Note:** Once you update the beatmap, it cannot be reversed. If you want to preserve the older version for some reason (say, to keep scores), then do not update.\n- A \"Latest pending version\" box appears means that the beatmap has been uploaded to the osu!website but is not ranked yet.\n- If replays matching the view setting of the beatmap exist, they will be displayed instead of a box denoting the ranked/played status of the beatmap. This is shown in the above picture.\n  - Under public rankings (e.g. Global, Friends, etc.), your high score will be shown at the bottom, as well as your rank on the leaderboard.\n- A \"No records set!\" box means that there are no replays for the current view setting (this is typically seen in the Local view setting if you just downloaded or edited the beatmap).\n  - Note: Scores for Multi are not counted as records.\n\nThese are the view settings:\n\n- Local Ranking\n- Country Ranking\\*\n- Global Ranking\n- Global Ranking (Selected Mods)\\*\n- Friend Ranking\\*\n\n\\*Requires you to be an [osu!supporter](/wiki/osu!supporter) to access them.\n\nClick the word bubble icon to call up the **Quick Web Access** screen for the selected beatmap:\n\n- Press `1` or click the `Beatmap Listing/Scores` button and your default internet browser will pull up the Beatmap Listing and score page of the beatmap set the selected beatmap belongs to.\n- Press `2` or click `Beatmap Modding` and your default internet browser will pull up the modding page of the beatmap set the selected beatmap belongs to.\n- Press `3` or `Esc` or click `Cancel` to return to the Song Selection Screen.\n\nWhile you are on the Quick Web Access Screen, you cannot access the Chat and Extended Chat Consoles.\n\n### Song\n\n![](img/beatmap-cards.jpg)\n\nThe song list displays all available beatmaps. Different beatmaps may have different coloured boxes:\n\n- **Pink**: This beatmap has not been played yet.\n- **Orange**: At least one beatmap from the beatmapset has been completed.\n- **Light Blue**: Other beatmaps in the same set, shown when a mapset is expanded.\n- **White**: Currently selected beatmap.\n\nYou can navigate the beatmap list by using the mouse wheel, using the up and down arrow keys, dragging it while holding the left mouse button or clicking the right mouse button (previously known as Absolute Scrolling), which will move the scroll bar to your mouse's Y position. Click on a box to select that beatmap and display its information on the upper left, high scores (if any) on the left and, if you've cleared it, the letter grade of the highest score you've achieved. Click the box again, press `Enter` or click the osu!cookie at the lower right to begin playing the beatmap.\n\n### Gameplay toolbox\n\n![](img/game-mode-selector.jpg \"List of available game modes\")\n\n![](img/gameplay-toolbox.jpg)\n\nThis section can be called the gameplay toolbox. We will cover each button's use from left to right.\n\nPress `Esc` or click the `Back` button to return to main menu.\n\nClick on the `Mode` button to open up a list of gameplay modes available on osu!. Click on your desired gameplay mode and osu! will switch to that gameplay mode style - the scoreboard will change accordingly. Alternatively, you can press `Ctrl` and `1` (osu!), `2` (osu!taiko), `3` (osu!catch), or `4` (osu!mania) to change the gamemode.\n\nThe background transparent icon and the \"Mode\" box will change to depict what mode is currently selected.\n\n![](img/game-modifiers.jpg \"Mod Selection Screen\")\n\nClick the `Mods` button or press `F1` to open the **[Mod Selection Screen](/wiki/Game_modifier)**.\n\nIn this screen, you can apply modifications (\"mods\" for short) to gameplay. Some mods lower difficulty and apply a multiplier that lowers the score you achieve. Conversely, some mods increase the difficulty, but apply a multiplier that increases the score you achieve. Finally, some mods modify gameplay in a different way. [Relax](/wiki/Game_modifier/Relax) and [Auto Pilot](/wiki/Game_modifier/Autopilot) fall in that category.\n\nPlace your mouse on a mod's icon to see a short description of its effect. Click on an icon to select or deselect that mod. Some mods, like Double Time, have multiple variations; click on the mod again to cycle through. The score multiplier value displays the combined effect the multipliers of the mod(s) of you have selected will have on your score. Click `Reset all mods` or press `1` to deselect all currently selected mods. Click `Close` or press `2` or `Esc` to return to the Song Selection Screen.\n\nWhile you are on the Mod Selection Screen, you cannot access the Chat and Extended Chat Consoles. In addition, skins can alter the text and/or icon of the mods, but the effects will still be the same.\n\nClick the `Random` button or press `F2` to have the game **randomly scroll through all of your beatmaps and pick one.** You cannot select a beatmap yourself until it has finished scrolling.\n\n*Note: You can press `Shift` + the `Random` button or `F2` to go back to the beatmap you had selected before you randomized your selection.*\n\n![](img/beatmap-options.jpg \"Possible commands for a beatmap\")\n\nClick the `Beatmap Options` button, press `F3` or right-click your mouse while hovering over the beatmap to call up the **Beatmap Options Menu for options on the currently selected beatmap**.\n\n- Press `1` or click the `Manage Collections` button to bring up the Collections screen - here, you can manage pre-existing collections, as well as add or remove the currently selected beatmap or mapset to or from a collection.\n- Press `2` or click `Delete...` to delete the \\[1\\] currently selected beatmapset, \\[2\\] delete the currently selected beatmap, or \\[3\\] delete **all VISIBLE beatmaps**.\n  - Note that deleted beatmaps are moved to the Recycle Bin.\n- Press `3` or click `Remove from Unplayed` to mark an unplayed beatmap as played (that is, change its box colour from pink to orange).\n- Press `4` or click `Clear local scores` to delete all records of the scores you have achieved in this beatmap.\n- Press `5` or click `Edit` to open the selected beatmap in osu!'s Editor.\n- Press `6` or `Esc` or click `Close` to return to the Song Selection Screen.\n\nClick on **your user panel** to access the **User Options Menu**.\n\nClick the **[osu!cookie](/wiki/Glossary#cookie)** to **start playing the selected beatmap**.\n\n## Results screen\n\n![](img/results-osu.jpg \"Accuracy in osu!\")\n\nThis is the results screen shown after you have successfully passed the beatmap. You can access your online results by scrolling down or pressing the obvious button.\n\n**Note:** The results screen may change depending on the used skin.\n\nBelow are the results screens of the other game modes.\n\n![](img/results-taiko.jpg \"Accuracy in osu!taiko\")\n\n![](img/results-mania.jpg \"Accuracy in osu!mania\")\n\n![](img/results-catch.jpg \"Accuracy in osu!catch\")\n\n### Online Leaderboard\n\n![](img/extended-results-screen.jpg \"An example of an osu!online score\")\n\nThis is your online leaderboard. You can go here by scrolling down from the results screen. Your Local Scoreboard will show your name and the score as usual.\n\n1. Your player bar. It shows your [PP](/wiki/Performance_Points), Global Rank, Total Score, Overall [Accuracy](/wiki/Accuracy), and level bar.\n2. `Save replay to Replays folder`: You can watch the replay later either by opening it from a local leaderboard, or by going to `Replays` directory and double clicking it.\n3. `Add as online favourite`: Include the beatmap into your list of favourites, which is located on your osu! profile page under the \"Beatmaps\" section.\n4. Local Leaderboard: All your results are stored on your computer. To see them, navigate to the [song selection screen](#song-selection-screen), then select `Local Rankings` from the drop-down menu on the left.\n5. `Beatmap Ranking` section. Available only for maps with online leaderboards ([qualified](/wiki/Beatmap/Category#qualified), [ranked](/wiki/Beatmap/Category#ranked), or [loved](/wiki/Beatmap/Category#loved)). You also need to be online to see this section.\n   1. `Overall`: Your position on the map's leaderboard, where you compete against players that used [mods](/wiki/Game_modifier), even if you didn't use any yourself.\n   2. `Accuracy`: How [precisely](/wiki/Accuracy) did you play the beatmap. Will only be counted when your old score is surpassed.\n   3. `Max Combo`: Your longest combo on the map you played.\n   4. `Ranked Score`: Your [best result](/wiki/Score#ranked-score) on the beatmap.\n   5. `Total Score`: Not taken into account, since it does not affect your position in online rankings.\n   6. `Performance`: The amount of [unweighted PP](/wiki/Performance_points#why-didnt-i-gain-the-full-amount-of-pp-from-a-map-i-played) you would receive for the play.\n6. `Overall Ranking` section. It's available only for beatmaps with online leaderboards. You also need to be online to see this section.\n   1. `Overall`: Your global ranking in the world.\n   2. `Accuracy`: Your average [accuracy](/wiki/Accuracy#accuracy) over all beatmaps you have played.\n   3. `Max Combo`: The longest combo over all beatmaps you have played.\n   4. [`Ranked Score`](/wiki/Score#ranked-score): The number of points earned from all ranked beatmaps that you have ever played, with every map being counted exactly once.\n   5. [`Total Score`](/wiki/Score#total-score): Same as ranked score, but it takes into account all beatmaps available on the osu! website, and also underplayed or failed beatmaps. This counts towards your level.\n   6. `Perfomance`: Displays your total amount of Performance Points, and also how many PP the submitted play was worth.\n7. Information about the beatmap with its playcount and pass rate.\n8. Beatmap rating. Use your personal discretion based on whether you enjoy the beatmap or not. Best left alone if you can't decide.\n9. Click here to return to the song selection screen.\n\n![](img/medal-unlock.jpg \"Unlocking a medal\")\n\nAbove is what it looks like to receive a medal.\n",
        };
    }
}
