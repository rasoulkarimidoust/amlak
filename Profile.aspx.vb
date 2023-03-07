
Partial Class KUpdate
    Inherits System.Web.UI.Page
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.IsPostBack = False Then
            If IsNothing(Session("user")) = False Then
                If Session("UserType") = "karfarma" Then
                    txtName.Text = Session("user").item("name").ToString
                    txtEmail.Text = Session("user").item("Email").ToString

                    txtTel.Text = Session("user").item("tel").ToString
                    txtMobile.Text = Session("user").item("mobile").ToString
                    txtAddress.Text = Session("user").item("address")
                    txtMobile.Enabled = False
                    txtTel.Enabled = False
                Else
                    If IsNothing(Request.QueryString("uid")) = False Then
                        Try
                            Dim dr As Data.DataRow = dbl.SelectAllwhere("Karfarma", "karfarmaid", Request.QueryString("uid").ToString).Rows(0)
                            With dr
                                txtName.Text = .Item("name").ToString
                                txtEmail.Text = .Item("Email").ToString
                                txtTel.Text = .Item("tel").ToString
                                txtMobile.Text = .Item("mobile").ToString
                                txtAddress.Text = .Item("address").ToString
                            End With
                            txtMobile.Enabled = False
                            txtTel.Enabled = False


                        Catch ex As Exception

                        End Try


                    End If
                End If
            End If


        End If

    End Sub
    Public Function check() As String
        If txtNewPass.Text = "" Then
            Return "فیلد کلمه عبور نمیتواند خالی باشد"
        End If
        If txtNewPass.Text <> txtNewPass2.Text Then
            Return "کلمه عبور با تکرار کلمه عبور یکسان نیست"
        End If
        If txtAddress.Text = "" Then
            Return "فیلد آدرس نمیتواند خالی باشد"
        End If
        If txtCaptcha.Text = "" Then
            Return "فیلد شماره تصویر نمیتواند خالی باشد"
        End If
        If txtEmail.Text = "" Then
            Return "فیلد ایمیل نمیتواند خالی باشد"
        End If
        If txtMobile.Text = "" Then
            Return "فیلد موبایل نمیتواند خالی باشد"
        End If
        If txtName.Text = "" Then
            Return "فیلد نام نمیتواند خالی باشد"
        End If
        If txtTel.Text = "" Then
            Return "فیلد تلفن نمیتواند خالی باشد"
        End If
        If txtEmail.Text.Contains("@") = False Then
            Return "فیلد ایمیل را بصورت صحیح وارد کنید"
        End If
        If txtEmail.Text.Contains(".") = False Then
            Return "فیلد ایمیل را بصورت صحیح وارد کنید"
        End If
        If IsNumeric(txtTel.Text) = False Then
            Return "فیلد تلفن را بصورت عددی وارد نمائید"
        End If
        If txtTel.Text.Length < 7 Then
            Return "فیلد تلفن را بصورت صحیح وارد نمائید"
        End If
        If IsNumeric(txtMobile.Text) = False Then
            Return "فیلد موبایل را بصورت عددی وارد نمائید"
        End If
        If txtMobile.Text.Length < 7 Then
            Return "فیلد موبایل را بصورت صحیح وارد نمائید"
        End If
        If txtCaptcha.Text <> Session("captcha") = False Then
            Return "کد شکل صحیح نیست."
        End If

        Return ""
    End Function
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim err As String = check()
        If err <> "" Then
            General.MyMsgBox(err)
        Else

            If IsNothing(Session("user")) = False Then
                If Session("UserType") = "karfarma" Then
                    dbl.Update("Karfarma", "name", txtName.Text, "tel", txtTel.Text, "mobile", txtMobile.Text, "address", txtAddress.Text, "Pass", Me.txtNewPass.Text, , , , , , , , , , , "karfarmaId", Session("User").item("karfarmaId").ToString)
                End If
            Else
                Try
                    dbl.Update("Karfarma", "name", txtName.Text, "tel", txtTel.Text, "mobile", txtMobile.Text, "address", txtAddress.Text, "Pass", Me.txtNewPass.Text, , , , , , , , , , , "karfarmaId", Request.QueryString("uid"))

                Catch ex As Exception

                End Try
            End If
            General.MyMsgBox("اطلاعات شما ثبت شد. لطفا با نام کاربری و کلمه عبور خود وارد شوید ", "آها", 5, "logout.aspx")

        End If


    End Sub
End Class
