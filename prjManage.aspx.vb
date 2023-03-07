
Partial Class prjManage
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.ddPrjStatus.DataSource = dbl.SelectAll("PrjStatus")
            Me.ddPrjStatus.DataTextField = "StatusName"
            Me.ddPrjStatus.DataValueField = "StatusCode"
            Me.ddPrjStatus.DataBind()
            Me.GridView1.DataSource = dbl.SelectFromCommand("select top(10) * from prj where status=0 and deleted=0  order by prjid desc") 'where status=1 or status=2")
            Me.GridView1.DataBind()
            General.setGridStyle(Me.GridView1)

        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Response.Redirect("Ads.aspx?Code=" + Me.GridView1.SelectedRow.Cells(0).Text)
    End Sub

    Public Function GetRate(val As Integer, count As Integer) As String
        If count = 0 Then
            Return "0"
        End If
        Return (val / count).ToString
    End Function
 

    Protected Sub ddPrjStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddPrjStatus.SelectedIndexChanged
        Me.GridView1.DataSource = dbl.SelectFromCommand("select top(10) * from prj where status=" + ddPrjStatus.SelectedValue.ToString + " order by prjid desc") 'where status=1 or status=2")
        Me.GridView1.DataBind()
        General.setGridStyle(Me.GridView1)

    End Sub
End Class
