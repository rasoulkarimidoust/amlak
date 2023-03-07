
Partial Class JobView
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dr As Data.DataRow = dbl.SelectAllwhere("job", "jobCode", Request.QueryString("code")).Rows(0)
        With dr
            Me.html.InnerHtml = .Item("html").ToString
            Me.Label1.Text = .Item("jobname")
            Me.Label2.Text = .Item("jobname") + "(تعداد پروژه :" + dbl.SelectFromCommand("select count(*) as c from prj where jobid=" + Request.QueryString("code")).Rows(0).Item(0).ToString + ")"
        End With
        Me.Jobss.DataSource = dbl.SelectAll("LastChildJobsViaPrjCount")
        Me.Jobss.DataBind()
    End Sub
End Class
