
Partial Class Offer
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public Function check() As String

        If txtName.Text = "" Then
            Return "لطفا نام خود را وارد نمائید"
        End If
        If txtEmail.Text = "" Then
            Return "لطفا ایمیل خود را وارد کنید"
        End If
        If txtMobile.Text = "" Then
            Return "لطفا موبایل خود را وارد نمائید"
        End If

        Return ""
    End Function
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim err As String = check()
        If err <> "" Then
            General.MyMsgBox(err, " ")
        Else
            dbl.Insert("contacts", "name", txtName.Text, "tel", Me.txtTel.Text, "mobile", Me.txtMobile.Text, "Email", txtEmail.Text, "description", txtDescription.Text, "title", txttitle.Text)
            General.MyMsgBox("اطلاعات شما ثبت شد", "ایسکون", 5, "default.aspx")
        End If
    End Sub
End Class
