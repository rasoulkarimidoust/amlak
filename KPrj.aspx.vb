Imports AjaxControlToolkit

Partial Class KAds
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GridView1.DataSource = dbl.SelectFromCommand(" select * from Prj where status=1 and karfarmaId=" + Session("User").item("karfarmaid").ToString)
        Me.GridView1.DataBind()
        General.setGridStyle(GridView1)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Session("prjid") = Me.GridView1.SelectedRow.Cells(0).Text
        Me.ratingControl1.CurrentRating = 0
        Me.ratingControl2.CurrentRating = 0
        Me.ratingControl3.CurrentRating = 0
        Me.ratingControl4.CurrentRating = 0
        Me.ratingControl5.CurrentRating = 0
        Me.ratingControl6.CurrentRating = 0
        Me.Label1.Text = "0"
        Me.Label2.Text = "0"
        Me.Label3.Text = "0"
        Me.Label4.Text = "0"
        Me.Label5.Text = "0"
        Me.Label6.Text = "0"
        Me.txtKComment.Text = ""
        Me.divRate.Visible = True
        General.MyMsgBox("", "")
    End Sub
    Protected Sub ratingControl1_Changed(sender As Object, e As RatingEventArgs)
        Me.Label1.Text = (e.Value * 2).ToString
    End Sub

    Protected Sub ratingControl2_Changed(sender As Object, e As RatingEventArgs)
        Me.Label2.Text = (e.Value * 2).ToString
    End Sub
    Protected Sub ratingControl3_Changed(sender As Object, e As RatingEventArgs)
        Me.Label3.Text = (e.Value * 2).ToString
    End Sub
    Protected Sub ratingControl4_Changed(sender As Object, e As RatingEventArgs)
        Me.Label4.Text = (e.Value * 2).ToString
    End Sub
    Protected Sub ratingControl5_Changed(sender As Object, e As RatingEventArgs)
        Me.Label5.Text = (e.Value * 2).ToString
    End Sub
    Protected Sub ratingControl6_Changed(sender As Object, e As RatingEventArgs)
        Me.Label6.Text = (e.Value * 2).ToString
    End Sub

    Protected Sub btnSaveComment_Click(sender As Object, e As EventArgs) Handles btnSaveComment.Click
        Dim PeymankarId As String = dbl.SelectAllwhere("prj", "prjId", Session("prjid")).Rows(0).Item("PeymankarId").ToString
        Dim newStatus As String = ""
        If rbCancelAndContinue.Checked Then
            newStatus = "0"
            dbl.ExecCommand(" update prj set PeymankarId=NULL,status=0,statusText=N'آگهی' where prjid=" + Session("prjid"))
            dbl.UpdateAField("offer", "deleted", "1", "prjId", Session("prjid"), , "PeymankarId", PeymankarId)
            Dim offerCount As String = dbl.SelectAllwhere("offer", "deleted", "0", "prjId", Session("prjid"), "PeymankarId", PeymankarId).Rows.Count
            dbl.UpdateAField("prj", "OfferCount", offerCount, "prjId", Session("prjid"))

        End If
        If rbCancelAndDelete.Checked Then
            newStatus = "3"
            dbl.UpdateAField("offer", "deleted", "1", "prjId", Session("prjid"), , "PeymankarId", PeymankarId)
            Dim offerCount As String = dbl.SelectAllwhere("offer", "deleted", "0", "prjId", Session("prjid"), "PeymankarId", PeymankarId).Rows.Count
            dbl.Update("prj", "status", "3", "statusText", "کنسل", "OfferCount", offerCount, , , , , , , , , , , , , , , "prjId", Session("prjid"))
        End If
        If rbEnd.Checked Then
            newStatus = "2"
            dbl.ExecCommand(" update prj set status=2,statusText=N'اتمام' where prjid=" + Session("prjid"))
            Dim rate As Integer
            Dim sum As Integer = 0
            sum = CInt(Me.Label1.Text) + CInt(Me.Label2.Text) + CInt(Me.Label3.Text) + CInt(Me.Label4.Text) + CInt(Me.Label5.Text) + CInt(Me.Label6.Text)
            rate = sum / 6
            dbl.Update("prj", "status", "2", "statusText", "اتمام", "KComment", txtKComment.Text, "rate1", Label1.Text, "rate2", Label2.Text, "rate3", Label3.Text, "rate4", Label4.Text, "rate5", Label5.Text, "rate6", Label6.Text, "rate", rate, "prjId", Session("prjid"))
            updateRate(PeymankarId)
        End If
        Me.divRate.Visible = False
        General.MyMsgBox("نظر شما در مورد پیمانکار ذخیره شد و وضعیت پروژه بروز گردید")
    End Sub
    Public Sub updateRate(peymankarid As String)
        Dim rate As Integer
        Dim tbl As Data.DataTable
        Dim sum As Integer = 0
        tbl = dbl.SelectAllwhere("prj", "peymankarid", peymankarid)
        For i = 0 To tbl.Rows.Count - 1
            sum += tbl.Rows(0).Item("rate1")
            sum += tbl.Rows(0).Item("rate2")
            sum += tbl.Rows(0).Item("rate3")
            sum += tbl.Rows(0).Item("rate4")
            sum += tbl.Rows(0).Item("rate5")
            sum += tbl.Rows(0).Item("rate6")
        Next
        rate = sum / ((tbl.Rows.Count) * 6)
        dbl.UpdateAField("Peymankar", "rate", rate.ToString, "PeymankarId", peymankarid)
    End Sub
End Class
