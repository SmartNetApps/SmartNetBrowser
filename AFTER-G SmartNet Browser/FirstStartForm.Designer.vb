<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FirstStartForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FirstStartForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HomepageGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HomepageURLBox = New System.Windows.Forms.TextBox()
        Me.SearchEngineGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.SmartNetSecurityGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.AdBlockerCheckBox = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.HomepageGroupBox.SuspendLayout()
        Me.SearchEngineGroupBox.SuspendLayout()
        Me.SmartNetSecurityGroupBox.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Maroon
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'HomepageGroupBox
        '
        Me.HomepageGroupBox.Controls.Add(Me.Label3)
        Me.HomepageGroupBox.Controls.Add(Me.HomepageURLBox)
        Me.HomepageGroupBox.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.HomepageGroupBox, "HomepageGroupBox")
        Me.HomepageGroupBox.Name = "HomepageGroupBox"
        Me.HomepageGroupBox.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'HomepageURLBox
        '
        resources.ApplyResources(Me.HomepageURLBox, "HomepageURLBox")
        Me.HomepageURLBox.Name = "HomepageURLBox"
        '
        'SearchEngineGroupBox
        '
        Me.SearchEngineGroupBox.Controls.Add(Me.Label6)
        Me.SearchEngineGroupBox.Controls.Add(Me.Label4)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton5)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton4)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton3)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton2)
        Me.SearchEngineGroupBox.Controls.Add(Me.RadioButton1)
        Me.SearchEngineGroupBox.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.SearchEngineGroupBox, "SearchEngineGroupBox")
        Me.SearchEngineGroupBox.Name = "SearchEngineGroupBox"
        Me.SearchEngineGroupBox.TabStop = False
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'RadioButton5
        '
        resources.ApplyResources(Me.RadioButton5, "RadioButton5")
        Me.RadioButton5.Checked = True
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        resources.ApplyResources(Me.RadioButton4, "RadioButton4")
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        resources.ApplyResources(Me.RadioButton3, "RadioButton3")
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        resources.ApplyResources(Me.RadioButton2, "RadioButton2")
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        resources.ApplyResources(Me.RadioButton1, "RadioButton1")
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'StartButton
        '
        resources.ApplyResources(Me.StartButton, "StartButton")
        Me.StartButton.Name = "StartButton"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'SmartNetSecurityGroupBox
        '
        Me.SmartNetSecurityGroupBox.Controls.Add(Me.Label2)
        Me.SmartNetSecurityGroupBox.Controls.Add(Me.Label5)
        Me.SmartNetSecurityGroupBox.Controls.Add(Me.AdBlockerCheckBox)
        Me.SmartNetSecurityGroupBox.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.SmartNetSecurityGroupBox, "SmartNetSecurityGroupBox")
        Me.SmartNetSecurityGroupBox.Name = "SmartNetSecurityGroupBox"
        Me.SmartNetSecurityGroupBox.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'AdBlockerCheckBox
        '
        resources.ApplyResources(Me.AdBlockerCheckBox, "AdBlockerCheckBox")
        Me.AdBlockerCheckBox.Name = "AdBlockerCheckBox"
        Me.AdBlockerCheckBox.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Maroon
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Maroon
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'FirstStartForm
        '
        Me.AcceptButton = Me.StartButton
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.SmartNetSecurityGroupBox)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.SearchEngineGroupBox)
        Me.Controls.Add(Me.HomepageGroupBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FirstStartForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.HomepageGroupBox.ResumeLayout(False)
        Me.HomepageGroupBox.PerformLayout()
        Me.SearchEngineGroupBox.ResumeLayout(False)
        Me.SearchEngineGroupBox.PerformLayout()
        Me.SmartNetSecurityGroupBox.ResumeLayout(False)
        Me.SmartNetSecurityGroupBox.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents HomepageGroupBox As GroupBox
    Friend WithEvents HomepageURLBox As TextBox
    Friend WithEvents SearchEngineGroupBox As GroupBox
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents StartButton As Button
    Friend WithEvents SmartNetSecurityGroupBox As GroupBox
    Friend WithEvents AdBlockerCheckBox As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RadioButton5 As RadioButton
End Class
