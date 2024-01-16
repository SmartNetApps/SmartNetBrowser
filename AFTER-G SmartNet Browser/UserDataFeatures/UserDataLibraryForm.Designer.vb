<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserDataLibraryForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDataLibraryForm))
        Me.HistoryListView = New System.Windows.Forms.ListView()
        Me.TitleColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.URLColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VisitDateColumnHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HistoryFaviconImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.OpenPageButton = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageHistory = New System.Windows.Forms.TabPage()
        Me.TabPageFavorites = New System.Windows.Forms.TabPage()
        Me.ButtonDeleteFavorite = New System.Windows.Forms.Button()
        Me.ButtonOpenFavorite = New System.Windows.Forms.Button()
        Me.ListViewFavorites = New System.Windows.Forms.ListView()
        Me.ColumnHeaderTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeaderURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPageSearchHistory = New System.Windows.Forms.TabPage()
        Me.SearchHistoryListView = New System.Windows.Forms.ListView()
        Me.Query = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CreationDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonDeleteSearch = New System.Windows.Forms.Button()
        Me.ButtonSearchAgain = New System.Windows.Forms.Button()
        Me.TabPageDownloads = New System.Windows.Forms.TabPage()
        Me.ButtonDeleteDownload = New System.Windows.Forms.Button()
        Me.ButtonDownloadAgain = New System.Windows.Forms.Button()
        Me.FavoritesFaviconImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AffichageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RafraîchirLesListesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposDeSmartNetBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadedItemsListView = New System.Windows.Forms.ListView()
        Me.DownloadedItemUri = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DownloadedItemTitle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DownloadedItemCreationDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1.SuspendLayout()
        Me.TabPageHistory.SuspendLayout()
        Me.TabPageFavorites.SuspendLayout()
        Me.TabPageSearchHistory.SuspendLayout()
        Me.TabPageDownloads.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'HistoryListView
        '
        resources.ApplyResources(Me.HistoryListView, "HistoryListView")
        Me.HistoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TitleColumnHeader, Me.URLColumnHeader, Me.VisitDateColumnHeader})
        Me.HistoryListView.FullRowSelect = True
        Me.HistoryListView.HideSelection = False
        Me.HistoryListView.LargeImageList = Me.HistoryFaviconImageList
        Me.HistoryListView.Name = "HistoryListView"
        Me.HistoryListView.SmallImageList = Me.HistoryFaviconImageList
        Me.HistoryListView.StateImageList = Me.HistoryFaviconImageList
        Me.HistoryListView.TileSize = New System.Drawing.Size(32, 32)
        Me.HistoryListView.UseCompatibleStateImageBehavior = False
        Me.HistoryListView.View = System.Windows.Forms.View.Details
        '
        'TitleColumnHeader
        '
        resources.ApplyResources(Me.TitleColumnHeader, "TitleColumnHeader")
        '
        'URLColumnHeader
        '
        resources.ApplyResources(Me.URLColumnHeader, "URLColumnHeader")
        '
        'VisitDateColumnHeader
        '
        resources.ApplyResources(Me.VisitDateColumnHeader, "VisitDateColumnHeader")
        '
        'HistoryFaviconImageList
        '
        Me.HistoryFaviconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.HistoryFaviconImageList, "HistoryFaviconImageList")
        Me.HistoryFaviconImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'DeleteButton
        '
        resources.ApplyResources(Me.DeleteButton, "DeleteButton")
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'OpenPageButton
        '
        resources.ApplyResources(Me.OpenPageButton, "OpenPageButton")
        Me.OpenPageButton.Name = "OpenPageButton"
        Me.OpenPageButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageHistory)
        Me.TabControl1.Controls.Add(Me.TabPageFavorites)
        Me.TabControl1.Controls.Add(Me.TabPageSearchHistory)
        Me.TabControl1.Controls.Add(Me.TabPageDownloads)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPageHistory
        '
        Me.TabPageHistory.Controls.Add(Me.HistoryListView)
        Me.TabPageHistory.Controls.Add(Me.DeleteButton)
        Me.TabPageHistory.Controls.Add(Me.OpenPageButton)
        resources.ApplyResources(Me.TabPageHistory, "TabPageHistory")
        Me.TabPageHistory.Name = "TabPageHistory"
        Me.TabPageHistory.UseVisualStyleBackColor = True
        '
        'TabPageFavorites
        '
        Me.TabPageFavorites.Controls.Add(Me.ButtonDeleteFavorite)
        Me.TabPageFavorites.Controls.Add(Me.ButtonOpenFavorite)
        Me.TabPageFavorites.Controls.Add(Me.ListViewFavorites)
        resources.ApplyResources(Me.TabPageFavorites, "TabPageFavorites")
        Me.TabPageFavorites.Name = "TabPageFavorites"
        Me.TabPageFavorites.UseVisualStyleBackColor = True
        '
        'ButtonDeleteFavorite
        '
        resources.ApplyResources(Me.ButtonDeleteFavorite, "ButtonDeleteFavorite")
        Me.ButtonDeleteFavorite.Name = "ButtonDeleteFavorite"
        Me.ButtonDeleteFavorite.UseVisualStyleBackColor = True
        '
        'ButtonOpenFavorite
        '
        resources.ApplyResources(Me.ButtonOpenFavorite, "ButtonOpenFavorite")
        Me.ButtonOpenFavorite.Name = "ButtonOpenFavorite"
        Me.ButtonOpenFavorite.UseVisualStyleBackColor = True
        '
        'ListViewFavorites
        '
        resources.ApplyResources(Me.ListViewFavorites, "ListViewFavorites")
        Me.ListViewFavorites.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderTitle, Me.ColumnHeaderURL})
        Me.ListViewFavorites.FullRowSelect = True
        Me.ListViewFavorites.HideSelection = False
        Me.ListViewFavorites.Name = "ListViewFavorites"
        Me.ListViewFavorites.UseCompatibleStateImageBehavior = False
        Me.ListViewFavorites.View = System.Windows.Forms.View.Details
        '
        'ColumnHeaderTitle
        '
        resources.ApplyResources(Me.ColumnHeaderTitle, "ColumnHeaderTitle")
        '
        'ColumnHeaderURL
        '
        resources.ApplyResources(Me.ColumnHeaderURL, "ColumnHeaderURL")
        '
        'TabPageSearchHistory
        '
        Me.TabPageSearchHistory.Controls.Add(Me.SearchHistoryListView)
        Me.TabPageSearchHistory.Controls.Add(Me.ButtonDeleteSearch)
        Me.TabPageSearchHistory.Controls.Add(Me.ButtonSearchAgain)
        resources.ApplyResources(Me.TabPageSearchHistory, "TabPageSearchHistory")
        Me.TabPageSearchHistory.Name = "TabPageSearchHistory"
        Me.TabPageSearchHistory.UseVisualStyleBackColor = True
        '
        'SearchHistoryListView
        '
        resources.ApplyResources(Me.SearchHistoryListView, "SearchHistoryListView")
        Me.SearchHistoryListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Query, Me.CreationDate})
        Me.SearchHistoryListView.HideSelection = False
        Me.SearchHistoryListView.Name = "SearchHistoryListView"
        Me.SearchHistoryListView.UseCompatibleStateImageBehavior = False
        Me.SearchHistoryListView.View = System.Windows.Forms.View.Details
        '
        'Query
        '
        resources.ApplyResources(Me.Query, "Query")
        '
        'CreationDate
        '
        resources.ApplyResources(Me.CreationDate, "CreationDate")
        '
        'ButtonDeleteSearch
        '
        resources.ApplyResources(Me.ButtonDeleteSearch, "ButtonDeleteSearch")
        Me.ButtonDeleteSearch.Name = "ButtonDeleteSearch"
        Me.ButtonDeleteSearch.UseVisualStyleBackColor = True
        '
        'ButtonSearchAgain
        '
        resources.ApplyResources(Me.ButtonSearchAgain, "ButtonSearchAgain")
        Me.ButtonSearchAgain.Name = "ButtonSearchAgain"
        Me.ButtonSearchAgain.UseVisualStyleBackColor = True
        '
        'TabPageDownloads
        '
        Me.TabPageDownloads.Controls.Add(Me.DownloadedItemsListView)
        Me.TabPageDownloads.Controls.Add(Me.ButtonDeleteDownload)
        Me.TabPageDownloads.Controls.Add(Me.ButtonDownloadAgain)
        resources.ApplyResources(Me.TabPageDownloads, "TabPageDownloads")
        Me.TabPageDownloads.Name = "TabPageDownloads"
        Me.TabPageDownloads.UseVisualStyleBackColor = True
        '
        'ButtonDeleteDownload
        '
        resources.ApplyResources(Me.ButtonDeleteDownload, "ButtonDeleteDownload")
        Me.ButtonDeleteDownload.Name = "ButtonDeleteDownload"
        Me.ButtonDeleteDownload.UseVisualStyleBackColor = True
        '
        'ButtonDownloadAgain
        '
        resources.ApplyResources(Me.ButtonDownloadAgain, "ButtonDownloadAgain")
        Me.ButtonDownloadAgain.Name = "ButtonDownloadAgain"
        Me.ButtonDownloadAgain.UseVisualStyleBackColor = True
        '
        'FavoritesFaviconImageList
        '
        Me.FavoritesFaviconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        resources.ApplyResources(Me.FavoritesFaviconImageList, "FavoritesFaviconImageList")
        Me.FavoritesFaviconImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FichierToolStripMenuItem, Me.AffichageToolStripMenuItem, Me.ToolStripMenuItem1})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        resources.ApplyResources(Me.FichierToolStripMenuItem, "FichierToolStripMenuItem")
        '
        'FermerToolStripMenuItem
        '
        Me.FermerToolStripMenuItem.Name = "FermerToolStripMenuItem"
        resources.ApplyResources(Me.FermerToolStripMenuItem, "FermerToolStripMenuItem")
        '
        'AffichageToolStripMenuItem
        '
        Me.AffichageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RafraîchirLesListesToolStripMenuItem})
        Me.AffichageToolStripMenuItem.Name = "AffichageToolStripMenuItem"
        resources.ApplyResources(Me.AffichageToolStripMenuItem, "AffichageToolStripMenuItem")
        '
        'RafraîchirLesListesToolStripMenuItem
        '
        Me.RafraîchirLesListesToolStripMenuItem.Image = Global.SmartNet_Browser.My.Resources.Resources.RefreshBlack
        Me.RafraîchirLesListesToolStripMenuItem.Name = "RafraîchirLesListesToolStripMenuItem"
        resources.ApplyResources(Me.RafraîchirLesListesToolStripMenuItem, "RafraîchirLesListesToolStripMenuItem")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AProposDeSmartNetBrowserToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'AProposDeSmartNetBrowserToolStripMenuItem
        '
        Me.AProposDeSmartNetBrowserToolStripMenuItem.Name = "AProposDeSmartNetBrowserToolStripMenuItem"
        resources.ApplyResources(Me.AProposDeSmartNetBrowserToolStripMenuItem, "AProposDeSmartNetBrowserToolStripMenuItem")
        '
        'DownloadedItemsListView
        '
        resources.ApplyResources(Me.DownloadedItemsListView, "DownloadedItemsListView")
        Me.DownloadedItemsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DownloadedItemUri, Me.DownloadedItemTitle, Me.DownloadedItemCreationDate})
        Me.DownloadedItemsListView.HideSelection = False
        Me.DownloadedItemsListView.Name = "DownloadedItemsListView"
        Me.DownloadedItemsListView.UseCompatibleStateImageBehavior = False
        Me.DownloadedItemsListView.View = System.Windows.Forms.View.Details
        '
        'DownloadedItemUri
        '
        resources.ApplyResources(Me.DownloadedItemUri, "DownloadedItemUri")
        '
        'DownloadedItemTitle
        '
        resources.ApplyResources(Me.DownloadedItemTitle, "DownloadedItemTitle")
        '
        'DownloadedItemCreationDate
        '
        resources.ApplyResources(Me.DownloadedItemCreationDate, "DownloadedItemCreationDate")
        '
        'UserDataLibraryForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "UserDataLibraryForm"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageHistory.ResumeLayout(False)
        Me.TabPageFavorites.ResumeLayout(False)
        Me.TabPageSearchHistory.ResumeLayout(False)
        Me.TabPageDownloads.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents HistoryListView As ListView
    Friend WithEvents TitleColumnHeader As ColumnHeader
    Friend WithEvents URLColumnHeader As ColumnHeader
    Friend WithEvents HistoryFaviconImageList As ImageList
    Friend WithEvents DeleteButton As Button
    Friend WithEvents OpenPageButton As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageHistory As TabPage
    Friend WithEvents TabPageFavorites As TabPage
    Friend WithEvents ListViewFavorites As ListView
    Friend WithEvents ColumnHeaderTitle As ColumnHeader
    Friend WithEvents ColumnHeaderURL As ColumnHeader
    Friend WithEvents TabPageSearchHistory As TabPage
    Friend WithEvents TabPageDownloads As TabPage
    Friend WithEvents FavoritesFaviconImageList As ImageList
    Friend WithEvents ButtonDeleteFavorite As Button
    Friend WithEvents ButtonOpenFavorite As Button
    Friend WithEvents ButtonSearchAgain As Button
    Friend WithEvents ButtonDeleteSearch As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AffichageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FermerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RafraîchirLesListesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AProposDeSmartNetBrowserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ButtonDeleteDownload As Button
    Friend WithEvents ButtonDownloadAgain As Button
    Friend WithEvents VisitDateColumnHeader As ColumnHeader
    Friend WithEvents SearchHistoryListView As ListView
    Friend WithEvents Query As ColumnHeader
    Friend WithEvents CreationDate As ColumnHeader
    Friend WithEvents DownloadedItemsListView As ListView
    Friend WithEvents DownloadedItemUri As ColumnHeader
    Friend WithEvents DownloadedItemTitle As ColumnHeader
    Friend WithEvents DownloadedItemCreationDate As ColumnHeader
End Class
