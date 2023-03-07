
Partial Class KUpdate
    Inherits System.Web.UI.Page
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        dr = dbl.SelectAll("txtSetting").Rows(0)

        If IsNothing(Session("user")) = False Then
            If Session("UserType") = "karfarma" Then
                txtName.Text = Session("user").item("name").ToString
                N.Text = Session("user").item("N").ToString
                Me.E.Text = Session("user").item("E").ToString
                'txtNewUserName.Text = Session("user").item("UserName").ToString
                'txtNewUserName.Enabled = False
                'txtEmail.Text = Session("user").item("Email").ToString
                'txtTel.Text = Session("user").item("tel").ToString
                'txtMobile.Text = Session("user").item("mobile").ToString
                'txtAddress.Text = Session("user").item("address")

            End If

        End If
        If Request.QueryString("kid").ToString <> "" Then
            Dim dr1 As Data.DataRow = dbl.SelectAllwhere("karfarma", "karfarmaid", Request.QueryString("kid").ToString).Rows(0)
            txtName.Text = dr1.Item("name").ToString
            N.Text = dr1.Item("N").ToString
            Me.E.Text = dr1.Item("E").ToString

        End If


    End Sub

End Class
