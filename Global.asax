<%@ Application Language="VB"  %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes)
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a new session is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when a session ends. 
        ' Note: The Session_End event is raised only when the sessionstate mode
        ' is set to InProc in the Web.config file. If session mode is set to StateServer 
        ' or SQLServer, the event is not raised.
    End Sub
    Private Shared Sub RegisterRoutes(ByVal routes As System.Web.Routing.RouteCollection)
        routes.MapPageRoute("sale", "sale", "~/default.aspx?jobcode=2")
        routes.MapPageRoute("rent", "rent", "~/default.aspx?jobcode=3")
        routes.MapPageRoute("project", "project", "~/default.aspx?jobcode=4")
    End Sub
    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)



        ' اگر درخواست شامل صفحه نباشد و بصورت ساب دایرکتوری باشد
        If HttpContext.Current.Request.Url.ToString.ToLower.Contains(".aspx") = False Then
            Dim inputUrl As String = HttpContext.Current.Request.Url.ToString
            Dim urlNohttp As String = inputUrl.Substring(10)
            Dim id As String = ""
            Dim link As String = ""
            Dim parts As String() = urlNohttp.Split("/")
            If parts.Length = 3 Then
                If Regex.IsMatch(parts(1), "^[0-9]+$") Then
                    id = parts(1)
                    link = parts(2)
                Else
                    link = parts(1)
                End If
            Else
                link = parts(1)
            End If
            If link <> "" Then

                Dim dbl As New DataBaseLayer("server=.;user id=sa;password=4Sardar;initial catalog=amlak")
                Dim seoKeyTbl As Data.DataTable
                If id <> "" Then

                    seoKeyTbl = dbl.SelectAllwhere("prj", "prjid", id)
                    Dim Redireclink As String
                    Try
                        Redireclink = seoKeyTbl.Rows(0).Item("link")
                    Catch ex As Exception
                        Context.RewritePath("~/404.aspx")
                    End Try


                    If seoKeyTbl.Rows.Count > 0 Then
                        If Redireclink = link Then
                            Context.RewritePath("~/AdsView.aspx?prjid=" + seoKeyTbl.Rows(0).Item("prjid").ToString)


                        Else
                            Dim root As String = HttpContext.Current.Request.Url.OriginalString.Substring(0, Request.Url.OriginalString.Replace("//", "").IndexOf("/") + 2)
                            Response.RedirectPermanent(root + "/" + seoKeyTbl.Rows(0).Item("prjid").ToString + "/" + Redireclink, True)
                        End If

                    End If






                Else

                    'If link = "admin" Then
                    '    Context.RewritePath("Admin.aspx")
                    'End If
                    'If link = "webgardi" Then
                    '    Context.RewritePath("js/webgardi.js")
                    'End If
                    'If link = "tag" Then
                    '    Context.RewritePath("/searchResult.aspx?txtSearch=" + HttpUtility.UrlEncode(parts(2).ToString))
                    'End If
                    'seoKeyTbl = dbl.SelectAllwhere("newsCat", "domainCode", General.domain("code"), "CatName", link)
                    'If seoKeyTbl.Rows.Count > 0 Then
                    '    Context.RewritePath("Cat.aspx?CatId=" + seoKeyTbl.Rows(0).Item("CatId").ToString)

                    'End If

                    'seoKeyTbl = dbl.SelectAllwhere("newsAgency", "domainCode", General.domain("code"), "SiteLink", link)
                    'If seoKeyTbl.Rows.Count > 0 Then
                    '    Context.RewritePath("NewsAgency.aspx?SiteId=" + seoKeyTbl.Rows(0).Item("SiteId").ToString)
                    'End If





                End If

            End If

        End If

    End Sub

</script>