
Partial Class prjManage
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GridView1.DataSource = dbl.SelectFromCommand("select * from Reportprj where deleted=0 and ReportCount>0  order by ReportCount desc") 'where status=1 or status=2")
        Me.GridView1.DataBind()
        General.setGridStyle(Me.GridView1)
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Response.Redirect("Ads.aspx?Code=" + Me.GridView1.SelectedRow.Cells(0).Text)
    End Sub


 

End Class
