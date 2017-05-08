Imports System.ComponentModel

Public Class frmEventEdit
    Dim lblTribute(5) As Label, chkIsTribKiller(5), chkIsTribKilled(5) As CheckBox, cmbDeathType(5) As ComboBox,
        EventScope, KillerCount, KilledCount As Byte, NewEventAdded As Boolean
    Private Sub clbEventScope_SelectedIndexChanged(sender As Object, e As EventArgs) Handles clbEventScope.SelectedIndexChanged
        EventScope = 0
        If clbEventScope.CheckedIndices.Count > 0 Then
            Dim tempstr As String = ""
            For ctr = 0 To clbEventScope.CheckedIndices.Count - 1
                EventScope = EventScope + 2 ^ clbEventScope.CheckedIndices(ctr)
                tempstr = tempstr & clbEventScope.CheckedIndices(ctr) & " "
            Next
        End If

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmEventEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        For ctr = 0 To 5
            chkIsTribKilled(ctr) = New CheckBox
            With chkIsTribKilled(ctr)
                .Top = lblIsKilled.Top + lblIsKilled.Height + (.Height * ctr)
                .Left = lblIsKilled.Left + (lblIsKilled.Width / 2)
                .Text = ""
                If ctr > 0 Then .Visible = False
                .Tag = ctr
                AddHandler .CheckedChanged, AddressOf chkIsTribKilled_CheckChange
            End With
            Controls.Add(chkIsTribKilled(ctr))

            cmbDeathType(ctr) = New ComboBox
            With cmbDeathType(ctr)
                .Top = lblIsKilled.Top + lblIsKilled.Height + (chkIsTribKilled(ctr).Height * ctr)
                .Left = chkIsTribKilled(ctr).Left + chkIsTribKilled(ctr).Width
                .Items.Add("Combat Death")
                .Items.Add("Suicide")
                .Items.Add("Other Death")
                If ctr > 0 Then .Visible = False
                .Enabled = False
            End With
            Controls.Add(cmbDeathType(ctr))

            chkIsTribKiller(ctr) = New CheckBox
            With chkIsTribKiller(ctr)
                .Top = lblIsKiller.Top + lblIsKiller.Height + (.Height * ctr)
                .Left = lblIsKiller.Left + (lblIsKiller.Width / 2)
                .Text = ""
                If ctr > 0 Then .Visible = False
                .Tag = ctr
                .Enabled = False
                AddHandler .CheckedChanged, AddressOf chkIsTribKiller_CheckChange
            End With
            Controls.Add(chkIsTribKiller(ctr))

            lblTribute(ctr) = New Label
            With lblTribute(ctr)
                .Text = "Player " & ctr + 1
                .Top = lblIsKiller.Top + lblIsKiller.Height + 5 + (chkIsTribKiller(ctr).Height * ctr)
                .Left = lblIsKiller.Left - .Width
                If ctr > 0 Then .Visible = False
            End With
            Controls.Add(lblTribute(ctr))
        Next
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        txtEventText.Text.Trim()
        If txtEventText.Text = "" Then
            MsgBox("No text provided for event")
        Else
            Dim HasDuplicate, HasNoKillers As Boolean
            For Each member In ArenaEvent
                If member.EventText = txtEventText.Text Then
                    HasDuplicate = True
                    Exit For
                End If
            Next
            If HasDuplicate Then
                MsgBox("Event with similar text already exists")
            ElseIf clbEventScope.CheckedIndices.Count = 0 Then
                MsgBox("Event has no scope selected")
            Else
                Dim HasUnmentionedPlayer As Boolean
                For ctr = 1 To nudTribCount.Value
                    If txtEventText.Text.IndexOf("(Player" & ctr & ")") = -1 Then
                        MsgBox("Player" & ctr & " is not mentioned in event text")
                        HasUnmentionedPlayer = True
                        Exit For
                    End If
                Next
                If Not HasUnmentionedPlayer Then
                    Dim ExcessPlayerCount As Integer
                    If nudTribCount.Value < 6 Then
                        For ctr = nudTribCount.Value + 1 To 6
                            If txtEventText.Text.IndexOf("(Player" & ctr & ")") > -1 Then ExcessPlayerCount = ExcessPlayerCount + 1
                        Next
                    End If
                    If ExcessPlayerCount > 0 Then
                        MsgBox(ExcessPlayerCount & " excess player" & If(ExcessPlayerCount > 1, "s are", " is") & " found")
                    ElseIf KillerCount = 0 And KilledCount > 0 Then
                        For Each cmb In cmbDeathType
                            If cmb.SelectedIndex = 0 Then
                                MsgBox("At least one killer needed")
                                HasNoKillers = True
                                Exit For
                            End If
                        Next
                    End If
                    If Not HasNoKillers Then
                        ReDim Preserve ArenaEvent(UBound(ArenaEvent) + 1)
                        With ArenaEvent(UBound(ArenaEvent))
                            .EventText = txtEventText.Text
                            .PlayerCount = nudTribCount.Value
                            For ctr = 0 To clbEventScope.CheckedIndices.Count - 1
                                .EventScope = .EventScope + 2 ^ clbEventScope.CheckedIndices(ctr)
                            Next
                            .KillCount = KilledCount
                            .IsSharedKill = chkIsKillShared.Checked
                            ReDim .P(5)
                            For ctr = 0 To 5
                                .P(ctr).IsKiller = chkIsTribKiller(ctr).Checked
                                .P(ctr).DeathType = cmbDeathType(ctr).SelectedIndex + 1
                            Next
                        End With
                        NewEventAdded = True
                        Close()
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub nudTribCount_ValueChanged(sender As Object, e As EventArgs) Handles nudTribCount.ValueChanged
        If Not lblTribute(0) Is Nothing Then 'Check if the affected controls are present
            For ctr = 0 To 5
                lblTribute(ctr).Visible = ctr < nudTribCount.Value
                chkIsTribKilled(ctr).Visible = ctr < nudTribCount.Value
                If Not chkIsTribKilled(ctr).Visible Then chkIsTribKilled(ctr).Checked = False
                chkIsTribKiller(ctr).Visible = ctr < nudTribCount.Value
                If Not chkIsTribKiller(ctr).Visible Then chkIsTribKiller(ctr).Checked = False
                cmbDeathType(ctr).Visible = ctr < nudTribCount.Value
            Next
            If nudTribCount.Value = 1 And chkIsTribKilled(0).Checked Then cmbDeathType(0).SelectedIndex = 1
        End If
    End Sub
    Private Sub chkIsTribKilled_CheckChange(sender As Object, e As EventArgs)
        KilledCount = 0
        For Each chk In chkIsTribKilled
            If chk.Checked Then KilledCount = KilledCount + 1
        Next
        For Each chk In chkIsTribKiller
            chk.Enabled = KilledCount > 0
            If Not chk.Enabled Then chk.Checked = False
        Next
        With cmbDeathType(CType(sender, CheckBox).Tag)
            If CType(sender, CheckBox).Checked Then
                .Enabled = True
                .SelectedIndex = If(nudTribCount.Value = 1, 1, 0) 'Default death type: Combat death if tribcount>1, Suicide if tribcount =1
            Else
                .Enabled = False
                .SelectedIndex = -1 'Set to non-fatal
            End If
        End With
    End Sub
    Private Sub chkIsTribKiller_CheckChange(sender As Object, e As EventArgs)
        KillerCount = 0
        For Each chk In chkIsTribKiller
            If chk.Checked Then KillerCount = KillerCount + 1
        Next
        If KillerCount > 1 Then
            If Not chkIsKillShared.Enabled Then
                chkIsKillShared.Enabled = True
                chkIsKillShared.Checked = True
            End If
        Else
            chkIsKillShared.Enabled = False
            chkIsKillShared.Checked = False
        End If
    End Sub
    Private Sub frmEventEdit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose() 'Needed to reset form
    End Sub
    Private Sub frmEventEdit_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not NewEventAdded Then
            frmEvents.lbxEventList.Items.Clear()
            For ctr = 0 To UBound(ArenaEvent)
                frmEvents.lbxEventList.Items.Add(ArenaEvent(ctr).EventText)
            Next
        End If
    End Sub
End Class