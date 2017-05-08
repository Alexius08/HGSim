<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStats
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
        Me.picTribPic = New System.Windows.Forms.PictureBox()
        Me.lbxTribList = New System.Windows.Forms.ListBox()
        Me.lblTribName = New System.Windows.Forms.Label()
        Me.lblStatDesc = New System.Windows.Forms.Label()
        Me.lblTribStats = New System.Windows.Forms.Label()
        Me.btnResetStats = New System.Windows.Forms.Button()
        Me.btnResetTribs = New System.Windows.Forms.Button()
        Me.btnSelectTribute = New System.Windows.Forms.Button()
        CType(Me.picTribPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picTribPic
        '
        Me.picTribPic.Location = New System.Drawing.Point(21, 12)
        Me.picTribPic.Name = "picTribPic"
        Me.picTribPic.Size = New System.Drawing.Size(90, 90)
        Me.picTribPic.TabIndex = 0
        Me.picTribPic.TabStop = False
        '
        'lbxTribList
        '
        Me.lbxTribList.FormattingEnabled = True
        Me.lbxTribList.Location = New System.Drawing.Point(12, 154)
        Me.lbxTribList.Name = "lbxTribList"
        Me.lbxTribList.Size = New System.Drawing.Size(147, 95)
        Me.lbxTribList.TabIndex = 1
        '
        'lblTribName
        '
        Me.lblTribName.Location = New System.Drawing.Point(-1, 105)
        Me.lblTribName.Name = "lblTribName"
        Me.lblTribName.Size = New System.Drawing.Size(135, 14)
        Me.lblTribName.TabIndex = 2
        Me.lblTribName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStatDesc
        '
        Me.lblStatDesc.AutoSize = True
        Me.lblStatDesc.Location = New System.Drawing.Point(140, 12)
        Me.lblStatDesc.Name = "lblStatDesc"
        Me.lblStatDesc.Size = New System.Drawing.Size(80, 130)
        Me.lblStatDesc.TabIndex = 3
        Me.lblStatDesc.Text = "Wins" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "KILLS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Solo Kills" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Shared Kills" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DEATHS" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Combat Deaths" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Suicides" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Other" &
    " Deaths"
        '
        'lblTribStats
        '
        Me.lblTribStats.Location = New System.Drawing.Point(242, 12)
        Me.lblTribStats.Name = "lblTribStats"
        Me.lblTribStats.Size = New System.Drawing.Size(30, 130)
        Me.lblTribStats.TabIndex = 4
        Me.lblTribStats.Text = "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblTribStats.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnResetStats
        '
        Me.btnResetStats.Location = New System.Drawing.Point(180, 200)
        Me.btnResetStats.Name = "btnResetStats"
        Me.btnResetStats.Size = New System.Drawing.Size(92, 21)
        Me.btnResetStats.TabIndex = 5
        Me.btnResetStats.Text = "Reset Stats"
        Me.btnResetStats.UseVisualStyleBackColor = True
        '
        'btnResetTribs
        '
        Me.btnResetTribs.Location = New System.Drawing.Point(180, 227)
        Me.btnResetTribs.Name = "btnResetTribs"
        Me.btnResetTribs.Size = New System.Drawing.Size(92, 22)
        Me.btnResetTribs.TabIndex = 6
        Me.btnResetTribs.Text = "Reset Tributes"
        Me.btnResetTribs.UseVisualStyleBackColor = True
        '
        'btnSelectTribute
        '
        Me.btnSelectTribute.Enabled = False
        Me.btnSelectTribute.Location = New System.Drawing.Point(180, 160)
        Me.btnSelectTribute.Name = "btnSelectTribute"
        Me.btnSelectTribute.Size = New System.Drawing.Size(96, 34)
        Me.btnSelectTribute.TabIndex = 7
        Me.btnSelectTribute.Text = "Select Tribute"
        Me.btnSelectTribute.UseVisualStyleBackColor = True
        Me.btnSelectTribute.Visible = False
        '
        'frmStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnSelectTribute)
        Me.Controls.Add(Me.btnResetTribs)
        Me.Controls.Add(Me.btnResetStats)
        Me.Controls.Add(Me.lblTribStats)
        Me.Controls.Add(Me.lblStatDesc)
        Me.Controls.Add(Me.lblTribName)
        Me.Controls.Add(Me.lbxTribList)
        Me.Controls.Add(Me.picTribPic)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmStats"
        Me.Text = "Statistics"
        CType(Me.picTribPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picTribPic As PictureBox
    Friend WithEvents lbxTribList As ListBox
    Friend WithEvents lblTribName As Label
    Friend WithEvents lblStatDesc As Label
    Friend WithEvents lblTribStats As Label
    Friend WithEvents btnResetStats As Button
    Friend WithEvents btnResetTribs As Button
    Friend WithEvents btnSelectTribute As Button
End Class
