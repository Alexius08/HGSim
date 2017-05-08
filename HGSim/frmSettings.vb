Public Class frmSettings
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        HasArenaEvents = chkArenaEvent.Checked
        FatalEventOdds = 0.2 - (0.05 * cbxKillRate.SelectedIndex)
        DefaultEventRate = 0.4 - cbxDefEvent.SelectedIndex * 0.2
        ShowRecentDeaths = chkRecentDeaths.Checked
        Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class