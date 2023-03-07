Imports System.Web.UI.DataVisualization.Charting

Partial Class rptAdsView
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public Function GetAds() As String
        Return dbl.SelectAllwhere("Prj", "prjid", Request.QueryString("adsId").ToString).Rows(0).Item("title")
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dt As Data.DataTable = dbl.SelectAllwhere("bazdid", "adsId", Request.QueryString("adsId").ToString)
        Dim x As String() = New String(dt.Rows.Count - 1) {}
        Dim y As Integer() = New Integer(dt.Rows.Count - 1) {}
        For i As Integer = 0 To dt.Rows.Count - 1
            x(i) = dt.Rows(i)("Shamsi").ToString()
            y(i) = Convert.ToInt32(dt.Rows(i)("ViewCount"))
        Next
        Chart1.Series(0).Points.DataBindXY(x, y)
        Chart1.Series(0).ChartType = SeriesChartType.Line
        'Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True
        Chart1.Legends(0).Enabled = False
        Chart1.Visible = True
        Dim dt2 As Data.DataTable = dbl.SelectAllwhere("msg", "PrjId", Request.QueryString("adsId").ToString)
        Me.GridView1.DataSource = dt2
        General.setGridStyle(Me.GridView1)
        Me.GridView1.DataBind()
    End Sub
End Class
