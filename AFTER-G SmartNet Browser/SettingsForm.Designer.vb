<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsForm))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Général = New System.Windows.Forms.TabPage()
        Me.AutresOptionsGroupBox = New System.Windows.Forms.GroupBox()
        Me.PreventMultipleTabsCloseCheckBox = New System.Windows.Forms.CheckBox()
        Me.SearchEngineGroupBox = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.CustomSearchSettingsButton = New System.Windows.Forms.Button()
        Me.RadioButton0 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.HomepageGroupBox = New System.Windows.Forms.GroupBox()
        Me.WhitePageHomepageButton = New System.Windows.Forms.Button()
        Me.ActualPageURLHomepageButton = New System.Windows.Forms.Button()
        Me.MenuURLHomepageButton = New System.Windows.Forms.Button()
        Me.HomepageURLBox = New System.Windows.Forms.TextBox()
        Me.Confidentialité = New System.Windows.Forms.TabPage()
        Me.DeleteDataGroupBox = New System.Windows.Forms.GroupBox()
        Me.DeleteSearchHistoryButton = New System.Windows.Forms.Button()
        Me.DeleteTemporaryInternetFilesButton = New System.Windows.Forms.Button()
        Me.DeleteCookiesButton = New System.Windows.Forms.Button()
        Me.DeleteHistoryButton = New System.Windows.Forms.Button()
        Me.HistoryGroupBox = New System.Windows.Forms.GroupBox()
        Me.CookiesLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.EraseCookiesCheckBox = New System.Windows.Forms.CheckBox()
        Me.PrivateBrowsingCheckBox = New System.Windows.Forms.CheckBox()
        Me.SecurityTabPage = New System.Windows.Forms.TabPage()
        Me.BrowserSettingsSecurityGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ChangeBrowserSettingsSecurityPasswordButton = New System.Windows.Forms.Button()
        Me.BrowserSettingsSecurityCheckBox = New System.Windows.Forms.CheckBox()
        Me.ChildrenProtectionGroupBox = New System.Windows.Forms.GroupBox()
        Me.ChildGuardProblemSignalementButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChangeChildrenProtectionPasswordButton = New System.Windows.Forms.Button()
        Me.ChildrenProtectionCheckBox = New System.Windows.Forms.CheckBox()
        Me.AdBlockerTabPage = New System.Windows.Forms.TabPage()
        Me.AdsBlockerProblemSignalementButton = New System.Windows.Forms.Button()
        Me.PopUpsBlockerCheckBox = New System.Windows.Forms.CheckBox()
        Me.EditWhitelistButton = New System.Windows.Forms.Button()
        Me.AdBlockerCheckBox = New System.Windows.Forms.CheckBox()
        Me.MisesàJour = New System.Windows.Forms.TabPage()
        Me.UpdatesGroupBox = New System.Windows.Forms.GroupBox()
        Me.CheckUpdatesNowButton = New System.Windows.Forms.Button()
        Me.VersionActuelleLabel = New System.Windows.Forms.Label()
        Me.AutoUpdateGroupBox = New System.Windows.Forms.GroupBox()
        Me.AutoUpdateCheckBox = New System.Windows.Forms.CheckBox()
        Me.Avancé = New System.Windows.Forms.TabPage()
        Me.LanguageGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LanguagesComboBox = New System.Windows.Forms.ComboBox()
        Me.DevelopmentGroupBox = New System.Windows.Forms.GroupBox()
        Me.ChangeUserAgentLinkLabel = New System.Windows.Forms.LinkLabel()
        Me.UserAgentTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DisplayExceptionsCheckBox = New System.Windows.Forms.CheckBox()
        Me.FirstStartDialogButton = New System.Windows.Forms.Button()
        Me.RepareBrowserGroupBox = New System.Windows.Forms.GroupBox()
        Me.RepareBrowserButton = New System.Windows.Forms.Button()
        Me.SettingsSavesGroupBox = New System.Windows.Forms.GroupBox()
        Me.ImportSettingsButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AbortButton = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.Général.SuspendLayout()
        Me.AutresOptionsGroupBox.SuspendLayout()
        Me.SearchEngineGroupBox.SuspendLayout()
        Me.HomepageGroupBox.SuspendLayout()
        Me.Confidentialité.SuspendLayout()
        Me.DeleteDataGroupBox.SuspendLayout()
        Me.HistoryGroupBox.SuspendLayout()
        Me.SecurityTabPage.SuspendLayout()
        Me.BrowserSettingsSecurityGroupBox.SuspendLayout()
        Me.ChildrenProtectionGroupBox.SuspendLayout()
        Me.AdBlockerTabPage.SuspendLayout()
        Me.MisesàJour.SuspendLayout()
        Me.UpdatesGroupBox.SuspendLayout()
        Me.AutoUpdateGroupBox.SuspendLayout()
        Me.Avancé.SuspendLayout()
        Me.LanguageGroupBox.SuspendLayout()
        Me.DevelopmentGroupBox.SuspendLayout()
        Me.RepareBrowserGroupBox.SuspendLayout()
        Me.SettingsSavesGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.Général)
        Me.TabControl1.Controls.Add(Me.Confidentialité)
        Me.TabControl1.Controls.Add(Me.SecurityTabPage)
        Me.TabControl1.Controls.Add(Me.AdBlockerTabPage)
        Me.TabControl1.Controls.Add(Me.MisesàJour)
        Me.TabControl1.Controls.Add(Me.Avancé)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'Général
        '
        resources.ApplyResources(Me.Général, "Général")
        Me.Général.Controls.Add(Me.AutresOptionsGroupBox)
        Me.Général.Controls.Add(Me.SearchEngineGroupBox)
        Me.Général.Controls.Add(Me.HomepageGroupBox)
        Me.Général.Name = "Général"
        Me.Général.UseVisualStyleBackColor = True
        '
        'AutresOptionsGroupBox
        '
        resources.ApplyResources(Me.AutresOptionsGroupBox, "AutresOptionsGroupBox")
        Me.AutresOptionsGroupBox.Controls.Add(Me.PreventMultipleTabsCloseCheckBox)
        Me.AutresOptionsGroupBox.Name = "AutresOptionsGroupBox"
        Me.AutresOptionsGroupBox.TabStop = False
        '
        'PreventMultipleTabsCloseCheckBox
        '
        resources.ApplyResources(Me.PreventMultipleTabsCloseCheckBox, "PreventMultipleTabsCloseCheckBox")
        Me.PreventMultipleTabsCloseCheckBox.Checked = True
        Me.PreventMultipleTabsCloseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PreventMultipleTabsCloseCheckBox.Name = "PreventMultipleTabsCloseCheckBox"
        Me.PreventMultipleTabsCloseCheckBox.UseVisualStyleBackColor = True
        '
        'SearchEngineGroupBox
        '
        resources.ApplyResources(Me.SearchEngineGroupBox, "SearchEngineGroupBox")
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton5)
        Me.SearchEngineGroupBox.Controls.Add(Me.CustomSearchSettingsButton)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton0)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton4)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton3)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton2)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton1)
        Me.SearchEngineGroupBox.Name = "SearchEngineGroupBox"
        Me.SearchEngineGroupBox.TabStop = False
        '
        'RadioButton5
        '
        resources.ApplyResources(Me.RadioButton5, "RadioButton5")
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'CustomSearchSettingsButton
        '
        resources.ApplyResources(Me.CustomSearchSettingsButton, "CustomSearchSettingsButton")
        Me.CustomSearchSettingsButton.Name = "CustomSearchSettingsButton"
        Me.CustomSearchSettingsButton.UseVisualStyleBackColor = True
        '
        'RadioButton0
        '
        resources.ApplyResources(Me.RadioButton0, "RadioButton0")
        Me.RadioButton0.Name = "RadioButton0"
        Me.RadioButton0.TabStop = True
        Me.RadioButton0.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        resources.ApplyResources(Me.RadioButton4, "RadioButton4")
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'HomepageGroupBox
        '
        resources.ApplyResources(Me.HomepageGroupBox, "HomepageGroupBox")
        Me.HomepageGroupBox.Controls.Add(Me.WhitePageHomepageButton)
        Me.HomepageGroupBox.Controls.Add(Me.ActualPageURLHomepageButton)
        Me.HomepageGroupBox.Controls.Add(Me.MenuURLHomepageButton)
        Me.HomepageGroupBox.Controls.Add(Me.HomepageURLBox)
        Me.HomepageGroupBox.Name = "HomepageGroupBox"
        Me.HomepageGroupBox.TabStop = False
        '
        'WhitePageHomepageButton
        '
        resources.ApplyResources(Me.WhitePageHomepageButton, "WhitePageHomepageButton")
        Me.WhitePageHomepageButton.Name = "WhitePageHomepageButton"
        Me.WhitePageHomepageButton.UseVisualStyleBackColor = True
        '
        'ActualPageURLHomepageButton
        '
        resources.ApplyResources(Me.ActualPageURLHomepageButton, "ActualPageURLHomepageButton")
        Me.ActualPageURLHomepageButton.Name = "ActualPageURLHomepageButton"
        Me.ActualPageURLHomepageButton.UseVisualStyleBackColor = True
        '
        'MenuURLHomepageButton
        '
        resources.ApplyResources(Me.MenuURLHomepageButton, "MenuURLHomepageButton")
        Me.MenuURLHomepageButton.Name = "MenuURLHomepageButton"
        Me.MenuURLHomepageButton.UseVisualStyleBackColor = True
        '
        'HomepageURLBox
        '
        resources.ApplyResources(Me.HomepageURLBox, "HomepageURLBox")
        Me.HomepageURLBox.Name = "HomepageURLBox"
        '
        'Confidentialité
        '
        resources.ApplyResources(Me.Confidentialité, "Confidentialité")
        Me.Confidentialité.Controls.Add(Me.DeleteDataGroupBox)
        Me.Confidentialité.Controls.Add(Me.HistoryGroupBox)
        Me.Confidentialité.Name = "Confidentialité"
        Me.Confidentialité.UseVisualStyleBackColor = True
        '
        'DeleteDataGroupBox
        '
        resources.ApplyResources(Me.DeleteDataGroupBox, "DeleteDataGroupBox")
        Me.DeleteDataGroupBox.Controls.Add(Me.DeleteSearchHistoryButton)
        Me.DeleteDataGroupBox.Controls.Add(Me.DeleteTemporaryInternetFilesButton)
        Me.DeleteDataGroupBox.Controls.Add(Me.DeleteCookiesButton)
        Me.DeleteDataGroupBox.Controls.Add(Me.DeleteHistoryButton)
        Me.DeleteDataGroupBox.Name = "DeleteDataGroupBox"
        Me.DeleteDataGroupBox.TabStop = False
        '
        'DeleteSearchHistoryButton
        '
        resources.ApplyResources(Me.DeleteSearchHistoryButton, "DeleteSearchHistoryButton")
        Me.DeleteSearchHistoryButton.Name = "DeleteSearchHistoryButton"
        Me.DeleteSearchHistoryButton.UseVisualStyleBackColor = True
        '
        'DeleteTemporaryInternetFilesButton
        '
        resources.ApplyResources(Me.DeleteTemporaryInternetFilesButton, "DeleteTemporaryInternetFilesButton")
        Me.DeleteTemporaryInternetFilesButton.Name = "DeleteTemporaryInternetFilesButton"
        Me.DeleteTemporaryInternetFilesButton.UseVisualStyleBackColor = True
        '
        'DeleteCookiesButton
        '
        resources.ApplyResources(Me.DeleteCookiesButton, "DeleteCookiesButton")
        Me.DeleteCookiesButton.Name = "DeleteCookiesButton"
        Me.DeleteCookiesButton.UseVisualStyleBackColor = True
        '
        'DeleteHistoryButton
        '
        resources.ApplyResources(Me.DeleteHistoryButton, "DeleteHistoryButton")
        Me.DeleteHistoryButton.Name = "DeleteHistoryButton"
        Me.DeleteHistoryButton.UseVisualStyleBackColor = True
        '
        'HistoryGroupBox
        '
        resources.ApplyResources(Me.HistoryGroupBox, "HistoryGroupBox")
        Me.HistoryGroupBox.Controls.Add(Me.CookiesLinkLabel)
        Me.HistoryGroupBox.Controls.Add(Me.EraseCookiesCheckBox)
        Me.HistoryGroupBox.Controls.Add(Me.PrivateBrowsingCheckBox)
        Me.HistoryGroupBox.Name = "HistoryGroupBox"
        Me.HistoryGroupBox.TabStop = False
        '
        'CookiesLinkLabel
        '
        resources.ApplyResources(Me.CookiesLinkLabel, "CookiesLinkLabel")
        Me.CookiesLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.HotTrack
        Me.CookiesLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CookiesLinkLabel.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.CookiesLinkLabel.Name = "CookiesLinkLabel"
        Me.CookiesLinkLabel.TabStop = True
        Me.CookiesLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.HotTrack
        '
        'EraseCookiesCheckBox
        '
        resources.ApplyResources(Me.EraseCookiesCheckBox, "EraseCookiesCheckBox")
        Me.EraseCookiesCheckBox.Name = "EraseCookiesCheckBox"
        Me.EraseCookiesCheckBox.UseVisualStyleBackColor = True
        '
        'PrivateBrowsingCheckBox
        '
        resources.ApplyResources(Me.PrivateBrowsingCheckBox, "PrivateBrowsingCheckBox")
        Me.PrivateBrowsingCheckBox.Checked = True
        Me.PrivateBrowsingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PrivateBrowsingCheckBox.Name = "PrivateBrowsingCheckBox"
        Me.PrivateBrowsingCheckBox.UseVisualStyleBackColor = True
        '
        'SecurityTabPage
        '
        resources.ApplyResources(Me.SecurityTabPage, "SecurityTabPage")
        Me.SecurityTabPage.Controls.Add(Me.BrowserSettingsSecurityGroupBox)
        Me.SecurityTabPage.Controls.Add(Me.ChildrenProtectionGroupBox)
        Me.SecurityTabPage.Name = "SecurityTabPage"
        Me.SecurityTabPage.UseVisualStyleBackColor = True
        '
        'BrowserSettingsSecurityGroupBox
        '
        resources.ApplyResources(Me.BrowserSettingsSecurityGroupBox, "BrowserSettingsSecurityGroupBox")
        Me.BrowserSettingsSecurityGroupBox.Controls.Add(Me.Label4)
        Me.BrowserSettingsSecurityGroupBox.Controls.Add(Me.ChangeBrowserSettingsSecurityPasswordButton)
        Me.BrowserSettingsSecurityGroupBox.Controls.Add(Me.BrowserSettingsSecurityCheckBox)
        Me.BrowserSettingsSecurityGroupBox.Name = "BrowserSettingsSecurityGroupBox"
        Me.BrowserSettingsSecurityGroupBox.TabStop = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'ChangeBrowserSettingsSecurityPasswordButton
        '
        resources.ApplyResources(Me.ChangeBrowserSettingsSecurityPasswordButton, "ChangeBrowserSettingsSecurityPasswordButton")
        Me.ChangeBrowserSettingsSecurityPasswordButton.Name = "ChangeBrowserSettingsSecurityPasswordButton"
        Me.ChangeBrowserSettingsSecurityPasswordButton.UseVisualStyleBackColor = True
        '
        'BrowserSettingsSecurityCheckBox
        '
        resources.ApplyResources(Me.BrowserSettingsSecurityCheckBox, "BrowserSettingsSecurityCheckBox")
        Me.BrowserSettingsSecurityCheckBox.Name = "BrowserSettingsSecurityCheckBox"
        Me.BrowserSettingsSecurityCheckBox.UseVisualStyleBackColor = True
        '
        'ChildrenProtectionGroupBox
        '
        resources.ApplyResources(Me.ChildrenProtectionGroupBox, "ChildrenProtectionGroupBox")
        Me.ChildrenProtectionGroupBox.Controls.Add(Me.ChildGuardProblemSignalementButton)
        Me.ChildrenProtectionGroupBox.Controls.Add(Me.Label3)
        Me.ChildrenProtectionGroupBox.Controls.Add(Me.ChangeChildrenProtectionPasswordButton)
        Me.ChildrenProtectionGroupBox.Controls.Add(Me.ChildrenProtectionCheckBox)
        Me.ChildrenProtectionGroupBox.Name = "ChildrenProtectionGroupBox"
        Me.ChildrenProtectionGroupBox.TabStop = False
        '
        'ChildGuardProblemSignalementButton
        '
        resources.ApplyResources(Me.ChildGuardProblemSignalementButton, "ChildGuardProblemSignalementButton")
        Me.ChildGuardProblemSignalementButton.Name = "ChildGuardProblemSignalementButton"
        Me.ChildGuardProblemSignalementButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'ChangeChildrenProtectionPasswordButton
        '
        resources.ApplyResources(Me.ChangeChildrenProtectionPasswordButton, "ChangeChildrenProtectionPasswordButton")
        Me.ChangeChildrenProtectionPasswordButton.Name = "ChangeChildrenProtectionPasswordButton"
        Me.ChangeChildrenProtectionPasswordButton.UseVisualStyleBackColor = True
        '
        'ChildrenProtectionCheckBox
        '
        resources.ApplyResources(Me.ChildrenProtectionCheckBox, "ChildrenProtectionCheckBox")
        Me.ChildrenProtectionCheckBox.Name = "ChildrenProtectionCheckBox"
        Me.ChildrenProtectionCheckBox.UseVisualStyleBackColor = True
        '
        'AdBlockerTabPage
        '
        resources.ApplyResources(Me.AdBlockerTabPage, "AdBlockerTabPage")
        Me.AdBlockerTabPage.Controls.Add(Me.AdsBlockerProblemSignalementButton)
        Me.AdBlockerTabPage.Controls.Add(Me.PopUpsBlockerCheckBox)
        Me.AdBlockerTabPage.Controls.Add(Me.EditWhitelistButton)
        Me.AdBlockerTabPage.Controls.Add(Me.AdBlockerCheckBox)
        Me.AdBlockerTabPage.Name = "AdBlockerTabPage"
        Me.AdBlockerTabPage.UseVisualStyleBackColor = True
        '
        'AdsBlockerProblemSignalementButton
        '
        resources.ApplyResources(Me.AdsBlockerProblemSignalementButton, "AdsBlockerProblemSignalementButton")
        Me.AdsBlockerProblemSignalementButton.Name = "AdsBlockerProblemSignalementButton"
        Me.AdsBlockerProblemSignalementButton.UseVisualStyleBackColor = True
        '
        'PopUpsBlockerCheckBox
        '
        resources.ApplyResources(Me.PopUpsBlockerCheckBox, "PopUpsBlockerCheckBox")
        Me.PopUpsBlockerCheckBox.Name = "PopUpsBlockerCheckBox"
        Me.PopUpsBlockerCheckBox.UseVisualStyleBackColor = True
        '
        'EditWhitelistButton
        '
        resources.ApplyResources(Me.EditWhitelistButton, "EditWhitelistButton")
        Me.EditWhitelistButton.Name = "EditWhitelistButton"
        Me.EditWhitelistButton.UseVisualStyleBackColor = True
        '
        'AdBlockerCheckBox
        '
        resources.ApplyResources(Me.AdBlockerCheckBox, "AdBlockerCheckBox")
        Me.AdBlockerCheckBox.Name = "AdBlockerCheckBox"
        Me.AdBlockerCheckBox.UseVisualStyleBackColor = True
        '
        'MisesàJour
        '
        resources.ApplyResources(Me.MisesàJour, "MisesàJour")
        Me.MisesàJour.Controls.Add(Me.UpdatesGroupBox)
        Me.MisesàJour.Controls.Add(Me.AutoUpdateGroupBox)
        Me.MisesàJour.Name = "MisesàJour"
        Me.MisesàJour.UseVisualStyleBackColor = True
        '
        'UpdatesGroupBox
        '
        resources.ApplyResources(Me.UpdatesGroupBox, "UpdatesGroupBox")
        Me.UpdatesGroupBox.Controls.Add(Me.CheckUpdatesNowButton)
        Me.UpdatesGroupBox.Controls.Add(Me.VersionActuelleLabel)
        Me.UpdatesGroupBox.Name = "UpdatesGroupBox"
        Me.UpdatesGroupBox.TabStop = False
        '
        'CheckUpdatesNowButton
        '
        resources.ApplyResources(Me.CheckUpdatesNowButton, "CheckUpdatesNowButton")
        Me.CheckUpdatesNowButton.Name = "CheckUpdatesNowButton"
        Me.CheckUpdatesNowButton.UseVisualStyleBackColor = True
        '
        'VersionActuelleLabel
        '
        resources.ApplyResources(Me.VersionActuelleLabel, "VersionActuelleLabel")
        Me.VersionActuelleLabel.Name = "VersionActuelleLabel"
        '
        'AutoUpdateGroupBox
        '
        resources.ApplyResources(Me.AutoUpdateGroupBox, "AutoUpdateGroupBox")
        Me.AutoUpdateGroupBox.Controls.Add(Me.AutoUpdateCheckBox)
        Me.AutoUpdateGroupBox.Name = "AutoUpdateGroupBox"
        Me.AutoUpdateGroupBox.TabStop = False
        '
        'AutoUpdateCheckBox
        '
        resources.ApplyResources(Me.AutoUpdateCheckBox, "AutoUpdateCheckBox")
        Me.AutoUpdateCheckBox.Checked = True
        Me.AutoUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoUpdateCheckBox.Name = "AutoUpdateCheckBox"
        Me.AutoUpdateCheckBox.UseVisualStyleBackColor = True
        '
        'Avancé
        '
        resources.ApplyResources(Me.Avancé, "Avancé")
        Me.Avancé.Controls.Add(Me.LanguageGroupBox)
        Me.Avancé.Controls.Add(Me.DevelopmentGroupBox)
        Me.Avancé.Controls.Add(Me.FirstStartDialogButton)
        Me.Avancé.Controls.Add(Me.RepareBrowserGroupBox)
        Me.Avancé.Controls.Add(Me.SettingsSavesGroupBox)
        Me.Avancé.Name = "Avancé"
        Me.Avancé.UseVisualStyleBackColor = True
        '
        'LanguageGroupBox
        '
        resources.ApplyResources(Me.LanguageGroupBox, "LanguageGroupBox")
        Me.LanguageGroupBox.Controls.Add(Me.Label1)
        Me.LanguageGroupBox.Controls.Add(Me.LanguagesComboBox)
        Me.LanguageGroupBox.Name = "LanguageGroupBox"
        Me.LanguageGroupBox.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'LanguagesComboBox
        '
        resources.ApplyResources(Me.LanguagesComboBox, "LanguagesComboBox")
        Me.LanguagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguagesComboBox.Items.AddRange(New Object() {resources.GetString("LanguagesComboBox.Items"), resources.GetString("LanguagesComboBox.Items1"), resources.GetString("LanguagesComboBox.Items2"), resources.GetString("LanguagesComboBox.Items3"), resources.GetString("LanguagesComboBox.Items4"), resources.GetString("LanguagesComboBox.Items5"), resources.GetString("LanguagesComboBox.Items6"), resources.GetString("LanguagesComboBox.Items7"), resources.GetString("LanguagesComboBox.Items8"), resources.GetString("LanguagesComboBox.Items9"), resources.GetString("LanguagesComboBox.Items10"), resources.GetString("LanguagesComboBox.Items11"), resources.GetString("LanguagesComboBox.Items12"), resources.GetString("LanguagesComboBox.Items13"), resources.GetString("LanguagesComboBox.Items14"), resources.GetString("LanguagesComboBox.Items15"), resources.GetString("LanguagesComboBox.Items16"), resources.GetString("LanguagesComboBox.Items17"), resources.GetString("LanguagesComboBox.Items18"), resources.GetString("LanguagesComboBox.Items19"), resources.GetString("LanguagesComboBox.Items20"), resources.GetString("LanguagesComboBox.Items21"), resources.GetString("LanguagesComboBox.Items22"), resources.GetString("LanguagesComboBox.Items23"), resources.GetString("LanguagesComboBox.Items24"), resources.GetString("LanguagesComboBox.Items25"), resources.GetString("LanguagesComboBox.Items26"), resources.GetString("LanguagesComboBox.Items27"), resources.GetString("LanguagesComboBox.Items28"), resources.GetString("LanguagesComboBox.Items29"), resources.GetString("LanguagesComboBox.Items30"), resources.GetString("LanguagesComboBox.Items31"), resources.GetString("LanguagesComboBox.Items32"), resources.GetString("LanguagesComboBox.Items33"), resources.GetString("LanguagesComboBox.Items34"), resources.GetString("LanguagesComboBox.Items35"), resources.GetString("LanguagesComboBox.Items36"), resources.GetString("LanguagesComboBox.Items37"), resources.GetString("LanguagesComboBox.Items38"), resources.GetString("LanguagesComboBox.Items39"), resources.GetString("LanguagesComboBox.Items40"), resources.GetString("LanguagesComboBox.Items41"), resources.GetString("LanguagesComboBox.Items42"), resources.GetString("LanguagesComboBox.Items43"), resources.GetString("LanguagesComboBox.Items44"), resources.GetString("LanguagesComboBox.Items45"), resources.GetString("LanguagesComboBox.Items46"), resources.GetString("LanguagesComboBox.Items47"), resources.GetString("LanguagesComboBox.Items48"), resources.GetString("LanguagesComboBox.Items49"), resources.GetString("LanguagesComboBox.Items50"), resources.GetString("LanguagesComboBox.Items51"), resources.GetString("LanguagesComboBox.Items52"), resources.GetString("LanguagesComboBox.Items53"), resources.GetString("LanguagesComboBox.Items54"), resources.GetString("LanguagesComboBox.Items55"), resources.GetString("LanguagesComboBox.Items56"), resources.GetString("LanguagesComboBox.Items57"), resources.GetString("LanguagesComboBox.Items58"), resources.GetString("LanguagesComboBox.Items59"), resources.GetString("LanguagesComboBox.Items60"), resources.GetString("LanguagesComboBox.Items61"), resources.GetString("LanguagesComboBox.Items62"), resources.GetString("LanguagesComboBox.Items63"), resources.GetString("LanguagesComboBox.Items64"), resources.GetString("LanguagesComboBox.Items65"), resources.GetString("LanguagesComboBox.Items66"), resources.GetString("LanguagesComboBox.Items67"), resources.GetString("LanguagesComboBox.Items68"), resources.GetString("LanguagesComboBox.Items69"), resources.GetString("LanguagesComboBox.Items70"), resources.GetString("LanguagesComboBox.Items71"), resources.GetString("LanguagesComboBox.Items72"), resources.GetString("LanguagesComboBox.Items73"), resources.GetString("LanguagesComboBox.Items74"), resources.GetString("LanguagesComboBox.Items75"), resources.GetString("LanguagesComboBox.Items76"), resources.GetString("LanguagesComboBox.Items77"), resources.GetString("LanguagesComboBox.Items78"), resources.GetString("LanguagesComboBox.Items79"), resources.GetString("LanguagesComboBox.Items80"), resources.GetString("LanguagesComboBox.Items81"), resources.GetString("LanguagesComboBox.Items82"), resources.GetString("LanguagesComboBox.Items83"), resources.GetString("LanguagesComboBox.Items84"), resources.GetString("LanguagesComboBox.Items85"), resources.GetString("LanguagesComboBox.Items86"), resources.GetString("LanguagesComboBox.Items87"), resources.GetString("LanguagesComboBox.Items88"), resources.GetString("LanguagesComboBox.Items89"), resources.GetString("LanguagesComboBox.Items90"), resources.GetString("LanguagesComboBox.Items91"), resources.GetString("LanguagesComboBox.Items92"), resources.GetString("LanguagesComboBox.Items93"), resources.GetString("LanguagesComboBox.Items94"), resources.GetString("LanguagesComboBox.Items95"), resources.GetString("LanguagesComboBox.Items96"), resources.GetString("LanguagesComboBox.Items97"), resources.GetString("LanguagesComboBox.Items98"), resources.GetString("LanguagesComboBox.Items99"), resources.GetString("LanguagesComboBox.Items100"), resources.GetString("LanguagesComboBox.Items101"), resources.GetString("LanguagesComboBox.Items102"), resources.GetString("LanguagesComboBox.Items103"), resources.GetString("LanguagesComboBox.Items104"), resources.GetString("LanguagesComboBox.Items105"), resources.GetString("LanguagesComboBox.Items106"), resources.GetString("LanguagesComboBox.Items107"), resources.GetString("LanguagesComboBox.Items108"), resources.GetString("LanguagesComboBox.Items109"), resources.GetString("LanguagesComboBox.Items110"), resources.GetString("LanguagesComboBox.Items111"), resources.GetString("LanguagesComboBox.Items112"), resources.GetString("LanguagesComboBox.Items113"), resources.GetString("LanguagesComboBox.Items114"), resources.GetString("LanguagesComboBox.Items115"), resources.GetString("LanguagesComboBox.Items116"), resources.GetString("LanguagesComboBox.Items117"), resources.GetString("LanguagesComboBox.Items118"), resources.GetString("LanguagesComboBox.Items119"), resources.GetString("LanguagesComboBox.Items120"), resources.GetString("LanguagesComboBox.Items121"), resources.GetString("LanguagesComboBox.Items122"), resources.GetString("LanguagesComboBox.Items123"), resources.GetString("LanguagesComboBox.Items124"), resources.GetString("LanguagesComboBox.Items125"), resources.GetString("LanguagesComboBox.Items126"), resources.GetString("LanguagesComboBox.Items127"), resources.GetString("LanguagesComboBox.Items128"), resources.GetString("LanguagesComboBox.Items129"), resources.GetString("LanguagesComboBox.Items130"), resources.GetString("LanguagesComboBox.Items131"), resources.GetString("LanguagesComboBox.Items132"), resources.GetString("LanguagesComboBox.Items133"), resources.GetString("LanguagesComboBox.Items134"), resources.GetString("LanguagesComboBox.Items135"), resources.GetString("LanguagesComboBox.Items136"), resources.GetString("LanguagesComboBox.Items137"), resources.GetString("LanguagesComboBox.Items138"), resources.GetString("LanguagesComboBox.Items139"), resources.GetString("LanguagesComboBox.Items140"), resources.GetString("LanguagesComboBox.Items141"), resources.GetString("LanguagesComboBox.Items142"), resources.GetString("LanguagesComboBox.Items143"), resources.GetString("LanguagesComboBox.Items144"), resources.GetString("LanguagesComboBox.Items145"), resources.GetString("LanguagesComboBox.Items146"), resources.GetString("LanguagesComboBox.Items147"), resources.GetString("LanguagesComboBox.Items148"), resources.GetString("LanguagesComboBox.Items149"), resources.GetString("LanguagesComboBox.Items150"), resources.GetString("LanguagesComboBox.Items151"), resources.GetString("LanguagesComboBox.Items152"), resources.GetString("LanguagesComboBox.Items153"), resources.GetString("LanguagesComboBox.Items154"), resources.GetString("LanguagesComboBox.Items155"), resources.GetString("LanguagesComboBox.Items156"), resources.GetString("LanguagesComboBox.Items157"), resources.GetString("LanguagesComboBox.Items158"), resources.GetString("LanguagesComboBox.Items159"), resources.GetString("LanguagesComboBox.Items160"), resources.GetString("LanguagesComboBox.Items161"), resources.GetString("LanguagesComboBox.Items162"), resources.GetString("LanguagesComboBox.Items163"), resources.GetString("LanguagesComboBox.Items164"), resources.GetString("LanguagesComboBox.Items165"), resources.GetString("LanguagesComboBox.Items166"), resources.GetString("LanguagesComboBox.Items167"), resources.GetString("LanguagesComboBox.Items168"), resources.GetString("LanguagesComboBox.Items169"), resources.GetString("LanguagesComboBox.Items170"), resources.GetString("LanguagesComboBox.Items171"), resources.GetString("LanguagesComboBox.Items172")})
        Me.LanguagesComboBox.Name = "LanguagesComboBox"
        '
        'DevelopmentGroupBox
        '
        resources.ApplyResources(Me.DevelopmentGroupBox, "DevelopmentGroupBox")
        Me.DevelopmentGroupBox.Controls.Add(Me.ChangeUserAgentLinkLabel)
        Me.DevelopmentGroupBox.Controls.Add(Me.UserAgentTextBox)
        Me.DevelopmentGroupBox.Controls.Add(Me.Label2)
        Me.DevelopmentGroupBox.Controls.Add(Me.DisplayExceptionsCheckBox)
        Me.DevelopmentGroupBox.Name = "DevelopmentGroupBox"
        Me.DevelopmentGroupBox.TabStop = False
        '
        'ChangeUserAgentLinkLabel
        '
        resources.ApplyResources(Me.ChangeUserAgentLinkLabel, "ChangeUserAgentLinkLabel")
        Me.ChangeUserAgentLinkLabel.ActiveLinkColor = System.Drawing.SystemColors.ControlText
        Me.ChangeUserAgentLinkLabel.LinkColor = System.Drawing.SystemColors.ControlText
        Me.ChangeUserAgentLinkLabel.Name = "ChangeUserAgentLinkLabel"
        Me.ChangeUserAgentLinkLabel.TabStop = True
        Me.ChangeUserAgentLinkLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText
        '
        'UserAgentTextBox
        '
        resources.ApplyResources(Me.UserAgentTextBox, "UserAgentTextBox")
        Me.UserAgentTextBox.BackColor = System.Drawing.Color.White
        Me.UserAgentTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserAgentTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.UserAgentTextBox.DetectUrls = False
        Me.UserAgentTextBox.Name = "UserAgentTextBox"
        Me.UserAgentTextBox.ReadOnly = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'DisplayExceptionsCheckBox
        '
        resources.ApplyResources(Me.DisplayExceptionsCheckBox, "DisplayExceptionsCheckBox")
        Me.DisplayExceptionsCheckBox.Name = "DisplayExceptionsCheckBox"
        Me.DisplayExceptionsCheckBox.UseVisualStyleBackColor = True
        '
        'FirstStartDialogButton
        '
        resources.ApplyResources(Me.FirstStartDialogButton, "FirstStartDialogButton")
        Me.FirstStartDialogButton.Name = "FirstStartDialogButton"
        Me.FirstStartDialogButton.UseVisualStyleBackColor = True
        '
        'RepareBrowserGroupBox
        '
        resources.ApplyResources(Me.RepareBrowserGroupBox, "RepareBrowserGroupBox")
        Me.RepareBrowserGroupBox.Controls.Add(Me.RepareBrowserButton)
        Me.RepareBrowserGroupBox.Name = "RepareBrowserGroupBox"
        Me.RepareBrowserGroupBox.TabStop = False
        '
        'RepareBrowserButton
        '
        resources.ApplyResources(Me.RepareBrowserButton, "RepareBrowserButton")
        Me.RepareBrowserButton.Name = "RepareBrowserButton"
        Me.RepareBrowserButton.UseVisualStyleBackColor = True
        '
        'SettingsSavesGroupBox
        '
        resources.ApplyResources(Me.SettingsSavesGroupBox, "SettingsSavesGroupBox")
        Me.SettingsSavesGroupBox.Controls.Add(Me.ImportSettingsButton)
        Me.SettingsSavesGroupBox.Name = "SettingsSavesGroupBox"
        Me.SettingsSavesGroupBox.TabStop = False
        '
        'ImportSettingsButton
        '
        resources.ApplyResources(Me.ImportSettingsButton, "ImportSettingsButton")
        Me.ImportSettingsButton.Name = "ImportSettingsButton"
        Me.ImportSettingsButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'FolderBrowserDialog1
        '
        resources.ApplyResources(Me.FolderBrowserDialog1, "FolderBrowserDialog1")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "Fichier de configuration|*.config"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'AbortButton
        '
        resources.ApplyResources(Me.AbortButton, "AbortButton")
        Me.AbortButton.Name = "AbortButton"
        Me.AbortButton.UseVisualStyleBackColor = True
        '
        'SettingsForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.AbortButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TabControl1.ResumeLayout(False)
        Me.Général.ResumeLayout(False)
        Me.AutresOptionsGroupBox.ResumeLayout(False)
        Me.AutresOptionsGroupBox.PerformLayout()
        Me.SearchEngineGroupBox.ResumeLayout(False)
        Me.SearchEngineGroupBox.PerformLayout()
        Me.HomepageGroupBox.ResumeLayout(False)
        Me.HomepageGroupBox.PerformLayout()
        Me.Confidentialité.ResumeLayout(False)
        Me.DeleteDataGroupBox.ResumeLayout(False)
        Me.HistoryGroupBox.ResumeLayout(False)
        Me.HistoryGroupBox.PerformLayout()
        Me.SecurityTabPage.ResumeLayout(False)
        Me.BrowserSettingsSecurityGroupBox.ResumeLayout(False)
        Me.BrowserSettingsSecurityGroupBox.PerformLayout()
        Me.ChildrenProtectionGroupBox.ResumeLayout(False)
        Me.ChildrenProtectionGroupBox.PerformLayout()
        Me.AdBlockerTabPage.ResumeLayout(False)
        Me.AdBlockerTabPage.PerformLayout()
        Me.MisesàJour.ResumeLayout(False)
        Me.UpdatesGroupBox.ResumeLayout(False)
        Me.UpdatesGroupBox.PerformLayout()
        Me.AutoUpdateGroupBox.ResumeLayout(False)
        Me.AutoUpdateGroupBox.PerformLayout()
        Me.Avancé.ResumeLayout(False)
        Me.LanguageGroupBox.ResumeLayout(False)
        Me.LanguageGroupBox.PerformLayout()
        Me.DevelopmentGroupBox.ResumeLayout(False)
        Me.DevelopmentGroupBox.PerformLayout()
        Me.RepareBrowserGroupBox.ResumeLayout(False)
        Me.SettingsSavesGroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Général As TabPage
    Friend WithEvents AutresOptionsGroupBox As GroupBox
    Friend WithEvents PreventMultipleTabsCloseCheckBox As CheckBox
    Friend WithEvents SearchEngineGroupBox As GroupBox
    Friend WithEvents RadioButton0 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents HomepageGroupBox As GroupBox
    Friend WithEvents WhitePageHomepageButton As Button
    Friend WithEvents ActualPageURLHomepageButton As Button
    Friend WithEvents MenuURLHomepageButton As Button
    Friend WithEvents HomepageURLBox As TextBox
    Friend WithEvents Confidentialité As TabPage
    Friend WithEvents DeleteDataGroupBox As GroupBox
    Friend WithEvents DeleteSearchHistoryButton As Button
    Friend WithEvents DeleteTemporaryInternetFilesButton As Button
    Friend WithEvents DeleteCookiesButton As Button
    Friend WithEvents DeleteHistoryButton As Button
    Friend WithEvents HistoryGroupBox As GroupBox
    Friend WithEvents PrivateBrowsingCheckBox As CheckBox
    Friend WithEvents MisesàJour As TabPage
    Friend WithEvents UpdatesGroupBox As GroupBox
    Friend WithEvents CheckUpdatesNowButton As Button
    Friend WithEvents VersionActuelleLabel As Label
    Friend WithEvents AutoUpdateGroupBox As GroupBox
    Friend WithEvents AutoUpdateCheckBox As CheckBox
    Friend WithEvents Avancé As TabPage
    Friend WithEvents FirstStartDialogButton As Button
    Friend WithEvents RepareBrowserGroupBox As GroupBox
    Friend WithEvents RepareBrowserButton As Button
    Friend WithEvents SettingsSavesGroupBox As GroupBox
    Friend WithEvents ImportSettingsButton As Button
    Friend WithEvents OKButton As Button
    Private WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents CustomSearchSettingsButton As Button
    Friend WithEvents DevelopmentGroupBox As GroupBox
    Friend WithEvents DisplayExceptionsCheckBox As CheckBox
    Friend WithEvents SecurityTabPage As TabPage
    Friend WithEvents ChildGuardProblemSignalementButton As Button
    Friend WithEvents ChildrenProtectionGroupBox As GroupBox
    Friend WithEvents ChildrenProtectionCheckBox As CheckBox
    Friend WithEvents BrowserSettingsSecurityGroupBox As GroupBox
    Friend WithEvents ChangeBrowserSettingsSecurityPasswordButton As Button
    Friend WithEvents BrowserSettingsSecurityCheckBox As CheckBox
    Friend WithEvents ChangeChildrenProtectionPasswordButton As Button
    Friend WithEvents UserAgentTextBox As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents EraseCookiesCheckBox As CheckBox
    Friend WithEvents CookiesLinkLabel As LinkLabel
    Friend WithEvents ChangeUserAgentLinkLabel As LinkLabel
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents AdBlockerTabPage As TabPage
    Friend WithEvents EditWhitelistButton As Button
    Friend WithEvents AdBlockerCheckBox As CheckBox
    Friend WithEvents PopUpsBlockerCheckBox As CheckBox
    Friend WithEvents AbortButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents AdsBlockerProblemSignalementButton As Button
    Friend WithEvents LanguageGroupBox As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LanguagesComboBox As ComboBox
End Class
