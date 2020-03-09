<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BrowserForm
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    ''' <summary>
    ''' Procédure requise pour le concepteur Windows Forms.
    ''' </summary>
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BrowserForm))
        Me.MainToolbar = New System.Windows.Forms.MenuStrip()
        Me.MainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeConnecterÀAppSyncToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseTabToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AperçuAvantImpressionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÉditionSubMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CouperToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SélectionnerToutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.RechercherDansLaPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom75 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom125 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom150 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom175 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom200 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom250 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom300 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Zoom400 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomPlusButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomMinusButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TéléchargerCetteVidéoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FavorisSubMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLesFavorisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterCettePageDansLesFavorisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLhistoriqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoriqueDeNavigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoriqueDesRecherchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TéléchargementsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.PleinÉcranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterLePleinÉcranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ParamètresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CentreDaideEnLigneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContacterLéquipeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ÀProposDeSmartNetBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnvoyerVosCommentairesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.SignalerUnSiteMalveillantToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NouvelleVersionDisponibleSubMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.TéléchargerLaVersionXXXXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerSmartNetBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.URLBox = New System.Windows.Forms.ComboBox()
        Me.UpdateNotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.BrowserContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OuvrirLeLienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuvrirDansUnNouvelOngletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierLadresseDuLienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjouterLeLienAuxFavorisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LinkToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.EnregistrerLimageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierLadresseDeLimageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLimageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.CouperToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopierToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditionToolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ActualiserLaPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropriétésToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AfficherLeCodeSourceDeLaPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrowserTabs = New System.Windows.Forms.TabControl()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TabsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FermerCetOngletToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RouvrirLeDernierOngletFerméToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.URLBoxLabel = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.MessageBarLabel1 = New System.Windows.Forms.Label()
        Me.MessageBarButton1 = New System.Windows.Forms.Button()
        Me.GardeFouTimer = New System.Windows.Forms.Timer(Me.components)
        Me.NextpageButton = New System.Windows.Forms.Button()
        Me.PreviouspageButton = New System.Windows.Forms.Button()
        Me.NewTabButton = New System.Windows.Forms.Button()
        Me.CloseTabButton = New System.Windows.Forms.Button()
        Me.HomepageButton = New System.Windows.Forms.Button()
        Me.FavoritesButton = New System.Windows.Forms.Button()
        Me.GoButton = New System.Windows.Forms.Button()
        Me.StopOrRefreshButton = New System.Windows.Forms.Button()
        Me.AppSyncTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MessageBarPanel = New System.Windows.Forms.Panel()
        Me.MessageBarCloseButton = New System.Windows.Forms.Button()
        Me.URLBoxPanel = New System.Windows.Forms.Panel()
        Me.PageSecurityButton = New System.Windows.Forms.Button()
        Me.AdBlockerButton = New System.Windows.Forms.Button()
        Me.MainToolbar.SuspendLayout()
        Me.BrowserContextMenuStrip.SuspendLayout()
        Me.TabsContextMenuStrip.SuspendLayout()
        Me.MessageBarPanel.SuspendLayout()
        Me.URLBoxPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainToolbar
        '
        Me.MainToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(253, Byte), Integer))
        resources.ApplyResources(Me.MainToolbar, "MainToolbar")
        Me.MainToolbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenu})
        Me.MainToolbar.Name = "MainToolbar"
        '
        'MainMenu
        '
        resources.ApplyResources(Me.MainMenu, "MainMenu")
        Me.MainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SeConnecterÀAppSyncToolStripMenuItem, Me.ToolStripSeparator11, Me.NewTabToolStripMenuItem, Me.CloseTabToolStripMenuItem, Me.ToolStripSeparator1, Me.OpenPageToolStripMenuItem, Me.SavePageToolStripMenuItem, Me.AperçuAvantImpressionToolStripMenuItem, Me.EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem, Me.ÉditionSubMenu, Me.ZoomToolStripMenuItem, Me.ToolStripSeparator2, Me.TéléchargerCetteVidéoToolStripMenuItem, Me.ToolStripSeparator6, Me.FavorisSubMenu, Me.AfficherLhistoriqueToolStripMenuItem, Me.ToolStripSeparator4, Me.PleinÉcranToolStripMenuItem, Me.QuitterLePleinÉcranToolStripMenuItem, Me.ToolStripSeparator3, Me.ParamètresToolStripMenuItem, Me.SupportToolStripMenuItem, Me.NouvelleVersionDisponibleSubMenu, Me.FermerSmartNetBrowserToolStripMenuItem})
        Me.MainMenu.Image = Global.SmartNet_Browser.My.Resources.Resources.MenuBlack
        Me.MainMenu.Name = "MainMenu"
        '
        'SeConnecterÀAppSyncToolStripMenuItem
        '
        Me.SeConnecterÀAppSyncToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Person
        Me.SeConnecterÀAppSyncToolStripMenuItem.Name = "SeConnecterÀAppSyncToolStripMenuItem"
        resources.ApplyResources(Me.SeConnecterÀAppSyncToolStripMenuItem, "SeConnecterÀAppSyncToolStripMenuItem")
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        resources.ApplyResources(Me.ToolStripSeparator11, "ToolStripSeparator11")
        '
        'NewTabToolStripMenuItem
        '
        Me.NewTabToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.NewTabBlack
        Me.NewTabToolStripMenuItem.Name = "NewTabToolStripMenuItem"
        resources.ApplyResources(Me.NewTabToolStripMenuItem, "NewTabToolStripMenuItem")
        '
        'CloseTabToolStripMenuItem
        '
        Me.CloseTabToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.CloseTabBlack
        Me.CloseTabToolStripMenuItem.Name = "CloseTabToolStripMenuItem"
        resources.ApplyResources(Me.CloseTabToolStripMenuItem, "CloseTabToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'OpenPageToolStripMenuItem
        '
        Me.OpenPageToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Open
        Me.OpenPageToolStripMenuItem.Name = "OpenPageToolStripMenuItem"
        resources.ApplyResources(Me.OpenPageToolStripMenuItem, "OpenPageToolStripMenuItem")
        '
        'SavePageToolStripMenuItem
        '
        Me.SavePageToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.SaveAs
        Me.SavePageToolStripMenuItem.Name = "SavePageToolStripMenuItem"
        resources.ApplyResources(Me.SavePageToolStripMenuItem, "SavePageToolStripMenuItem")
        '
        'AperçuAvantImpressionToolStripMenuItem
        '
        Me.AperçuAvantImpressionToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Print
        Me.AperçuAvantImpressionToolStripMenuItem.Name = "AperçuAvantImpressionToolStripMenuItem"
        resources.ApplyResources(Me.AperçuAvantImpressionToolStripMenuItem, "AperçuAvantImpressionToolStripMenuItem")
        '
        'EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem
        '
        Me.EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.SendEmail
        Me.EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem.Name = "EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem"
        resources.ApplyResources(Me.EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem, "EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem")
        '
        'ÉditionSubMenu
        '
        Me.ÉditionSubMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CouperToolStripMenuItem, Me.CopierToolStripMenuItem, Me.CollerToolStripMenuItem, Me.SélectionnerToutToolStripMenuItem, Me.ToolStripSeparator9, Me.RechercherDansLaPageToolStripMenuItem})
        Me.ÉditionSubMenu.Name = "ÉditionSubMenu"
        resources.ApplyResources(Me.ÉditionSubMenu, "ÉditionSubMenu")
        '
        'CouperToolStripMenuItem
        '
        Me.CouperToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Cut
        Me.CouperToolStripMenuItem.Name = "CouperToolStripMenuItem"
        resources.ApplyResources(Me.CouperToolStripMenuItem, "CouperToolStripMenuItem")
        '
        'CopierToolStripMenuItem
        '
        Me.CopierToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Copy
        Me.CopierToolStripMenuItem.Name = "CopierToolStripMenuItem"
        resources.ApplyResources(Me.CopierToolStripMenuItem, "CopierToolStripMenuItem")
        '
        'CollerToolStripMenuItem
        '
        Me.CollerToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Paste
        Me.CollerToolStripMenuItem.Name = "CollerToolStripMenuItem"
        resources.ApplyResources(Me.CollerToolStripMenuItem, "CollerToolStripMenuItem")
        '
        'SélectionnerToutToolStripMenuItem
        '
        Me.SélectionnerToutToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.SelectAll
        Me.SélectionnerToutToolStripMenuItem.Name = "SélectionnerToutToolStripMenuItem"
        resources.ApplyResources(Me.SélectionnerToutToolStripMenuItem, "SélectionnerToutToolStripMenuItem")
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        '
        'RechercherDansLaPageToolStripMenuItem
        '
        Me.RechercherDansLaPageToolStripMenuItem.Name = "RechercherDansLaPageToolStripMenuItem"
        resources.ApplyResources(Me.RechercherDansLaPageToolStripMenuItem, "RechercherDansLaPageToolStripMenuItem")
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Zoom50, Me.Zoom75, Me.Zoom100, Me.Zoom125, Me.Zoom150, Me.Zoom175, Me.Zoom200, Me.Zoom250, Me.Zoom300, Me.Zoom400, Me.ToolStripSeparator8, Me.ZoomPlusButton, Me.ZoomMinusButton})
        resources.ApplyResources(Me.ZoomToolStripMenuItem, "ZoomToolStripMenuItem")
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        '
        'Zoom50
        '
        Me.Zoom50.Name = "Zoom50"
        resources.ApplyResources(Me.Zoom50, "Zoom50")
        '
        'Zoom75
        '
        Me.Zoom75.Name = "Zoom75"
        resources.ApplyResources(Me.Zoom75, "Zoom75")
        '
        'Zoom100
        '
        Me.Zoom100.Name = "Zoom100"
        resources.ApplyResources(Me.Zoom100, "Zoom100")
        '
        'Zoom125
        '
        Me.Zoom125.Name = "Zoom125"
        resources.ApplyResources(Me.Zoom125, "Zoom125")
        '
        'Zoom150
        '
        Me.Zoom150.Name = "Zoom150"
        resources.ApplyResources(Me.Zoom150, "Zoom150")
        '
        'Zoom175
        '
        Me.Zoom175.Name = "Zoom175"
        resources.ApplyResources(Me.Zoom175, "Zoom175")
        '
        'Zoom200
        '
        Me.Zoom200.Name = "Zoom200"
        resources.ApplyResources(Me.Zoom200, "Zoom200")
        '
        'Zoom250
        '
        Me.Zoom250.Name = "Zoom250"
        resources.ApplyResources(Me.Zoom250, "Zoom250")
        '
        'Zoom300
        '
        Me.Zoom300.Name = "Zoom300"
        resources.ApplyResources(Me.Zoom300, "Zoom300")
        '
        'Zoom400
        '
        Me.Zoom400.Name = "Zoom400"
        resources.ApplyResources(Me.Zoom400, "Zoom400")
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        '
        'ZoomPlusButton
        '
        Me.ZoomPlusButton.Name = "ZoomPlusButton"
        resources.ApplyResources(Me.ZoomPlusButton, "ZoomPlusButton")
        '
        'ZoomMinusButton
        '
        Me.ZoomMinusButton.Name = "ZoomMinusButton"
        resources.ApplyResources(Me.ZoomMinusButton, "ZoomMinusButton")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'TéléchargerCetteVidéoToolStripMenuItem
        '
        Me.TéléchargerCetteVidéoToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Download
        Me.TéléchargerCetteVidéoToolStripMenuItem.Name = "TéléchargerCetteVidéoToolStripMenuItem"
        resources.ApplyResources(Me.TéléchargerCetteVidéoToolStripMenuItem, "TéléchargerCetteVidéoToolStripMenuItem")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'FavorisSubMenu
        '
        Me.FavorisSubMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AfficherLesFavorisToolStripMenuItem, Me.AjouterCettePageDansLesFavorisToolStripMenuItem})
        Me.FavorisSubMenu.Image = Global.SmartNet_Browser.My.Resources.Resources.Favorites
        Me.FavorisSubMenu.Name = "FavorisSubMenu"
        resources.ApplyResources(Me.FavorisSubMenu, "FavorisSubMenu")
        '
        'AfficherLesFavorisToolStripMenuItem
        '
        Me.AfficherLesFavorisToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Favorites
        Me.AfficherLesFavorisToolStripMenuItem.Name = "AfficherLesFavorisToolStripMenuItem"
        resources.ApplyResources(Me.AfficherLesFavorisToolStripMenuItem, "AfficherLesFavorisToolStripMenuItem")
        '
        'AjouterCettePageDansLesFavorisToolStripMenuItem
        '
        Me.AjouterCettePageDansLesFavorisToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.AddFavorite
        Me.AjouterCettePageDansLesFavorisToolStripMenuItem.Name = "AjouterCettePageDansLesFavorisToolStripMenuItem"
        resources.ApplyResources(Me.AjouterCettePageDansLesFavorisToolStripMenuItem, "AjouterCettePageDansLesFavorisToolStripMenuItem")
        '
        'AfficherLhistoriqueToolStripMenuItem
        '
        Me.AfficherLhistoriqueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistoriqueDeNavigationToolStripMenuItem, Me.HistoriqueDesRecherchesToolStripMenuItem, Me.TéléchargementsToolStripMenuItem})
        Me.AfficherLhistoriqueToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.History
        Me.AfficherLhistoriqueToolStripMenuItem.Name = "AfficherLhistoriqueToolStripMenuItem"
        resources.ApplyResources(Me.AfficherLhistoriqueToolStripMenuItem, "AfficherLhistoriqueToolStripMenuItem")
        '
        'HistoriqueDeNavigationToolStripMenuItem
        '
        Me.HistoriqueDeNavigationToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.History
        Me.HistoriqueDeNavigationToolStripMenuItem.Name = "HistoriqueDeNavigationToolStripMenuItem"
        resources.ApplyResources(Me.HistoriqueDeNavigationToolStripMenuItem, "HistoriqueDeNavigationToolStripMenuItem")
        '
        'HistoriqueDesRecherchesToolStripMenuItem
        '
        Me.HistoriqueDesRecherchesToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Search
        Me.HistoriqueDesRecherchesToolStripMenuItem.Name = "HistoriqueDesRecherchesToolStripMenuItem"
        resources.ApplyResources(Me.HistoriqueDesRecherchesToolStripMenuItem, "HistoriqueDesRecherchesToolStripMenuItem")
        '
        'TéléchargementsToolStripMenuItem
        '
        Me.TéléchargementsToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Download
        Me.TéléchargementsToolStripMenuItem.Name = "TéléchargementsToolStripMenuItem"
        resources.ApplyResources(Me.TéléchargementsToolStripMenuItem, "TéléchargementsToolStripMenuItem")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'PleinÉcranToolStripMenuItem
        '
        Me.PleinÉcranToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Fullscreen
        Me.PleinÉcranToolStripMenuItem.Name = "PleinÉcranToolStripMenuItem"
        resources.ApplyResources(Me.PleinÉcranToolStripMenuItem, "PleinÉcranToolStripMenuItem")
        '
        'QuitterLePleinÉcranToolStripMenuItem
        '
        resources.ApplyResources(Me.QuitterLePleinÉcranToolStripMenuItem, "QuitterLePleinÉcranToolStripMenuItem")
        Me.QuitterLePleinÉcranToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.FullscreenExit
        Me.QuitterLePleinÉcranToolStripMenuItem.Name = "QuitterLePleinÉcranToolStripMenuItem"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ParamètresToolStripMenuItem
        '
        Me.ParamètresToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Settings
        Me.ParamètresToolStripMenuItem.Name = "ParamètresToolStripMenuItem"
        resources.ApplyResources(Me.ParamètresToolStripMenuItem, "ParamètresToolStripMenuItem")
        '
        'SupportToolStripMenuItem
        '
        Me.SupportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CentreDaideEnLigneToolStripMenuItem, Me.ContacterLéquipeToolStripMenuItem, Me.ToolStripSeparator5, Me.ÀProposDeSmartNetBrowserToolStripMenuItem, Me.EnvoyerVosCommentairesToolStripMenuItem, Me.ToolStripSeparator10, Me.SignalerUnSiteMalveillantToolStripMenuItem})
        Me.SupportToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Help
        Me.SupportToolStripMenuItem.Name = "SupportToolStripMenuItem"
        resources.ApplyResources(Me.SupportToolStripMenuItem, "SupportToolStripMenuItem")
        '
        'CentreDaideEnLigneToolStripMenuItem
        '
        Me.CentreDaideEnLigneToolStripMenuItem.Name = "CentreDaideEnLigneToolStripMenuItem"
        resources.ApplyResources(Me.CentreDaideEnLigneToolStripMenuItem, "CentreDaideEnLigneToolStripMenuItem")
        '
        'ContacterLéquipeToolStripMenuItem
        '
        Me.ContacterLéquipeToolStripMenuItem.Name = "ContacterLéquipeToolStripMenuItem"
        resources.ApplyResources(Me.ContacterLéquipeToolStripMenuItem, "ContacterLéquipeToolStripMenuItem")
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'ÀProposDeSmartNetBrowserToolStripMenuItem
        '
        Me.ÀProposDeSmartNetBrowserToolStripMenuItem.Name = "ÀProposDeSmartNetBrowserToolStripMenuItem"
        resources.ApplyResources(Me.ÀProposDeSmartNetBrowserToolStripMenuItem, "ÀProposDeSmartNetBrowserToolStripMenuItem")
        '
        'EnvoyerVosCommentairesToolStripMenuItem
        '
        Me.EnvoyerVosCommentairesToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.SendFeedback
        Me.EnvoyerVosCommentairesToolStripMenuItem.Name = "EnvoyerVosCommentairesToolStripMenuItem"
        resources.ApplyResources(Me.EnvoyerVosCommentairesToolStripMenuItem, "EnvoyerVosCommentairesToolStripMenuItem")
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        '
        'SignalerUnSiteMalveillantToolStripMenuItem
        '
        Me.SignalerUnSiteMalveillantToolStripMenuItem.Name = "SignalerUnSiteMalveillantToolStripMenuItem"
        resources.ApplyResources(Me.SignalerUnSiteMalveillantToolStripMenuItem, "SignalerUnSiteMalveillantToolStripMenuItem")
        '
        'NouvelleVersionDisponibleSubMenu
        '
        Me.NouvelleVersionDisponibleSubMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TéléchargerLaVersionXXXXToolStripMenuItem})
        Me.NouvelleVersionDisponibleSubMenu.Image = Global.SmartNet_Browser.My.Resources.Resources._2019_SmartNetAppsUpdater_1024
        Me.NouvelleVersionDisponibleSubMenu.Name = "NouvelleVersionDisponibleSubMenu"
        resources.ApplyResources(Me.NouvelleVersionDisponibleSubMenu, "NouvelleVersionDisponibleSubMenu")
        '
        'TéléchargerLaVersionXXXXToolStripMenuItem
        '
        Me.TéléchargerLaVersionXXXXToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources._2019_SmartNetBrowserInstaller_1024
        Me.TéléchargerLaVersionXXXXToolStripMenuItem.Name = "TéléchargerLaVersionXXXXToolStripMenuItem"
        resources.ApplyResources(Me.TéléchargerLaVersionXXXXToolStripMenuItem, "TéléchargerLaVersionXXXXToolStripMenuItem")
        '
        'FermerSmartNetBrowserToolStripMenuItem
        '
        Me.FermerSmartNetBrowserToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.Close
        Me.FermerSmartNetBrowserToolStripMenuItem.Name = "FermerSmartNetBrowserToolStripMenuItem"
        resources.ApplyResources(Me.FermerSmartNetBrowserToolStripMenuItem, "FermerSmartNetBrowserToolStripMenuItem")
        '
        'URLBox
        '
        resources.ApplyResources(Me.URLBox, "URLBox")
        Me.URLBox.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox
        Me.URLBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.URLBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.URLBox.FormattingEnabled = True
        Me.URLBox.Name = "URLBox"
        '
        'UpdateNotifyIcon
        '
        Me.UpdateNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        resources.ApplyResources(Me.UpdateNotifyIcon, "UpdateNotifyIcon")
        '
        'BrowserContextMenuStrip
        '
        Me.BrowserContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvrirLeLienToolStripMenuItem, Me.OuvrirDansUnNouvelOngletToolStripMenuItem, Me.CopierLadresseDuLienToolStripMenuItem, Me.AjouterLeLienAuxFavorisToolStripMenuItem, Me.LinkToolStripSeparator, Me.EnregistrerLimageToolStripMenuItem, Me.CopierLadresseDeLimageToolStripMenuItem, Me.AfficherLimageToolStripMenuItem, Me.ImageToolStripSeparator, Me.CouperToolStripMenuItem1, Me.CopierToolStripMenuItem1, Me.CollerToolStripMenuItem1, Me.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem, Me.EditionToolStripSeparator, Me.ActualiserLaPageToolStripMenuItem, Me.ToolStripSeparator7, Me.PropriétésToolStripMenuItem, Me.AfficherLeCodeSourceDeLaPageToolStripMenuItem})
        Me.BrowserContextMenuStrip.Name = "BrowserContextMenuStrip"
        resources.ApplyResources(Me.BrowserContextMenuStrip, "BrowserContextMenuStrip")
        '
        'OuvrirLeLienToolStripMenuItem
        '
        Me.OuvrirLeLienToolStripMenuItem.Name = "OuvrirLeLienToolStripMenuItem"
        resources.ApplyResources(Me.OuvrirLeLienToolStripMenuItem, "OuvrirLeLienToolStripMenuItem")
        '
        'OuvrirDansUnNouvelOngletToolStripMenuItem
        '
        Me.OuvrirDansUnNouvelOngletToolStripMenuItem.Name = "OuvrirDansUnNouvelOngletToolStripMenuItem"
        resources.ApplyResources(Me.OuvrirDansUnNouvelOngletToolStripMenuItem, "OuvrirDansUnNouvelOngletToolStripMenuItem")
        '
        'CopierLadresseDuLienToolStripMenuItem
        '
        Me.CopierLadresseDuLienToolStripMenuItem.Name = "CopierLadresseDuLienToolStripMenuItem"
        resources.ApplyResources(Me.CopierLadresseDuLienToolStripMenuItem, "CopierLadresseDuLienToolStripMenuItem")
        '
        'AjouterLeLienAuxFavorisToolStripMenuItem
        '
        Me.AjouterLeLienAuxFavorisToolStripMenuItem.Name = "AjouterLeLienAuxFavorisToolStripMenuItem"
        resources.ApplyResources(Me.AjouterLeLienAuxFavorisToolStripMenuItem, "AjouterLeLienAuxFavorisToolStripMenuItem")
        '
        'LinkToolStripSeparator
        '
        Me.LinkToolStripSeparator.Name = "LinkToolStripSeparator"
        resources.ApplyResources(Me.LinkToolStripSeparator, "LinkToolStripSeparator")
        '
        'EnregistrerLimageToolStripMenuItem
        '
        Me.EnregistrerLimageToolStripMenuItem.Name = "EnregistrerLimageToolStripMenuItem"
        resources.ApplyResources(Me.EnregistrerLimageToolStripMenuItem, "EnregistrerLimageToolStripMenuItem")
        '
        'CopierLadresseDeLimageToolStripMenuItem
        '
        Me.CopierLadresseDeLimageToolStripMenuItem.Name = "CopierLadresseDeLimageToolStripMenuItem"
        resources.ApplyResources(Me.CopierLadresseDeLimageToolStripMenuItem, "CopierLadresseDeLimageToolStripMenuItem")
        '
        'AfficherLimageToolStripMenuItem
        '
        Me.AfficherLimageToolStripMenuItem.Name = "AfficherLimageToolStripMenuItem"
        resources.ApplyResources(Me.AfficherLimageToolStripMenuItem, "AfficherLimageToolStripMenuItem")
        '
        'ImageToolStripSeparator
        '
        Me.ImageToolStripSeparator.Name = "ImageToolStripSeparator"
        resources.ApplyResources(Me.ImageToolStripSeparator, "ImageToolStripSeparator")
        '
        'CouperToolStripMenuItem1
        '
        Me.CouperToolStripMenuItem1.Name = "CouperToolStripMenuItem1"
        resources.ApplyResources(Me.CouperToolStripMenuItem1, "CouperToolStripMenuItem1")
        '
        'CopierToolStripMenuItem1
        '
        Me.CopierToolStripMenuItem1.Name = "CopierToolStripMenuItem1"
        resources.ApplyResources(Me.CopierToolStripMenuItem1, "CopierToolStripMenuItem1")
        '
        'CollerToolStripMenuItem1
        '
        Me.CollerToolStripMenuItem1.Name = "CollerToolStripMenuItem1"
        resources.ApplyResources(Me.CollerToolStripMenuItem1, "CollerToolStripMenuItem1")
        '
        'LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem
        '
        Me.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem.Name = "LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem"
        resources.ApplyResources(Me.LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem, "LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem")
        '
        'EditionToolStripSeparator
        '
        Me.EditionToolStripSeparator.Name = "EditionToolStripSeparator"
        resources.ApplyResources(Me.EditionToolStripSeparator, "EditionToolStripSeparator")
        '
        'ActualiserLaPageToolStripMenuItem
        '
        Me.ActualiserLaPageToolStripMenuItem.Name = "ActualiserLaPageToolStripMenuItem"
        resources.ApplyResources(Me.ActualiserLaPageToolStripMenuItem, "ActualiserLaPageToolStripMenuItem")
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'PropriétésToolStripMenuItem
        '
        Me.PropriétésToolStripMenuItem.Name = "PropriétésToolStripMenuItem"
        resources.ApplyResources(Me.PropriétésToolStripMenuItem, "PropriétésToolStripMenuItem")
        '
        'AfficherLeCodeSourceDeLaPageToolStripMenuItem
        '
        Me.AfficherLeCodeSourceDeLaPageToolStripMenuItem.Name = "AfficherLeCodeSourceDeLaPageToolStripMenuItem"
        resources.ApplyResources(Me.AfficherLeCodeSourceDeLaPageToolStripMenuItem, "AfficherLeCodeSourceDeLaPageToolStripMenuItem")
        '
        'BrowserTabs
        '
        resources.ApplyResources(Me.BrowserTabs, "BrowserTabs")
        Me.BrowserTabs.ImageList = Me.ImageList1
        Me.BrowserTabs.Name = "BrowserTabs"
        Me.BrowserTabs.SelectedIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ErrorFavicon.png")
        '
        'TabsContextMenuStrip
        '
        Me.TabsContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerCetOngletToolStripMenuItem, Me.RouvrirLeDernierOngletFerméToolStripMenuItem})
        Me.TabsContextMenuStrip.Name = "TabsContextMenuStrip"
        resources.ApplyResources(Me.TabsContextMenuStrip, "TabsContextMenuStrip")
        '
        'FermerCetOngletToolStripMenuItem
        '
        Me.FermerCetOngletToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.CloseTabBlack
        Me.FermerCetOngletToolStripMenuItem.Name = "FermerCetOngletToolStripMenuItem"
        resources.ApplyResources(Me.FermerCetOngletToolStripMenuItem, "FermerCetOngletToolStripMenuItem")
        '
        'RouvrirLeDernierOngletFerméToolStripMenuItem
        '
        Me.RouvrirLeDernierOngletFerméToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.NewTabBlack
        Me.RouvrirLeDernierOngletFerméToolStripMenuItem.Name = "RouvrirLeDernierOngletFerméToolStripMenuItem"
        resources.ApplyResources(Me.RouvrirLeDernierOngletFerméToolStripMenuItem, "RouvrirLeDernierOngletFerméToolStripMenuItem")
        '
        'URLBoxLabel
        '
        resources.ApplyResources(Me.URLBoxLabel, "URLBoxLabel")
        Me.URLBoxLabel.BackColor = System.Drawing.Color.White
        Me.URLBoxLabel.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.URLBoxLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.URLBoxLabel.Name = "URLBoxLabel"
        '
        'StatusLabel
        '
        resources.ApplyResources(Me.StatusLabel, "StatusLabel")
        Me.StatusLabel.BackColor = System.Drawing.SystemColors.Window
        Me.StatusLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StatusLabel.Name = "StatusLabel"
        '
        'MessageBarLabel1
        '
        resources.ApplyResources(Me.MessageBarLabel1, "MessageBarLabel1")
        Me.MessageBarLabel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MessageBarLabel1.ForeColor = System.Drawing.Color.White
        Me.MessageBarLabel1.Name = "MessageBarLabel1"
        '
        'MessageBarButton1
        '
        resources.ApplyResources(Me.MessageBarButton1, "MessageBarButton1")
        Me.MessageBarButton1.FlatAppearance.BorderSize = 0
        Me.MessageBarButton1.Name = "MessageBarButton1"
        Me.MessageBarButton1.UseVisualStyleBackColor = True
        '
        'GardeFouTimer
        '
        Me.GardeFouTimer.Enabled = True
        Me.GardeFouTimer.Interval = 5000
        '
        'NextpageButton
        '
        resources.ApplyResources(Me.NextpageButton, "NextpageButton")
        Me.NextpageButton.FlatAppearance.BorderSize = 0
        Me.NextpageButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.NextpageButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.NextpageButton.Image = Global.SmartNet_Browser.My.Resources.Resources.NextBlack
        Me.NextpageButton.Name = "NextpageButton"
        Me.NextpageButton.UseVisualStyleBackColor = True
        '
        'PreviouspageButton
        '
        resources.ApplyResources(Me.PreviouspageButton, "PreviouspageButton")
        Me.PreviouspageButton.FlatAppearance.BorderSize = 0
        Me.PreviouspageButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.PreviouspageButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.PreviouspageButton.Image = Global.SmartNet_Browser.My.Resources.Resources.PreviousBlack
        Me.PreviouspageButton.Name = "PreviouspageButton"
        Me.PreviouspageButton.UseVisualStyleBackColor = True
        '
        'NewTabButton
        '
        resources.ApplyResources(Me.NewTabButton, "NewTabButton")
        Me.NewTabButton.FlatAppearance.BorderSize = 0
        Me.NewTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.NewTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.NewTabButton.Image = Global.SmartNet_Browser.My.Resources.Resources.NewTabBlack
        Me.NewTabButton.Name = "NewTabButton"
        Me.NewTabButton.UseVisualStyleBackColor = True
        '
        'CloseTabButton
        '
        resources.ApplyResources(Me.CloseTabButton, "CloseTabButton")
        Me.CloseTabButton.FlatAppearance.BorderSize = 0
        Me.CloseTabButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.CloseTabButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.CloseTabButton.Image = Global.SmartNet_Browser.My.Resources.Resources.CloseTabBlack
        Me.CloseTabButton.Name = "CloseTabButton"
        Me.CloseTabButton.UseVisualStyleBackColor = True
        '
        'HomepageButton
        '
        resources.ApplyResources(Me.HomepageButton, "HomepageButton")
        Me.HomepageButton.FlatAppearance.BorderSize = 0
        Me.HomepageButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.HomepageButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.HomepageButton.Image = Global.SmartNet_Browser.My.Resources.Resources.HomeBlack
        Me.HomepageButton.Name = "HomepageButton"
        Me.HomepageButton.UseVisualStyleBackColor = True
        '
        'FavoritesButton
        '
        resources.ApplyResources(Me.FavoritesButton, "FavoritesButton")
        Me.FavoritesButton.FlatAppearance.BorderSize = 0
        Me.FavoritesButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.FavoritesButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.FavoritesButton.Image = Global.SmartNet_Browser.My.Resources.Resources.Favorites
        Me.FavoritesButton.Name = "FavoritesButton"
        Me.FavoritesButton.UseVisualStyleBackColor = False
        '
        'GoButton
        '
        resources.ApplyResources(Me.GoButton, "GoButton")
        Me.GoButton.BackColor = System.Drawing.Color.White
        Me.GoButton.FlatAppearance.BorderSize = 0
        Me.GoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.GoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.GoButton.Image = Global.SmartNet_Browser.My.Resources.Resources.GoBlack
        Me.GoButton.Name = "GoButton"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'StopOrRefreshButton
        '
        resources.ApplyResources(Me.StopOrRefreshButton, "StopOrRefreshButton")
        Me.StopOrRefreshButton.FlatAppearance.BorderSize = 0
        Me.StopOrRefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.StopOrRefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight
        Me.StopOrRefreshButton.Image = Global.SmartNet_Browser.My.Resources.Resources.StopBlack
        Me.StopOrRefreshButton.Name = "StopOrRefreshButton"
        Me.StopOrRefreshButton.UseVisualStyleBackColor = True
        '
        'AppSyncTimer
        '
        Me.AppSyncTimer.Enabled = True
        Me.AppSyncTimer.Interval = 300000
        '
        'MessageBarPanel
        '
        resources.ApplyResources(Me.MessageBarPanel, "MessageBarPanel")
        Me.MessageBarPanel.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MessageBarPanel.Controls.Add(Me.MessageBarCloseButton)
        Me.MessageBarPanel.Controls.Add(Me.MessageBarLabel1)
        Me.MessageBarPanel.Controls.Add(Me.MessageBarButton1)
        Me.MessageBarPanel.Name = "MessageBarPanel"
        '
        'MessageBarCloseButton
        '
        resources.ApplyResources(Me.MessageBarCloseButton, "MessageBarCloseButton")
        Me.MessageBarCloseButton.FlatAppearance.BorderSize = 0
        Me.MessageBarCloseButton.Image = Global.SmartNet_Browser.My.Resources.Resources.StopBlack
        Me.MessageBarCloseButton.Name = "MessageBarCloseButton"
        Me.MessageBarCloseButton.UseVisualStyleBackColor = True
        '
        'URLBoxPanel
        '
        resources.ApplyResources(Me.URLBoxPanel, "URLBoxPanel")
        Me.URLBoxPanel.BackColor = System.Drawing.Color.White
        Me.URLBoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.URLBoxPanel.Controls.Add(Me.PageSecurityButton)
        Me.URLBoxPanel.Controls.Add(Me.AdBlockerButton)
        Me.URLBoxPanel.Controls.Add(Me.URLBoxLabel)
        Me.URLBoxPanel.Controls.Add(Me.GoButton)
        Me.URLBoxPanel.Controls.Add(Me.FavoritesButton)
        Me.URLBoxPanel.Controls.Add(Me.URLBox)
        Me.URLBoxPanel.Name = "URLBoxPanel"
        '
        'PageSecurityButton
        '
        Me.PageSecurityButton.FlatAppearance.BorderSize = 0
        Me.PageSecurityButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.PageSecurityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        resources.ApplyResources(Me.PageSecurityButton, "PageSecurityButton")
        Me.PageSecurityButton.Image = Global.SmartNet_Browser.My.Resources.Resources.PageSecurity_red
        Me.PageSecurityButton.Name = "PageSecurityButton"
        Me.PageSecurityButton.UseVisualStyleBackColor = True
        '
        'AdBlockerButton
        '
        resources.ApplyResources(Me.AdBlockerButton, "AdBlockerButton")
        Me.AdBlockerButton.FlatAppearance.BorderSize = 0
        Me.AdBlockerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro
        Me.AdBlockerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.AdBlockerButton.Image = Global.SmartNet_Browser.My.Resources.Resources.AdsBlockerButton_enabled
        Me.AdBlockerButton.Name = "AdBlockerButton"
        Me.AdBlockerButton.UseVisualStyleBackColor = True
        '
        'BrowserForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Controls.Add(Me.MessageBarPanel)
        Me.Controls.Add(Me.StopOrRefreshButton)
        Me.Controls.Add(Me.HomepageButton)
        Me.Controls.Add(Me.CloseTabButton)
        Me.Controls.Add(Me.NewTabButton)
        Me.Controls.Add(Me.PreviouspageButton)
        Me.Controls.Add(Me.NextpageButton)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.BrowserTabs)
        Me.Controls.Add(Me.MainToolbar)
        Me.Controls.Add(Me.URLBoxPanel)
        Me.KeyPreview = True
        Me.Name = "BrowserForm"
        Me.MainToolbar.ResumeLayout(False)
        Me.MainToolbar.PerformLayout()
        Me.BrowserContextMenuStrip.ResumeLayout(False)
        Me.TabsContextMenuStrip.ResumeLayout(False)
        Me.MessageBarPanel.ResumeLayout(False)
        Me.URLBoxPanel.ResumeLayout(False)
        Me.URLBoxPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainToolbar As MenuStrip
    Friend WithEvents MainMenu As ToolStripMenuItem
    Friend WithEvents URLBox As ComboBox
    Friend WithEvents UpdateNotifyIcon As NotifyIcon
    Friend WithEvents ÉditionSubMenu As ToolStripMenuItem
    Friend WithEvents CouperToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FavorisSubMenu As ToolStripMenuItem
    Friend WithEvents AfficherLesFavorisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterCettePageDansLesFavorisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NouvelleVersionDisponibleSubMenu As ToolStripMenuItem
    Friend WithEvents TéléchargerLaVersionXXXXToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FermerSmartNetBrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewTabToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseTabToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents OpenPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SavePageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AperçuAvantImpressionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AfficherLhistoriqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents PleinÉcranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterLePleinÉcranToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ParamètresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CentreDaideEnLigneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContacterLéquipeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÀProposDeSmartNetBrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents TéléchargerCetteVidéoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents BrowserContextMenuStrip As ContextMenuStrip
    Friend WithEvents OuvrirLeLienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OuvrirDansUnNouvelOngletToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopierLadresseDuLienToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LinkToolStripSeparator As ToolStripSeparator
    Friend WithEvents EnregistrerLimageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopierLadresseDeLimageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AfficherLimageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageToolStripSeparator As ToolStripSeparator
    Friend WithEvents PropriétésToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjouterLeLienAuxFavorisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ActualiserLaPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents AfficherLeCodeSourceDeLaPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CouperToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CopierToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CollerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditionToolStripSeparator As ToolStripSeparator
    Friend WithEvents LancerUneRechercheAvecLeTexteSélectionnéToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnvoyerVosCommentairesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BrowserTabs As TabControl
    Friend WithEvents ZoomToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Zoom50 As ToolStripMenuItem
    Friend WithEvents Zoom75 As ToolStripMenuItem
    Friend WithEvents Zoom100 As ToolStripMenuItem
    Friend WithEvents Zoom125 As ToolStripMenuItem
    Friend WithEvents Zoom150 As ToolStripMenuItem
    Friend WithEvents Zoom175 As ToolStripMenuItem
    Friend WithEvents Zoom200 As ToolStripMenuItem
    Friend WithEvents Zoom250 As ToolStripMenuItem
    Friend WithEvents Zoom300 As ToolStripMenuItem
    Friend WithEvents Zoom400 As ToolStripMenuItem
    Friend WithEvents URLBoxLabel As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ZoomPlusButton As ToolStripMenuItem
    Friend WithEvents ZoomMinusButton As ToolStripMenuItem
    Friend WithEvents SélectionnerToutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents RechercherDansLaPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnvoyerLadresseDeLaPageParCourrierÉlectoniqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents MessageBarLabel1 As Label
    Friend WithEvents MessageBarButton1 As Button
    Friend WithEvents TabsContextMenuStrip As ContextMenuStrip
    Friend WithEvents FermerCetOngletToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RouvrirLeDernierOngletFerméToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GardeFouTimer As Timer
    Friend WithEvents ToolStripSeparator10 As ToolStripSeparator
    Friend WithEvents SignalerUnSiteMalveillantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NextpageButton As Button
    Friend WithEvents PreviouspageButton As Button
    Friend WithEvents NewTabButton As Button
    Friend WithEvents CloseTabButton As Button
    Friend WithEvents HomepageButton As Button
    Friend WithEvents FavoritesButton As Button
    Friend WithEvents GoButton As Button
    Friend WithEvents StopOrRefreshButton As Button
    Friend WithEvents HistoriqueDeNavigationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HistoriqueDesRecherchesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TéléchargementsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SeConnecterÀAppSyncToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents AppSyncTimer As Timer
    Friend WithEvents MessageBarPanel As Panel
    Friend WithEvents MessageBarCloseButton As Button
    Friend WithEvents URLBoxPanel As Panel
    Friend WithEvents AdBlockerButton As Button
    Friend WithEvents PageSecurityButton As Button
End Class
