Imports System.ComponentModel
Public Class frmStats
    Private Sub frmStats_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        With frmReaping
            If .Visible Then
                .Enabled = True
                .TributePicker(Tag).Text = Tribute(.ChosenTribute(Tag)).Name
            End If
        End With
    End Sub
    Private Sub frmStats_Load(sender As Object, e As EventArgs) Handles Me.Load
        For ctr = 1 To UBound(Tribute)
            lbxTribList.Items.Add(Tribute(ctr).Name)
        Next
    End Sub
    Private Sub lbxTribList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxTribList.SelectedIndexChanged
        If lbxTribList.SelectedIndex > -1 Then
            If btnSelectTribute.Visible Then btnSelectTribute.Enabled = True
            With Tribute(lbxTribList.SelectedIndex + 1)
                If Not picTribPic.Image Is Nothing Then picTribPic.Image.Dispose()
                picTribPic.Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & .Picture)
                lblTribName.Text = .Name
                lblTribStats.Text = .Wins & vbCrLf & vbCrLf & .Kills & vbCrLf & .SoloKills & vbCrLf & .SharedKills & vbCrLf & vbCrLf & .Deaths & vbCrLf & .CombatDeaths & vbCrLf & .Suicides & vbCrLf & .OtherDeaths & vbCrLf
            End With
        End If
    End Sub
    Private Sub btnResetTribs_Click(sender As Object, e As EventArgs) Handles btnResetTribs.Click
        InitializeTributeFile()
        Dim DefaultFiles As New List(Of String)
        DefaultFiles.Add("tributes.txt")
        lbxTribList.Items.Clear()
        For ctr = 1 To UBound(Tribute)
            lbxTribList.Items.Add(Tribute(ctr).Name)
            DefaultFiles.Add(Tribute(ctr).Picture) 'Gather filenames of default tribute pictures to a list
        Next
        For Each file In IO.Directory.GetFiles(IO.Directory.GetCurrentDirectory & "\tribdb\")
            If Not DefaultFiles.Contains(file.Substring(file.LastIndexOf("\") + 1)) Then IO.File.Delete(file) 'remove all user-added files
        Next
        WriteTributeFile()
    End Sub

    Private Sub btnResetStats_Click(sender As Object, e As EventArgs) Handles btnResetStats.Click
        For ctr = 1 To UBound(Tribute)
            With Tribute(ctr)
                .Wins = 0
                .Kills = 0
                .SoloKills = 0
                .SharedKills = 0
                .Deaths = 0
                .CombatDeaths = 0
                .Suicides = 0
                .OtherDeaths = 0
            End With
        Next
        WriteTributeFile()
        picTribPic.Image = Nothing
        lbxTribList.SelectedIndex = -1
        lblTribStats.Text = "0" & vbCrLf & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "0" & vbCrLf & "0"
        lblTribName.ResetText()
    End Sub

    Private Sub btnSelectTribute_Click(sender As Object, e As EventArgs) Handles btnSelectTribute.Click
        If (lbxTribList.SelectedIndex = -1) Then
            MsgBox("Please select a tribute on the list")
        Else
            If frmReaping.ChosenTribute.Contains(lbxTribList.SelectedIndex + 1) Then
                MsgBox("Tribute is already on the present lineup")
            Else
                frmReaping.ChosenTribute(Tag) = lbxTribList.SelectedIndex + 1
                'Debug.Print("Enter tribute no. " & lbxTribList.SelectedIndex + 1)
                Close()
            End If
        End If

    End Sub
End Class