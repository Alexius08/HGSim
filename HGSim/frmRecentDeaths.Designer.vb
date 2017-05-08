<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecentDeaths
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
        Me.lblCasualtyCount = New System.Windows.Forms.Label()
        Me.pnlCasualtyList = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCasualtyCount
        '
        Me.lblCasualtyCount.Location = New System.Drawing.Point(5, 9)
        Me.lblCasualtyCount.Name = "lblCasualtyCount"
        Me.lblCasualtyCount.Size = New System.Drawing.Size(277, 15)
        Me.lblCasualtyCount.TabIndex = 0
        Me.lblCasualtyCount.Text = "cannon blasts can be heard in the distance."
        Me.lblCasualtyCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlCasualtyList
        '
        Me.pnlCasualtyList.AutoScroll = True
        Me.pnlCasualtyList.Location = New System.Drawing.Point(0, 27)
        Me.pnlCasualtyList.Name = "pnlCasualtyList"
        Me.pnlCasualtyList.Size = New System.Drawing.Size(282, 203)
        Me.pnlCasualtyList.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(99, 236)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmRecentDeaths
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pnlCasualtyList)
        Me.Controls.Add(Me.lblCasualtyCount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRecentDeaths"
        Me.Text = "Recent Deaths"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblCasualtyCount As Label
    Friend WithEvents pnlCasualtyList As Panel
    Friend WithEvents btnOK As Button
End Class
