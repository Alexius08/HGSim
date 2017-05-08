Imports System.ComponentModel

Public Class frmScoreboard
    Dim TribPic() As PictureBox, TribName() As Label, KillCount() As Label

    Private Sub frmScoreboard_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dispose()
    End Sub
    Private Sub frmScoreboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim TribPic(UBound(Roster))
        ReDim TribName(UBound(Roster))
        ReDim KillCount(UBound(Roster))

        For ctr = 0 To UBound(Roster)
            TribPic(ctr) = New PictureBox
            With TribPic(ctr)
                If Roster(ctr).Deaths = 0 Then
                    .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Roster(ctr).Picture)
                Else
                    Select Case Roster(ctr).DeathPicture
                        Case "BW"
                            .Image = MakeGrey(Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Roster(ctr).Picture))
                        Case "N"
                            .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Roster(ctr).Picture)
                        Case "X"
                            .Image = DrawXOver(Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Roster(ctr).Picture))
                        Case Else
                            .Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & Roster(ctr).DeathPicture)
                    End Select
                End If
                .Height = 90
                .Width = 90
                .SizeMode = PictureBoxSizeMode.StretchImage
                .Top = 147 * (ctr Mod 12)
                .Left = 110 * (ctr \ 12)
            End With
            Controls.Add(TribPic(ctr))

            TribName(ctr) = New Label
            With TribName(ctr)
                .Text = Roster(ctr).Nickname
                .Width = 90
                .Top = TribPic(ctr).Top + 90
                .Left = TribPic(ctr).Left
                .TextAlign = ContentAlignment.TopCenter
            End With
            Controls.Add(TribName(ctr))

            KillCount(ctr) = New Label
            With KillCount(ctr)
                .Text = If(Roster(ctr).Deaths = 0, "Alive", "Dead") & vbCrLf & Roster(ctr).Kills & " Kill" & If(Roster(ctr).Kills = 1, "", "s")
                .Width = 90
                .Top = TribName(ctr).Top + 26
                .Left = TribName(ctr).Left
                .TextAlign = ContentAlignment.TopCenter
            End With
            Controls.Add(KillCount(ctr))
        Next
    End Sub
End Class