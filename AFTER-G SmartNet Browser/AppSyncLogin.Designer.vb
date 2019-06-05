<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppSyncLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppSyncLogin))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label_Email = New System.Windows.Forms.Label()
        Me.Label_MDP = New System.Windows.Forms.Label()
        Me.Label_Title = New System.Windows.Forms.Label()
        Me.TextBox_Email = New System.Windows.Forms.TextBox()
        Me.TextBox_MDP = New System.Windows.Forms.TextBox()
        Me.Button_Connecter = New System.Windows.Forms.Button()
        Me.LinkLabel_MDPOublie = New System.Windows.Forms.LinkLabel()
        Me.Button_CreerCompte = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.BackgroundImage = Global.SmartNet_Browser.My.Resources.Resources.CloudBackground
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Label_Email
        '
        resources.ApplyResources(Me.Label_Email, "Label_Email")
        Me.Label_Email.Name = "Label_Email"
        '
        'Label_MDP
        '
        resources.ApplyResources(Me.Label_MDP, "Label_MDP")
        Me.Label_MDP.Name = "Label_MDP"
        '
        'Label_Title
        '
        resources.ApplyResources(Me.Label_Title, "Label_Title")
        Me.Label_Title.BackColor = System.Drawing.Color.Transparent
        Me.Label_Title.Name = "Label_Title"
        '
        'TextBox_Email
        '
        resources.ApplyResources(Me.TextBox_Email, "TextBox_Email")
        Me.TextBox_Email.Name = "TextBox_Email"
        '
        'TextBox_MDP
        '
        resources.ApplyResources(Me.TextBox_MDP, "TextBox_MDP")
        Me.TextBox_MDP.Name = "TextBox_MDP"
        Me.TextBox_MDP.UseSystemPasswordChar = True
        '
        'Button_Connecter
        '
        resources.ApplyResources(Me.Button_Connecter, "Button_Connecter")
        Me.Button_Connecter.Name = "Button_Connecter"
        Me.Button_Connecter.UseVisualStyleBackColor = True
        '
        'LinkLabel_MDPOublie
        '
        resources.ApplyResources(Me.LinkLabel_MDPOublie, "LinkLabel_MDPOublie")
        Me.LinkLabel_MDPOublie.Name = "LinkLabel_MDPOublie"
        Me.LinkLabel_MDPOublie.TabStop = True
        '
        'Button_CreerCompte
        '
        resources.ApplyResources(Me.Button_CreerCompte, "Button_CreerCompte")
        Me.Button_CreerCompte.Name = "Button_CreerCompte"
        Me.Button_CreerCompte.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.SmartNet_Browser.My.Resources.Resources.appsync_1024
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'AppSyncLogin
        '
        Me.AcceptButton = Me.Button_Connecter
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Label_Title)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Button_CreerCompte)
        Me.Controls.Add(Me.LinkLabel_MDPOublie)
        Me.Controls.Add(Me.Button_Connecter)
        Me.Controls.Add(Me.TextBox_MDP)
        Me.Controls.Add(Me.TextBox_Email)
        Me.Controls.Add(Me.Label_MDP)
        Me.Controls.Add(Me.Label_Email)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AppSyncLogin"
        Me.ShowIcon = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label_Email As Label
    Friend WithEvents Label_MDP As Label
    Friend WithEvents Label_Title As Label
    Friend WithEvents TextBox_Email As TextBox
    Friend WithEvents TextBox_MDP As TextBox
    Friend WithEvents Button_Connecter As Button
    Friend WithEvents LinkLabel_MDPOublie As LinkLabel
    Friend WithEvents Button_CreerCompte As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
