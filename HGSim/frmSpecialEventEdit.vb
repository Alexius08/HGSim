Imports System.ComponentModel

Public Class frmSpecialEventEdit

    Dim SpecialEventOutcome(5) As TabPage, lblEventText(5), lblTribCount(5) As Label, txtEventText(5) As TextBox,
        nudTribCount(3) As NumericUpDown, chkIsTribKiller(3)(), chkIsTribKilled(3)(), chkIsKillShared(3) As CheckBox,
        cmbDeathType(4)() As ComboBox, lblTribute(4)(), lblDeathType(4), lblIsKiller(3), lblIsKilled(3) As Label,
        PlayerCount(5), KillerCount(5), KilledCount(5) As Byte, NewEventAdded As Boolean

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        txtEventIntro.Text.Trim()
        If txtEventIntro.Text = "" Then
            MsgBox("Event introduction text is empty.")
        Else
            Dim ArenaEventList As New List(Of String)
            For Each member In SpecialArenaEvent
                ArenaEventList.Add(member.DescriptionText)
            Next

            If ArenaEventList.Contains(txtEventIntro.Text) Then
                MsgBox("Error: event with similar text already exists")
            Else
                Dim EventTextsComplete As Boolean
                For ctr = 0 To 5
                    txtEventText(ctr).Text.Trim()
                    If txtEventText(ctr).Text = "" Then
                        MsgBox("Event " & ctr & " text is empty.")
                        EventTextsComplete = False
                        Exit For
                    End If
                    EventTextsComplete = True
                Next
                If EventTextsComplete Then
                    Dim FatalEventsComplete As Boolean
                    For ctr = 2 To 5
                        If KilledCount(ctr) = 0 Then
                            MsgBox("Fatal event " & ctr & " has no casualties")
                            FatalEventsComplete = False
                            Exit For
                        End If
                        FatalEventsComplete = True
                    Next
                    If FatalEventsComplete Then
                        Dim HasUnmentionedPlayer As Boolean
                        For ctr = 0 To 5
                            For ctr2 = 1 To PlayerCount(ctr)
                                If txtEventText(ctr).Text.IndexOf("(Player" & ctr2 & ")") = -1 Then
                                    MsgBox("Error: Player" & ctr2 & " is not mentioned in event text " & ctr)
                                    HasUnmentionedPlayer = True
                                    Exit For
                                End If
                            Next
                            If HasUnmentionedPlayer Then Exit For
                        Next
                        If Not HasUnmentionedPlayer Then
                            Dim ExcessPlayerCount As Integer
                            For ctr = 0 To 3
                                If nudTribCount(ctr).Value < 6 Then
                                    For ctr2 = nudTribCount(ctr).Value + 1 To 6
                                        If txtEventText(ctr + 2).Text.IndexOf("(Player" & ctr2 & ")") > -1 Then ExcessPlayerCount = ExcessPlayerCount + 1
                                    Next
                                End If
                                If ExcessPlayerCount > 0 Then
                                    MsgBox("Error: " & ExcessPlayerCount & " excess player" & If(ExcessPlayerCount > 1, "s are", " is") & " found in event " & ctr)
                                    Exit For
                                End If
                            Next
                            If ExcessPlayerCount = 0 Then
                                Dim HasNoKillers As Boolean
                                For ctr = 2 To 5
                                    If KillerCount(ctr) = 0 And KilledCount(ctr) > 0 Then
                                        For Each cmb In cmbDeathType(ctr - 1)
                                            If cmb.SelectedIndex = 0 Then
                                                MsgBox("At least one killer is needed for fatal event " & ctr)
                                                HasNoKillers = True
                                                Exit For
                                            End If
                                        Next
                                    End If
                                Next
                                If Not HasNoKillers Then
                                    ReDim Preserve SpecialArenaEvent(UBound(SpecialArenaEvent) + 1)
                                    With SpecialArenaEvent(UBound(SpecialArenaEvent))
                                        .DescriptionText = txtEventIntro.Text
                                        .NonFatalEvent.EventText = txtEventText(0).Text
                                        ReDim .FatalEvent(4)
                                        For ctr = 0 To 4
                                            With .FatalEvent(ctr)
                                                ReDim .P(5)
                                                .EventText = txtEventText(ctr + 1).Text
                                                .PlayerCount = PlayerCount(ctr + 1)
                                                .KillCount = KilledCount(ctr + 1)
                                                .IsSharedKill = If(ctr > 0, chkIsKillShared(ctr - 1).Checked, False)
                                                If ctr > 0 Then
                                                    For ctr2 = 0 To .PlayerCount - 1
                                                        .P(ctr2).IsKiller = chkIsTribKiller(ctr - 1)(ctr2).Checked
                                                        .P(ctr2).DeathType = cmbDeathType(ctr)(ctr2).SelectedIndex + 1
                                                    Next
                                                Else
                                                    .P(ctr).IsKiller = False
                                                    .P(ctr).DeathType = cmbDeathType(0)(0).SelectedIndex + 2
                                                End If
                                            End With
                                        Next
                                    End With
                                    NewEventAdded = True
                                    Close()
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
    Private Sub frmSpecialEventEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SpecialEventOutcome = {tabNonFatal, tabFatalEvent1, tabFatalEvent2, tabFatalEvent3, tabFatalEvent4, tabFatalEvent5}

        For ctr = 0 To 5
            lblEventText(ctr) = New Label
            With lblEventText(ctr)
                .Text = "Event text:"
                .Top = 5
                .Left = 0
            End With
            SpecialEventOutcome(ctr).Controls.Add(lblEventText(ctr))

            txtEventText(ctr) = New TextBox
            With txtEventText(ctr)
                .Top = 5
                .Left = lblEventText(ctr).Left + lblEventText(ctr).Width
                .Size = New Size(450, 70)
                .Multiline = True
            End With
            SpecialEventOutcome(ctr).Controls.Add(txtEventText(ctr))

            lblTribCount(ctr) = New Label
            With lblTribCount(ctr)
                .Text = "Number of tributes involved:"
                .AutoSize = True
                If ctr < 2 Then .Text = .Text & " 1"
                .Top = 82
                .Left = txtEventText(ctr).Left
            End With
            SpecialEventOutcome(ctr).Controls.Add(lblTribCount(ctr))

            If ctr > 0 Then
                lblDeathType(ctr - 1) = New Label
                With lblDeathType(ctr - 1)
                    .Text = "Death Type"
                    .Top = 100
                    .Left = 400
                    .AutoSize = True
                End With
                SpecialEventOutcome(ctr).Controls.Add(lblDeathType(ctr - 1))
            End If

            If ctr > 1 Then
                nudTribCount(ctr - 2) = New NumericUpDown
                With nudTribCount(ctr - 2)
                    .Value = 1
                    .Minimum = 1
                    .Maximum = 6
                    .Top = 80
                    .Left = lblTribCount(ctr).Left + lblTribCount(ctr).Width
                    .Width = 30
                    AddHandler .ValueChanged, AddressOf nudTribCount_ValueChanged
                    .Tag = ctr - 2
                End With
                SpecialEventOutcome(ctr).Controls.Add(nudTribCount(ctr - 2))

                chkIsKillShared(ctr - 2) = New CheckBox
                With chkIsKillShared(ctr - 2)
                    .Text = "Is shared kill?"
                    .Enabled = False
                    .Top = 77
                    .Left = nudTribCount(ctr - 2).Left + 60
                End With
                SpecialEventOutcome(ctr).Controls.Add(chkIsKillShared(ctr - 2))

                lblIsKiller(ctr - 2) = New Label
                With lblIsKiller(ctr - 2)
                    .Text = "Is killer?"
                    .Top = nudTribCount(ctr - 2).Top + nudTribCount(ctr - 2).Height
                    .Left = 240
                    .AutoSize = True
                End With
                SpecialEventOutcome(ctr).Controls.Add(lblIsKiller(ctr - 2))

                lblIsKilled(ctr - 2) = New Label
                With lblIsKilled(ctr - 2)
                    .Text = "Is killed?"
                    .Top = nudTribCount(ctr - 2).Top + nudTribCount(ctr - 2).Height
                    .Left = 300
                    .AutoSize = True
                End With
                SpecialEventOutcome(ctr).Controls.Add(lblIsKilled(ctr - 2))

                ReDim chkIsTribKiller(ctr - 2)(5)
                For ctr2 = 0 To 5
                    chkIsTribKiller(ctr - 2)(ctr2) = New CheckBox
                    With chkIsTribKiller(ctr - 2)(ctr2)
                        .Text = ""
                        .Top = 120 + (20 * ctr2)
                        .Left = 240
                        .AutoSize = True
                        If ctr2 > 0 Then .Visible = False 'Activate when ready
                        .Tag = ctr - 2
                        AddHandler .CheckedChanged, AddressOf chkIsTribKiller_CheckChange
                        .Enabled = False
                    End With
                    SpecialEventOutcome(ctr).Controls.Add(chkIsTribKiller(ctr - 2)(ctr2))
                Next

                ReDim chkIsTribKilled(ctr - 2)(5)
                For ctr2 = 0 To 5
                    chkIsTribKilled(ctr - 2)(ctr2) = New CheckBox
                    With chkIsTribKilled(ctr - 2)(ctr2)
                        .Text = ""
                        .Top = 120 + (20 * ctr2)
                        .Left = 300
                        .AutoSize = True
                        If ctr2 > 0 Then .Visible = False 'Activate when ready
                        .Tag = (ctr - 2) * 6 + ctr2
                        AddHandler .CheckedChanged, AddressOf chkIsTribKilled_CheckChange
                    End With
                    SpecialEventOutcome(ctr).Controls.Add(chkIsTribKilled(ctr - 2)(ctr2))
                Next

                ReDim lblTribute(ctr - 1)(5)
                For ctr2 = 0 To 5
                    lblTribute(ctr - 1)(ctr2) = New Label
                    With lblTribute(ctr - 1)(ctr2)
                        .Text = "Player " & (ctr2 + 1)
                        .Top = 120 + (20 * ctr2)
                        .Left = 100
                        .AutoSize = True
                        If ctr2 > 0 Then .Visible = False 'Activate when ready
                    End With
                    SpecialEventOutcome(ctr).Controls.Add(lblTribute(ctr - 1)(ctr2))
                Next

                ReDim cmbDeathType(ctr - 1)(5)
                For ctr2 = 0 To 5
                    cmbDeathType(ctr - 1)(ctr2) = New ComboBox
                    With cmbDeathType(ctr - 1)(ctr2)
                        .Top = 120 + (20 * ctr2)
                        .Left = 400
                        .Items.Add("Combat Death")
                        .Items.Add("Suicide")
                        .Items.Add("Other Death")
                        If ctr2 > 0 Then .Visible = False
                        .Enabled = False
                    End With
                    SpecialEventOutcome(ctr).Controls.Add(cmbDeathType(ctr - 1)(ctr2))
                Next
            End If
        Next

        txtEventText(0).Text = "(Player1) survives." 'Default value

        ReDim lblTribute(0)(0)
        lblTribute(0)(0) = New Label
        With lblTribute(0)(0)
            .Top = 125
            .Left = 340
            .AutoSize = True
            .Text = "Player 1"
        End With
        SpecialEventOutcome(1).Controls.Add(lblTribute(0)(0))

        ReDim cmbDeathType(0)(0)
        cmbDeathType(0)(0) = New ComboBox
        With cmbDeathType(0)(0)
            .Top = 120
            .Left = 400
            .Items.Add("Suicide")
            .Items.Add("Other Death")
            .SelectedIndex = 0
        End With
        SpecialEventOutcome(1).Controls.Add(cmbDeathType(0)(0))

        PlayerCount(0) = 1
        PlayerCount(1) = 1
        KilledCount(0) = 0
        KilledCount(1) = 1
    End Sub

    Private Sub nudTribCount_ValueChanged(sender As Object, e As EventArgs)
        PlayerCount(2 + CType(sender, NumericUpDown).Tag) = CType(sender, NumericUpDown).Value
        For ctr = 0 To 5
            lblTribute(CType(sender, NumericUpDown).Tag + 1)(ctr).Visible = ctr < CType(sender, NumericUpDown).Value
            chkIsTribKilled(CType(sender, NumericUpDown).Tag)(ctr).Visible = ctr < CType(sender, NumericUpDown).Value
            If Not chkIsTribKilled(CType(sender, NumericUpDown).Tag)(ctr).Visible Then chkIsTribKilled(CType(sender, NumericUpDown).Tag)(ctr).Checked = False
            chkIsTribKiller(CType(sender, NumericUpDown).Tag)(ctr).Visible = ctr < CType(sender, NumericUpDown).Value
            If Not chkIsTribKiller(CType(sender, NumericUpDown).Tag)(ctr).Visible Then chkIsTribKiller(CType(sender, NumericUpDown).Tag)(ctr).Checked = False
            cmbDeathType(CType(sender, NumericUpDown).Tag + 1)(ctr).Visible = ctr < CType(sender, NumericUpDown).Value
        Next
        If CType(sender, NumericUpDown).Value = 1 And chkIsTribKilled(CType(sender, NumericUpDown).Tag)(0).Checked Then cmbDeathType(CType(sender, NumericUpDown).Tag + 1)(0).SelectedIndex = 1
    End Sub
    Private Sub chkIsTribKiller_CheckChange(sender As Object, e As EventArgs)
        KillerCount(2 + CType(sender, CheckBox).Tag) = 0
        For Each chk In chkIsTribKiller(CType(sender, CheckBox).Tag)
            If chk.Checked Then KillerCount(2 + CType(sender, CheckBox).Tag) = KillerCount(2 + CType(sender, CheckBox).Tag) + 1
        Next
        If KillerCount(CType(sender, CheckBox).Tag) > 1 Then
            If Not chkIsKillShared(CType(sender, CheckBox).Tag).Enabled Then
                chkIsKillShared(CType(sender, CheckBox).Tag).Enabled = True
                chkIsKillShared(CType(sender, CheckBox).Tag).Checked = True
            End If
        Else
            chkIsKillShared(CType(sender, CheckBox).Tag).Enabled = False
            chkIsKillShared(CType(sender, CheckBox).Tag).Checked = False
        End If
    End Sub
    Private Sub chkIsTribKilled_CheckChange(sender As Object, e As EventArgs)
        KilledCount(2 + CType(sender, CheckBox).Tag \ 6) = 0
        For Each chk In chkIsTribKilled(CType(sender, CheckBox).Tag \ 6)
            If chk.Checked Then KilledCount(2 + CType(sender, CheckBox).Tag \ 6) = KilledCount(2 + CType(sender, CheckBox).Tag \ 6) + 1
        Next
        For Each chk In chkIsTribKiller(CType(sender, CheckBox).Tag \ 6)
            chk.Enabled = KilledCount(2 + CType(sender, CheckBox).Tag \ 6) > 0
            If Not chk.Enabled Then chk.Checked = False
        Next
        Debug.Print(CType(sender, CheckBox).Tag)
        With cmbDeathType(1 + CType(sender, CheckBox).Tag \ 6)(CType(sender, CheckBox).Tag Mod 6)
            If CType(sender, CheckBox).Checked Then
                .Enabled = True
                .SelectedIndex = If(nudTribCount(CType(sender, CheckBox).Tag \ 6).Value = 1, 1, 0) 'Default death type: Combat death if tribcount>1, Suicide if tribcount =1
            Else
                .Enabled = False
                .SelectedIndex = -1 'Set to non-fatal
            End If
        End With
    End Sub

    Private Sub frmSpecialEventEdit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub

    Private Sub frmSpecialEventEdit_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If NewEventAdded Then
            frmEvents.lbxSpecialArenaEvents.Items.Add(SpecialArenaEvent(UBound(SpecialArenaEvent)).DescriptionText)
        End If
    End Sub
End Class