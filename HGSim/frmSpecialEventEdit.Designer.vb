<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSpecialEventEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tabArenaEventOutcome = New System.Windows.Forms.TabControl()
        Me.tabNonFatal = New System.Windows.Forms.TabPage()
        Me.tabFatalEvent1 = New System.Windows.Forms.TabPage()
        Me.tabFatalEvent2 = New System.Windows.Forms.TabPage()
        Me.tabFatalEvent3 = New System.Windows.Forms.TabPage()
        Me.tabFatalEvent4 = New System.Windows.Forms.TabPage()
        Me.tabFatalEvent5 = New System.Windows.Forms.TabPage()
        Me.lblEventIntro = New System.Windows.Forms.Label()
        Me.txtEventIntro = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tabArenaEventOutcome.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabArenaEventOutcome
        '
        Me.tabArenaEventOutcome.Controls.Add(Me.tabNonFatal)
        Me.tabArenaEventOutcome.Controls.Add(Me.tabFatalEvent1)
        Me.tabArenaEventOutcome.Controls.Add(Me.tabFatalEvent2)
        Me.tabArenaEventOutcome.Controls.Add(Me.tabFatalEvent3)
        Me.tabArenaEventOutcome.Controls.Add(Me.tabFatalEvent4)
        Me.tabArenaEventOutcome.Controls.Add(Me.tabFatalEvent5)
        Me.tabArenaEventOutcome.Location = New System.Drawing.Point(12, 36)
        Me.tabArenaEventOutcome.Name = "tabArenaEventOutcome"
        Me.tabArenaEventOutcome.SelectedIndex = 0
        Me.tabArenaEventOutcome.Size = New System.Drawing.Size(580, 270)
        Me.tabArenaEventOutcome.TabIndex = 0
        '
        'tabNonFatal
        '
        Me.tabNonFatal.Location = New System.Drawing.Point(4, 22)
        Me.tabNonFatal.Name = "tabNonFatal"
        Me.tabNonFatal.Padding = New System.Windows.Forms.Padding(3)
        Me.tabNonFatal.Size = New System.Drawing.Size(572, 244)
        Me.tabNonFatal.TabIndex = 0
        Me.tabNonFatal.Text = "Non-Fatal Event"
        Me.tabNonFatal.UseVisualStyleBackColor = True
        '
        'tabFatalEvent1
        '
        Me.tabFatalEvent1.Location = New System.Drawing.Point(4, 22)
        Me.tabFatalEvent1.Name = "tabFatalEvent1"
        Me.tabFatalEvent1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFatalEvent1.Size = New System.Drawing.Size(572, 244)
        Me.tabFatalEvent1.TabIndex = 1
        Me.tabFatalEvent1.Text = "Fatal Event 1"
        Me.tabFatalEvent1.UseVisualStyleBackColor = True
        '
        'tabFatalEvent2
        '
        Me.tabFatalEvent2.AutoScroll = True
        Me.tabFatalEvent2.Location = New System.Drawing.Point(4, 22)
        Me.tabFatalEvent2.Name = "tabFatalEvent2"
        Me.tabFatalEvent2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFatalEvent2.Size = New System.Drawing.Size(572, 244)
        Me.tabFatalEvent2.TabIndex = 2
        Me.tabFatalEvent2.Text = "Fatal Event 2"
        Me.tabFatalEvent2.UseVisualStyleBackColor = True
        '
        'tabFatalEvent3
        '
        Me.tabFatalEvent3.AutoScroll = True
        Me.tabFatalEvent3.Location = New System.Drawing.Point(4, 22)
        Me.tabFatalEvent3.Name = "tabFatalEvent3"
        Me.tabFatalEvent3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFatalEvent3.Size = New System.Drawing.Size(572, 244)
        Me.tabFatalEvent3.TabIndex = 3
        Me.tabFatalEvent3.Text = "Fatal Event 3"
        Me.tabFatalEvent3.UseVisualStyleBackColor = True
        '
        'tabFatalEvent4
        '
        Me.tabFatalEvent4.AutoScroll = True
        Me.tabFatalEvent4.Location = New System.Drawing.Point(4, 22)
        Me.tabFatalEvent4.Name = "tabFatalEvent4"
        Me.tabFatalEvent4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFatalEvent4.Size = New System.Drawing.Size(572, 244)
        Me.tabFatalEvent4.TabIndex = 4
        Me.tabFatalEvent4.Text = "Fatal Event 4"
        Me.tabFatalEvent4.UseVisualStyleBackColor = True
        '
        'tabFatalEvent5
        '
        Me.tabFatalEvent5.AutoScroll = True
        Me.tabFatalEvent5.Location = New System.Drawing.Point(4, 22)
        Me.tabFatalEvent5.Name = "tabFatalEvent5"
        Me.tabFatalEvent5.Size = New System.Drawing.Size(572, 244)
        Me.tabFatalEvent5.TabIndex = 5
        Me.tabFatalEvent5.Text = "Fatal Event 5"
        Me.tabFatalEvent5.UseVisualStyleBackColor = True
        '
        'lblEventIntro
        '
        Me.lblEventIntro.AutoSize = True
        Me.lblEventIntro.Location = New System.Drawing.Point(13, 9)
        Me.lblEventIntro.Name = "lblEventIntro"
        Me.lblEventIntro.Size = New System.Drawing.Size(96, 13)
        Me.lblEventIntro.TabIndex = 1
        Me.lblEventIntro.Text = "Event introduction:"
        '
        'txtEventIntro
        '
        Me.txtEventIntro.Location = New System.Drawing.Point(115, 6)
        Me.txtEventIntro.Name = "txtEventIntro"
        Me.txtEventIntro.Size = New System.Drawing.Size(473, 20)
        Me.txtEventIntro.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(214, 312)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(319, 312)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 24)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmSpecialEventEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 348)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtEventIntro)
        Me.Controls.Add(Me.lblEventIntro)
        Me.Controls.Add(Me.tabArenaEventOutcome)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSpecialEventEdit"
        Me.Text = "Add new arena event"
        Me.tabArenaEventOutcome.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tabArenaEventOutcome As TabControl
    Friend WithEvents tabNonFatal As TabPage
    Friend WithEvents tabFatalEvent1 As TabPage
    Friend WithEvents tabFatalEvent2 As TabPage
    Friend WithEvents tabFatalEvent3 As TabPage
    Friend WithEvents tabFatalEvent4 As TabPage
    Friend WithEvents tabFatalEvent5 As TabPage
    Friend WithEvents lblEventIntro As Label
    Friend WithEvents txtEventIntro As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
