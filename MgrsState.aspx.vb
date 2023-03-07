
Imports System.Web.UI.DataVisualization.Charting

Partial Class Mgrs
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            bind()
            General.setGridStyle(Me.GridView1)
        End If


    End Sub
    Public Sub bind()
        Dim dt As Data.DataTable
        dt = dbl.SelectAll("Admin")
        Me.GridView1.DataSource = dt
        Me.GridView1.DataBind()

        drawChartAll()
    End Sub

    Private Sub ddAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddAction.SelectedIndexChanged
        If ddAction.SelectedValue = "All" Then
            drawChartAll()
        Else
            drawChart()
        End If
        Chart1.DataBind()
    End Sub
    Public Sub drawChartAll()
        Dim dt As Data.DataTable
        dt = dbl.SelectAll("Admin")
        Chart1.DataSource = dt

        Dim series As Series
        Dim leg As Legend

        Chart1.Legends.Clear()
        Chart1.Series.Clear()

        leg = New Legend("تائید آگهی")
        Chart1.Legends.Add(leg)

        series = New Series("تائید آگهی", DataVisualization.Charting.SeriesChartType.Area)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "OkadsCount"
        Chart1.Series.Add(series)

        leg = New Legend("رد آگهی")
        Chart1.Legends.Add(leg)
        series = New Series("رد آگهی", DataVisualization.Charting.SeriesChartType.Line)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "NOkadsCount"
        Chart1.Series.Add(series)


        leg = New Legend("تائید همکاری")
        Chart1.Legends.Add(leg)
        series = New Series("تائید همکاری", DataVisualization.Charting.SeriesChartType.BoxPlot)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "OKempCount"
        Chart1.Series.Add(series)

        leg = New Legend("رد همکاری")
        Chart1.Legends.Add(leg)
        series = New Series("رد همکاری", DataVisualization.Charting.SeriesChartType.Bar)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "NOKempCount"
        Chart1.Series.Add(series)

        leg = New Legend("بایگانی همکاری")
        Chart1.Legends.Add(leg)
        series = New Series("بایگانی همکاری", DataVisualization.Charting.SeriesChartType.Bubble)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "ARCempCount"
        Chart1.Series.Add(series)

        leg = New Legend("تائید پیشنهاد/انتقاد")
        Chart1.Legends.Add(leg)
        series = New Series("تائید پیشنهاد/انتقاد", DataVisualization.Charting.SeriesChartType.Candlestick)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "OkofferCount"
        Chart1.Series.Add(series)

        leg = New Legend("رد پیشنهاد/انتقاد")
        Chart1.Legends.Add(leg)
        series = New Series("رد پیشنهاد/انتقاد", DataVisualization.Charting.SeriesChartType.Column)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "NOkofferCount"
        Chart1.Series.Add(series)

        leg = New Legend("بایگانی پیشنهاد/انتقاد")
        Chart1.Legends.Add(leg)
        series = New Series("بایگانی پیشنهاد/انتقاد", DataVisualization.Charting.SeriesChartType.Doughnut)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = "ARCofferCount"
        Chart1.Series.Add(series)

        Chart1.DataBind()

    End Sub
    Public Sub drawChart()
        Dim dt As Data.DataTable
        dt = dbl.SelectAll("Admin")
        Chart1.DataSource = dt

        Dim series As Series
        Dim leg As Legend

        Chart1.Legends.Clear()
        Chart1.Series.Clear()

        leg = New Legend(Me.ddAction.SelectedItem.Text)
        Chart1.Legends.Add(leg)

        series = New Series(Me.ddAction.SelectedItem.Text, DataVisualization.Charting.SeriesChartType.Area)
        series.ChartType = DataVisualization.Charting.SeriesChartType.Line
        series.XValueMember = "Name"
        series.YValueMembers = Me.ddAction.SelectedValue
        Chart1.Series.Add(series)
        Chart1.DataBind()


    End Sub
End Class
