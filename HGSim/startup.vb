Public Structure Player
    Dim ID, Wins, Kills, SoloKills, SharedKills, Deaths, CombatDeaths, Suicides, OtherDeaths As Integer
    Dim Name, Nickname, Picture, DeathPicture As String, Gender As Char
End Structure
Public Structure GameEvent
    Structure Combatant
        Dim DeathType As Byte, IsKiller As Boolean
    End Structure
    Dim EventText As String, PlayerCount, EventScope, KillCount As Byte, P() As Combatant, IsSharedKill As Boolean
End Structure
Public Structure SpecialEvent
    Dim DescriptionText As String, NonFatalEvent, FatalEvent() As GameEvent
End Structure
Public Module GlobalVars
    Public ArenaEvent(), BloodbathEvent(), BloodbathFatal(), DayEvent(), DayFatal(),
        NightEvent(), NightFatal(), FeastEvent(), FeastFatal() As GameEvent
    Public DefaultBloodbath(), DefaultBloodbathFatal(), DefaultDay(), DefaultDayFatal(),
        DefaultNight(), DefaultNightFatal(), DefaultFeast(), DefaultFeastFatal() As GameEvent
    Public BloodbathLimit(5), BloodbathFatalLimit(10), DayLimit(5), DayFatalLimit(10),
        NightLimit(5), NightFatalLimit(10), FeastLimit(5), FeastFatalLimit(10) As Integer
    Public SpecialArenaEvent() As SpecialEvent, Tribute(), Roster() As Player, IsFirstRun,
        HasArenaEvents, ShowRecentDeaths As Boolean, FatalEventOdds, DefaultEventRate As Single, PreviousTribute() As Integer
    Public ini As New IniFile, inipath As String = IO.Directory.GetCurrentDirectory & "\settings.ini"
    Public BloodbathEventColl(5)(), DayEventColl(5)(), NightEventColl(5)(), FeastEventColl(5)(),
        BloodbathFatalColl(10)(), DayFatalColl(10)(), NightFatalColl(10)(), FeastFatalColl(10)() As GameEvent
End Module
Module MainModule
    Public Sub InitializeTributeFile()
        ReDim Tribute(24)
        For ctr = 1 To 24
            With Tribute(ctr)
                .ID = ctr
                .Wins = 0
                .Kills = 0
                .SoloKills = 0
                .SharedKills = 0
                .Deaths = 0
                .CombatDeaths = 0
                .Suicides = 0
                .OtherDeaths = 0
                .Gender = If(ctr Mod 2 = 1, "M", "F")
                .Picture = "T" & ctr.ToString("D5") & ".png"
                .DeathPicture = "BW"
                Select Case ctr
                    Case 1
                        .Name = "Marvel"
                    Case 2
                        .Name = "Glimmer"
                    Case 3
                        .Name = "Cato"
                    Case 4
                        .Name = "Clove"
                    Case 10
                        .Name = "Foxface"
                    Case 11
                        .Name = "Jason"
                    Case 21
                        .Name = "Thresh"
                    Case 22
                        .Name = "Rue"
                    Case 23
                        .Name = "Peeta Mellark"
                    Case 24
                        .Name = "Katniss Everdeen"
                    Case Else
                        .Name = "District " & (ctr + 1) \ 2 & " " & If(ctr Mod 2 = 1, "M", "Fem") & "ale"
                End Select
                .Nickname = If(ctr > 22, Left(.Name, InStr(.Name, " ") - 1), .Name)
            End With
        Next
    End Sub
    Public Sub InitializeEventFile()
        ReDim ArenaEvent(205)
        '---------------------BEGIN ASSIGNING EVENT TEXT----------------------------------
        ArenaEvent(0).EventText = "(Player1) grabs a shovel."
        ArenaEvent(1).EventText = "(Player1) grabs a backpack and retreats."
        ArenaEvent(2).EventText = "(Player1) finds a bow, some arrows, and a quiver."
        ArenaEvent(3).EventText = "(Player1) runs into the cornucopia and hides."
        ArenaEvent(4).EventText = "(Player1) takes a handful of throwing knives."
        ArenaEvent(5).EventText = "(Player1) finds a canteen full of water."
        ArenaEvent(6).EventText = "(Player1) stays at the cornucopia for resources."
        ArenaEvent(7).EventText = "(Player1) gathers as much food as (he/she1) can."
        ArenaEvent(8).EventText = "(Player1) grabs a sword."
        ArenaEvent(9).EventText = "(Player1) takes a spear from inside the cornucopia."
        ArenaEvent(10).EventText = "(Player1) finds a bag full of explosives."
        ArenaEvent(11).EventText = "(Player1) clutches a first aid kit and runs away."
        ArenaEvent(12).EventText = "(Player1) takes a sickle from inside the cornucopia."
        ArenaEvent(13).EventText = "(Player1) runs away with a lighter and some rope."
        ArenaEvent(14).EventText = "(Player1) snatches a bottle of alcohol and a rag."
        ArenaEvent(15).EventText = "(Player1) finds a backpack full of camping equipment."
        ArenaEvent(16).EventText = "(Player1) grabs a backpack, not realizing it is empty."
        ArenaEvent(17).EventText = "(Player1) retrieves a trident from inside the cornucopia."
        ArenaEvent(18).EventText = "(Player1) grabs a shield leaning on the cornucopia."
        ArenaEvent(19).EventText = "(Player1) snatches a pair of sais."
        ArenaEvent(20).EventText = "(Player1) grabs a jar of fishing bait while (Player2) gets fishing gear."
        ArenaEvent(21).EventText = "(Player1) scares (Player2) away from the cornucopia."
        ArenaEvent(22).EventText = "(Player1) and (Player2) fight for a bag. (Player1) gives up and retreats."
        ArenaEvent(23).EventText = "(Player1) and (Player2) fight for a bag. (Player2) gives up and retreats."
        ArenaEvent(24).EventText = "(Player1) breaks (Player2)'s nose for a basket of bread."
        ArenaEvent(25).EventText = "(Player1) rips a mace out of (Player2)'s hands."
        ArenaEvent(26).EventText = "(Player1), (Player2), and (Player3) work together to get as many supplies as possible."
        ArenaEvent(27).EventText = "(Player1), (Player2), (Player3), and (Player4) share everything they gathered before running."
        ArenaEvent(28).EventText = "(Player1) goes hunting."
        ArenaEvent(29).EventText = "(Player1) injures (himself/herself1)."
        ArenaEvent(30).EventText = "(Player1) explores the arena."
        ArenaEvent(31).EventText = "(Player1) fishes."
        ArenaEvent(32).EventText = "(Player1) camouflauges (himself/herself1) in the bushes."
        ArenaEvent(33).EventText = "(Player1) makes a wooden spear."
        ArenaEvent(34).EventText = "(Player1) discovers a cave."
        ArenaEvent(35).EventText = "(Player1) collects fruit from a tree."
        ArenaEvent(36).EventText = "(Player1) searches for a water source."
        ArenaEvent(37).EventText = "(Player1) tries to sleep through the entire day."
        ArenaEvent(38).EventText = "(Player1) makes a slingshot."
        ArenaEvent(39).EventText = "(Player1) travels to higher ground."
        ArenaEvent(40).EventText = "(Player1) discovers a river."
        ArenaEvent(41).EventText = "(Player1) is pricked by thorns while picking berries."
        ArenaEvent(42).EventText = "(Player1) tries to spear fish with a trident."
        ArenaEvent(43).EventText = "(Player1) searches for firewood."
        ArenaEvent(44).EventText = "(Player1) constructs a shack."
        ArenaEvent(45).EventText = "(Player1) practices (his/her1) archery."
        ArenaEvent(46).EventText = "(Player1) picks flowers."
        ArenaEvent(47).EventText = "(Player1) sees smoke rising in the distance, but decides not to investigate."
        ArenaEvent(48).EventText = "(Player1) scares (Player2) off."
        ArenaEvent(49).EventText = "(Player1) diverts (Player2)'s attention and runs away."
        ArenaEvent(50).EventText = "(Player1) stalks (Player2)."
        ArenaEvent(51).EventText = "(Player1) steals from (Player2) while (he/she2) isn't looking."
        ArenaEvent(52).EventText = "(Player1) attacks (Player2), but (he/she2) manages to escape."
        ArenaEvent(53).EventText = "(Player1) chases (Player2)."
        ArenaEvent(54).EventText = "(Player1) runs away from (Player2)."
        ArenaEvent(55).EventText = "(Player1) and (Player2) work together for the day."
        ArenaEvent(56).EventText = "(Player1) and (Player2) split up to search for resources."
        ArenaEvent(57).EventText = "(Player1) sprains (his/her1) ankle while running away from (Player2)."
        ArenaEvent(58).EventText = "(Player1), (Player2), (Player3), and (Player4) raid (Player5)'s camp while (he/she5) is hunting."
        ArenaEvent(59).EventText = "(Player1) overhears (Player2) and (Player3) talking in the distance."
        ArenaEvent(60).EventText = "(Player1) hunts for other tributes."
        ArenaEvent(61).EventText = "(Player1) and (Player2) hunt for other tributes."
        ArenaEvent(62).EventText = "(Player1), (Player2), and (Player3) hunt for other tributes."
        ArenaEvent(63).EventText = "(Player1), (Player2), (Player3), and (Player4) hunt for other tributes."
        ArenaEvent(64).EventText = "(Player1), (Player2), (Player3), (Player4), and (Player5) hunt for other tributes."
        ArenaEvent(65).EventText = "(Player1), (Player2), (Player3), (Player4), (Player5), and (Player6) hunt for other tributes."
        ArenaEvent(66).EventText = "(Player1) receives a hatchet from an unknown sponsor."
        ArenaEvent(67).EventText = "(Player1) receives clean water from an unknown sponsor."
        ArenaEvent(68).EventText = "(Player1) receives medical supplies from an unknown sponsor."
        ArenaEvent(69).EventText = "(Player1) receives fresh food from an unknown sponsor."
        ArenaEvent(70).EventText = "(Player1) receives an explosive from an unknown sponsor."
        ArenaEvent(71).EventText = "(Player1) thinks about home."
        ArenaEvent(72).EventText = "(Player1) questions (his/her1) sanity."
        ArenaEvent(73).EventText = "(Player1) defeats (Player2) in a fight, but spares (his/her2) life."
        ArenaEvent(74).EventText = "(Player1) begs for (Player2) to kill (him/her1). (He/She2) refuses, keeping (Player1) alive."
        ArenaEvent(75).EventText = "(Player1) tends to (Player2)'s wounds."
        ArenaEvent(76).EventText = "(Player1) starts a fire."
        ArenaEvent(77).EventText = "(Player1) sets up camp for the night."
        ArenaEvent(78).EventText = "(Player1) loses sight of where (he/she1) is."
        ArenaEvent(79).EventText = "(Player1) climbs a tree to rest."
        ArenaEvent(80).EventText = "(Player1) goes to sleep."
        ArenaEvent(81).EventText = "(Player1) tends to (his/her1) wounds."
        ArenaEvent(82).EventText = "(Player1) sees a fire, but stays hidden."
        ArenaEvent(83).EventText = "(Player1) screams for help."
        ArenaEvent(84).EventText = "(Player1) stays awake all night."
        ArenaEvent(85).EventText = "(Player1) passes out from exhaustion."
        ArenaEvent(86).EventText = "(Player1) cooks (his/her1) food before putting (his/her1) fire out."
        ArenaEvent(87).EventText = "(Player1) cries (himself/herself1) to sleep."
        ArenaEvent(88).EventText = "(Player1) tries to treat (his/her1) infection."
        ArenaEvent(89).EventText = "(Player1) is awoken by nightmares."
        ArenaEvent(90).EventText = "(Player1) thinks about winning."
        ArenaEvent(91).EventText = "(Player1) tries to sing (himself/herself1) to sleep."
        ArenaEvent(92).EventText = "(Player1) attempts to start a fire, but is unsuccessful."
        ArenaEvent(93).EventText = "(Player1) quietly hums."
        ArenaEvent(94).EventText = "(Player1) is unable to start a fire and sleeps without warmth."
        ArenaEvent(95).EventText = "(Player1) looks at the night sky."
        ArenaEvent(96).EventText = "(Player1), (Player2), (Player3), (Player4), and (Player5) sleep in shifts."
        ArenaEvent(97).EventText = "(Player1), (Player2), (Player3), and (Player4) sleep in shifts."
        ArenaEvent(98).EventText = "(Player1), (Player2), and (Player3) sleep in shifts."
        ArenaEvent(99).EventText = "(Player1) and (Player2) sleep in shifts."
        ArenaEvent(100).EventText = "(Player1) and (Player2) hold hands."
        ArenaEvent(101).EventText = "(Player1) convinces (Player2) to snuggle with (him/her1)."
        ArenaEvent(102).EventText = "(Player1) destroys (Player2)'s supplies while (he/she2) is asleep."
        ArenaEvent(103).EventText = "(Player1) lets (Player2) into (his/her1) shelter."
        ArenaEvent(104).EventText = "(Player1) and (Player2) talk about the tributes still alive."
        ArenaEvent(105).EventText = "(Player1) and (Player2) huddle for warmth."
        ArenaEvent(106).EventText = "(Player1) and (Player2) tell stories about themselves to each other."
        ArenaEvent(107).EventText = "(Player1) and (Player2) run into each other and decide to truce for the night."
        ArenaEvent(108).EventText = "(Player1), (Player2), and (Player3) cheerfully sing songs together."
        ArenaEvent(109).EventText = "(Player1), (Player2), and (Player3) discuss the games and what might happen in the morning."
        ArenaEvent(110).EventText = "(Player1), (Player2), (Player3), and (Player4) tell each other ghost stories to lighten the mood."
        ArenaEvent(111).EventText = "(Player1) fends (Player2), (Player3), and (Player4) away from (his/her1) fire."
        ArenaEvent(112).EventText = "(Player1) gathers as much food into a bag as (he/she1) can before fleeing."
        ArenaEvent(113).EventText = "(Player1) sobs while gripping a photo of (his/her1) friends and family."
        ArenaEvent(114).EventText = "(Player1) takes a staff leaning against the cornucopia."
        ArenaEvent(115).EventText = "(Player1) stuffs a bundle of dry clothing into a backpack before sprinting away."
        ArenaEvent(116).EventText = "(Player1) and (Player2) decide to work together to get more supplies."
        ArenaEvent(117).EventText = "(Player1) steals (Player2)'s memoirs."
        ArenaEvent(118).EventText = "(Player1) destroys (Player2)'s memoirs out of spite."
        ArenaEvent(119).EventText = "(Player1) and (Player2) get into a fight over raw meat, but (Player2) gives up and runs away."
        ArenaEvent(120).EventText = "(Player1) and (Player2) get into a fight over raw meat, but (Player1) gives up and runs away."
        ArenaEvent(121).EventText = "(Player1), (Player2), and (Player3) confront each other, but grab what they want slowly to avoid conflict."
        ArenaEvent(122).EventText = "(Player1), (Player2), (Player3), and (Player4) team up to grab food, supplies, weapons, and memoirs."
        ArenaEvent(123).EventText = "(Player1) bleeds out due to untreated injuries."
        ArenaEvent(124).EventText = "(Player1) dies from an infection."
        ArenaEvent(125).EventText = "(Player1), (Player2), and (Player3) successfully ambush and kill (Player4), (Player5), and (Player6)."
        ArenaEvent(126).EventText = "(Player1), (Player2), and (Player3) unsuccessfully ambush (Player4), (Player5), and (Player6), who kill them instead."
        ArenaEvent(127).EventText = "(Player1), (Player2), (Player3), (Player4), and (Player5) track down and kill (Player6)."
        ArenaEvent(128).EventText = "(Player1), (Player2), (Player3), and (Player4) track down and kill (Player5)."
        ArenaEvent(129).EventText = "(Player1), (Player2), and (Player3) track down and kill (Player4)."
        ArenaEvent(130).EventText = "(Player1) and (Player2) track down and kill (Player3)."
        ArenaEvent(131).EventText = "(Player1) tracks down and kills (Player2)."
        ArenaEvent(132).EventText = "(Player1) ambushes (Player2) and kills (him/her2)."
        ArenaEvent(133).EventText = "(Player1) throws a knife into (Player2)'s head."
        ArenaEvent(134).EventText = "(Player1) catches (Player2) off guard and kills (him/her2)."
        ArenaEvent(135).EventText = "(Player1) strangles (Player2) after engaging in a fist fight."
        ArenaEvent(136).EventText = "(Player1) shoots an arrow into (Player2)'s head."
        ArenaEvent(137).EventText = "(Player1) bashes (Player2)'s head against a rock several times."
        ArenaEvent(138).EventText = "(Player1) silently snaps (Player2)'s neck."
        ArenaEvent(139).EventText = "(Player1) decapitates (Player2) with a sword."
        ArenaEvent(140).EventText = "(Player1) spears (Player2) in the abdomen."
        ArenaEvent(141).EventText = "(Player1) sets (Player2) on fire with a molotov."
        ArenaEvent(142).EventText = "(Player1) stabs (Player2) while (his/her2) back is turned."
        ArenaEvent(143).EventText = "(Player1) severely injures (Player2), but puts (him/her2) out of (his/her2) misery."
        ArenaEvent(144).EventText = "(Player1) severely injures (Player2) and leaves (him/her2) to die."
        ArenaEvent(145).EventText = "(Player1) bashes (Player2)'s head in with a mace."
        ArenaEvent(146).EventText = "(Player1) pushes (Player2) off a cliff during a knife fight."
        ArenaEvent(147).EventText = "(Player1) throws a knife into (Player2)'s chest."
        ArenaEvent(148).EventText = "(Player1) convinces (Player2) to not kill (him/her1), only to kill (him/her2) instead."
        ArenaEvent(149).EventText = "(Player1) kills (Player2) with (his/her2) own weapon."
        ArenaEvent(150).EventText = "(Player1) overpowers (Player2), killing (him/her2)."
        ArenaEvent(151).EventText = "(Player1) kills (Player2) as (he/she2) tries to run."
        ArenaEvent(152).EventText = "(Player1) kills (Player2) with a hatchet."
        ArenaEvent(153).EventText = "(Player1) severely slices (Player2) with a sword."
        ArenaEvent(154).EventText = "(Player1) strangles (Player2) with a rope."
        ArenaEvent(155).EventText = "(Player1) kills (Player2) for (his/her2) supplies."
        ArenaEvent(156).EventText = "(Player1) shoots a poisonous blow dart into (Player2)'s neck, slowly killing (him/her2)."
        ArenaEvent(157).EventText = "(Player1) stabs (Player2) with a tree branch."
        ArenaEvent(158).EventText = "(Player1) stabs (Player2) in the back with a trident."
        ArenaEvent(159).EventText = "(Player1) kills (Player2) with a sickle."
        ArenaEvent(160).EventText = "(Player1) repeatedly stabs (Player2) to death with sais."
        ArenaEvent(161).EventText = "(Player1) is unable to convince (Player2) to not kill (him/her1)."
        ArenaEvent(162).EventText = "(Player1) attacks (Player2), but (Player3) protects (him/her2), killing (Player1)."
        ArenaEvent(163).EventText = "(Player1) shoots an arrow at (Player2), but misses and kills (Player3) instead."
        ArenaEvent(164).EventText = "(Player1), (Player2), and (Player3) start fighting, but (Player2) runs away as (Player1) kills (Player3)."
        ArenaEvent(165).EventText = "(Player1) and (Player2) work together to drown (Player3)."
        ArenaEvent(166).EventText = "(Player1), (Player2), and (Player3) get into a fight. (Player1) triumphantly kills them both."
        ArenaEvent(167).EventText = "(Player1), (Player2), and (Player3) get into a fight. (Player2) triumphantly kills them both."
        ArenaEvent(168).EventText = "(Player1), (Player2), and (Player3) get into a fight. (Player3) triumphantly kills them both."
        ArenaEvent(169).EventText = "(Player1) sets an explosive off, killing (Player2)."
        ArenaEvent(170).EventText = "(Player1) sets an explosive off, killing (Player2) and (Player3)."
        ArenaEvent(171).EventText = "(Player1) sets an explosive off, killing (Player2), (Player3), and (Player4)."
        ArenaEvent(172).EventText = "(Player1) sets an explosive off, killing (Player2), (Player3), (Player4), and (Player5)."
        ArenaEvent(173).EventText = "(Player1) sets an explosive off, killing (Player2), (Player3), (Player4), (Player5), and (Player6)."
        ArenaEvent(174).EventText = "(Player1) and (Player2) threaten a double suicide. It fails and they die."
        ArenaEvent(175).EventText = "(Player1), (Player2), (Player3), and (Player4) form a suicide pact, killing themselves."
        ArenaEvent(176).EventText = "(Player1) and (Player2) fight (Player3) and (Player4). (Player1) and (Player2) survive."
        ArenaEvent(177).EventText = "(Player1) and (Player2) fight (Player3) and (Player4). (Player3) and (Player4) survive."
        ArenaEvent(178).EventText = "(Player1) accidently steps on a landmine."
        ArenaEvent(179).EventText = "(Player1) cannot handle the circumstances and commits suicide."
        ArenaEvent(180).EventText = "(Player1) falls into a pit and dies."
        ArenaEvent(181).EventText = "(Player1) falls into a frozen lake and drowns."
        ArenaEvent(182).EventText = "(Player1) steps off (his/her1) podium too soon and blows up."
        ArenaEvent(183).EventText = "(Player1) finds (Player2) hiding in the cornucopia and kills (him/her2)."
        ArenaEvent(184).EventText = "(Player1) finds (Player2) hiding in the cornucopia, but (Player2) kills (him/her1)."
        ArenaEvent(185).EventText = "(Player1) and (Player2) fight for a bag. (Player2) strangles (Player1) with the straps and runs."
        ArenaEvent(186).EventText = "(Player1) and (Player2) fight for a bag. (Player1) strangles (Player2) with the straps and runs."
        ArenaEvent(187).EventText = "(Player1) begs for (Player2) to kill (him/her1). (He/She2) reluctantly obliges, killing (Player1)."
        ArenaEvent(188).EventText = "(Player1) poisons (Player2)'s drink, but mistakes it for (his/her1) own and dies."
        ArenaEvent(189).EventText = "(Player1) poisons (Player2)'s drink. (He/She2) drinks it and dies."
        ArenaEvent(190).EventText = "(Player1)'s trap kills (Player2)."
        ArenaEvent(191).EventText = "(Player1) kills (Player2) while (he/she2) is resting."
        ArenaEvent(192).EventText = "(Player1) taints (Player2)'s food, killing (him/her2)."
        ArenaEvent(193).EventText = "(Player1) unknowingly eats toxic berries."
        ArenaEvent(194).EventText = "(Player1) dies from hypothermia."
        ArenaEvent(195).EventText = "(Player1) dies from hunger."
        ArenaEvent(196).EventText = "(Player1) dies from thirst."
        ArenaEvent(197).EventText = "(Player1) dies trying to escape the arena."
        ArenaEvent(198).EventText = "(Player1) dies of dysentery."
        ArenaEvent(199).EventText = "(Player1) attempts to climb a tree, but falls to (his/her1) death."
        ArenaEvent(200).EventText = "(Player1) accidently detonates a land mine while trying to arm it."
        ArenaEvent(201).EventText = "(Player1) attempts to climb a tree, but falls on (Player2), killing them both."
        ArenaEvent(202).EventText = "(Player1) forces (Player2) to kill (Player3) or (Player4). (He/She2) decides to kill (Player3)."
        ArenaEvent(203).EventText = "(Player1) forces (Player2) to kill (Player3) or (Player4). (He/She2) decides to kill (Player4)."
        ArenaEvent(204).EventText = "(Player1) forces (Player2) to kill (Player3) or (Player4). (He/She2) refuses to kill, so (Player1) kills (him/her2) instead."
        ArenaEvent(205).EventText = "(Player1) forces (Player2) to kill (Player3) or (Player4). (He/She2) takes a third option and kills (Player1) instead."
        '-------------------END ASSIGNING EVENT TEXT-----------------------------------
        For ctr = 0 To 205
            With ArenaEvent(ctr)
                ReDim .P(5)
                For ctr2 = 0 To 5 'DEFAULT PLAYER STATUS
                    .P(ctr2).DeathType = 0
                    .P(ctr2).IsKiller = False
                Next
                '-------------ASSIGN EVENT SCOPE
                If ctr < 28 Or (ctr > 132 And ctr < 187) Then .EventScope = .EventScope + 1 'Bloodbath
                If (ctr > 27 And ctr < 76) Or (ctr > 123 And ctr < 181) Or ctr > 186 Then .EventScope = .EventScope + 2 'Day
                If (ctr > 65 And ctr < 112) Or (ctr > 123 And ctr < 181) Or ctr > 186 Then .EventScope = .EventScope + 4 'Night
                If (ctr > 111 And ctr < 182) Then .EventScope = .EventScope + 8 'Feast
                '-------------ASSIGN KILL COUNT
                Select Case ctr
                    Case 0 To 122
                        .KillCount = 0
                    Case 166 To 168, 170, 174, 176, 177, 201
                        .KillCount = 2
                    Case 125, 126, 171
                        .KillCount = 3
                    Case 172, 175
                        .KillCount = 4
                    Case 173
                        .KillCount = 5
                    Case Else
                        .KillCount = 1
                End Select
                '-----------ASSIGN PLAYER COUNT 
                Select Case ctr
                    Case 0 To 19, 28 To 47, 60, 66 To 72, 76 To 95, 112 To 115, 123, 124, 178 To 182, 193 To 200
                        .PlayerCount = 1
                    Case 20 To 25, 48 To 57, 61, 73 To 75, 99 To 107, 116 To 120, 131 To 161, 169, 174, 183 To 192, 201
                        .PlayerCount = 2
                    Case 26, 59, 62, 98, 108, 109, 121, 130, 162 To 168, 170
                        .PlayerCount = 3
                    Case 27, 63, 97, 110, 111, 122, 129, 171, 175 To 177, 202 To 205
                        .PlayerCount = 4
                    Case 58, 64, 96, 128, 172
                        .PlayerCount = 5
                    Case 65, 125 To 127, 173
                        .PlayerCount = 6
                End Select
                '-----------ASSIGN DEATH TYPE
                Select Case ctr
                    Case 123, 124, 193 To 198
                        .P(0).DeathType = 3 'Other Death
                    Case 127 To 160, 163 To 165, 169, 183, 186, 189 To 192, 203
                        .P(.PlayerCount - 1).DeathType = 1 'Combat Death for last player
                    Case 178 To 182, 188, 199, 200
                        .P(0).DeathType = 2 'Suicide
                    Case 161, 162, 184, 185, 187, 205
                        .P(0).DeathType = 1 'Combat death for player 1
                    '--------SPECIAL CASES
                    Case 125
                        .P(3).DeathType = 1
                        .P(4).DeathType = 1
                        .P(5).DeathType = 1
                    Case 126
                        .P(0).DeathType = 1
                        .P(1).DeathType = 1
                        .P(2).DeathType = 1
                    Case 166
                        .P(1).DeathType = 1
                        .P(2).DeathType = 1
                    Case 167
                        .P(0).DeathType = 1
                        .P(2).DeathType = 1
                    Case 168, 177
                        .P(0).DeathType = 1
                        .P(1).DeathType = 1
                    Case 170 To 173
                        For ctr2 = 1 To (ctr - 168)
                            .P(ctr2).DeathType = 1
                        Next
                    Case 174
                        .P(0).DeathType = 2
                        .P(1).DeathType = 2
                    Case 175
                        For ctr2 = 0 To 3
                            .P(ctr2).DeathType = 2
                        Next
                    Case 176
                        .P(2).DeathType = 1
                        .P(3).DeathType = 1
                    Case 201
                        .P(0).DeathType = 2
                        .P(1).DeathType = 1
                    Case 202
                        .P(2).DeathType = 1
                    Case 204
                        .P(1).DeathType = 1
                End Select
                '-----------CONFIGURE KILL ATTRIBUTION
                Select Case ctr
                    Case 125
                        .P(0).IsKiller = True
                        .P(1).IsKiller = True
                        .P(2).IsKiller = True
                    Case 126
                        .P(3).IsKiller = True
                        .P(4).IsKiller = True
                        .P(5).IsKiller = True
                    Case 127 To 130
                        For ctr2 = 0 To (131 - ctr)
                            .P(ctr2).IsKiller = True
                        Next
                    Case 165, 176
                        .P(0).IsKiller = True
                        .P(1).IsKiller = True
                    Case 131 To 161, 163, 164, 166, 169 To 173, 183, 186, 189 To 192, 201, 204
                        .P(0).IsKiller = True
                    Case 162, 168
                        .P(2).IsKiller = True
                    Case 167, 184, 185, 187, 205
                        .P(1).IsKiller = True
                    Case 177
                        .P(2).IsKiller = True
                        .P(3).IsKiller = True
                    Case 202, 203
                        .P(0).IsKiller = True
                        .P(1).IsKiller = True
                End Select
                '-----------ASSIGN KILL TYPE
                .IsSharedKill = If((ctr > 124 And ctr < 131) Or ctr = 165 Or ctr = 176 Or ctr = 177 Or ctr = 202 Or ctr = 203, True, False)
            End With
        Next

        ReDim DefaultBloodbath(27)
        For ctr = 0 To 27
            DefaultBloodbath(ctr) = ArenaEvent(ctr)
        Next

        Dim templist As New List(Of GameEvent)
        For Each member In ArenaEvent
            If member.EventScope Mod 2 = 1 And member.KillCount > 0 Then templist.Add(member)
        Next
        DefaultBloodbathFatal = (From member In templist Order By ((1 + member.PlayerCount) * (member.PlayerCount / 2) - (member.PlayerCount - member.KillCount)) Select member).ToArray

        templist.Clear()
        For Each member In ArenaEvent
            Dim currentscope = member.EventScope
            If currentscope >= 8 Then currentscope = currentscope - 8
            If currentscope >= 4 Then currentscope = currentscope - 4
            If currentscope >= 2 And member.KillCount = 0 Then templist.Add(member)
        Next
        DefaultDay = (From member In templist Order By (member.PlayerCount) Select member).ToArray

        templist.Clear()
        For Each member In ArenaEvent
            If If(member.EventScope > 7, member.EventScope - 8, member.EventScope) > 4 And member.KillCount > 0 Then templist.Add(member)
        Next
        DefaultNightFatal = (From member In templist Order By ((1 + member.PlayerCount) * (member.PlayerCount / 2) - (member.PlayerCount - member.KillCount)) Select member).ToArray
        DefaultDayFatal = DefaultNightFatal

        templist.Clear()
        For Each member In ArenaEvent
            If If(member.EventScope > 7, member.EventScope - 8, member.EventScope) >= 4 And member.KillCount > 0 Then templist.Add(member)
        Next
        DefaultNight = (From member In templist Order By (member.PlayerCount) Select member).ToArray

        ReDim DefaultFeast(10)
        For ctr = 112 To 122
            DefaultFeast(ctr - 112) = ArenaEvent(ctr)
        Next

        templist.Clear()
        For Each member In ArenaEvent
            If member.EventScope > 7 And member.KillCount > 0 Then templist.Add(member)
        Next
        DefaultFeastFatal = (From member In templist Order By ((1 + member.PlayerCount) * (member.PlayerCount / 2) - (member.PlayerCount - member.KillCount)) Select member).ToArray
    End Sub
    Public Sub ReadEventFile()
        Dim rawfile As String = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\events.txt")
        Dim rows() As String = Split(rawfile, vbCrLf), entries() As String
        ReDim ArenaEvent(UBound(rows))
        For ctr = 0 To UBound(rows)
            entries = Split(rows(ctr), "|")
            With ArenaEvent(ctr)
                .EventText = entries(0)
                .EventScope = CByte(entries(1))
                .PlayerCount = CByte(entries(2))
                .KillCount = CByte(entries(3))
                .IsSharedKill = CBool(entries(4))
                ReDim .P(5)
                For ctr2 = 0 To 5
                    .P(ctr2).IsKiller = CBool(entries(5 + 2 * ctr2))
                    .P(ctr2).DeathType = CByte(entries(6 + 2 * ctr2))
                Next
            End With
        Next
    End Sub
    Public Sub WriteEventFile()
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(IO.Directory.GetCurrentDirectory & "\events.txt", False)
        For ctr = 0 To UBound(ArenaEvent)
            If ctr > 0 Then file.Write(vbCrLf)
            With ArenaEvent(ctr)
                file.Write(.EventText & "|" & .EventScope & "|" & .PlayerCount & "|" & .KillCount & "|" & .IsSharedKill)
                For ctr2 = 0 To 5
                    file.Write("|" & .P(ctr2).IsKiller & "|" & .P(ctr2).DeathType)
                Next
            End With
        Next
        file.Close()
    End Sub
    Public Sub ReadTributeFile()
        Dim rawfile As String = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\tribdb\tributes.txt")
        Dim rows() As String = Split(rawfile, vbCrLf), entries() As String
        ReDim Tribute(UBound(rows))
        For ctr = 1 To UBound(rows)
            entries = Split(rows(ctr), "|")
            With Tribute(ctr)
                .ID = CInt(entries(0))
                .Name = entries(1)
                .Nickname = entries(2)
                .Picture = entries(3)
                .DeathPicture = entries(4)
                .Gender = entries(5)
                .Wins = CInt(entries(6))
                .Kills = CInt(entries(7))
                .SoloKills = CInt(entries(8))
                .SharedKills = CInt(entries(9))
                .Deaths = CInt(entries(10))
                .CombatDeaths = CInt(entries(11))
                .Suicides = CInt(entries(12))
                .OtherDeaths = CInt(entries(13))
            End With
        Next
    End Sub
    Public Sub WriteTributeFile()
        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(IO.Directory.GetCurrentDirectory & "\tribdb\tributes.txt", False)
        file.Write("ID|Name|Nickname|Picture|DeathPicture|Gender|Wins|Kills|SoloKills|SharedKills|Deaths|CombatDeaths|Suicides|OtherDeaths")
        For ctr = 1 To UBound(Tribute)
            With Tribute(ctr)
                file.Write(vbCrLf & .ID & "|" & .Name & "|" & .Nickname & "|" &
                           .Picture & "|" & .DeathPicture & "|" & .Gender & "|" & .Wins & "|" &
                           .Kills & "|" & .SoloKills & "|" & .SharedKills & "|" &
                           .Deaths & "|" & .CombatDeaths & "|" & .Suicides & "|" & .OtherDeaths)
            End With
        Next
        file.Close()
    End Sub
    Public Sub InitializeSpecialEventFile()
        ReDim SpecialArenaEvent(12)
        For ctr = 0 To 12
            With SpecialArenaEvent(ctr)
                ReDim .NonFatalEvent.P(5)
                ReDim .FatalEvent(4)
                For ctr2 = 0 To 4
                    ReDim .FatalEvent(ctr2).P(5)
                    .FatalEvent(ctr2).IsSharedKill = False
                Next
                'Begin Arena event defaults
                .NonFatalEvent.EventText = "(Player1) survives."
                .NonFatalEvent.KillCount = 0
                .NonFatalEvent.PlayerCount = 1
                .FatalEvent(0).KillCount = 1
                .FatalEvent(0).PlayerCount = 1
                .FatalEvent(0).P(0).DeathType = 3
                .FatalEvent(1).KillCount = 1
                .FatalEvent(1).PlayerCount = 1
                .FatalEvent(1).P(0).DeathType = 3
                .FatalEvent(2).KillCount = 1
                .FatalEvent(2).PlayerCount = 2
                .FatalEvent(2).P(0).IsKiller = True
                .FatalEvent(2).P(1).DeathType = 1
                .FatalEvent(3).KillCount = 1
                .FatalEvent(3).PlayerCount = 2
                .FatalEvent(3).P(0).IsKiller = True
                .FatalEvent(3).P(1).DeathType = 1
                .FatalEvent(4).KillCount = 2
                .FatalEvent(4).PlayerCount = 2
                'End Arena event defaults
            End With
        Next
        With SpecialArenaEvent(0)
            .DescriptionText = "Wolf mutts are let loose in the arena."
            .FatalEvent(0).EventText = "(Player1) is crushed by a pack of wolf mutts."
            .FatalEvent(1).EventText = "(Player1) is eaten by wolf mutts."
            .FatalEvent(2).EventText = "(Player1) knocks (Player2) out and leaves (him/her2) for the wolf mutts."
            .FatalEvent(3).EventText = "(Player1) pushes (Player2) into a pack of wolf mutts."
            .FatalEvent(4).EventText = "As (Player1) and (Player2) fight, a pack of wolf mutts show up and kill them both."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(1)
            .DescriptionText = "Acidic rain pours down on the arena."
            .FatalEvent(0).EventText = "(Player1) is unable to find shelter and dies."
            .FatalEvent(1).EventText = "(Player1) trips face first into a puddle of acidic rain."
            .FatalEvent(2).EventText = "(Player1) injures (Player2) and leaves (him/her2) in the rain to die."
            .FatalEvent(3).EventText = "(Player1) refuses (Player2) shelter, killing (him/her2)."
            .FatalEvent(4).EventText = "(Player1) shoves (Player2) into a pond of acidic rain, but is pulled in by (Player2), killing them both."
            .FatalEvent(4).P(0).IsKiller = True
            .FatalEvent(4).P(1).IsKiller = True
            .FatalEvent(4).P(0).DeathType = 1
            .FatalEvent(4).P(1).DeathType = 1
        End With
        With SpecialArenaEvent(2)
            .DescriptionText = "A cloud of poisonous smoke starts to fill the arena."
            .FatalEvent(0).EventText = "(Player1) is engulfed in the cloud of poisonous smoke."
            .FatalEvent(1).EventText = "(Player1) sacrifices (himself/herself1) so (Player2) can get away."
            .FatalEvent(1).PlayerCount = 2 'ALL OTHER INSTANCES OF FATAL EVENT #2 ONLY HAS PLAYER1
            .FatalEvent(1).P(0).DeathType = 2
            .FatalEvent(2).EventText = "(Player1) slowly pushes (Player2) closer into the cloud until (he/she2) can't resist any more."
            .FatalEvent(3).EventText = "(Player1) and (Player2) agree to die in the cloud together, but (Player1) pushes (Player2) in without warning."
            .FatalEvent(4).EventText = "(Player1) and (Player2) decide to run into the cloud together."
            .FatalEvent(4).P(0).DeathType = 2
            .FatalEvent(4).P(1).DeathType = 2
        End With
        With SpecialArenaEvent(3)
            .DescriptionText = "A monstrous hurricane wreaks havoc on the arena."
            .FatalEvent(0).EventText = "(Player1) is sucked into the hurricane."
            .FatalEvent(1).EventText = "(Player1) is incapacitated by flying debris and dies."
            .FatalEvent(2).EventText = "(Player1) pushes (Player2) into an incoming boulder."
            .FatalEvent(3).EventText = "(Player1) stabs (Player2), then pushes (him/her2) close enough to the hurricane to suck (him/her2) in."
            .FatalEvent(4).EventText = "(Player1) tries to save (Player2) from being sucked into the hurricane, only to be sucked in as well."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(4)
            .DescriptionText = "A swarm of tracker jackers invades the arena."
            .FatalEvent(0).EventText = "(Player1) is stung to death."
            .FatalEvent(1).EventText = "(Player1) slowly dies from the tracker jacker toxins."
            .FatalEvent(2).EventText = "(Player1) knocks (Player2) unconscious and leaves (him/her2) there as bait."
            .FatalEvent(3).EventText = "While running away from the tracker jackers, (Player1) grabs (Player2) and throws (him/her2) to the ground."
            .FatalEvent(4).EventText = "(Player1) and (Player2) run out of places to run and are stung to death."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(5)
            .DescriptionText = "A tsunami rolls into the the arena."
            .FatalEvent(0).EventText = "(Player1) is swept away."
            .FatalEvent(1).EventText = "(Player1) fatally injures (himself/herself1) on debris."
            .FatalEvent(2).EventText = "(Player1) holds (Player2) underwater to drown."
            .FatalEvent(3).EventText = "(Player1) defeats (Player2), but throws (him/her2) in the water to make sure (he/she2) dies."
            .FatalEvent(4).EventText = "(Player1) and (Player2) smash their heads together as the tsunami rolls in, leaving them both to drown."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(6)
            .DescriptionText = "A fire spreads throughout the arena."
            .FatalEvent(0).EventText = "The fire catches up to (Player1), killing (him/her1)."
            .FatalEvent(1).EventText = "A fireball strikes (Player1), killing (him/her1)."
            .FatalEvent(2).EventText = "(Player1) kills (Player2) in order to utilize a body of water safely."
            .FatalEvent(3).EventText = "(Player1) falls to the ground, but kicks (Player2) hard enough to then push (him/her2) into the fire."
            .FatalEvent(4).EventText = "(Player1) and (Player2) fail to find a safe spot and suffocate."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(7)
            .DescriptionText = "The arena's border begins to rapidly contract."
            .FatalEvent(0).EventText = "(Player1) is electrocuted by the border."
            .FatalEvent(1).EventText = "(Player1) trips on a tree root and is unable to recover fast enough."
            .FatalEvent(2).EventText = "(Player1) restrains (Player2) to a tree and leaves (him/her2) to die."
            .FatalEvent(3).EventText = "(Player1) pushes (Player2) into the border while (he/she2) is not paying attention."
            .FatalEvent(4).EventText = "Thinking they could escape, (Player1) and (Player2) attempt to run through the border together."
            .FatalEvent(4).P(0).DeathType = 2
            .FatalEvent(4).P(1).DeathType = 2
        End With
        With SpecialArenaEvent(8)
            .DescriptionText = "Monkey mutts fill the arena."
            .FatalEvent(0).EventText = "(Player1) dies from internal bleeding caused by a monkey mutt."
            .FatalEvent(1).EventText = "(Player1) is pummeled to the ground and killed by a troop of monkey mutts."
            .FatalEvent(2).EventText = "(Player1) uses (Player2) as a shield from the monkey mutts."
            .FatalEvent(3).EventText = "(Player1) injures (Player2) and leaves (him/her2) for the monkey mutts."
            .FatalEvent(4).EventText = "While running, (Player1) falls over and grabs (Player2) on the way down. The monkey mutts kill them."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(9)
            .DescriptionText = "Carnivorous squirrels start attacking the tributes."
            .FatalEvent(0).EventText = "(Player1) is brutally attacked by a scurry of squirrels."
            .FatalEvent(1).EventText = "(Player1) tries to kill as many squirrels as (he/she1) can, but there are too many."
            .FatalEvent(2).EventText = "(Player1) uses the squirrels to (his/her1) advantage, shoving (Player2) into them."
            .FatalEvent(3).EventText = "(Player1), in agony, kills (Player2) so (he/she2) does not have to be attacked by the squirrels."
            .FatalEvent(4).EventText = "The squirrels separate and kill (Player1) and (Player2)."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(10)
            .DescriptionText = "A volcano erupts at the center of the arena."
            .FatalEvent(0).EventText = "(Player1) is buried in ash."
            .FatalEvent(1).EventText = "(Player1) suffocates."
            .FatalEvent(2).EventText = "(Player1) pushes (Player2) in the lava."
            .FatalEvent(3).EventText = "(Player1) dips (his/her1) weapon in the lava and kills (Player2) with it."
            .FatalEvent(4).EventText = "As (Player1) trips over (Player2) into the lava, (he/she1) grabs (him/her2) and pulls (him/her2) down with (him/her1)."
            .FatalEvent(4).P(0).IsKiller = True
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 1
        End With
        With SpecialArenaEvent(11)
            .DescriptionText = "The arena turns pitch black and nobody can see a thing."
            .FatalEvent(0).EventText = "(Player1) trips on a rock and falls off a cliff."
            .FatalEvent(1).EventText = "(Player1) accidently makes contact with spiny, lethal plant life."
            .FatalEvent(2).EventText = "(Player1) flails (his/her1) weapon around, accidently killing (Player2)."
            .FatalEvent(3).EventText = "(Player1) finds and kills (Player2), who was making too much noise."
            .FatalEvent(4).EventText = "While fighting, (Player1) and (Player2) lose their balance, roll down a jagged hillside, and die."
            .FatalEvent(4).P(0).DeathType = 3
            .FatalEvent(4).P(1).DeathType = 3
        End With
        With SpecialArenaEvent(12)
            .DescriptionText = "The remaining tributes begin to hallucinate."
            .FatalEvent(0).EventText = "(Player1) eats a scorpion, thinking it is a delicate dessert."
            .FatalEvent(1).EventText = "(Player1) hugs a tracker jacker nest, believing it to be a pillow."
            .FatalEvent(2).EventText = "(Player1) mistakes (Player2) for a bear and kills (him/her2)."
            .FatalEvent(3).EventText = "(Player1) drowns (Player2), who (he/she1) thought was a shark trying to eat (him/her1)."
            .FatalEvent(4).EventText = "(Player1) and (Player2) decide to jump down the rabbit hole to Wonderland, which turns out to be a pit of rocks."
            .FatalEvent(4).P(0).DeathType = 2
            .FatalEvent(4).P(1).DeathType = 2
        End With
    End Sub
    Public Sub WriteSpecialEventFile()
        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(IO.Directory.GetCurrentDirectory & "\specialevents.txt", False)
        For ctr = 0 To UBound(SpecialArenaEvent)
            If ctr > 0 Then file.Write(vbCrLf)
            With SpecialArenaEvent(ctr)
                file.WriteLine(.DescriptionText)
                file.Write(.NonFatalEvent.EventText)
                For ctr2 = 0 To 4
                    file.Write(vbCrLf & .FatalEvent(ctr2).EventText & "|" & .FatalEvent(ctr2).PlayerCount & "|" & .FatalEvent(ctr2).KillCount & "|" & .FatalEvent(ctr2).IsSharedKill)
                    For ctr3 = 0 To 5
                        file.Write("|" & .FatalEvent(ctr2).P(ctr3).IsKiller & "|" & .FatalEvent(ctr2).P(ctr3).DeathType)
                    Next
                Next
            End With
        Next
        file.Close()
    End Sub
    Public Sub ReadSpecialEventFile()
        Dim rawfile As String = My.Computer.FileSystem.ReadAllText(IO.Directory.GetCurrentDirectory & "\specialevents.txt")
        Dim rows() As String = Split(rawfile, vbCrLf), entries() As String, SpecialEventCount As Integer = (UBound(rows) + 1) / 7
        ReDim SpecialArenaEvent(SpecialEventCount - 1)
        For ctr = 0 To UBound(rows)
            entries = Split(rows(ctr), "|")
            With SpecialArenaEvent(ctr \ 7)
                Select Case ctr Mod 7
                    Case 0
                        .DescriptionText = entries(0)
                        ReDim .FatalEvent(4)
                    Case 1
                        .NonFatalEvent.EventText = entries(0)
                    Case Else
                        With .FatalEvent((ctr Mod 7) - 2)
                            ReDim .P(5)
                            .EventText = entries(0)
                            .PlayerCount = CByte(entries(1))
                            .KillCount = CByte(entries(2))
                            .IsSharedKill = CBool(entries(3))
                            For ctr2 = 0 To 5
                                .P(ctr2).IsKiller = CBool(entries(4 + 2 * ctr2))
                                .P(ctr2).DeathType = CByte(entries(5 + 2 * ctr2))
                            Next
                        End With
                End Select
            End With
        Next
    End Sub
    Public Sub SeparateEvents()
        For Each entry In ArenaEvent
            Dim temp As Byte = entry.EventScope
            If temp >= 8 Then
                If entry.KillCount = 0 Then
                    CollectNormalEvent(entry, FeastEventColl)
                Else
                    CollectFatalEvent(entry, FeastFatalColl)
                End If
                temp = temp - 8
            End If
            If temp >= 4 Then
                If entry.KillCount = 0 Then
                    CollectNormalEvent(entry, NightEventColl)
                Else
                    CollectFatalEvent(entry, NightFatalColl)
                End If
                temp = temp - 4
            End If
            If temp >= 2 Then
                If entry.KillCount = 0 Then
                    CollectNormalEvent(entry, DayEventColl)
                Else
                    CollectFatalEvent(entry, DayFatalColl)
                End If
                temp = temp - 2
            End If
            If temp = 1 Then
                If entry.KillCount = 0 Then
                    CollectNormalEvent(entry, BloodbathEventColl)
                Else
                    CollectFatalEvent(entry, BloodbathFatalColl)
                End If
            End If
        Next
    End Sub
    Private Sub CollectNormalEvent(ByVal ChosenEvent As GameEvent, ByRef EventGroup()() As GameEvent)
        ReDim Preserve EventGroup(ChosenEvent.PlayerCount - 1)(
            If(EventGroup(ChosenEvent.PlayerCount - 1) Is Nothing, 0, UBound(EventGroup(ChosenEvent.PlayerCount - 1)) + 1))
        EventGroup(ChosenEvent.PlayerCount - 1)(UBound(EventGroup(ChosenEvent.PlayerCount - 1))) = ChosenEvent
    End Sub
    Private Sub CollectFatalEvent(ByVal ChosenEvent As GameEvent, ByRef EventGroup()() As GameEvent)
        Dim ArrayIndex = 2 * (ChosenEvent.PlayerCount - 1) - If(ChosenEvent.PlayerCount - ChosenEvent.KillCount > 0, 1, 0)
        'Formerly (1 + ChosenEvent.PlayerCount) * (ChosenEvent.PlayerCount / 2) - (ChosenEvent.PlayerCount - ChosenEvent.KillCount) - 1
        ReDim Preserve EventGroup(ArrayIndex)(If(EventGroup(ArrayIndex) Is Nothing, 0, UBound(EventGroup(ArrayIndex)) + 1))
        EventGroup(ArrayIndex)(UBound(EventGroup(ArrayIndex))) = ChosenEvent
    End Sub
    Public Sub GatherEventGroup(ByVal Source()() As GameEvent, ByRef Destination() As GameEvent, ByRef CounterColl() As Integer)
        Destination = Nothing 'Clear it first. Needed when user runs the program for another round
        For ctr = 0 To UBound(Source)
            If Not Source(ctr) Is Nothing Then
                For Each entry In Source(ctr)
                    ReDim Preserve Destination(If(Destination Is Nothing, 0, UBound(Destination) + 1))
                    Destination(UBound(Destination)) = entry
                Next
            End If
            CounterColl(ctr) = UBound(Destination)
        Next
    End Sub
    Public Function MakeGrey(SourceImage As Image)
        Dim grayscale As New Imaging.ColorMatrix(New Single()() _
            {
            New Single() {0.299, 0.299, 0.299, 0, 0},
            New Single() {0.587, 0.587, 0.587, 0, 0},
            New Single() {0.114, 0.114, 0.114, 0, 0},
            New Single() {0, 0, 0, 1, 0},
            New Single() {0, 0, 0, 0, 1}
            })

        Dim bmp As New Bitmap(SourceImage), imgattr As New Imaging.ImageAttributes()
        imgattr.SetColorMatrix(grayscale)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.DrawImage(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, bmp.Width, bmp.Height,
                    GraphicsUnit.Pixel, imgattr)
        End Using
        Return bmp
    End Function
    Public Function DrawXOver(SourceImage As Image)
        Dim bmp As New Bitmap(SourceImage)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim marker As New Pen(Color.Red, 10)
            g.DrawLine(marker, 0, 0, 90, 90)
            g.DrawLine(marker, 0, 90, 90, 0)
        End Using
        Return bmp
    End Function
    Sub Main()
        If My.Computer.FileSystem.FileExists(IO.Directory.GetCurrentDirectory & "\tribdb\tributes.txt") Then
            ReadTributeFile()
        Else
            InitializeTributeFile()
            WriteTributeFile()
        End If

        InitializeEventFile()
        If My.Computer.FileSystem.FileExists(IO.Directory.GetCurrentDirectory & "\events.txt") _
            AndAlso My.Computer.FileSystem.GetFileInfo(IO.Directory.GetCurrentDirectory & "\events.txt").Length > 0 Then
            ReadEventFile()
        Else
            WriteEventFile()
        End If
        SeparateEvents()

        If BloodbathEventColl(0).Length = 0 Then
            BloodbathEvent = DefaultBloodbath
            BloodbathLimit = {19, 25, 26, 27, 27, 27}
        Else
            GatherEventGroup(BloodbathEventColl, BloodbathEvent, BloodbathLimit)
        End If
        If BloodbathFatalColl(0).Length = 0 Then
            BloodbathFatal = DefaultBloodbathFatal
            BloodbathFatalLimit = {4, 38, 39, 47, 47, 50, 51, 52, 52, 53, 53}
        Else
            GatherEventGroup(BloodbathFatalColl, BloodbathFatal, BloodbathFatalLimit)
        End If

        If DayEventColl(0).Length = 0 Then
            DayEvent = DefaultDay
            DayLimit = {27, 41, 43, 44, 46, 47}
        Else
            GatherEventGroup(DayEventColl, DayEvent, DayLimit)
        End If
        If DayFatalColl(0).Length = 0 Then
            DayFatal = DefaultDayFatal
            DayFatalLimit = {11, 49, 51, 60, 60, 68, 69, 71, 71, 75, 75}
        Else
            GatherEventGroup(DayFatalColl, DayFatal, DayFatalLimit)
        End If

        If NightEventColl(0).Length = 0 Then
            NightEvent = DefaultNight
            NightLimit = {26, 38, 41, 44, 45, 45}
        Else
            GatherEventGroup(NightEventColl, NightEvent, NightLimit)
        End If
        If NightFatalColl(0).Length = 0 Then
            NightFatal = DefaultNightFatal
            NightFatalLimit = {11, 49, 51, 60, 60, 68, 69, 71, 71, 75, 75}
        Else
            GatherEventGroup(NightFatalColl, NightFatal, NightFatalLimit)
        End If

        If FeastEventColl(0).Length = 0 Then
            FeastEvent = DefaultFeast
            FeastLimit = {3, 8, 9, 10, 10, 10}
        Else
            GatherEventGroup(FeastEventColl, FeastEvent, FeastLimit)
        End If
        If FeastFatalColl(0).Length = 0 Then
            FeastFatal = DefaultFeastFatal
            FeastFatalLimit = {5, 37, 38, 47, 47, 51, 52, 54, 54, 58, 58}
        Else
            GatherEventGroup(FeastFatalColl, FeastFatal, FeastFatalLimit)
        End If

        If My.Computer.FileSystem.FileExists(IO.Directory.GetCurrentDirectory & "\specialevents.txt") Then
            ReadSpecialEventFile()
        Else
            InitializeSpecialEventFile()
            WriteSpecialEventFile()
        End If
        IsFirstRun = True

        If My.Computer.FileSystem.FileExists(inipath) Then
            ini.Load(inipath)
        Else
            ini.AddSection("Settings").AddKey("DefaultEventRate").SetValue("0.4")
            ini.AddSection("Settings").AddKey("HasArenaEvents").SetValue("True")
            ini.AddSection("Settings").AddKey("FatalEventOdds").SetValue("0.15")
            ini.AddSection("Settings").AddKey("ShowRecentDeaths").SetValue("True")
            ini.Save(inipath)
        End If
        DefaultEventRate = CSng(ini.GetKeyValue("Settings", "DefaultEventRate"))
        HasArenaEvents = CBool(ini.GetKeyValue("Settings", "HasArenaEvents"))
        FatalEventOdds = CSng(ini.GetKeyValue("Settings", "FatalEventOdds"))
        ShowRecentDeaths = CBool(ini.GetKeyValue("Settings", "ShowRecentDeaths"))

        frmSplash.ShowDialog()
    End Sub
End Module