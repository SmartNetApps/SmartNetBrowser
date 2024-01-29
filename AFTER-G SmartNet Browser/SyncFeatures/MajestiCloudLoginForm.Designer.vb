<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MajestiCloudLoginForm
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
        Me.UrlPanel = New System.Windows.Forms.Panel()
        Me.UrlLabel = New System.Windows.Forms.Label()
        Me.BrowserPanel = New System.Windows.Forms.Panel()
        Me.UrlPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'UrlPanel
        '
        Me.UrlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.UrlPanel.Controls.Add(Me.UrlLabel)
        Me.UrlPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.UrlPanel.Location = New System.Drawing.Point(0, 0)
        Me.UrlPanel.Name = "UrlPanel"
        Me.UrlPanel.Size = New System.Drawing.Size(704, 31)
        Me.UrlPanel.TabIndex = 0
        '
        'UrlLabel
        '
        Me.UrlLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UrlLabel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UrlLabel.Location = New System.Drawing.Point(0, 0)
        Me.UrlLabel.Name = "UrlLabel"
        Me.UrlLabel.Size = New System.Drawing.Size(704, 31)
        Me.UrlLabel.TabIndex = 0
        Me.UrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BrowserPanel
        '
        Me.BrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BrowserPanel.Location = New System.Drawing.Point(0, 31)
        Me.BrowserPanel.Name = "BrowserPanel"
        Me.BrowserPanel.Size = New System.Drawing.Size(704, 650)
        Me.BrowserPanel.TabIndex = 1
        '
        'MajestiCloudLoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 681)
        Me.Controls.Add(Me.BrowserPanel)
        Me.Controls.Add(Me.UrlPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MajestiCloudLoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Se connecter à MajestiCloud"
        Me.TopMost = True
        Me.UrlPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UrlPanel As Panel
    Friend WithEvents UrlLabel As Label
    Friend WithEvents BrowserPanel As Panel
End Class
