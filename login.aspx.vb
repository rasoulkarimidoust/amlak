
Partial Class login
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.txtLogin.Focus()

    End Sub



    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim dt As Data.DataTable
        Try
            dt = dbl.SelectAllwhere("Admin", "UserName", Me.txtLogin.Text, "Pass", Me.txtPass.Text, "deleted", "0")
            If dt.Rows.Count > 0 Then
                Session("Pass") = dt.Rows(0).Item("Pass").ToString
                Session("user") = dt.Rows(0)
                Session("UserType") = "admin"
                Dim Enc As New Encryption.Utils
                Response.Cookies("u").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("u").Value = txtLogin.Text
                Response.Redirect("king.aspx")


            End If
            dt = dbl.SelectAllwhere("karfarma", "mobile", Me.txtLogin.Text, "Pass", Me.txtPass.Text)
            If dt.Rows.Count > 0 Then
                Session("user") = dt.Rows(0)
                Session("UserType") = "karfarma"
                Dim Enc As New Encryption.Utils
                Response.Cookies("u").Expires = DateTime.Now.AddDays(30)
                Response.Cookies("u").Value = txtLogin.Text
                Response.Redirect("king.aspx")

            End If
            Me.txtLogin.Text = ""


        Catch ex As Exception
            Me.txtLogin.Text = ""

        End Try



    End Sub
End Class
