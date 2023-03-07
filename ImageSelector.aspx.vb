
Partial Class ImageSelector
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(general.GetConnectionString())
    Public Sub getImages()
        Dim filesindirectory As String()
        filesindirectory = IO.Directory.GetFiles(Server.MapPath("~/UserFiles/image"))
        Dim images As List(Of [String]) = New List(Of String)(filesindirectory.Count())
        'Dim urlStr As String = HttpContext.Current.Request.Url.OriginalString.Replace("www.", "")
        'Dim UrlBase As String = urlStr.Substring(0, urlStr.IndexOf("modules") - 1)

        For Each item As String In filesindirectory

            images.Add([String].Format("UserFiles/image/{0}", System.IO.Path.GetFileName(item)))

        Next
        RepeaterImages.DataSource = images
        RepeaterImages.DataBind()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getImages()
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim fileName As String = IO.Path.GetFileName(FileUpload1.FileName)
        Me.FileUpload1.SaveAs(Server.MapPath("~/UserFiles/image/") + fileName)
        getImages()
    End Sub
End Class
