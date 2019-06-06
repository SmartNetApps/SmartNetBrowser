<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreventTabsCloseForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PreventTabsCloseForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DontAskAgainCheckBox = New System.Windows.Forms.CheckBox()
        Me.CloseTabsButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'DontAskAgainCheckBox
        '
        resources.ApplyResources(Me.DontAskAgainCheckBox, "DontAskAgainCheckBox")
        Me.DontAskAgainCheckBox.Name = "DontAskAgainCheckBox"
        Me.DontAskAgainCheckBox.UseVisualStyleBackColor = True
        '
        'CloseTabsButton
        '
        resources.ApplyResources(Me.CloseTabsButton, "CloseTabsButton")
        Me.CloseTabsButton.Name = "CloseTabsButton"
        Me.CloseTabsButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'PreventTabsCloseForm
        '
        Me.AcceptButton = Me.CloseTabsButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.CloseTabsButton)
        Me.Controls.Add(Me.DontAskAgainCheckBox)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PreventTabsCloseForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DontAskAgainCheckBox As CheckBox
    Friend WithEvents CloseTabsButton As Button
    Friend WithEvents CloseButton As Button
End Class
