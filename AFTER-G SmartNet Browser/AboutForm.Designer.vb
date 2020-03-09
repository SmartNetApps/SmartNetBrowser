<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.HomepageLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.LicenseLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ClipconverterLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.GeckoFXLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.ReleaseNotesLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.GitHubLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'HomepageLinkLabel
        '
        Me.HomepageLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.HomepageLinkLabel, "HomepageLinkLabel")
        Me.HomepageLinkLabel.BackColor = System.Drawing.SystemColors.Control
        Me.HomepageLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.HomepageLinkLabel.Name = "HomepageLinkLabel"
        Me.HomepageLinkLabel.TabStop = True
        Me.HomepageLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'LicenseLinkLabel
        '
        Me.LicenseLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.LicenseLinkLabel, "LicenseLinkLabel")
        Me.LicenseLinkLabel.BackColor = System.Drawing.SystemColors.Control
        Me.LicenseLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LicenseLinkLabel.Name = "LicenseLinkLabel"
        Me.LicenseLinkLabel.TabStop = True
        Me.LicenseLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'ClipconverterLinkLabel
        '
        Me.ClipconverterLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.ClipconverterLinkLabel, "ClipconverterLinkLabel")
        Me.ClipconverterLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.ClipconverterLinkLabel.Name = "ClipconverterLinkLabel"
        Me.ClipconverterLinkLabel.TabStop = True
        Me.ClipconverterLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'GeckoFXLinkLabel
        '
        Me.GeckoFXLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.GeckoFXLinkLabel, "GeckoFXLinkLabel")
        Me.GeckoFXLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.GeckoFXLinkLabel.Name = "GeckoFXLinkLabel"
        Me.GeckoFXLinkLabel.TabStop = True
        Me.GeckoFXLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'PictureBox5
        '
        resources.ApplyResources(Me.PictureBox5, "PictureBox5")
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.Image = Global.SmartNet_Browser.My.Resources.Resources.Logo_ClipConverter_cc
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.ErrorImage = Global.SmartNet_Browser.My.Resources.Resources._2019_SmartNetBrowser_1024
        Me.PictureBox1.Image = Global.SmartNet_Browser.My.Resources.Resources._2019_SmartNetBrowser_1024
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.InitialImage = Global.SmartNet_Browser.My.Resources.Resources._2019_SmartNetBrowser_1024
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.PictureBox6, "PictureBox6")
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.TabStop = False
        '
        'ReleaseNotesLinkLabel
        '
        Me.ReleaseNotesLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.ReleaseNotesLinkLabel, "ReleaseNotesLinkLabel")
        Me.ReleaseNotesLinkLabel.BackColor = System.Drawing.Color.White
        Me.ReleaseNotesLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.ReleaseNotesLinkLabel.Name = "ReleaseNotesLinkLabel"
        Me.ReleaseNotesLinkLabel.TabStop = True
        Me.ReleaseNotesLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'GitHubLinkLabel
        '
        Me.GitHubLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.GitHubLinkLabel, "GitHubLinkLabel")
        Me.GitHubLinkLabel.BackColor = System.Drawing.SystemColors.Control
        Me.GitHubLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.GitHubLinkLabel.Name = "GitHubLinkLabel"
        Me.GitHubLinkLabel.TabStop = True
        Me.GitHubLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ClipconverterLinkLabel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.GeckoFXLinkLabel)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.SmartNet_Browser.My.Resources.Resources.wordmark_black_36
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'AboutForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GitHubLinkLabel)
        Me.Controls.Add(Me.ReleaseNotesLinkLabel)
        Me.Controls.Add(Me.LicenseLinkLabel)
        Me.Controls.Add(Me.HomepageLinkLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.ShowInTaskbar = False
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents HomepageLinkLabel As LinkLabel
    Friend WithEvents LicenseLinkLabel As LinkLabel
    Friend WithEvents ClipconverterLinkLabel As LinkLabel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents GeckoFXLinkLabel As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents ReleaseNotesLinkLabel As LinkLabel
    Friend WithEvents GitHubLinkLabel As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label4 As Label
End Class
