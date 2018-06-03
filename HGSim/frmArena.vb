Imports System.ComponentModel
Public Class frmArena
    Public RecentDeaths() As Integer
    Dim LiveTribute() As Player, ctr, DayCtr, LiveTributes, CurrentRound As Integer, HasFeast, IsDay As Boolean, ChosenEvent As GameEvent
    Dim btnRound() As Button, lblEventDesc()() As Label, picTribute()() As PictureBox, RushMode As Boolean
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        HideRoundResult()
        CurrentRound = CurrentRound - 1
        ShowRoundResult()
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        HideRoundResult()
        CurrentRound = CurrentRound + 1
        If CurrentRound > UBound(btnRound) Then
            ReDim Preserve btnRound(UBound(btnRound) + 1)
            btnRound(UBound(btnRound)) = New Button
            With btnRound(UBound(btnRound))
                .Top = btnRound(0).Top + CurrentRound * (5 + .Height)
                .Left = pnlRounds.Width / 2 - .Width / 2
                .Tag = UBound(btnRound)
                AddHandler .Click, AddressOf btnRound_Click
            End With
            pnlRounds.Controls.Add(btnRound(UBound(btnRound)))

            ReDim Preserve picTribute(CurrentRound)
            ReDim Preserve lblEventDesc(CurrentRound)

            'Remove dead tributes
            Dim temp() As Player = {}
            For Each member In LiveTribute
                If member.Deaths = 0 Then
                    ReDim Preserve temp(If(temp Is Nothing, 0, UBound(temp) + 1))
                    temp(UBound(temp)) = member
                Else
                    ReDim Preserve RecentDeaths(If(RecentDeaths Is Nothing, 0, UBound(RecentDeaths) + 1))
                    RecentDeaths(UBound(RecentDeaths)) = Roster(member.ID).ID
                End If
            Next
            LiveTribute = temp
            Shuffle(LiveTribute)
            ctr = LiveTributes

            If LiveTributes = 1 Then
                If ShowRecentDeaths And Not RushMode Then frmRecentDeaths.ShowDialog()
                With ChosenEvent
                    .EventText = "(Player1) is the winner!"
                    .PlayerCount = 1
                    'Make sure nothing is added to winner's killcount & deathcount
                    .KillCount = 0
                    ReDim .P(0)
                    .P(0).IsKiller = False
                    .P(0).DeathType = 0
                End With
                lblRoundDesc.Visible = False
                GenerateEvent()
                btnNext.Enabled = False
                btnRound(CurrentRound).Text = "The Winner"
                LiveTribute(0).Wins = 1
                Roster(LiveTribute(0).ID).Wins = 1
            Else
                If Not HasFeast And IsDay And LiveTributes <= Roster.Count / 4 Then
                    btnRound(CurrentRound).Text = "Feast"
                    lblRoundDesc.Visible = True
                    FeastRound()
                    HasFeast = True
                Else
                    If Rnd() < 0.2 And HasArenaEvents Then 'Chances of generating special events: 5% when enabled
                        btnRound(CurrentRound).Text = "Arena Event"
                        lblRoundDesc.Visible = True
                        ArenaEventRound()
                    Else
                        If IsDay Then
                            lblRoundDesc.Visible = False
                            btnRound(CurrentRound).Text = "Day " & DayCtr
                            DayRound()
                            IsDay = False
                        Else
                            If ShowRecentDeaths And Not RushMode Then frmRecentDeaths.ShowDialog() 'Display recent deaths if option is enabled
                            lblRoundDesc.Visible = False
                            btnRound(CurrentRound).Text = "Night " & DayCtr
                            NightRound()
                            IsDay = True
                            DayCtr = DayCtr + 1
                        End If
                    End If
                End If
                UpdateTribStats()
            End If
        End If
        ShowRoundResult()

    End Sub
    Private Sub btnRound_Click(sender As Object, e As EventArgs)
        If CType(sender, Button).Tag <> CurrentRound Then
            HideRoundResult()
            CurrentRound = CType(sender, Button).Tag
            ShowRoundResult()
        End If
    End Sub
    Private Sub frmArena_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        e.Cancel = If(LiveTributes = 1 OrElse MsgBox("Do you want to abort the current simulation?", vbYesNo) = vbYes, False, True)
        Me.Dispose()
        For Each PicArray In picTribute
            For Each pic In PicArray
                pic.Image.Dispose()
            Next
        Next
        If LiveTributes = 1 And LiveTribute.Count > 1 Then
            'Only the winner remains. Save data on the losers if their data isn't saved yet.
            Dim temp(0) As Player
            For Each member In LiveTribute
                If member.Deaths = 0 Then
                    temp(0) = member
                Else
                    'Update stats while dead tribute is being removed
                    ReDim Preserve RecentDeaths(If(RecentDeaths Is Nothing, 0, UBound(RecentDeaths) + 1))
                    With member
                        RecentDeaths(UBound(RecentDeaths)) = Roster(.ID).ID
                        Roster(.ID).Kills = .Kills
                        Roster(.ID).SoloKills = .SoloKills
                        Roster(.ID).SharedKills = .SharedKills
                        Roster(.ID).Deaths = .Deaths
                        Roster(.ID).CombatDeaths = .CombatDeaths
                        Roster(.ID).Suicides = .Suicides
                        Roster(.ID).OtherDeaths = .OtherDeaths
                    End With
                End If
            Next
            LiveTribute = temp
            LiveTribute(0).Wins = 1
        End If

        If LiveTribute(0).Wins = 1 Then
            'Save stats for all tributes
            For Each member In Roster
                With Tribute(member.ID)
                    .Wins = .Wins + member.Wins
                    .Kills = .Kills + member.Kills
                    .SoloKills = .SoloKills + member.SoloKills
                    .SharedKills = .SharedKills + member.SharedKills
                    .Deaths = .Deaths + member.Deaths
                    .CombatDeaths = .CombatDeaths + member.CombatDeaths
                    .Suicides = .Suicides + member.Suicides
                    .OtherDeaths = .OtherDeaths + member.OtherDeaths
                End With
            Next
            WriteTributeFile()
        End If
        IsFirstRun = False
        frmSplash.Show()
    End Sub
    Private Sub frmArena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim LiveTribute(UBound(Roster))
        For ctr2 = 0 To UBound(Roster)
            LiveTribute(ctr2) = Roster(ctr2)
        Next
        'LiveTribute = Roster (doesn't work properly, roster also gets affected by changes to livetribute if copying is done this way)
        LiveTributes = LiveTribute.Count
        For ctr2 = 0 To LiveTributes - 1
            LiveTribute(ctr2).ID = ctr2 'For later matching with the roster array
        Next
        Shuffle(LiveTribute)

        ctr = LiveTribute.Count
        Randomize()

        Dim BloodbathDefault As GameEvent
        With BloodbathDefault
            .EventText = "(Player1) runs away from the cornucopia."
            .PlayerCount = 1
            ReDim .P(0)
        End With

        ReDim lblEventDesc(0)
        ReDim picTribute(0)
        DayCtr = 0

        ReDim btnRound(0)
        btnRound(0) = New Button
        With btnRound(0)
            .Text = "Bloodbath"
            .Top = 5
            .Left = pnlRounds.Width / 2 - .Width / 2
            .Tag = 0
            AddHandler .Click, AddressOf btnRound_Click
        End With
        pnlRounds.Controls.Add(btnRound(0))
        btnRound(CurrentRound).BackColor = Color.LightGray
        CurrentRound = 0

        With lblRoundDesc
            .Text = "As the tributes stand on their podiums, the horn sounds."
            .Left = pnlEventDisplay.Width / 2 - .Width / 2
        End With

        Do
            If Rnd() > FatalEventOdds Then
                ChosenEvent = If(Rnd() > DefaultEventRate, PickEvent(BloodbathEvent, BloodbathLimit), BloodbathDefault) 'Odds of generating default event: 40%
            Else
                ChosenEvent = PickFatalEvent(BloodbathFatal, BloodbathFatalLimit)
            End If
            GenerateEvent()
            ctr = ctr - (ChosenEvent.PlayerCount)
            LiveTributes = LiveTributes - ChosenEvent.KillCount
        Loop While ctr > 0 And LiveTributes > 1
        DayCtr = DayCtr + 1
        IsDay = True
        UpdateTribStats()
    End Sub
    Sub FeastRound()
        Dim FeastDefault As GameEvent

        With FeastDefault
            .EventText = "(Player1) decides not to go to the Feast."
            .PlayerCount = 1
            ReDim .P(0)
        End With

        lblRoundDesc.Text = "The cornucopia is replenished with food, supplies, weapons, and memoirs from the tributes' families."

        Do
            If Rnd() > FatalEventOdds Then
                ChosenEvent = If(Rnd() > DefaultEventRate, PickEvent(FeastEvent, FeastLimit), FeastDefault) 'Odds of generating default event: 40%
            Else
                ChosenEvent = PickFatalEvent(FeastFatal, FeastFatalLimit)
            End If
            GenerateEvent()
            ctr = ctr - (ChosenEvent.PlayerCount)
            LiveTributes = LiveTributes - ChosenEvent.KillCount
        Loop While ctr > 0 And LiveTributes > 1
    End Sub
    Sub DayRound()
        Do
            If Rnd() > FatalEventOdds Then
                ChosenEvent = PickEvent(DayEvent, DayLimit)
            Else
                ChosenEvent = PickFatalEvent(DayFatal, DayFatalLimit)
            End If
            GenerateEvent()
            ctr = ctr - (ChosenEvent.PlayerCount)
            LiveTributes = LiveTributes - ChosenEvent.KillCount
        Loop While ctr > 0 And LiveTributes > 1
    End Sub
    Sub NightRound()
        Do
            If Rnd() > FatalEventOdds Then
                ChosenEvent = PickEvent(NightEvent, NightLimit)
            Else
                ChosenEvent = PickFatalEvent(NightFatal, NightFatalLimit)
            End If
            GenerateEvent()
            ctr = ctr - (ChosenEvent.PlayerCount)
            LiveTributes = LiveTributes - ChosenEvent.KillCount
        Loop While ctr > 0 And LiveTributes > 1
    End Sub

    Private Sub btnShowScore_Click(sender As Object, e As EventArgs) Handles btnShowScore.Click
        frmScoreboard.ShowDialog()
    End Sub

    Private Sub btnSkipToEnd_Click(sender As Object, e As EventArgs) Handles btnSkipToEnd.Click
        RushMode = True
        Do
            btnNext_Click(btnNext, e)
        Loop Until btnRound(UBound(btnRound)).Text = "The Winner"
        pnlRounds.ScrollControlIntoView(btnRound(UBound(btnRound)))
        btnSkipToEnd.Enabled = False
        RushMode = False
    End Sub

    Sub ArenaEventRound()
        Dim ChosenTheme As SpecialEvent = SpecialArenaEvent(Math.Floor(Rnd() * SpecialArenaEvent.Count))
        With lblRoundDesc
            .Top = 0
            .Text = ChosenTheme.DescriptionText
            .Left = pnlEventDisplay.Width / 2 - .Width / 2
        End With
        ReDim ChosenTheme.NonFatalEvent.P(5)
        ChosenTheme.NonFatalEvent.PlayerCount = 1
        Do
            If Rnd() > FatalEventOdds Then
                ChosenEvent = ChosenTheme.NonFatalEvent
            Else
                ChosenEvent = ChosenTheme.FatalEvent(Math.Floor(5 * Rnd()))
                If LiveTributes - ChosenEvent.KillCount < 1 Or ctr - ChosenEvent.PlayerCount < 0 Then Continue Do
            End If
            GenerateEvent()
            ctr = ctr - (ChosenEvent.PlayerCount)
            LiveTributes = LiveTributes - ChosenEvent.KillCount
        Loop While ctr > 0 And LiveTributes > 1
        lblEventDesc(CurrentRound)(0).Tag = ChosenTheme.DescriptionText
    End Sub
    Sub Shuffle(ByRef Roster() As Player)
        Dim r As New Random
        Dim out = (From member In Roster Order By r.Next Select member).ToArray
        Roster = out
    End Sub
    Function GenerateEventText(ByVal ChosenEvent As GameEvent, ByVal ChosenPlayer() As Player)
        Dim Result As String
        Result = ChosenEvent.EventText
        For i = 0 To UBound(ChosenPlayer)
            With ChosenPlayer(i)
                Result = Replace(Result, "(Player" & i + 1 & ")", .Nickname)
                'Pronoun replacement section
                Result = Replace(Result, "(he/she" & i + 1 & ")", If(.Gender = "M", "he", If(.Gender = "F", "she", If(.Gender = "N", "it", "they"))))
                Result = Replace(Result, "(He/She" & i + 1 & ")", If(.Gender = "M", "He", If(.Gender = "F", "She", If(.Gender = "N", "It", "They"))))
                Result = Replace(Result, "(his/her" & i + 1 & ")", If(.Gender = "M", "his", If(.Gender = "F", "her", If(.Gender = "N", "its", "their"))))
                Result = Replace(Result, "(His/Her" & i + 1 & ")", If(.Gender = "M", "His", If(.Gender = "F", "Her", If(.Gender = "N", "Its", "Their"))))
                Result = Replace(Result, "(him/her" & i + 1 & ")", If(.Gender = "M", "him", If(.Gender = "F", "her", If(.Gender = "N", "it", "them"))))
                Result = Replace(Result, "(Him/Her" & i + 1 & ")", If(.Gender = "M", "Him", If(.Gender = "F", "Her", If(.Gender = "N", "It", "Them"))))
                Result = Replace(Result, "(himself/herself" & i + 1 & ")", If(.Gender = "M", "himself", If(.Gender = "F", "herself", If(.Gender = "N", "itself", "themselves"))))
                Result = Replace(Result, "(Himself/Herself" & i + 1 & ")", If(.Gender = "M", "Himself", If(.Gender = "F", "Herself", If(.Gender = "N", "Itself", "Themselves"))))
            End With
        Next
        Return Result
    End Function
    Sub GenerateEvent()
        Dim ChosenTribute(ChosenEvent.PlayerCount - 1) As Player, RoundCtr As Integer = UBound(btnRound)
        For ctr2 = 0 To UBound(ChosenTribute)
            ChosenTribute(ctr2) = LiveTribute(ctr - ctr2 - 1)
            ReDim Preserve picTribute(RoundCtr)(If(picTribute(RoundCtr) Is Nothing, 0, UBound(picTribute(RoundCtr)) + 1))
            Dim LatestPicNum = UBound(picTribute(RoundCtr)), DisplayStart As Integer = If(lblRoundDesc.Visible, lblRoundDesc.Height, 0), PrevEventLabel As New Label
            If Not lblEventDesc(RoundCtr) Is Nothing Then PrevEventLabel = lblEventDesc(RoundCtr)(UBound(lblEventDesc(RoundCtr)))
            picTribute(RoundCtr)(LatestPicNum) = New PictureBox
            With picTribute(RoundCtr)(LatestPicNum)
                .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & ChosenTribute(ctr2).Picture)
                .Top = If(lblEventDesc(RoundCtr) Is Nothing, DisplayStart, PrevEventLabel.Top + PrevEventLabel.Height)
                .Height = 90
                .Width = 90
                pnlEventDisplay.Controls.Add(picTribute(RoundCtr)(LatestPicNum))
                .Left = pnlEventDisplay.Width / 2 - (ChosenEvent.PlayerCount * 45 + (ChosenEvent.PlayerCount - 1) * 5 - (ctr2 * 100))
            End With

            If ChosenEvent.KillCount > 0 Then
                With LiveTribute(ctr - ctr2 - 1)
                    If ChosenEvent.P(ctr2).DeathType > 0 Then 'UPDATE DEATHCOUNT
                        .Deaths = 1
                        Select Case ChosenEvent.P(ctr2).DeathType
                            Case 1
                                .CombatDeaths = 1
                            Case 2
                                .Suicides = 1
                            Case 3
                                .OtherDeaths = 1
                        End Select
                    End If
                    'UPDATE KILLCOUNT
                    If ChosenEvent.P(ctr2).IsKiller Then
                        If Not ChosenEvent.IsSharedKill Then
                            Dim KillerCount As Integer
                            For ctr3 = 0 To 5
                                If ChosenEvent.P(ctr3).IsKiller Then KillerCount = KillerCount + 1
                            Next
                            .Kills = .Kills + (ChosenEvent.KillCount / KillerCount) - .Suicides
                            .SoloKills = .SoloKills + (ChosenEvent.KillCount / KillerCount) - .Suicides
                        Else
                            .Kills = .Kills + ChosenEvent.KillCount - .Suicides
                            .SharedKills = .SharedKills + ChosenEvent.KillCount - .Suicides
                        End If
                    End If
                End With
            End If
        Next
        ReDim Preserve lblEventDesc(RoundCtr)(If(lblEventDesc(RoundCtr) Is Nothing, 0, UBound(lblEventDesc(RoundCtr)) + 1))
        Dim LatestEventNum = UBound(lblEventDesc(RoundCtr))
        lblEventDesc(RoundCtr)(LatestEventNum) = New Label
        With lblEventDesc(RoundCtr)(LatestEventNum)
            .Text = GenerateEventText(ChosenEvent, ChosenTribute)
            .TextAlign = ContentAlignment.TopCenter
            .AutoSize = True
            .MaximumSize = New Size(440, 0)
            pnlEventDisplay.Controls.Add(lblEventDesc(RoundCtr)(LatestEventNum))
            .Top = picTribute(RoundCtr)(UBound(picTribute(RoundCtr))).Top + picTribute(RoundCtr)(UBound(picTribute(RoundCtr))).Height
            .Left = pnlEventDisplay.Width / 2 - .Width / 2
        End With
    End Sub
    Function PickEvent(ByVal EventPool() As GameEvent, EventPoolLimit() As Integer)
        Dim PickedEvent As GameEvent
        If ctr > 5 Then
            PickedEvent = EventPool(CInt(Math.Floor(EventPool.Count * Rnd())))
        Else
            PickedEvent = EventPool(CInt(Math.Floor((1 + EventPoolLimit(ctr - 1)) * Rnd())))
        End If
        Return PickedEvent
    End Function
    Function PickFatalEvent(ByVal EventPool() As GameEvent, EventPoolLimit() As Integer)
        Dim PickedEvent As GameEvent, r As New Random
        If ctr > 6 Then
            PickedEvent = EventPool(CInt(Math.Floor(Rnd() * EventPool.Count))) 'r.next doesn't work
        Else
            Dim ArrayIndex = 2 * (ctr - 1) - If(LiveTributes - ctr > 0, 0, 1) 'Keep at least one tribute alive
            PickedEvent = EventPool(CInt(Math.Floor(r.Next(EventPoolLimit(ArrayIndex) + 1))))
        End If
        Return PickedEvent
    End Function
    Sub HideRoundResult()
        For Each PicBox In picTribute(CurrentRound)
            PicBox.Hide()
        Next
        For Each lbl In lblEventDesc(CurrentRound)
            lbl.Hide()
        Next
        btnRound(CurrentRound).BackColor = SystemColors.ButtonFace
        btnRound(CurrentRound).UseVisualStyleBackColor = True
    End Sub
    Sub ShowRoundResult()
        With lblRoundDesc
            Select Case btnRound(CurrentRound).Text
                Case "Bloodbath"
                    .Text = "As the tributes stand on their podiums, the horn sounds."
                Case "Feast"
                    .Text = "The cornucopia is replenished with food, supplies, weapons, and memoirs from the tributes' families."
                Case "Arena Event"
                    .Text = lblEventDesc(CurrentRound)(0).Tag
            End Select
            If btnRound(CurrentRound).Text = "Bloodbath" Or btnRound(CurrentRound).Text = "Feast" Or btnRound(CurrentRound).Text = "Arena Event" Then
                .Visible = True
                .Left = pnlEventDisplay.Width / 2 - .Width / 2
            Else
                .Visible = False
            End If
        End With
        For Each PicBox In picTribute(CurrentRound)
            PicBox.Show()
        Next
        For Each lbl In lblEventDesc(CurrentRound)
            lbl.Show()
        Next
        pnlRounds.ScrollControlIntoView(btnRound(CurrentRound))
        btnRound(CurrentRound).BackColor = Color.LightGray
        btnPrev.Enabled = (CurrentRound > 0)
        btnNext.Enabled = Not btnRound(CurrentRound).Text = "The Winner"
    End Sub
    Sub UpdateTribStats()
        For Each member In LiveTribute
            With member
                Roster(.ID).Kills = .Kills
                Roster(.ID).SoloKills = .SoloKills
                Roster(.ID).SharedKills = .SharedKills
                Roster(.ID).Deaths = .Deaths
                Roster(.ID).CombatDeaths = .CombatDeaths
                Roster(.ID).Suicides = .Suicides
                Roster(.ID).OtherDeaths = .OtherDeaths
            End With
        Next
    End Sub
End Class