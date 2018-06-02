<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTribEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.picTribute = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtTribName = New System.Windows.Forms.TextBox()
        Me.lblNick = New System.Windows.Forms.Label()
        Me.txtNick = New System.Windows.Forms.TextBox()
        Me.cbxGender = New System.Windows.Forms.ComboBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblDeathPic = New System.Windows.Forms.Label()
        Me.radGrayscale = New System.Windows.Forms.RadioButton()
        Me.radNorm = New System.Windows.Forms.RadioButton()
        Me.radXMark = New System.Windows.Forms.RadioButton()
        Me.radCustom = New System.Windows.Forms.RadioButton()
        Me.picDeadTribute = New System.Windows.Forms.PictureBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ofdPicSelection = New System.Windows.Forms.OpenFileDialog()
        Me.lblTribPic = New System.Windows.Forms.Label()
        CType(Me.picTribute, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDeadTribute, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picTribute
        '
        Me.picTribute.BackColor = System.Drawing.Color.Transparent
        Me.picTribute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picTribute.Location = New System.Drawing.Point(191, 3)
        Me.picTribute.Name = "picTribute"
        Me.picTribute.Size = New System.Drawing.Size(90, 90)
        Me.picTribute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picTribute.TabIndex = 0
        Me.picTribute.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(2, 6)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'txtTribName
        '
        Me.txtTribName.Location = New System.Drawing.Point(57, 3)
        Me.txtTribName.Name = "txtTribName"
        Me.txtTribName.Size = New System.Drawing.Size(128, 20)
        Me.txtTribName.TabIndex = 2
        '
        'lblNick
        '
        Me.lblNick.AutoSize = True
        Me.lblNick.Location = New System.Drawing.Point(2, 32)
        Me.lblNick.Name = "lblNick"
        Me.lblNick.Size = New System.Drawing.Size(55, 13)
        Me.lblNick.TabIndex = 3
        Me.lblNick.Text = "Nickname"
        '
        'txtNick
        '
        Me.txtNick.Location = New System.Drawing.Point(57, 29)
        Me.txtNick.Name = "txtNick"
        Me.txtNick.Size = New System.Drawing.Size(128, 20)
        Me.txtNick.TabIndex = 4
        '
        'cbxGender
        '
        Me.cbxGender.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cbxGender.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxGender.FormattingEnabled = True
        Me.cbxGender.Items.AddRange(New Object() {"Male", "Female", "Neuter", "Plural"})
        Me.cbxGender.Location = New System.Drawing.Point(57, 55)
        Me.cbxGender.Name = "cbxGender"
        Me.cbxGender.Size = New System.Drawing.Size(121, 21)
        Me.cbxGender.TabIndex = 5
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(2, 58)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(42, 13)
        Me.lblGender.TabIndex = 6
        Me.lblGender.Text = "Gender"
        '
        'lblDeathPic
        '
        Me.lblDeathPic.AutoSize = True
        Me.lblDeathPic.Location = New System.Drawing.Point(2, 98)
        Me.lblDeathPic.Name = "lblDeathPic"
        Me.lblDeathPic.Size = New System.Drawing.Size(72, 13)
        Me.lblDeathPic.TabIndex = 7
        Me.lblDeathPic.Text = "Death Picture"
        '
        'radGrayscale
        '
        Me.radGrayscale.AutoSize = True
        Me.radGrayscale.Checked = True
        Me.radGrayscale.Location = New System.Drawing.Point(80, 96)
        Me.radGrayscale.Name = "radGrayscale"
        Me.radGrayscale.Size = New System.Drawing.Size(72, 17)
        Me.radGrayscale.TabIndex = 8
        Me.radGrayscale.TabStop = True
        Me.radGrayscale.Text = "Grayscale"
        Me.radGrayscale.UseVisualStyleBackColor = True
        '
        'radNorm
        '
        Me.radNorm.AutoSize = True
        Me.radNorm.Location = New System.Drawing.Point(80, 119)
        Me.radNorm.Name = "radNorm"
        Me.radNorm.Size = New System.Drawing.Size(58, 17)
        Me.radNorm.TabIndex = 9
        Me.radNorm.Text = "Normal"
        Me.radNorm.UseVisualStyleBackColor = True
        '
        'radXMark
        '
        Me.radXMark.AutoSize = True
        Me.radXMark.Location = New System.Drawing.Point(80, 142)
        Me.radXMark.Name = "radXMark"
        Me.radXMark.Size = New System.Drawing.Size(78, 17)
        Me.radXMark.TabIndex = 10
        Me.radXMark.Text = "Cross Mark"
        Me.radXMark.UseVisualStyleBackColor = True
        '
        'radCustom
        '
        Me.radCustom.AutoSize = True
        Me.radCustom.Location = New System.Drawing.Point(80, 165)
        Me.radCustom.Name = "radCustom"
        Me.radCustom.Size = New System.Drawing.Size(60, 17)
        Me.radCustom.TabIndex = 11
        Me.radCustom.Text = "Custom"
        Me.radCustom.UseVisualStyleBackColor = True
        '
        'picDeadTribute
        '
        Me.picDeadTribute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picDeadTribute.Location = New System.Drawing.Point(191, 99)
        Me.picDeadTribute.Name = "picDeadTribute"
        Me.picDeadTribute.Size = New System.Drawing.Size(90, 90)
        Me.picDeadTribute.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picDeadTribute.TabIndex = 12
        Me.picDeadTribute.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(53, 227)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 22)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(144, 227)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 22)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'ofdPicSelection
        '
        Me.ofdPicSelection.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG"
        '
        'lblTribPic
        '
        Me.lblTribPic.AutoSize = True
        Me.lblTribPic.Location = New System.Drawing.Point(209, 28)
        Me.lblTribPic.MaximumSize = New System.Drawing.Size(70, 0)
        Me.lblTribPic.Name = "lblTribPic"
        Me.lblTribPic.Size = New System.Drawing.Size(54, 39)
        Me.lblTribPic.TabIndex = 15
        Me.lblTribPic.Text = "Click to choose a picture"
        '
        'frmTribEdit
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picDeadTribute)
        Me.Controls.Add(Me.radCustom)
        Me.Controls.Add(Me.radXMark)
        Me.Controls.Add(Me.radNorm)
        Me.Controls.Add(Me.radGrayscale)
        Me.Controls.Add(Me.lblDeathPic)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.cbxGender)
        Me.Controls.Add(Me.txtNick)
        Me.Controls.Add(Me.lblNick)
        Me.Controls.Add(Me.txtTribName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblTribPic)
        Me.Controls.Add(Me.picTribute)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTribEdit"
        Me.Text = "Add new tribute"
        CType(Me.picTribute, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDeadTribute, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picTribute As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents txtTribName As TextBox
    Friend WithEvents lblNick As Label
    Friend WithEvents txtNick As TextBox
    Friend WithEvents cbxGender As ComboBox
    Friend WithEvents lblGender As Label
    Friend WithEvents lblDeathPic As Label
    Friend WithEvents radGrayscale As RadioButton
    Friend WithEvents radNorm As RadioButton
    Friend WithEvents radXMark As RadioButton
    Friend WithEvents radCustom As RadioButton
    Friend WithEvents picDeadTribute As PictureBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents ofdPicSelection As OpenFileDialog
    Friend WithEvents lblTribPic As Label
End Class
