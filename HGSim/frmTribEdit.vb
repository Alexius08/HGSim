Imports System.ComponentModel 'Used for frmTribEdit_Closing
Imports System.Drawing.Drawing2D 'Used for Image Resize
Public Class frmTribEdit
    Dim SelectedPic, SelectedDeathPic As String
    Private Sub frmTribEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not picTribute.Image Is Nothing And radGrayscale.Checked Then
            picDeadTribute.Image = MakeGrey(picTribute.Image)
        End If
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        txtTribName.Text.Trim()
        If txtTribName.Text = "" Then
            MsgBox("Please enter a valid name")
        ElseIf Text = "Edit current tribute" Then
            With frmReaping
                .TributePicker(Tag).Items.Item(0) = "Edit current tribute"
                .TributePicker(Tag).Text = txtTribName.Text
                With Tribute(.ChosenTribute(CType(sender, ComboBox).Tag))
                    .Name = txtTribName.Text
                    .Nickname = txtNick.Text
                    .Picture = "T" & .ID.ToString("D5") & SelectedPic.Substring(SelectedPic.LastIndexOf("."))
                    If IO.Directory.GetCurrentDirectory & "\tribdb\" & .Picture <> SelectedPic Then
                        Dim OrigFormat As Imaging.ImageFormat = Imaging.ImageFormat.Png
                        Select Case StrConv(SelectedPic.Substring(SelectedPic.LastIndexOf(".") + 1), VbStrConv.Lowercase)
                            Case "bmp"
                                OrigFormat = Imaging.ImageFormat.Bmp
                            Case "jpg", "jpeg"
                                OrigFormat = Imaging.ImageFormat.Jpeg
                            Case "gif"
                                OrigFormat = Imaging.ImageFormat.Gif
                            Case "png"
                                OrigFormat = Imaging.ImageFormat.Png
                        End Select
                        picTribute.Image.Save(IO.Directory.GetCurrentDirectory & "\tribdb\" & SelectedPic.Substring(SelectedPic.LastIndexOf("\") + 1), OrigFormat)
                    End If
                    .Gender = cbxGender.Text.Chars(0)
                    If radCustom.Checked Then
                        .DeathPicture = picDeadTribute.ImageLocation
                    ElseIf radGrayscale.Checked Then
                        .DeathPicture = "BW"
                    ElseIf radNorm.Checked Then
                        .DeathPicture = "N"
                    ElseIf radXMark.Checked Then
                        .DeathPicture = "X"
                    End If
                End With
            End With
        Else
            Dim TribList As New List(Of String)
            For Each member In Tribute
                TribList.Add(member.Name)
            Next
            For ctr = 0 To UBound(frmReaping.NewTribute)
                If ctr <> Tag And Not frmReaping.NewTribute(ctr).Name Is Nothing Then TribList.Add(frmReaping.NewTribute(ctr).Name)
            Next

            If TribList.Contains(txtTribName.Text) Then
                MsgBox("A tribute with the same name already exists")
            Else
                txtNick.Text.Trim()
                If txtNick.Text = "" Then
                    MsgBox("Please enter a valid nickname")
                ElseIf cbxGender.SelectedIndex = -1 Then
                    MsgBox("Gender is not yet selected")
                ElseIf picTribute.Image Is Nothing Then
                    MsgBox("Please provide a valid picture")
                Else
                    If Not IO.Directory.Exists(IO.Directory.GetCurrentDirectory & "\temp") Then IO.Directory.CreateDirectory(IO.Directory.GetCurrentDirectory & "\temp")
                    Dim OrigFormat As Imaging.ImageFormat = Imaging.ImageFormat.Png
                    Select Case StrConv(SelectedPic.Substring(SelectedPic.LastIndexOf(".") + 1), VbStrConv.Lowercase)
                        Case "bmp"
                            OrigFormat = Imaging.ImageFormat.Bmp
                        Case "jpg", "jpeg"
                            OrigFormat = Imaging.ImageFormat.Jpeg
                        Case "gif"
                            OrigFormat = Imaging.ImageFormat.Gif
                        Case "png"
                            OrigFormat = Imaging.ImageFormat.Png
                    End Select
                    picTribute.Image.Save(IO.Directory.GetCurrentDirectory & "\temp\" & SelectedPic.Substring(SelectedPic.LastIndexOf("\") + 1), OrigFormat)
                    With frmReaping
                        .TributePicker(Tag).Items.Item(0) = "Edit new tribute"
                        .TributePicker(Tag).Text = txtTribName.Text
                        With .NewTribute(Tag)
                            .Name = txtTribName.Text
                            .Nickname = txtNick.Text
                            .Picture = IO.Directory.GetCurrentDirectory & "\temp\" & SelectedPic.Substring(SelectedPic.LastIndexOf("\") + 1)
                            .Gender = cbxGender.Text.Chars(0)
                            If radCustom.Checked Then
                                Select Case StrConv(SelectedDeathPic.Substring(SelectedDeathPic.LastIndexOf(".") + 1), VbStrConv.Lowercase)
                                    Case "bmp"
                                        OrigFormat = Imaging.ImageFormat.Bmp
                                    Case "jpg", "jpeg"
                                        OrigFormat = Imaging.ImageFormat.Jpeg
                                    Case "gif"
                                        OrigFormat = Imaging.ImageFormat.Gif
                                    Case "png"
                                        OrigFormat = Imaging.ImageFormat.Png
                                End Select
                                .DeathPicture = IO.Directory.GetCurrentDirectory & "\temp\" & SelectedDeathPic.Substring(SelectedDeathPic.LastIndexOf("\") + 1)
                                picDeadTribute.Image.Save(.DeathPicture, OrigFormat)
                            ElseIf radGrayscale.Checked Then
                                .DeathPicture = "BW"
                            ElseIf radNorm.Checked Then
                                .DeathPicture = "N"
                            ElseIf radXMark.Checked Then
                                .DeathPicture = "X"
                            End If
                        End With
                    End With
                    Close()
                End If
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        With frmReaping
            If .NewTribute(Tag).Name <> Nothing And .TributePicker(Tag).SelectedIndex = 0 Then
                .TributePicker(Tag).Text = .NewTribute(Tag).Name
            Else
                .TributePicker(Tag).Text = Tribute(.ChosenTribute(Tag)).Name 'Don't save changes
            End If
        End With
        Close()
    End Sub
    Private Sub frmTribEdit_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not picTribute.Image Is Nothing Then picTribute.Image.Dispose()
        If Not picDeadTribute.Image Is Nothing Then picDeadTribute.Image.Dispose()
        frmReaping.Enabled = True
    End Sub
    Private Sub radGrayscale_CheckedChanged(sender As Object, e As EventArgs) Handles radGrayscale.CheckedChanged
        If radGrayscale.Checked Then
            frmReaping.NewTribute(Tag).DeathPicture = "BW"
            If Not picTribute.Image Is Nothing Then
                'picDeadTribute.Image.Dispose()
                picDeadTribute.Image = MakeGrey(picTribute.Image)
            End If
        End If

    End Sub
    Private Sub radNorm_CheckedChanged(sender As Object, e As EventArgs) Handles radNorm.CheckedChanged
        If radNorm.Checked Then
            frmReaping.NewTribute(Tag).DeathPicture = "N"
            If Not picTribute.Image Is Nothing Then
                'picDeadTribute.Image.Dispose()
                picDeadTribute.Image = picTribute.Image
            End If
        End If
    End Sub
    Private Sub radXMark_CheckedChanged(sender As Object, e As EventArgs) Handles radXMark.CheckedChanged
        If radXMark.Checked Then
            frmReaping.NewTribute(Tag).DeathPicture = "X"
            If Not picTribute.Image Is Nothing Then
                picDeadTribute.Image = DrawXOver(picTribute.Image)
            End If
        End If
    End Sub
    Private Sub radCustom_CheckedChanged(sender As Object, e As EventArgs) Handles radCustom.CheckedChanged
        If Visible And radCustom.Checked Then
            If ofdPicSelection.ShowDialog() = DialogResult.OK Then
                If Not picDeadTribute.Image Is Nothing Then picDeadTribute.Image.Dispose()
                picDeadTribute.Image = ResizeImage(Image.FromFile(ofdPicSelection.FileName), New Size(90, 90), False)
                SelectedDeathPic = ofdPicSelection.FileName
            End If
        End If
    End Sub

    Private Sub picTribute_Click(sender As Object, e As EventArgs) Handles picTribute.Click, lblTribPic.Click
        If ofdPicSelection.ShowDialog() = DialogResult.OK Then
            lblTribPic.Visible = False
            If Not picTribute.Image Is Nothing Then picTribute.Image.Dispose()
            picTribute.Image = ResizeImage(Image.FromFile(ofdPicSelection.FileName), New Size(90, 90), False)
            If radGrayscale.Checked Then
                picDeadTribute.Image = MakeGrey(picTribute.Image)
            End If
            SelectedPic = ofdPicSelection.FileName
        End If
        ofdPicSelection.Dispose()
    End Sub
    Private Function ResizeImage(ByVal image As Image,
  ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
                    percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As Image = New Bitmap(newWidth, newHeight)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
    Private Sub txtTribName_LostFocus(sender As Object, e As EventArgs) Handles txtTribName.LostFocus
        If txtTribName.Text <> "" And txtNick.Text = "" Then txtNick.Text = txtTribName.Text
    End Sub

End Class