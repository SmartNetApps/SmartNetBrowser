<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadForm))
        Me.SaveAsButton = New System.Windows.Forms.Button()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FileNameLabel = New System.Windows.Forms.Label()
        Me.URLLabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SaveAsButton
        '
        resources.ApplyResources(Me.SaveAsButton, "SaveAsButton")
        Me.SaveAsButton.Name = "SaveAsButton"
        Me.SaveAsButton.UseVisualStyleBackColor = True
        '
        'AbortButton
        '
        resources.ApplyResources(Me.AbortButton, "AbortButton")
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'FileNameLabel
        '
        resources.ApplyResources(Me.FileNameLabel, "FileNameLabel")
        Me.FileNameLabel.Name = "FileNameLabel"
        '
        'URLLabel
        '
        resources.ApplyResources(Me.URLLabel, "URLLabel")
        Me.URLLabel.Name = "URLLabel"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'ProgressBar1
        '
        resources.ApplyResources(Me.ProgressBar1, "ProgressBar1")
        Me.ProgressBar1.Name = "ProgressBar1"
        '
        'SaveButton
        '
        resources.ApplyResources(Me.SaveButton, "SaveButton")
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'DownloadForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.URLLabel)
        Me.Controls.Add(Me.FileNameLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.SaveAsButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "DownloadForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SaveAsButton As Button
    Friend WithEvents AbortButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents FileNameLabel As Label
    Friend WithEvents URLLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents SaveButton As Button
End Class
