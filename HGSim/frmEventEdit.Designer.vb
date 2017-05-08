<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEventEdit
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
        Me.lblEventText = New System.Windows.Forms.Label()
        Me.txtEventText = New System.Windows.Forms.TextBox()
        Me.lblEventTribCount = New System.Windows.Forms.Label()
        Me.nudTribCount = New System.Windows.Forms.NumericUpDown()
        Me.clbEventScope = New System.Windows.Forms.CheckedListBox()
        Me.lblEventScope = New System.Windows.Forms.Label()
        Me.lblIsKiller = New System.Windows.Forms.Label()
        Me.lblIsKilled = New System.Windows.Forms.Label()
        Me.lblDeathType = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.chkIsKillShared = New System.Windows.Forms.CheckBox()
        CType(Me.nudTribCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEventText
        '
        Me.lblEventText.AutoSize = True
        Me.lblEventText.Location = New System.Drawing.Point(12, 25)
        Me.lblEventText.Name = "lblEventText"
        Me.lblEventText.Size = New System.Drawing.Size(58, 13)
        Me.lblEventText.TabIndex = 0
        Me.lblEventText.Text = "Event text:"
        '
        'txtEventText
        '
        Me.txtEventText.Location = New System.Drawing.Point(76, 6)
        Me.txtEventText.Multiline = True
        Me.txtEventText.Name = "txtEventText"
        Me.txtEventText.Size = New System.Drawing.Size(278, 57)
        Me.txtEventText.TabIndex = 1
        '
        'lblEventTribCount
        '
        Me.lblEventTribCount.AutoSize = True
        Me.lblEventTribCount.Location = New System.Drawing.Point(47, 71)
        Me.lblEventTribCount.Name = "lblEventTribCount"
        Me.lblEventTribCount.Size = New System.Drawing.Size(139, 13)
        Me.lblEventTribCount.TabIndex = 2
        Me.lblEventTribCount.Text = "Number of tributes involved:"
        '
        'nudTribCount
        '
        Me.nudTribCount.Location = New System.Drawing.Point(192, 69)
        Me.nudTribCount.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.nudTribCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTribCount.Name = "nudTribCount"
        Me.nudTribCount.Size = New System.Drawing.Size(36, 20)
        Me.nudTribCount.TabIndex = 3
        Me.nudTribCount.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'clbEventScope
        '
        Me.clbEventScope.FormattingEnabled = True
        Me.clbEventScope.Items.AddRange(New Object() {"Bloodbath", "Day", "Night", "Feast"})
        Me.clbEventScope.Location = New System.Drawing.Point(360, 25)
        Me.clbEventScope.Name = "clbEventScope"
        Me.clbEventScope.Size = New System.Drawing.Size(77, 64)
        Me.clbEventScope.TabIndex = 4
        '
        'lblEventScope
        '
        Me.lblEventScope.AutoSize = True
        Me.lblEventScope.Location = New System.Drawing.Point(360, 9)
        Me.lblEventScope.Name = "lblEventScope"
        Me.lblEventScope.Size = New System.Drawing.Size(67, 13)
        Me.lblEventScope.TabIndex = 5
        Me.lblEventScope.Text = "Event scope"
        '
        'lblIsKiller
        '
        Me.lblIsKiller.AutoSize = True
        Me.lblIsKiller.Location = New System.Drawing.Point(125, 103)
        Me.lblIsKiller.Name = "lblIsKiller"
        Me.lblIsKiller.Size = New System.Drawing.Size(45, 13)
        Me.lblIsKiller.TabIndex = 6
        Me.lblIsKiller.Text = "Is killer?"
        '
        'lblIsKilled
        '
        Me.lblIsKilled.AutoSize = True
        Me.lblIsKilled.Location = New System.Drawing.Point(189, 103)
        Me.lblIsKilled.Name = "lblIsKilled"
        Me.lblIsKilled.Size = New System.Drawing.Size(48, 13)
        Me.lblIsKilled.TabIndex = 7
        Me.lblIsKilled.Text = "Is killed?"
        '
        'lblDeathType
        '
        Me.lblDeathType.AutoSize = True
        Me.lblDeathType.Location = New System.Drawing.Point(336, 103)
        Me.lblDeathType.Name = "lblDeathType"
        Me.lblDeathType.Size = New System.Drawing.Size(63, 13)
        Me.lblDeathType.TabIndex = 8
        Me.lblDeathType.Text = "Death Type"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(128, 274)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(82, 20)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(233, 274)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(82, 20)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkIsKillShared
        '
        Me.chkIsKillShared.AutoSize = True
        Me.chkIsKillShared.Enabled = False
        Me.chkIsKillShared.Location = New System.Drawing.Point(251, 72)
        Me.chkIsKillShared.Name = "chkIsKillShared"
        Me.chkIsKillShared.Size = New System.Drawing.Size(90, 17)
        Me.chkIsKillShared.TabIndex = 11
        Me.chkIsKillShared.Text = "Is kill shared?"
        Me.chkIsKillShared.UseVisualStyleBackColor = True
        '
        'frmEventEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 328)
        Me.Controls.Add(Me.chkIsKillShared)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblDeathType)
        Me.Controls.Add(Me.lblIsKilled)
        Me.Controls.Add(Me.lblIsKiller)
        Me.Controls.Add(Me.lblEventScope)
        Me.Controls.Add(Me.clbEventScope)
        Me.Controls.Add(Me.nudTribCount)
        Me.Controls.Add(Me.lblEventTribCount)
        Me.Controls.Add(Me.txtEventText)
        Me.Controls.Add(Me.lblEventText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmEventEdit"
        Me.Text = "Add new event"
        CType(Me.nudTribCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEventText As Label
    Friend WithEvents txtEventText As TextBox
    Friend WithEvents lblEventTribCount As Label
    Friend WithEvents nudTribCount As NumericUpDown
    Friend WithEvents clbEventScope As CheckedListBox
    Friend WithEvents lblEventScope As Label
    Friend WithEvents lblIsKiller As Label
    Friend WithEvents lblIsKilled As Label
    Friend WithEvents lblDeathType As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkIsKillShared As CheckBox
End Class
