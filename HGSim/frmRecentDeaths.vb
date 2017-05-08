Public Class frmRecentDeaths
    Dim DeadTribPic() As PictureBox, DeadTribName() As Label

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub
    Private Sub frmRecentDeaths_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For Each entry In DeadTribPic
            pnlCasualtyList.Controls.Remove(entry)
        Next
        For Each entry In DeadTribName
            pnlCasualtyList.Controls.Remove(entry)
        Next
        frmArena.RecentDeaths = Nothing
    End Sub

    Private Sub frmRecentDeaths_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmArena.RecentDeaths Is Nothing Then
            lblCasualtyCount.Text = "No cannon shots can be heard in the distance."
        Else
            lblCasualtyCount.Text = If(UBound(frmArena.RecentDeaths) = 0, "1 cannon shot", UBound(frmArena.RecentDeaths) + 1 & " cannon shots") & " can be heard in the distance."
            ReDim DeadTribPic(UBound(frmArena.RecentDeaths))
            ReDim DeadTribName(UBound(frmArena.RecentDeaths))
            For ctr = 0 To UBound(frmArena.RecentDeaths)
                DeadTribPic(ctr) = New PictureBox
                With DeadTribPic(ctr)
                    .Size = New Size(90, 90)
                    Select Case Tribute(frmArena.RecentDeaths(ctr)).DeathPicture
                        Case "BW"
                            .Image = MakeGrey(Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(frmArena.RecentDeaths(ctr)).Picture))
                        Case "N"
                            .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(frmArena.RecentDeaths(ctr)).Picture)
                        Case "X"
                            .Image = DrawXOver(Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(frmArena.RecentDeaths(ctr)).Picture))
                        Case Else
                            .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(frmArena.RecentDeaths(ctr)).DeathPicture)
                    End Select
                    .Top = ctr * 105
                    .Left = (Width / 2) - 45
                End With
                pnlCasualtyList.Controls.Add(DeadTribPic(ctr))

                DeadTribName(ctr) = New Label
                With DeadTribName(ctr)
                    .Text = Tribute(frmArena.RecentDeaths(ctr)).Name
                    .Top = DeadTribPic(ctr).Top + 90
                    .Left = (Width / 2) - (.Width / 2)
                    .TextAlign = ContentAlignment.TopCenter
                End With
                pnlCasualtyList.Controls.Add(DeadTribName(ctr))
            Next
        End If
    End Sub
End Class