﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.42000
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Fonctionnalité Enregistrement automatique My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PrivateBrowsing() As Boolean
            Get
                Return CType(Me("PrivateBrowsing"),Boolean)
            End Get
            Set
                Me("PrivateBrowsing") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property PreventMultipleTabsClose() As Boolean
            Get
                Return CType(Me("PreventMultipleTabsClose"),Boolean)
            End Get
            Set
                Me("PreventMultipleTabsClose") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("5")>  _
        Public Property SearchEngine() As Integer
            Get
                Return CType(Me("SearchEngine"),Integer)
            End Get
            Set
                Me("SearchEngine") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl)>  _
        Public Property CustomSearchURL() As String
            Get
                Return CType(Me("CustomSearchURL"),String)
            End Get
            Set
                Me("CustomSearchURL") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Moteur personnalisé")>  _
        Public Property CustomSearchName() As String
            Get
                Return CType(Me("CustomSearchName"),String)
            End Get
            Set
                Me("CustomSearchName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property FirstStart() As Boolean
            Get
                Return CType(Me("FirstStart"),Boolean)
            End Get
            Set
                Me("FirstStart") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property AutoUpdates() As Boolean
            Get
                Return CType(Me("AutoUpdates"),Boolean)
            End Get
            Set
                Me("AutoUpdates") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property AdBlocker() As Boolean
            Get
                Return CType(Me("AdBlocker"),Boolean)
            End Get
            Set
                Me("AdBlocker") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property ChildrenProtection() As Boolean
            Get
                Return CType(Me("ChildrenProtection"),Boolean)
            End Get
            Set
                Me("ChildrenProtection") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property ChildrenProtectionPassword() As String
            Get
                Return CType(Me("ChildrenProtectionPassword"),String)
            End Get
            Set
                Me("ChildrenProtectionPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property BrowserSettingsSecurity() As Boolean
            Get
                Return CType(Me("BrowserSettingsSecurity"),Boolean)
            End Get
            Set
                Me("BrowserSettingsSecurity") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property BrowserSettingsSecurityPassword() As String
            Get
                Return CType(Me("BrowserSettingsSecurityPassword"),String)
            End Get
            Set
                Me("BrowserSettingsSecurityPassword") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property DeleteCookiesWhileClosing() As Boolean
            Get
                Return CType(Me("DeleteCookiesWhileClosing"),Boolean)
            End Get
            Set
                Me("DeleteCookiesWhileClosing") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property FirstStartFromReset() As Boolean
            Get
                Return CType(Me("FirstStartFromReset"),Boolean)
            End Get
            Set
                Me("FirstStartFromReset") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PopUpBlocker() As Boolean
            Get
                Return CType(Me("PopUpBlocker"),Boolean)
            End Get
            Set
                Me("PopUpBlocker") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.WebServiceUrl),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://start.lesmajesticiels.org/")>  _
        Public Property Homepage() As String
            Get
                Return CType(Me("Homepage"),String)
            End Get
            Set
                Me("Homepage") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("fr")>  _
        Public Property UserAgentLanguage() As String
            Get
                Return CType(Me("UserAgentLanguage"),String)
            End Get
            Set
                Me("UserAgentLanguage") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property HistoryFavoritesSecurity() As Boolean
            Get
                Return CType(Me("HistoryFavoritesSecurity"),Boolean)
            End Get
            Set
                Me("HistoryFavoritesSecurity") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DefaultDownloadFolder() As String
            Get
                Return CType(Me("DefaultDownloadFolder"),String)
            End Get
            Set
                Me("DefaultDownloadFolder") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property DoNotTrack() As Boolean
            Get
                Return CType(Me("DoNotTrack"),Boolean)
            End Get
            Set
                Me("DoNotTrack") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property CorrectlyClosed() As Boolean
            Get
                Return CType(Me("CorrectlyClosed"),Boolean)
            End Get
            Set
                Me("CorrectlyClosed") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property LastSessionListOfTabs() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("LastSessionListOfTabs"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("LastSessionListOfTabs") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1753-01-01")>  _
        Public Property AppSyncLastSyncTime() As Date
            Get
                Return CType(Me("AppSyncLastSyncTime"),Date)
            End Get
            Set
                Me("AppSyncLastSyncTime") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property AppSyncDeviceNumber() As String
            Get
                Return CType(Me("AppSyncDeviceNumber"),String)
            End Get
            Set
                Me("AppSyncDeviceNumber") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsd=""http://www.w3."& _ 
            "org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" />")>  _
        Public Property History() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("History"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("History") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsd=""http://www.w3."& _ 
            "org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" />")>  _
        Public Property SearchHistory() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("SearchHistory"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("SearchHistory") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsd=""http://www.w3."& _ 
            "org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" />")>  _
        Public Property Favorites() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("Favorites"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("Favorites") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsd=""http://www.w3."& _ 
            "org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <s"& _ 
            "tring>*.lesmajesticiels.org</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <string>*.quentinpugeat.fr</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <"& _ 
            "string>localhost</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <string>127.0.0.1</string>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</ArrayOfString>")>  _
        Public Property AdBlockerWhitelist() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("AdBlockerWhitelist"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("AdBlockerWhitelist") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"<ArrayOfString xmlns:xsd=""http://www.w3."& _ 
            "org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"  <s"& _ 
            "tring xsi:nil=""true"" />"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"</ArrayOfString>")>  _
        Public Property DownloadHistory() As Global.System.Collections.Specialized.StringCollection
            Get
                Return CType(Me("DownloadHistory"),Global.System.Collections.Specialized.StringCollection)
            End Get
            Set
                Me("DownloadHistory") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("847d0e2a-bbb1-11ee-a555-0242ac110009")>  _
        Public ReadOnly Property MajestiCloudClientUuid() As String
            Get
                Return CType(Me("MajestiCloudClientUuid"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("https://browser-api.lesmajesticiels.org/majesticloud/callback.php")>  _
        Public ReadOnly Property MajestiCloudRedirectUri() As String
            Get
                Return CType(Me("MajestiCloudRedirectUri"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.SmartNet_Browser.My.MySettings
            Get
                Return Global.SmartNet_Browser.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
