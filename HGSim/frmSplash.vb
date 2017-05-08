
Public Class frmSplash
    Private Sub btnStats_Click(sender As Object, e As EventArgs) Handles btnStats.Click
        frmStats.Show()
    End Sub
    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        frmEvents.Show()
    End Sub
    Private Sub btnLaunch_Click(sender As Object, e As EventArgs) Handles btnLaunch.Click
        Hide()
        frmReaping.ShowDialog()
    End Sub
    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub frmSplash_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        ini.AddSection("Settings").AddKey("DefaultEventRate").SetValue(DefaultEventRate)
        ini.AddSection("Settings").AddKey("HasArenaEvents").SetValue(HasArenaEvents)
        ini.AddSection("Settings").AddKey("FatalEventOdds").SetValue(FatalEventOdds)
        ini.AddSection("Settings").AddKey("ShowRecentDeaths").SetValue(ShowRecentDeaths)
        ini.Save(inipath)
    End Sub
End Class
