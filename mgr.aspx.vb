Imports System.IO

Partial Class NewAds
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.IsPostBack = False Then
            If IsNothing(Request.QueryString("AdminId")) = False Then
                bind()
            Else
                If IsNothing(Request.QueryString("pr")) = False Then
                    If IsNothing(Session("User")) = False Then
                        Response.Redirect("mgr.aspx?AdminId=" + Session("User").item("AdminId").ToString)

                    End If

                End If

            End If
        End If

    End Sub
    Public Sub bind()
        Dim dr As Data.DataRow = dbl.SelectAllwhere("Admin", "AdminId", Request.QueryString("AdminId").ToString).Rows(0)
        Me.txtUserName.Text = dr.Item("UserName").ToString
        Me.txtEmail.Text = dr.Item("Email").ToString
        Me.txtPass.Text = dr.Item("Pass").ToString
        Me.txtName.Text = dr.Item("Name").ToString
        Me.txtAddress.Text = dr.Item("Address").ToString
        Me.txtTel.Text = dr.Item("tel").ToString
        Me.txtMobile.Text = dr.Item("Mobile").ToString
        Me.txtTahsilat.Text = dr.Item("Tahsilat").ToString
        Me.jobPerm.Checked = dr.Item("jobPerm")
        Me.userPerm.Checked = dr.Item("userPerm")
        Me.offerPerm.Checked = dr.Item("offerPerm")
        Me.empPerm.Checked = dr.Item("empPerm")
        Me.netPerm.Checked = dr.Item("netPerm")
        Me.faqPerm.Checked = dr.Item("faqPerm")
        Me.delJobPerm.Checked = dr.Item("delJobPerm")
        Me.hlResume.NavigateUrl = "~/UserFiles/admin" + Request.QueryString("AdminId").ToString + ".pdf"
        Me.pic.Src = "~/UserFiles/admin" + Request.QueryString("AdminId").ToString + ".png"
        Me.pic.Visible = True
        Me.divPerms.Visible = Session("User").item("UserName").ToString.ToLower = "admin"

        Me.btnSave.Text = "ویرایش مدیر"
    End Sub

 


    Public Function check() As String
        If txtEmail.Text = "" Then
            Return "لطفا فیلد ایمیل را پر نمائید"
        End If
        Return ""
    End Function
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim err As String = check()
        Dim AdminId As String
        If err = "" Then
            If IsNothing(Request.QueryString("AdminId")) = False Then
                dbl.BigUpdate("Admin", "UserName", txtUserName.Text, "Email", txtEmail.Text, "Pass", txtPass.Text, "Name", txtName.Text, "Address", txtAddress.Text, "tel", txtTel.Text, "Tahsilat", txtTahsilat.Text, "Mobile", txtMobile.Text, "jobPerm", IIf(jobPerm.Checked, "1", "0"), "userPerm", IIf(userPerm.Checked, "1", "0"), "offerPerm", IIf(offerPerm.Checked, "1", "0"), "empPerm", IIf(empPerm.Checked, "1", "0"), "netPerm", IIf(netPerm.Checked, "1", "0"), "faqPerm", IIf(faqPerm.Checked, "1", "0"), "delJobPerm", IIf(delJobPerm.Checked, "1", "0"), , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , , "AdminId", Request.QueryString("AdminId").ToString)
                AdminId = Request.QueryString("AdminId").ToString

            Else
                dbl.Insert("Admin", "UserName", txtUserName.Text, "Email", txtEmail.Text, "Pass", txtPass.Text, "Name", txtName.Text, "Address", txtAddress.Text, "tel", txtTel.Text, "Tahsilat", txtTahsilat.Text, "Mobile", txtMobile.Text, _
                            "jobPerm", IIf(jobPerm.Checked, "1", "0"), "userPerm", IIf(userPerm.Checked, "1", "0"), "offerPerm", IIf(offerPerm.Checked, "1", "0"), "empPerm", IIf(empPerm.Checked, "1", "0"), "netPerm", IIf(netPerm.Checked, "1", "0"), _
                            "faqPerm", IIf(faqPerm.Checked, "1", "0"), "delJobPerm", IIf(delJobPerm.Checked, "1", "0"))
                AdminId = dbl.GetMax("admin", "adminId")
            End If
            If fuPic.HasFile Then
                Me.fuPic.SaveAs(Server.MapPath("UserFiles") + "/admin" + AdminId + ".png")
            End If
            If fuResume.HasFile Then
                Me.fuResume.SaveAs(Server.MapPath("UserFiles") + "/admin" + AdminId + ".pdf")
            End If
            General.MyMsgBox("اطلاعات با موفقیت ثبت شد", "", 5, "king.aspx")
        Else
            General.MyMsgBox(err)
        End If
    End Sub
End Class
