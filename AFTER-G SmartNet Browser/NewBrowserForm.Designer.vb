<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewBrowserForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewBrowserForm))
        Me.URLBox = New System.Windows.Forms.TextBox()
        Me.FaviconBox = New System.Windows.Forms.PictureBox()
        Me.GeckoWebBrowser1 = New Gecko.GeckoWebBrowser()
        CType(Me.FaviconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'URLBox
        '
        Me.URLBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.URLBox.Location = New System.Drawing.Point(28, 4)
        Me.URLBox.Name = "URLBox"
        Me.URLBox.Size = New System.Drawing.Size(905, 23)
        Me.URLBox.TabIndex = 2
        Me.URLBox.TabStop = False
        '
        'FaviconBox
        '
        Me.FaviconBox.Location = New System.Drawing.Point(6, 7)
        Me.FaviconBox.Name = "FaviconBox"
        Me.FaviconBox.Size = New System.Drawing.Size(16, 16)
        Me.FaviconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FaviconBox.TabIndex = 2
        Me.FaviconBox.TabStop = False
        '
        'GeckoWebBrowser1
        '
        Me.GeckoWebBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GeckoWebBrowser1.FrameEventsPropagateToMainWindow = False
        Me.GeckoWebBrowser1.Location = New System.Drawing.Point(0, 33)
        Me.GeckoWebBrowser1.Name = "GeckoWebBrowser1"
        Me.GeckoWebBrowser1.Size = New System.Drawing.Size(939, 462)
        Me.GeckoWebBrowser1.TabIndex = 1
        Me.GeckoWebBrowser1.UseHttpActivityObserver = False
        '
        'NewBrowserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 495)
        Me.Controls.Add(Me.GeckoWebBrowser1)
        Me.Controls.Add(Me.FaviconBox)
        Me.Controls.Add(Me.URLBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewBrowserForm"
        Me.Text = "SmartNet Browser"
        CType(Me.FaviconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents URLBox As TextBox
    Friend WithEvents FaviconBox As PictureBox
    Friend WithEvents GeckoWebBrowser1 As Gecko.GeckoWebBrowser
End Class
