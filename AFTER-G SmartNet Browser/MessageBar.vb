''' <summary>
''' Représente les barres de message qui s'affichent sur BrowserForm.
''' </summary>
Public Class MessageBar
    Public message As String
    Public level As MessageBarLevel
    Public action As MessageBarAction
    Public buttonText As String
    Public link As String
    Public exception As Exception

    Public Sub New(lv As MessageBarLevel, msg As String)
        message = msg
        buttonText = ""
        level = lv
        action = MessageBarAction.NoAction
        link = ""
        exception = Nothing
    End Sub

    Public Sub New(lv As MessageBarLevel, msg As String, act As MessageBarAction, btnText As String)
        message = msg
        buttonText = btnText
        level = lv
        action = act
        link = ""
        exception = Nothing
    End Sub

    Public Sub New(lv As MessageBarLevel, msg As String, act As MessageBarAction, btnText As String, lnk As String)
        message = msg
        buttonText = btnText
        level = lv
        action = act
        link = lnk
        exception = Nothing
    End Sub

    Public Sub New(lv As MessageBarLevel, msg As String, act As MessageBarAction, btnText As String, ex As Exception)
        message = msg
        buttonText = btnText
        level = lv
        action = act
        link = ""
        exception = ex
        ExceptionForm.SetException(ex)
    End Sub

    Public Sub New(ex As Exception)
        message = ex.Message
        buttonText = "Voir les détails..."
        level = MessageBarLevel.Warning
        action = MessageBarAction.OpenExceptionForm
        link = ""
        exception = ex
        ExceptionForm.SetException(ex)
    End Sub

    Public Sub New(ex As Exception, customMsg As String)
        message = customMsg + " (" + ex.Message + ")"
        buttonText = "Voir les détails..."
        level = MessageBarLevel.Warning
        action = MessageBarAction.OpenExceptionForm
        link = ""
        exception = ex
        ExceptionForm.SetException(ex)
    End Sub

    ''' <summary>
    ''' Afficher la barre de message.
    ''' </summary>
    Public Sub Display()
        BrowserForm.msgBar = Me
        BrowserForm.DisplayMessageBar()
    End Sub

    Public Function GetColor() As Color
        Select Case level
            Case MessageBarLevel.Info
                Return Color.DarkBlue
            Case MessageBarLevel.Critical
                Return Color.DarkRed
            Case MessageBarLevel.Warning
                Return Color.DarkOrange
        End Select
    End Function

    ''' <summary>
    ''' Représente les différentes actions que peut réaliser l'appui sur le bouton de la barre de message.
    ''' </summary>
    Public Enum MessageBarAction
        ''' <summary>
        ''' Ouvrir un nouvel onglet avec l'URL renseignée.
        ''' </summary>
        OpenPopup
        ''' <summary>
        ''' Restaurer la session précédente.
        ''' </summary>
        RestorePreviousSession
        ''' <summary>
        ''' Ouvrir ExceptionForm.
        ''' </summary>
        OpenExceptionForm
        ''' <summary>
        ''' Ouvrir les paramètres Internet de Windows.
        ''' </summary>
        OpenInternetSettings
        ''' <summary>
        ''' Ouvrir le formulaire AppSyncLogin.
        ''' </summary>
        DisplayAppSyncLogin
        ''' <summary>
        ''' Ne rien faire. Le bouton de la barre de message sera caché.
        ''' </summary>
        NoAction
    End Enum

    ''' <summary>
    ''' Représente les niveaux d'alerte d'une barre de message
    ''' </summary>
    Public Enum MessageBarLevel
        ''' <summary>
        ''' Niveau d'alerte bas, barre de message bleue.
        ''' </summary>
        Info
        ''' <summary>
        ''' Niveau d'alerte moyen, barre de message orange.
        ''' </summary>
        Warning
        ''' <summary>
        ''' Niveau d'alerte critique, barre de message rouge.
        ''' </summary>
        Critical
    End Enum
End Class
