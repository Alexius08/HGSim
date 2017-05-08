Imports System.ComponentModel

Public Class frmEvents
    Private Sub frmEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For ctr = 0 To UBound(ArenaEvent)
            lbxEventList.Items.Add(ArenaEvent(ctr).EventText)
        Next
        For ctr = 0 To UBound(SpecialArenaEvent)
            lbxSpecialArenaEvents.Items.Add(SpecialArenaEvent(ctr).DescriptionText)
        Next
    End Sub

    Private Sub lbxEventList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxEventList.SelectedIndexChanged
        If lbxEventList.SelectedIndex > -1 Then
            With ArenaEvent(lbxEventList.SelectedIndex)
                Dim temp As String = "", ctr As Byte = .EventScope
                If .EventScope >= 8 Then
                    temp = "Feast"
                    ctr = ctr - 8
                End If
                If ctr >= 4 Then
                    temp = If(Len(temp) > 0, "Night, " & temp, "Night")
                    ctr = ctr - 4
                End If
                If ctr >= 2 Then
                    temp = If(Len(temp) > 0, "Day, " & temp, "Day")
                    ctr = ctr - 2
                End If
                If ctr = 1 Then temp = If(Len(temp) > 0, "Bloodbath, " & temp, "Bloodbath")

                lblEventDesc.Text = .EventText & vbCrLf & "Event scope: " & temp & vbCrLf & "Killer:"

                ctr = 0
                For ctr2 = 0 To 5
                    If .P(ctr2).IsKiller Then
                        lblEventDesc.Text = lblEventDesc.Text & If(ctr > 0, ", ", " ") & "Player" & CStr(ctr2 + 1)
                        ctr = ctr + 1
                    End If
                Next
                If ctr = 0 Then lblEventDesc.Text = lblEventDesc.Text & " None"
                lblEventDesc.Text = lblEventDesc.Text & vbCrLf & "Killed:"

                If .KillCount > 0 Then
                    ctr = 0
                    For ctr2 = 0 To 5
                        If .P(ctr2).DeathType > 0 Then
                            lblEventDesc.Text = lblEventDesc.Text & If(ctr > 0, ", ", " ") & "Player" & CStr(ctr2 + 1)
                            ctr = ctr + 1
                        End If
                    Next
                Else lblEventDesc.Text = lblEventDesc.Text & " None"
                End If
            End With
        End If
    End Sub
    Private Sub lbxSpecialArenaEvents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxSpecialArenaEvents.SelectedIndexChanged
        lbxSpecialArenaEventOutcome.Items.Clear()
        If lbxSpecialArenaEvents.SelectedIndex > -1 Then
            lbxSpecialArenaEventOutcome.Items.Add(SpecialArenaEvent(lbxSpecialArenaEvents.SelectedIndex).NonFatalEvent.EventText)
            For ctr = 0 To 4
                lbxSpecialArenaEventOutcome.Items.Add(SpecialArenaEvent(lbxSpecialArenaEvents.SelectedIndex).FatalEvent(ctr).EventText)
            Next
        End If
    End Sub
    Private Sub btnAddNewEvent_Click(sender As Object, e As EventArgs) Handles btnAddNewEvent.Click
        frmEventEdit.ShowDialog()
    End Sub
    Private Sub frmEvents_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        WriteSpecialEventFile()
        WriteEventFile()
        frmSplash.Focus()
    End Sub
    Private Sub btnRmEvent_Click(sender As Object, e As EventArgs) Handles btnRmEvent.Click
        If lbxEventList.SelectedIndex > -1 Then
            If lbxEventList.SelectedIndex < lbxEventList.Items.Count - 1 Then
                For ctr = lbxEventList.SelectedIndex To UBound(ArenaEvent) - 1
                    ArenaEvent(ctr) = ArenaEvent(ctr + 1)
                Next
            End If
            ReDim Preserve ArenaEvent(UBound(ArenaEvent) - 1)
            lbxEventList.Items.RemoveAt(lbxEventList.SelectedIndex)
        End If
    End Sub
    Private Sub btnRestoreDefaults_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaults.Click
        InitializeEventFile()
        lbxEventList.Items.Clear()
        For ctr = 0 To UBound(ArenaEvent)
            lbxEventList.Items.Add(ArenaEvent(ctr).EventText)
        Next
    End Sub
    Private Sub btmAddNewArenaEvent_Click(sender As Object, e As EventArgs) Handles btmAddNewArenaEvent.Click
        frmSpecialEventEdit.ShowDialog()
    End Sub
    Private Sub btnRestoreDefaultSets_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaultSets.Click
        InitializeSpecialEventFile()
        lbxSpecialArenaEventOutcome.Items.Clear()
        lbxSpecialArenaEvents.Items.Clear()
        For ctr = 0 To UBound(SpecialArenaEvent)
            lbxSpecialArenaEvents.Items.Add(SpecialArenaEvent(ctr).DescriptionText)
        Next
    End Sub
    Private Sub btnRemoveArenaEvent_Click(sender As Object, e As EventArgs) Handles btnRemoveArenaEvent.Click
        With lbxSpecialArenaEvents
            If .SelectedIndex > -1 Then
                If .SelectedIndex < .Items.Count - 1 Then
                    For ctr = .SelectedIndex To UBound(SpecialArenaEvent) - 1
                        SpecialArenaEvent(ctr) = SpecialArenaEvent(ctr + 1)
                    Next
                End If
                ReDim Preserve SpecialArenaEvent(UBound(SpecialArenaEvent) - 1)
                lbxSpecialArenaEventOutcome.Items.Clear()
                .Items.RemoveAt(.SelectedIndex)
            End If
        End With
    End Sub

    Private Sub frmEvents_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If UBound(SpecialArenaEvent) < 0 Then
            If MsgBox("There are no arena events present. Do you want to revert to the default arena event list?", vbYesNo) = MsgBoxResult.Yes Then
                InitializeSpecialEventFile()
            Else
                e.Cancel = True
            End If
        End If

        SeparateEvents()

        If BloodbathEventColl(0).Length = 0 Then
            If MsgBox("There are no single-player bloodbath events present. Do you want to use the default bloodbath event list?", vbYesNo) = MsgBoxResult.Yes Then
                BloodbathEvent = DefaultBloodbath
                BloodbathLimit = {19, 25, 26, 27, 27, 27}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(BloodbathEventColl, BloodbathEvent, BloodbathLimit)
        End If
        If BloodbathFatalColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no fatal single-player bloodbath events present. Do you want to use the default fatal bloodbath event list?", vbYesNo) = MsgBoxResult.Yes Then
                BloodbathFatal = DefaultBloodbathFatal
                BloodbathFatalLimit = {4, 38, 39, 47, 47, 50, 51, 52, 52, 53, 53}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(BloodbathFatalColl, BloodbathFatal, BloodbathFatalLimit)
        End If

        If DayEventColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no single-player day events present. Do you want to use the default day event list?", vbYesNo) = MsgBoxResult.Yes Then
                DayEvent = DefaultDay
                DayLimit = {27, 41, 43, 44, 46, 47}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(DayEventColl, DayEvent, DayLimit)
        End If
        If DayFatalColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no fatal single-player day events present. Do you want to use the default fatal day event list?", vbYesNo) = MsgBoxResult.Yes Then
                DayFatal = DefaultDayFatal
                DayFatalLimit = {11, 49, 51, 60, 60, 68, 69, 71, 71, 75, 75}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(DayFatalColl, DayFatal, DayFatalLimit)
        End If

        If NightEventColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no single-player night events present. Do you want to use the default night event list?", vbYesNo) = MsgBoxResult.Yes Then
                NightEvent = DefaultNight
                NightLimit = {26, 38, 41, 44, 45, 45}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(NightEventColl, NightEvent, NightLimit)
        End If
        If NightFatalColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no fatal single-player night events present. Do you want to use the default fatal night event list?", vbYesNo) = MsgBoxResult.Yes Then
                NightFatal = DefaultNightFatal
                NightFatalLimit = {11, 49, 51, 60, 60, 68, 69, 71, 71, 75, 75}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(NightFatalColl, NightFatal, NightFatalLimit)
        End If

        If FeastEventColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no single-player feast events present. Do you want to use the default feast event list?", vbYesNo) = MsgBoxResult.Yes Then
                FeastEvent = DefaultFeast
                FeastLimit = {3, 8, 9, 10, 10, 10}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(FeastEventColl, FeastEvent, FeastLimit)
        End If
        If FeastFatalColl(0).Length = 0 And Not e.Cancel Then
            If MsgBox("There are no fatal single-player feast events present. Do you want to use the default fatal feast event list?", vbYesNo) = MsgBoxResult.Yes Then
                FeastFatal = DefaultFeastFatal
                FeastFatalLimit = {5, 37, 38, 47, 47, 51, 52, 54, 54, 58, 58}
            Else
                e.Cancel = True
            End If
        Else
            GatherEventGroup(FeastFatalColl, FeastFatal, FeastFatalLimit)
        End If
    End Sub

End Class