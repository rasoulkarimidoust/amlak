
Partial Class MasterPage2
    Inherits System.Web.UI.MasterPage
    Public dr4Master As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub imgBtnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnClose.Click
        Me.MsgBoxAll.Visible = False
    End Sub
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.IsPostBack = False Then
            Dim pageName As String = Request.Url.Segments(Request.Url.Segments.Length - 1).Split(".")(0)
            Dim tbl As Data.DataTable = dbl.SelectAllwhere("Help4Controls", "PageName", pageName)
            Session("tblHelp") = tbl
            Me.lblError.Text = ""
            If ((Not (Request.Cookies("u")) Is Nothing) AndAlso IsNothing(Session("UserType"))) Then
                Autologin(Request.Cookies("u").Value)
            End If

            If IsNothing(Session("User")) Then
                Me.btnLogin.InnerText = "ورود"
                Me.btnLogin.HRef = "login.aspx"
            Else
                If Session("UserType") = "admin" Then
                    Me.mgrMenu.Visible = True
                End If
                Me.btnLogin.InnerText = "خروج"
                Me.btnLogin.HRef = "logout.aspx"
            End If

            'Me.htmlsocial.InnerHtml = dr.Item("social").ToString
        End If
        dr4Master = dbl.SelectAll("txtSetting").Rows(0)
    End Sub
    Public Sub Autologin(username As String)

        Dim dt As Data.DataTable
        Try
            dt = dbl.SelectAllwhere("Admin", "UserName", username)
            If dt.Rows.Count > 0 Then
                Session("user") = dt.Rows(0)
                Session("UserType") = "admin"
                Response.Redirect("king.aspx")

            End If
            dt = dbl.SelectAllwhere("karfarma", "mobile", username)
            If dt.Rows.Count > 0 Then

                Session("user") = dt.Rows(0)
                Session("UserType") = "karfarma"
                Response.Redirect("king.aspx")
            End If



        Catch ex As Exception

        End Try



    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pageName As String = IO.Path.GetFileName(Request.PhysicalPath)
            If (String.IsNullOrEmpty(Page.Title)) Then
                Page.Title = "کی چی پو"

            End If


        End If

    End Sub

End Class

