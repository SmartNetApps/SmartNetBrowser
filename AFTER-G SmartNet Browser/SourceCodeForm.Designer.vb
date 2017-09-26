<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SourceCodeForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SourceCodeForm))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagePrécédenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.FermerLaFenêtreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÉditionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÀProposDeSmartNetBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeckoWebBrowser1 = New Gecko.GeckoWebBrowser()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 25
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.ÉditionToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        resources.ApplyResources(Me.FichierToolStripMenuItem, "FichierToolStripMenuItem")
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PagePrécédenteToolStripMenuItem, Me.ToolStripSeparator1, Me.FermerLaFenêtreToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        '
        'PagePrécédenteToolStripMenuItem
        '
        resources.ApplyResources(Me.PagePrécédenteToolStripMenuItem, "PagePrécédenteToolStripMenuItem")
        Me.PagePrécédenteToolStripMenuItem.Name = "PagePrécédenteToolStripMenuItem"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'FermerLaFenêtreToolStripMenuItem
        '
        resources.ApplyResources(Me.FermerLaFenêtreToolStripMenuItem, "FermerLaFenêtreToolStripMenuItem")
        Me.FermerLaFenêtreToolStripMenuItem.Name = "FermerLaFenêtreToolStripMenuItem"
        '
        'ÉditionToolStripMenuItem
        '
        resources.ApplyResources(Me.ÉditionToolStripMenuItem, "ÉditionToolStripMenuItem")
        Me.ÉditionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopierToolStripMenuItem})
        Me.ÉditionToolStripMenuItem.Name = "ÉditionToolStripMenuItem"
        '
        'CopierToolStripMenuItem
        '
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÀProposDeSmartNetBrowserToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'ÀProposDeSmartNetBrowserToolStripMenuItem
        '
        resources.ApplyResources(Me.ÀProposDeSmartNetBrowserToolStripMenuItem, "ÀProposDeSmartNetBrowserToolStripMenuItem")
        Me.ÀProposDeSmartNetBrowserToolStripMenuItem.Name = "ÀProposDeSmartNetBrowserToolStripMenuItem"
        '
        'GeckoWebBrowser1
        '
        resources.ApplyResources(Me.GeckoWebBrowser1, "GeckoWebBrowser1")
        Me.GeckoWebBrowser1.FrameEventsPropagateToMainWindow = False
        Me.GeckoWebBrowser1.Name = "GeckoWebBrowser1"
        Me.GeckoWebBrowser1.UseHttpActivityObserver = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'SourceCodeForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GeckoWebBrowser1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "SourceCodeForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FermerLaFenêtreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÉditionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ÀProposDeSmartNetBrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeckoWebBrowser1 As Gecko.GeckoWebBrowser
    Friend WithEvents Label1 As Label
    Friend WithEvents PagePrécédenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
