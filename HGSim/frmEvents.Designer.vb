<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEvents
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
        Me.lbxEventList = New System.Windows.Forms.ListBox()
        Me.lblEventDesc = New System.Windows.Forms.Label()
        Me.lbxSpecialArenaEvents = New System.Windows.Forms.ListBox()
        Me.lbxSpecialArenaEventOutcome = New System.Windows.Forms.ListBox()
        Me.btnAddNewEvent = New System.Windows.Forms.Button()
        Me.btnRmEvent = New System.Windows.Forms.Button()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.btmAddNewArenaEvent = New System.Windows.Forms.Button()
        Me.btnRemoveArenaEvent = New System.Windows.Forms.Button()
        Me.btnRestoreDefaultSets = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbxEventList
        '
        Me.lbxEventList.FormattingEnabled = True
        Me.lbxEventList.Location = New System.Drawing.Point(27, 12)
        Me.lbxEventList.Name = "lbxEventList"
        Me.lbxEventList.Size = New System.Drawing.Size(531, 95)
        Me.lbxEventList.TabIndex = 0
        '
        'lblEventDesc
        '
        Me.lblEventDesc.AutoSize = True
        Me.lblEventDesc.Location = New System.Drawing.Point(24, 126)
        Me.lblEventDesc.Name = "lblEventDesc"
        Me.lblEventDesc.Size = New System.Drawing.Size(233, 13)
        Me.lblEventDesc.TabIndex = 1
        Me.lblEventDesc.Text = "Click on an event in the list to see its description"
        '
        'lbxSpecialArenaEvents
        '
        Me.lbxSpecialArenaEvents.FormattingEnabled = True
        Me.lbxSpecialArenaEvents.Location = New System.Drawing.Point(27, 201)
        Me.lbxSpecialArenaEvents.Name = "lbxSpecialArenaEvents"
        Me.lbxSpecialArenaEvents.Size = New System.Drawing.Size(414, 56)
        Me.lbxSpecialArenaEvents.TabIndex = 2
        '
        'lbxSpecialArenaEventOutcome
        '
        Me.lbxSpecialArenaEventOutcome.FormattingEnabled = True
        Me.lbxSpecialArenaEventOutcome.Location = New System.Drawing.Point(457, 201)
        Me.lbxSpecialArenaEventOutcome.Name = "lbxSpecialArenaEventOutcome"
        Me.lbxSpecialArenaEventOutcome.Size = New System.Drawing.Size(187, 56)
        Me.lbxSpecialArenaEventOutcome.TabIndex = 3
        '
        'btnAddNewEvent
        '
        Me.btnAddNewEvent.Location = New System.Drawing.Point(564, 12)
        Me.btnAddNewEvent.Name = "btnAddNewEvent"
        Me.btnAddNewEvent.Size = New System.Drawing.Size(102, 27)
        Me.btnAddNewEvent.TabIndex = 4
        Me.btnAddNewEvent.Text = "Add new event"
        Me.btnAddNewEvent.UseVisualStyleBackColor = True
        '
        'btnRmEvent
        '
        Me.btnRmEvent.Location = New System.Drawing.Point(564, 45)
        Me.btnRmEvent.Name = "btnRmEvent"
        Me.btnRmEvent.Size = New System.Drawing.Size(102, 27)
        Me.btnRmEvent.TabIndex = 5
        Me.btnRmEvent.Text = "Remove selected"
        Me.btnRmEvent.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaults
        '
        Me.btnRestoreDefaults.Location = New System.Drawing.Point(564, 78)
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.Size = New System.Drawing.Size(102, 27)
        Me.btnRestoreDefaults.TabIndex = 6
        Me.btnRestoreDefaults.Text = "Restore defaults"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = True
        '
        'btmAddNewArenaEvent
        '
        Me.btmAddNewArenaEvent.Location = New System.Drawing.Point(27, 263)
        Me.btmAddNewArenaEvent.Name = "btmAddNewArenaEvent"
        Me.btmAddNewArenaEvent.Size = New System.Drawing.Size(132, 27)
        Me.btmAddNewArenaEvent.TabIndex = 7
        Me.btmAddNewArenaEvent.Text = "Add new arena event"
        Me.btmAddNewArenaEvent.UseVisualStyleBackColor = True
        '
        'btnRemoveArenaEvent
        '
        Me.btnRemoveArenaEvent.Location = New System.Drawing.Point(165, 263)
        Me.btnRemoveArenaEvent.Name = "btnRemoveArenaEvent"
        Me.btnRemoveArenaEvent.Size = New System.Drawing.Size(132, 27)
        Me.btnRemoveArenaEvent.TabIndex = 8
        Me.btnRemoveArenaEvent.Text = "Remove selected"
        Me.btnRemoveArenaEvent.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaultSets
        '
        Me.btnRestoreDefaultSets.Location = New System.Drawing.Point(303, 263)
        Me.btnRestoreDefaultSets.Name = "btnRestoreDefaultSets"
        Me.btnRestoreDefaultSets.Size = New System.Drawing.Size(132, 27)
        Me.btnRestoreDefaultSets.TabIndex = 9
        Me.btnRestoreDefaultSets.Text = "Restore defaults"
        Me.btnRestoreDefaultSets.UseVisualStyleBackColor = True
        '
        'frmEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 334)
        Me.Controls.Add(Me.btnRestoreDefaultSets)
        Me.Controls.Add(Me.btnRemoveArenaEvent)
        Me.Controls.Add(Me.btmAddNewArenaEvent)
        Me.Controls.Add(Me.btnRestoreDefaults)
        Me.Controls.Add(Me.btnRmEvent)
        Me.Controls.Add(Me.btnAddNewEvent)
        Me.Controls.Add(Me.lbxSpecialArenaEventOutcome)
        Me.Controls.Add(Me.lbxSpecialArenaEvents)
        Me.Controls.Add(Me.lblEventDesc)
        Me.Controls.Add(Me.lbxEventList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmEvents"
        Me.Text = "Event List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbxEventList As ListBox
    Friend WithEvents lblEventDesc As Label
    Friend WithEvents lbxSpecialArenaEvents As ListBox
    Friend WithEvents lbxSpecialArenaEventOutcome As ListBox
    Friend WithEvents btnAddNewEvent As Button
    Friend WithEvents btnRmEvent As Button
    Friend WithEvents btnRestoreDefaults As Button
    Friend WithEvents btmAddNewArenaEvent As Button
    Friend WithEvents btnRemoveArenaEvent As Button
    Friend WithEvents btnRestoreDefaultSets As Button
End Class
