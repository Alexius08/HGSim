Public Class frmReaping
    Public TributePicker() As ComboBox 'Prevent nullref error
    Dim DistrictLabel(11) As Label, TribPic() As PictureBox, TribName() As Label
    Public ChosenTribute(47) As Integer, NewTribute(47) As Player
    Private Sub nudTribNumSel_ValueChanged(sender As Object, e As EventArgs) Handles nudTribNumSel.ValueChanged
        For ctr = 24 To 47
            If TributePicker IsNot Nothing Then TributePicker(ctr).Visible = If(nudTribNumSel.Value > ctr, True, False)
        Next
    End Sub
    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If btnStop.Text = "Cancel" Then
            Close()
        Else
            For ctr = 0 To nudTribNumSel.Value - 1
                TributePicker(ctr).Show()
                TribPic(ctr).Image.Dispose()
                TribPic(ctr).Dispose()
                TribName(ctr).Dispose()
            Next
            For Each member In DistrictLabel
                member.Show()
            Next
            pnlReaping.Hide()
            lblTribNumSel.Show()
            nudTribNumSel.Show()
            btnGo.Text = "Preview"
            btnStop.Text = "Cancel"
        End If
    End Sub
    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
        If btnGo.Text = "Preview" Then
            Dim UnfilledSlots As Byte
            For ctr = 0 To nudTribNumSel.Value - 1
                If TributePicker(ctr).Text = "" Then
                    UnfilledSlots = UnfilledSlots + 1
                End If
            Next
            If UnfilledSlots > 0 Then
                MsgBox(UnfilledSlots & " slot" & If(UnfilledSlots = 1, " is", "s are") & " not yet filled")
            Else
                ReDim TribPic(nudTribNumSel.Value - 1)
                ReDim TribName(nudTribNumSel.Value - 1)
                lblTribNumSel.Hide()
                nudTribNumSel.Hide()
                pnlReaping.Show()
                For ctr = 0 To nudTribNumSel.Value - 1
                    TributePicker(ctr).Hide()
                    TribPic(ctr) = New PictureBox
                    With TribPic(ctr)
                        .Image = Image.FromFile(If(NewTribute(ctr).Name = TributePicker(ctr).Text, NewTribute(ctr).Picture, IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(ChosenTribute(ctr)).Picture))
                        '.ImageLocation = IO.Directory.GetCurrentDirectory & "\tribdb\" & Tribute(ChosenTribute(ctr)).Picture Prone to memory leaks
                        .Height = 90
                        .Width = 90
                        .SizeMode = PictureBoxSizeMode.StretchImage
                        .Top = 103 * (ctr Mod 12)
                        .Left = 110 * (ctr \ 12)
                    End With
                    pnlReaping.Controls.Add(TribPic(ctr))
                    TribName(ctr) = New Label
                    With TribName(ctr)
                        .Text = If(NewTribute(ctr).Name = TributePicker(ctr).Text, NewTribute(ctr).Name, Tribute(ChosenTribute(ctr)).Name)
                        .Width = 90
                        .Top = TribPic(ctr).Top + 90
                        .Left = TribPic(ctr).Left
                        .TextAlign = ContentAlignment.TopCenter
                    End With
                    pnlReaping.Controls.Add(TribName(ctr))
                Next
                For Each member In DistrictLabel
                    member.Hide()
                Next

                btnGo.Text = "Simulate"
                btnStop.Text = "Back"
            End If
        Else
            For ctr = 0 To nudTribNumSel.Value - 1
                If NewTribute(ctr).Name = TributePicker(ctr).Text Then
                    ReDim Preserve Tribute(UBound(Tribute) + 1)
                    With Tribute(UBound(Tribute))
                        .ID = UBound(Tribute)
                        ChosenTribute(ctr) = .ID
                        .Name = NewTribute(ctr).Name
                        .Nickname = NewTribute(ctr).Nickname
                        .Gender = NewTribute(ctr).Gender
                        .Picture = "T" & .ID.ToString("D5") & NewTribute(ctr).Picture.Substring(NewTribute(ctr).Picture.LastIndexOf("."))
                        IO.File.Copy(NewTribute(ctr).Picture, IO.Directory.GetCurrentDirectory & "\tribdb\" & .Picture)
                        If NewTribute(ctr).DeathPicture = "BW" Or NewTribute(ctr).DeathPicture = "X" Or NewTribute(ctr).DeathPicture = "N" Then
                            .DeathPicture = NewTribute(ctr).DeathPicture
                        Else
                            .DeathPicture = "DT" & .ID.ToString("D5") & NewTribute(ctr).DeathPicture.Substring(NewTribute(ctr).DeathPicture.LastIndexOf("."))
                            IO.File.Copy(NewTribute(ctr).DeathPicture, IO.Directory.GetCurrentDirectory & "\tribdb\" & .DeathPicture)
                        End If
                    End With
                End If
            Next

            ReDim Roster(nudTribNumSel.Value - 1)
            ReDim PreviousTribute(nudTribNumSel.Value - 1)
            For ctr = 0 To nudTribNumSel.Value - 1
                With Tribute(ChosenTribute(ctr)) 'Roster members should have zero deaths and zero kills
                    PreviousTribute(ctr) = .ID
                    Roster(ctr).ID = .ID
                    Roster(ctr).Name = .Name
                    Roster(ctr).Nickname = .Nickname
                    Roster(ctr).Picture = .Picture
                    Roster(ctr).DeathPicture = .DeathPicture
                    Roster(ctr).Gender = .Gender
                End With
                TribPic(ctr).Image.Dispose()
                TribPic(ctr).Dispose()
            Next
            pnlReaping.Controls.Clear()
            pnlReaping.Hide()
            ClearTempFolder()
            Hide()
            frmArena.ShowDialog()
        End If

    End Sub
    Private Sub frmReaping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        btnGo.Text = "Preview"
        btnStop.Text = "Cancel"
        ReDim TributePicker(47)
        For ctr = 0 To 11
            DistrictLabel(ctr) = New Label
            With DistrictLabel(ctr)
                .Text = "District " & CStr(ctr + 1)
                .Top = ctr * .Height + nudTribNumSel.Top + nudTribNumSel.Height + 10
                .AutoSize = False
                .Width = 60
            End With
            Me.Controls.Add(DistrictLabel(ctr))
        Next
        For ctr = 0 To 47
            TributePicker(ctr) = New ComboBox
            With TributePicker(ctr)
                .Width = 120
                .Left = (ctr \ 12) * .Width + DistrictLabel(0).Width
                .Top = DistrictLabel(ctr Mod 12).Top - 4 'formerly (ctr Mod 12) * .Height + nudTribNumSel.Top + nudTribNumSel.Height + 5
                .Items.Add("Add new tribute")
                .Items.Add("Choose from tribute list")
                .Items.Add("Edit current tribute")
                .Items.Add("Select random tribute")
                .Tag = ctr
                AddHandler .SelectedIndexChanged, AddressOf TribPicker_SelectedIndexChanged
            End With
            Controls.Add(TributePicker(ctr))
        Next

        If IsFirstRun Then
            'load default roster
            For ctr = 0 To 23
                TributePicker(12 * (ctr Mod 2) + (ctr \ 2)).Text = Tribute(ctr + 1).Name
                ChosenTribute(12 * (ctr Mod 2) + (ctr \ 2)) = ctr + 1
            Next
            For ctr = 24 To 47
                TributePicker(ctr).Hide()
            Next
        Else
            'load previous roster
            lblTribNumSel.Show()
            nudTribNumSel.Show()
            nudTribNumSel.Value = UBound(PreviousTribute) + 1
            For ctr = 24 To 47
                TributePicker(ctr).Visible = ctr < nudTribNumSel.Value
            Next
            For ctr = 0 To UBound(PreviousTribute)
                ChosenTribute(ctr) = PreviousTribute(ctr)
                TributePicker(ctr).Text = Tribute(ChosenTribute(ctr)).Name
            Next
        End If
    End Sub

    Private Sub btnRandom_Click(sender As Object, e As EventArgs) Handles btnRandom.Click
        For ctr = 0 To nudTribNumSel.Value - 1
            TributePicker(ctr).SelectedIndex = 3
        Next
    End Sub

    Private Sub TribPicker_SelectedIndexChanged(sender As Object, e As EventArgs)
        If CType(sender, ComboBox).SelectedIndex = 1 Then
            With frmStats
                .Tag = CType(sender, ComboBox).Tag
                .btnSelectTribute.Visible = True
                .btnResetStats.Visible = False
                .btnResetTribs.Visible = False
                .Show() 'Don't switch to modal
                .Text = "Choose from existing tribute"
            End With
            Me.Enabled = False
        ElseIf CType(sender, ComboBox).SelectedIndex = 3 Then
            Dim AvailableTributes As List(Of Integer) = New List(Of Integer)
            For ctr = 1 To UBound(Tribute)
                If Not ChosenTribute.Contains(ctr) Then AvailableTributes.Add(ctr)
            Next
            If AvailableTributes.Count > 0 Then
                ChosenTribute(CType(sender, ComboBox).Tag) = AvailableTributes(Math.Floor(Rnd() * AvailableTributes.Count))
                Debug.Print(Tribute(ChosenTribute(CType(sender, ComboBox).Tag)).Name + " (#" + CStr(ChosenTribute(CType(sender, ComboBox).Tag)) + ") is chosen")
                CType(sender, ComboBox).Text = Tribute(ChosenTribute(CType(sender, ComboBox).Tag)).Name
            Else
                MsgBox("No more tributes left")
            End If
        ElseIf CType(sender, ComboBox).SelectedIndex <> -1 Then
            frmTribEdit.Text = CType(sender, ComboBox).Text
            If CType(sender, ComboBox).SelectedIndex = 2 Then
                If ChosenTribute(CType(sender, ComboBox).Tag) > 0 Then
                    frmTribEdit.lblTribPic.Visible = False
                    With Tribute(ChosenTribute(CType(sender, ComboBox).Tag))
                        frmTribEdit.txtTribName.Text = .Name
                        frmTribEdit.txtNick.Text = .Nickname
                        frmTribEdit.picTribute.Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & .Picture)
                        Select Case .Gender
                            Case "M"
                                frmTribEdit.cbxGender.SelectedIndex = 0
                            Case "F"
                                frmTribEdit.cbxGender.SelectedIndex = 1
                            Case "N"
                                frmTribEdit.cbxGender.SelectedIndex = 2
                        End Select
                        Select Case .DeathPicture
                            Case "BW"
                                frmTribEdit.radGrayscale.Checked = True
                            Case "N"
                                frmTribEdit.radNorm.Checked = True
                            Case "X"
                                frmTribEdit.radXMark.Checked = True
                            Case Else
                                frmTribEdit.radCustom.Checked = True
                                frmTribEdit.picDeadTribute.Image = Image.FromFile(IO.Directory.GetCurrentDirectory & "\tribdb\" & .DeathPicture)
                        End Select
                    End With
                    frmTribEdit.Tag = CType(sender, ComboBox).Tag
                    frmTribEdit.Show() 'Don't switch to modal
                    Me.Enabled = False
                Else
                    MsgBox("No tribute has been assigned")
                    CType(sender, ComboBox).SelectedIndex = -1
                End If
            ElseIf CType(sender, ComboBox).SelectedIndex = 0 Then
                If CType(sender, ComboBox).Text = "Edit new tribute" And Not frmTribEdit.Visible Then
                    frmTribEdit.lblTribPic.Visible = False
                    With NewTribute(CType(sender, ComboBox).Tag)
                        frmTribEdit.txtTribName.Text = .Name
                        frmTribEdit.txtNick.Text = .Nickname
                        frmTribEdit.picTribute.Image = Image.FromFile(.Picture)
                        Select Case .Gender
                            Case "M"
                                frmTribEdit.cbxGender.SelectedIndex = 0
                            Case "F"
                                frmTribEdit.cbxGender.SelectedIndex = 1
                            Case "N"
                                frmTribEdit.cbxGender.SelectedIndex = 2
                            Case "P"
                                frmTribEdit.cbxGender.SelectedIndex = 3
                        End Select
                        Select Case .DeathPicture
                            Case "BW"
                                frmTribEdit.radGrayscale.Checked = True
                            Case "N"
                                frmTribEdit.radNorm.Checked = True
                            Case "X"
                                frmTribEdit.radXMark.Checked = True
                            Case Else
                                frmTribEdit.radCustom.Checked = True
                                frmTribEdit.picDeadTribute.Image = Image.FromFile(.DeathPicture)
                        End Select
                    End With
                End If
                frmTribEdit.Tag = CType(sender, ComboBox).Tag
                frmTribEdit.Show() 'Don't switch to modal
                Me.Enabled = False
            End If
        End If
    End Sub
    Private Sub frmReaping_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = If(btnStop.Text = "Back", True, False) OrElse If(MsgBox("Do you want to exit?", MsgBoxStyle.YesNo) = vbYes, False, True)
        If Not e.Cancel Then
            If btnStop.Text = "Cancel" Then frmSplash.Show()
            ClearTempFolder()
        End If
    End Sub

    Sub ClearTempFolder()
        If IO.Directory.Exists(IO.Directory.GetCurrentDirectory & "\temp") Then
            For Each entry In IO.Directory.GetFiles(IO.Directory.GetCurrentDirectory & "\temp")
                IO.File.Delete(entry)
            Next
            IO.Directory.Delete(IO.Directory.GetCurrentDirectory & "\temp")
        End If
    End Sub
End Class