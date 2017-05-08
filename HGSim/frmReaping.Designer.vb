<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReaping
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
        Me.lblTribNumSel = New System.Windows.Forms.Label()
        Me.nudTribNumSel = New System.Windows.Forms.NumericUpDown()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.pnlReaping = New System.Windows.Forms.Panel()
        CType(Me.nudTribNumSel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTribNumSel
        '
        Me.lblTribNumSel.AutoSize = True
        Me.lblTribNumSel.Location = New System.Drawing.Point(3, 9)
        Me.lblTribNumSel.Name = "lblTribNumSel"
        Me.lblTribNumSel.Size = New System.Drawing.Size(127, 13)
        Me.lblTribNumSel.TabIndex = 0
        Me.lblTribNumSel.Text = "Select number of tributes:"
        '
        'nudTribNumSel
        '
        Me.nudTribNumSel.Increment = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudTribNumSel.Location = New System.Drawing.Point(136, 7)
        Me.nudTribNumSel.Maximum = New Decimal(New Integer() {48, 0, 0, 0})
        Me.nudTribNumSel.Minimum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.nudTribNumSel.Name = "nudTribNumSel"
        Me.nudTribNumSel.Size = New System.Drawing.Size(59, 20)
        Me.nudTribNumSel.TabIndex = 1
        Me.nudTribNumSel.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(222, 310)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(75, 23)
        Me.btnGo.TabIndex = 2
        Me.btnGo.Text = "Preview"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(303, 310)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Cancel"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'pnlReaping
        '
        Me.pnlReaping.AutoScroll = True
        Me.pnlReaping.Location = New System.Drawing.Point(6, 7)
        Me.pnlReaping.Name = "pnlReaping"
        Me.pnlReaping.Size = New System.Drawing.Size(643, 306)
        Me.pnlReaping.TabIndex = 4
        Me.pnlReaping.Visible = False
        '
        'frmReaping
        '
        Me.AcceptButton = Me.btnGo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(761, 349)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.nudTribNumSel)
        Me.Controls.Add(Me.lblTribNumSel)
        Me.Controls.Add(Me.pnlReaping)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmReaping"
        Me.Text = "Select Tributes"
        CType(Me.nudTribNumSel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTribNumSel As Label
    Friend WithEvents nudTribNumSel As NumericUpDown
    Friend WithEvents btnGo As Button
    Friend WithEvents btnStop As Button
    Friend WithEvents pnlReaping As Panel
End Class
