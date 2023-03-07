Imports System.Net.Mail
Imports System.Net
Partial Class FPass
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim tbl As Data.DataTable
        tbl = dbl.SelectAllwhere("peymankar", "email", txtEmail.Text)
        Dim html As String = ""
        If tbl.Rows.Count > 0 Then
            html = "<div style=""font-family:'IRANSans',Tahoma ; direction:rtl ; text-align:right ;"">" + "با سلام و تشکر بابت استفاده از خدمات سایت آها" + "<br />" + "رمز عبور شما:" + tbl.Rows(0).Item("pass").ToString + "<br/><br/>" + "با تشکر." + "<br />" + "تیم فنی آهااااااااااااا" + "</div>"
        Else
            tbl = dbl.SelectAllwhere("karfarma", "email", txtEmail.Text)
            If tbl.Rows.Count > 0 Then
                html = "<div style=""font-family:'IRANSans',Tahoma ; direction:rtl ; text-align:right ;"">" + "با سلام و تشکر بابت استفاده از خدمات سایت آها" + "<br />" + "رمز عبور شما:" + tbl.Rows(0).Item("pass").ToString + "<br/><br/>" + "با تشکر." + "<br />" + "تیم فنی آهااااااااااااا" + "</div>"
            End If
        End If
        If html <> "" Then
            If General.SendMail("تغییر رمز عبور", html, Me.txtEmail.Text) = "" Then
                General.MyMsgBox("کلمه عبور به پست الکترونیکی شما ارسال شد.")
            Else
                General.MyMsgBox("خطا در ارسال ایمیل")
            End If
        Else
            General.MyMsgBox("این کلمه عبور ثبت نام نکرده است")
        End If
    End Sub
End Class
