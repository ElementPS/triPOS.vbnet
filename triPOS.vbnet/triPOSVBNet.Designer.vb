<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSendTransaction = New System.Windows.Forms.Button()
        Me.btnGenerateJSON = New System.Windows.Forms.Button()
        Me.btnGenerateXML = New System.Windows.Forms.Button()
        Me.txtRequest = New System.Windows.Forms.TextBox()
        Me.txtResponse = New System.Windows.Forms.TextBox()
        Me.txtHeaders = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClearData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSendTransaction
        '
        Me.btnSendTransaction.Location = New System.Drawing.Point(285, 10)
        Me.btnSendTransaction.Name = "btnSendTransaction"
        Me.btnSendTransaction.Size = New System.Drawing.Size(110, 23)
        Me.btnSendTransaction.TabIndex = 0
        Me.btnSendTransaction.Text = "Send Transaction"
        Me.btnSendTransaction.UseVisualStyleBackColor = True
        '
        'btnGenerateJSON
        '
        Me.btnGenerateJSON.Location = New System.Drawing.Point(155, 10)
        Me.btnGenerateJSON.Name = "btnGenerateJSON"
        Me.btnGenerateJSON.Size = New System.Drawing.Size(110, 23)
        Me.btnGenerateJSON.TabIndex = 1
        Me.btnGenerateJSON.Text = "Generate JSON"
        Me.btnGenerateJSON.UseVisualStyleBackColor = True
        '
        'btnGenerateXML
        '
        Me.btnGenerateXML.Location = New System.Drawing.Point(29, 10)
        Me.btnGenerateXML.Name = "btnGenerateXML"
        Me.btnGenerateXML.Size = New System.Drawing.Size(110, 23)
        Me.btnGenerateXML.TabIndex = 2
        Me.btnGenerateXML.Text = "Generate XML"
        Me.btnGenerateXML.UseVisualStyleBackColor = True
        '
        'txtRequest
        '
        Me.txtRequest.Location = New System.Drawing.Point(29, 82)
        Me.txtRequest.Multiline = True
        Me.txtRequest.Name = "txtRequest"
        Me.txtRequest.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRequest.Size = New System.Drawing.Size(366, 127)
        Me.txtRequest.TabIndex = 3
        '
        'txtResponse
        '
        Me.txtResponse.Location = New System.Drawing.Point(29, 236)
        Me.txtResponse.Multiline = True
        Me.txtResponse.Name = "txtResponse"
        Me.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResponse.Size = New System.Drawing.Size(366, 127)
        Me.txtResponse.TabIndex = 4
        '
        'txtHeaders
        '
        Me.txtHeaders.Location = New System.Drawing.Point(29, 394)
        Me.txtHeaders.Multiline = True
        Me.txtHeaders.Name = "txtHeaders"
        Me.txtHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtHeaders.Size = New System.Drawing.Size(366, 127)
        Me.txtHeaders.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Request:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 220)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Response:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 378)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Headers:"
        '
        'btnClearData
        '
        Me.btnClearData.Location = New System.Drawing.Point(32, 38)
        Me.btnClearData.Name = "btnClearData"
        Me.btnClearData.Size = New System.Drawing.Size(363, 23)
        Me.btnClearData.TabIndex = 9
        Me.btnClearData.Text = "Clear Data"
        Me.btnClearData.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 532)
        Me.Controls.Add(Me.btnClearData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHeaders)
        Me.Controls.Add(Me.txtResponse)
        Me.Controls.Add(Me.txtRequest)
        Me.Controls.Add(Me.btnGenerateXML)
        Me.Controls.Add(Me.btnGenerateJSON)
        Me.Controls.Add(Me.btnSendTransaction)
        Me.Name = "Form1"
        Me.Text = "triPOSVBNet"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSendTransaction As Button
    Friend WithEvents btnGenerateJSON As Button
    Friend WithEvents btnGenerateXML As Button
    Friend WithEvents txtRequest As TextBox
    Friend WithEvents txtResponse As TextBox
    Friend WithEvents txtHeaders As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClearData As Button
End Class
