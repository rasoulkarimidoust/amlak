
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub imgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnClose.Click
        Me.MsgBoxAll.Visible = False
    End Sub
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.IsPostBack = False Then
            Me.lblError.Text = ""

            If ((Not (Request.Cookies("u")) Is Nothing) _
            AndAlso (Not (Request.Cookies("p")) Is Nothing)) _
                 AndAlso IsNothing(Session("UserType")) Then

                login(Request.Cookies("u").Value, Request.Cookies("p").Value)

            End If

            dr = dbl.SelectAll("txtSetting").Rows(0)
            Me.html102.InnerHtml = dr.Item("Main102").ToString
            'Me.html11.InnerHtml = dr.Item("Main11").ToString
            'Me.html101.InnerHtml = dr.Item("Main101").ToString
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pageName As String = IO.Path.GetFileName(Request.PhysicalPath)

            If IsNothing(Session("user")) = False Then
                Me.btnPrf.Visible = True
                btnPrf.InnerText = Session("User").item("Name")
                If Session("UserType") = "admin" Then
                    divMenuAdmin.Visible = True
                End If
                If Session("UserType") = "peymankar" Then
                    If IO.File.Exists(Server.MapPath("userfiles\" + Session("User").item("PeymankarId").ToString + "logo.png")) Then
                        Me.ImgPeymankarLogo.Src = "userfiles\" + Session("User").item("PeymankarId").ToString + "logo.png"
                        Me.ImgPeymankarLogo.Visible = True
                    End If
                    btnPrf.HRef = "PUpdate.aspx"

                End If
                If Session("UserType") = "karfarma" Then
                    divMenuKarfama.Visible = True
                    btnPrf.HRef = "KUpdate.aspx"

                End If
            Else
                divMenuGeneral.Visible = True
                btnLogin.Visible = True
            End If


        End If
        Me.txtUserName.Focus()

    End Sub
    Public Sub login(username As String, Pass As String)

        Dim dt As Data.DataTable
        Try
            dt = dbl.SelectAllwhere("Admin", "UserName", username, "Pass", Pass)
            If dt.Rows.Count > 0 Then
                Session("user") = dt.Rows(0)
                Session("UserType") = "admin"
                Response.Redirect("setting.aspx")
            End If
            dt = dbl.SelectAllwhere("Peymankar", "email", username, "Pass", Pass)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("AcceptByAdmin").ToString = "1" Then
                    Session("user") = dt.Rows(0)
                    Session("UserType") = "peymankar"
                    Response.Redirect("PAds.aspx")
                Else
                    General.MyMsgBox("هنوز مدیر سایت پروفایل شما را تائید نکرده است.", "آها:", 5, "logout.aspx")
                End If
            End If
            dt = dbl.SelectAllwhere("karfarma", "email", username, "Pass", Pass)
            If dt.Rows.Count > 0 Then
                Session("user") = dt.Rows(0)
                Session("UserType") = "karfarma"
                Response.Redirect("KAds.aspx")
            End If




        Catch ex As Exception

        End Try



    End Sub
    Private Sub imgBtnLogin_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnLogin.Click
        Try

            Dim Enc As New Encryption.Utils
            Response.Cookies("u").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("p").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("u").Value = txtUserName.Text
            Response.Cookies("p").Value = txtPass.Text

            login(Me.txtUserName.Text, Me.txtPass.Text)
            'Response.Redirect("Setting.aspx")
        Catch ex As Exception
            ex = ex
        End Try


    End Sub


End Class

