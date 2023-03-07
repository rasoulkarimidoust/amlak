Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Text

Partial Class Captcha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim objBMP As Bitmap = New System.Drawing.Bitmap(60, 20)
        Dim objGraphics As Graphics = System.Drawing.Graphics.FromImage(objBMP)
        objGraphics.Clear(Color.FromArgb(11863558))
        objGraphics.TextRenderingHint = TextRenderingHint.AntiAlias
        Dim objFont As Font = New Font("Arial", 8, FontStyle.Bold)
        Dim randomStr As String = ""
        Dim myIntArray() As Integer = New Integer((5) - 1) {}
        Dim x As Integer
        Dim autoRand As Random = New Random
        x = 0
        Do While (x < 5)
            myIntArray(x) = System.Convert.ToInt32(autoRand.Next(0, 9))
            randomStr = (randomStr + myIntArray(x).ToString)
            x = (x + 1)
        Loop

        'This is to add the string to session cookie, to be compared later
        Session.Add("captcha", randomStr)
        '' Write out the text
        objGraphics.DrawString(randomStr, objFont, Brushes.White, 3, 3)
        '' Set the content type and return the image
        Response.ContentType = "image/GIF"
        objBMP.Save(Response.OutputStream, ImageFormat.Gif)
        objFont.Dispose()
        objGraphics.Dispose()
        objBMP.Dispose()
    End Sub
End Class
