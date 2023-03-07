
Partial Class pay
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            Me.RadioButtonList1.Items(CInt(Request.QueryString("Code")) - 1).Selected = True
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("default.aspx")
    End Sub

    Protected Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        'بعد از پرداخت موفقیت آمیز
        Try
            If Request.QueryString("Code") = "1" Or Request.QueryString("Code") = "3" Then
                dbl.UpdateAField("prj", "chkFori", "1", "prjid", Request.QueryString("prjid"))
            End If
            If Request.QueryString("Code") = "2" Or Request.QueryString("Code") = "3" Then
                dbl.UpdateAField("prj", "chkNardban", "1", "prjid", Request.QueryString("prjid"))
            End If
            General.MyMsgBox("پرداخت با موفقیت انجام شد و گزینه های مورد نظر برای آگهی شما فعال گردید", "", 5, "default.aspx")

        Catch ex As Exception

        End Try
    End Sub
End Class
