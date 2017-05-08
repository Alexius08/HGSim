<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.chkArenaEvent = New System.Windows.Forms.CheckBox()
        Me.lblKillRate = New System.Windows.Forms.Label()
        Me.cbxKillRate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxDefEvent = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkRecentDeaths = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkArenaEvent
        '
        Me.chkArenaEvent.AutoSize = True
        Me.chkArenaEvent.Checked = True
        Me.chkArenaEvent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkArenaEvent.Location = New System.Drawing.Point(12, 59)
        Me.chkArenaEvent.Name = "chkArenaEvent"
        Me.chkArenaEvent.Size = New System.Drawing.Size(124, 17)
        Me.chkArenaEvent.TabIndex = 2
        Me.chkArenaEvent.Text = "Enable arena events"
        Me.chkArenaEvent.UseVisualStyleBackColor = True
        '
        'lblKillRate
        '
        Me.lblKillRate.AutoSize = True
        Me.lblKillRate.Location = New System.Drawing.Point(6, 9)
        Me.lblKillRate.Name = "lblKillRate"
        Me.lblKillRate.Size = New System.Drawing.Size(117, 13)
        Me.lblKillRate.TabIndex = 1
        Me.lblKillRate.Text = "Fatal Event Frequency:"
        '
        'cbxKillRate
        '
        Me.cbxKillRate.FormattingEnabled = True
        Me.cbxKillRate.Items.AddRange(New Object() {"Very High", "High", "Medium", "Low"})
        Me.cbxKillRate.Location = New System.Drawing.Point(192, 6)
        Me.cbxKillRate.Name = "cbxKillRate"
        Me.cbxKillRate.Size = New System.Drawing.Size(70, 21)
        Me.cbxKillRate.TabIndex = 0
        Me.cbxKillRate.Text = "High"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(183, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bloodbath/Feast Default Event Rate:"
        '
        'cbxDefEvent
        '
        Me.cbxDefEvent.FormattingEnabled = True
        Me.cbxDefEvent.Items.AddRange(New Object() {"Normal", "Reduced"})
        Me.cbxDefEvent.Location = New System.Drawing.Point(192, 32)
        Me.cbxDefEvent.Name = "cbxDefEvent"
        Me.cbxDefEvent.Size = New System.Drawing.Size(70, 21)
        Me.cbxDefEvent.TabIndex = 1
        Me.cbxDefEvent.Text = "Normal"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(65, 82)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(53, 26)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(136, 82)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(53, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkRecentDeaths
        '
        Me.chkRecentDeaths.AutoSize = True
        Me.chkRecentDeaths.Checked = True
        Me.chkRecentDeaths.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecentDeaths.Location = New System.Drawing.Point(151, 59)
        Me.chkRecentDeaths.Name = "chkRecentDeaths"
        Me.chkRecentDeaths.Size = New System.Drawing.Size(121, 17)
        Me.chkRecentDeaths.TabIndex = 6
        Me.chkRecentDeaths.Text = "Show recent deaths"
        Me.chkRecentDeaths.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 118)
        Me.Controls.Add(Me.chkRecentDeaths)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbxDefEvent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxKillRate)
        Me.Controls.Add(Me.lblKillRate)
        Me.Controls.Add(Me.chkArenaEvent)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkArenaEvent As CheckBox
    Friend WithEvents lblKillRate As Label
    Friend WithEvents cbxKillRate As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxDefEvent As ComboBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkRecentDeaths As CheckBox
End Class
