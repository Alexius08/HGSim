<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArena
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
        Me.pnlRounds = New System.Windows.Forms.Panel()
        Me.pnlEventDisplay = New System.Windows.Forms.Panel()
        Me.lblRoundDesc = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnShowScore = New System.Windows.Forms.Button()
        Me.btnSkipToEnd = New System.Windows.Forms.Button()
        Me.pnlEventDisplay.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlRounds
        '
        Me.pnlRounds.AutoScroll = True
        Me.pnlRounds.Location = New System.Drawing.Point(12, 12)
        Me.pnlRounds.Name = "pnlRounds"
        Me.pnlRounds.Size = New System.Drawing.Size(124, 255)
        Me.pnlRounds.TabIndex = 1
        '
        'pnlEventDisplay
        '
        Me.pnlEventDisplay.AutoScroll = True
        Me.pnlEventDisplay.Controls.Add(Me.lblRoundDesc)
        Me.pnlEventDisplay.Location = New System.Drawing.Point(151, 12)
        Me.pnlEventDisplay.Name = "pnlEventDisplay"
        Me.pnlEventDisplay.Size = New System.Drawing.Size(673, 255)
        Me.pnlEventDisplay.TabIndex = 2
        '
        'lblRoundDesc
        '
        Me.lblRoundDesc.AutoSize = True
        Me.lblRoundDesc.Location = New System.Drawing.Point(159, 0)
        Me.lblRoundDesc.Name = "lblRoundDesc"
        Me.lblRoundDesc.Size = New System.Drawing.Size(268, 13)
        Me.lblRoundDesc.TabIndex = 0
        Me.lblRoundDesc.Text = "As the tributes stand on their podiums, the horn sounds."
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(480, 286)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(98, 29)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Enabled = False
        Me.btnPrev.Location = New System.Drawing.Point(350, 286)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(98, 29)
        Me.btnPrev.TabIndex = 4
        Me.btnPrev.Text = "Previous"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnShowScore
        '
        Me.btnShowScore.Location = New System.Drawing.Point(12, 286)
        Me.btnShowScore.Name = "btnShowScore"
        Me.btnShowScore.Size = New System.Drawing.Size(124, 29)
        Me.btnShowScore.TabIndex = 5
        Me.btnShowScore.Text = "Show Current Score"
        Me.btnShowScore.UseVisualStyleBackColor = True
        '
        'btnSkipToEnd
        '
        Me.btnSkipToEnd.Location = New System.Drawing.Point(633, 286)
        Me.btnSkipToEnd.Name = "btnSkipToEnd"
        Me.btnSkipToEnd.Size = New System.Drawing.Size(98, 29)
        Me.btnSkipToEnd.TabIndex = 6
        Me.btnSkipToEnd.Text = "Skip to End"
        Me.btnSkipToEnd.UseVisualStyleBackColor = True
        '
        'frmArena
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 356)
        Me.Controls.Add(Me.btnSkipToEnd)
        Me.Controls.Add(Me.btnShowScore)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.pnlEventDisplay)
        Me.Controls.Add(Me.pnlRounds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmArena"
        Me.Text = "The Arena"
        Me.pnlEventDisplay.ResumeLayout(False)
        Me.pnlEventDisplay.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlRounds As Panel
    Friend WithEvents pnlEventDisplay As Panel
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents lblRoundDesc As Label
    Friend WithEvents btnShowScore As Button
    Friend WithEvents btnSkipToEnd As Button
End Class
