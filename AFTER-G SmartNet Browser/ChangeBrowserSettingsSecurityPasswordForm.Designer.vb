<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeBrowserSettingsSecurityPasswordForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeBrowserSettingsSecurityPasswordForm))
        Me.KeepCurrentSettingsButton = New System.Windows.Forms.Button()
        Me.SavePasswordButton = New System.Windows.Forms.Button()
        Me.NewPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.ActualPasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'KeepCurrentSettingsButton
        '
        resources.ApplyResources(Me.KeepCurrentSettingsButton, "KeepCurrentSettingsButton")
        Me.KeepCurrentSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.KeepCurrentSettingsButton.Name = "KeepCurrentSettingsButton"
        Me.KeepCurrentSettingsButton.UseVisualStyleBackColor = True
        '
        'SavePasswordButton
        '
        resources.ApplyResources(Me.SavePasswordButton, "SavePasswordButton")
        Me.SavePasswordButton.Name = "SavePasswordButton"
        Me.SavePasswordButton.UseVisualStyleBackColor = True
        '
        'NewPasswordTextBox
        '
        resources.ApplyResources(Me.NewPasswordTextBox, "NewPasswordTextBox")
        Me.NewPasswordTextBox.Name = "NewPasswordTextBox"
        Me.NewPasswordTextBox.UseSystemPasswordChar = True
        '
        'ActualPasswordTextBox
        '
        resources.ApplyResources(Me.ActualPasswordTextBox, "ActualPasswordTextBox")
        Me.ActualPasswordTextBox.Name = "ActualPasswordTextBox"
        Me.ActualPasswordTextBox.UseSystemPasswordChar = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ChangeBrowserSettingsSecurityPasswordForm
        '
        Me.AcceptButton = Me.SavePasswordButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.KeepCurrentSettingsButton
        Me.Controls.Add(Me.KeepCurrentSettingsButton)
        Me.Controls.Add(Me.SavePasswordButton)
        Me.Controls.Add(Me.NewPasswordTextBox)
        Me.Controls.Add(Me.ActualPasswordTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangeBrowserSettingsSecurityPasswordForm"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents KeepCurrentSettingsButton As Button
    Friend WithEvents SavePasswordButton As Button
    Friend WithEvents NewPasswordTextBox As TextBox
    Friend WithEvents ActualPasswordTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
