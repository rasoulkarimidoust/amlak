Imports System.Drawing
Imports System.IO
Imports System.Net.Mime.MediaTypeNames

Partial Class Agahi
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public dr As Data.DataRow
    Public Function ChangeIfFilm(src As String) As String
        Dim ext As String = src.Substring(src.LastIndexOf(".") + 1).ToLower
        If ext = "png" Or ext = "jpg" Or ext = "gif" Or ext = "jpeg" Or ext = "bmp" Then
            Return src
        End If
        Return "/images/film.png"

    End Function
    Public Function GetSectorName(SectorCode As String) As String
        Try
            If SectorCode <> "" Then
                Return dbl.SelectAllwhere("Sector", "SectorCode", SectorCode).Rows(0).Item("SectorName")
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init


        Dim PrjId As String = Request.QueryString("PrjId").ToString
        If Not (Request.Cookies("Recent") Is Nothing) Then
            If Not (Request.Cookies("Recent").Value Is Nothing) Then
                If Request.Cookies("Recent").Value.Contains("," + PrjId + ",") = False Then
                    Response.Cookies("Recent").Value = Request.Cookies("Recent").Value + "," + PrjId + ","
                End If
            Else
                Response.Cookies("Recent").Value = "," + PrjId + ","

            End If
        Else
            Response.Cookies("Recent").Value = "," + PrjId + ","

        End If

        If IsNothing(Session("User")) = False Then
            Try
                dbl.Insert("UserViewedAds", "mobile", Session("User").item("Mobile").ToString, "prjid", PrjId)
            Catch ex As Exception

            End Try
        End If

        dr = dbl.SelectAllwhere("prj", "prjId", PrjId).Rows(0)
        dbl.UpdateAField("Prj", "ViewCount", (dr.Item("ViewCount") + 1).ToString, "prjId", PrjId)
        Dim tbl As Data.DataTable = dbl.SelectFromCommand(" select * from bazdid where adsId=" + PrjId + "  AND (ViewDate =  convert(varchar(10),GETDATE(),120)) ")
        If tbl.Rows.Count > 0 Then
            dbl.ExecCommand(" update bazdid set ViewCount= ViewCount+1  where adsId=" + PrjId + "  AND (ViewDate =  convert(varchar(10),GETDATE(),120)) ")
        Else
            dbl.ExecCommand("insert into bazdid(adsid,ViewCount,shamsi) select  " + PrjId + ", 1,dbo.GetShamsiDate() ")
        End If
        Dim tblField As Data.DataTable = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", dr.Item("jobId").ToString, "sort")
        For i = 0 To tblField.Rows.Count - 1
            If IsDBNull(dr.Item("val" + (i + 1).ToString)) = False Then
                If dr.Item("val" + (i + 1).ToString) <> "" Then
                    If (tblField.Rows(i).Item("dataType") = "price") Then
                        Dim value As Double = Double.Parse(dr.Item("val" + (i + 1).ToString), System.Globalization.NumberStyles.Integer Or System.Globalization.NumberStyles.AllowThousands)
                        'txt.Text = value.ToString("N0")
                        Me.divFields.Controls.Add(New LiteralControl("<span  itemprop=""name"">" + tblField.Rows(i).Item("title") + ":" + value.ToString("N0") + "</span><br/>"))

                    End If
                Else

                    Me.divFields.Controls.Add(New LiteralControl("<span  itemprop=""name"">" + tblField.Rows(i).Item("title") + ":" + dr.Item("val" + (i + 1).ToString) + "</span><br/>"))
                End If

            End If
        Next
        If IsNothing(dr.Item("tags")) = False Then
            If dr.Item("tags").ToString <> "" Then
                Me.divTags.Controls.Add(New LiteralControl("برچسبها: "))
                Dim strTags() As String = dr.Item("tags").ToString.Split(";")
                For i = 0 To strTags.Length - 1
                    If strTags(i) <> "" Then
                        Me.divTags.Controls.Add(New LiteralControl("&nbsp;&nbsp;<a href=""default.aspx?tag=" + strTags(i) + """>" + strTags(i) + "</a>"))
                    End If

                Next
            End If
        End If

        If dr.Item("chkEmail").ToString = "True" Then
            Me.spnData.InnerHtml += "<br/>" + "ایمیل:" + dr.Item("Email").ToString
            Me.lblEmail.Text = dr.Item("Email").ToString
        Else
            Me.lblEmail.Text = "عدم اجازه نمایش"
        End If
        If dr.Item("SiteOk").ToString = "True" Then
            Me.spnData.InnerHtml += "<br/>" + "سایت:" + dr.Item("Site").ToString
        End If
        If dr.Item("chkfori").ToString = "True" Then
            Me.spnData.InnerHtml += "<br/>" + "فوری"
        End If
        If dr.Item("chkNew").ToString = "True" Then
            Me.spnData.InnerHtml += "<br/>" + "نو"
        End If
        If dr.Item("ratecount") = 0 Then
            Me.rates.CurrentRating = 0
        Else
            Me.rates.CurrentRating = dr.Item("rate") / dr.Item("ratecount")
        End If
        Me.N.Text = dr.Item("N").ToString
        Me.E.Text = dr.Item("E").ToString

        Dim path As String = Server.MapPath("UserFiles\" + PrjId)
        If IO.Directory.Exists(path) Then
            Dim imgfiles() As String = IO.Directory.GetFiles(path)
            If imgfiles.Length > 0 Then
                For i = 0 To imgfiles.Count - 1
                    imgfiles(i) = "/" + imgfiles(i).Substring(imgfiles(i).IndexOf("UserFiles"))

                Next

            End If

            Me.ads1.DataSource = imgfiles
            Me.ads1.DataBind()

        End If

        Dim IsAdmin As Boolean = False
        Try
            If Session("UserType") = "admin" Then
                IsAdmin = True
            End If

        Catch ex As Exception

        End Try
        If IsAdmin = False Then
            Dim tblSimilar As Data.DataTable = dbl.SelectFromCommand("select top(4) * from prj where (jobid=" + dr.Item("jobid").ToString + ") and (prjid<>" + PrjId + ")  order by prjid desc")
            If tblSimilar.Rows.Count > 0 Then
                Me.rptSimilar.DataSource = tblSimilar
                Me.rptSimilar.DataBind()
                Me.spnSimilar.Visible = True
            Else
                Me.spnSimilar.Visible = False
            End If
        Else
            Me.spnSimilar.Visible = False

        End If
        Me.divEdit2.Visible = Not IsNothing(Session("user"))
    End Sub
    Public Function GetImage(id As String) As String
        Dim path As String = Server.MapPath("UserFiles\" + id.ToString)
        Dim extensions4Pic As New List(Of String)
        extensions4Pic.Add("*.png")
        extensions4Pic.Add("*.jpg")
        extensions4Pic.Add("*.gif")
        extensions4Pic.Add("*.jpeg")
        extensions4Pic.Add("*.bmp")
        Dim axdar As String = "0"
        Try
            For i As Integer = 0 To extensions4Pic.Count - 1
                Dim imgfiles() As String = Directory.GetFiles(path, extensions4Pic(i), SearchOption.TopDirectoryOnly)
                If imgfiles.Length > 0 Then
                    Return "/" + imgfiles(0).Substring(imgfiles(0).IndexOf("UserFiles"))
                End If
            Next
        Catch ex As Exception

        End Try

        Return "/images/thumb_User.png"

    End Function
    Public Function DisplayIsFori(cond As String) As String
        If cond = "True" Then
            Return "inline"
        End If
        Return "none"
    End Function
    Public Function DisplayHasFilm(cond As String) As String
        If cond = "True" Then
            Return "inline"
        End If
        Return "none"
    End Function
    Public Function getEmptyOrFill(PrjId As String) As String
        Try
            Dim w As String = Request.Cookies("Neshan").Value
            If w.Contains(PrjId.ToString) Then
                Return "fa fa-bookmark"
            End If

        Catch ex As Exception

        End Try
        Return "fa fa-bookmark-o"
    End Function
    Public Function GetPrice(price As String) As String
        Dim EditedPrice As String = price
        Try
            EditedPrice = EditedPrice.Insert(EditedPrice.Length - 3, ".")
            If EditedPrice.Length > 7 Then
                EditedPrice = EditedPrice.Insert(EditedPrice.Length - 7, ".")
            End If
            If EditedPrice.Length > 11 Then
                EditedPrice = EditedPrice.Insert(EditedPrice.Length - 11, ".")

            End If
        Catch ex As Exception

        End Try
        EditedPrice += " تومان "
        Return EditedPrice
    End Function
    Public Function GetRate(val As Integer, count As Integer) As String
        If count = 0 Then
            Return "0"
        End If
        Return (val / count).ToString
    End Function

    Protected Sub rate_Changed(sender As Object, e As AjaxControlToolkit.RatingEventArgs) Handles rates.Changed
        dbl.ExecCommand("update prj set rate=rate+" + e.Value.ToString + ",ratecount=ratecount+1 where prjid=" + Request.QueryString("PrjId").ToString)
        Me.divConfirm.Visible = False
        Me.divReport.Visible = False
        Me.divMsg4Ader.Visible = False

        General.MyMsgBox("امتیاز شما ثبت شد")
    End Sub

    Protected Sub lbtnDel_Click(sender As Object, e As EventArgs) Handles lbtnDel.Click
        Me.divConfirm.Visible = True
        Me.divReport.Visible = False
        Me.divMsg4Ader.Visible = False

        General.MyMsgBox("", "آیا از حذف  مطمئن هستید؟ ")

    End Sub

    Protected Sub btnReportReson_Click(sender As Object, e As EventArgs) Handles btnReportReson.Click
        Dim PrjId As String = Request.QueryString("PrjId").ToString
        dbl.ExecCommand(" update prj set Reported=Reported+1 where prjid=" + PrjId)
        Dim txt As String = ""
        If ddReport.SelectedIndex > 0 Then
            txt = ddReport.SelectedValue
        End If
        txt += " : " + txtReport.Text
        dbl.Insert("report", "prjid", PrjId, "text", txt)
        Me.divReport.Visible = False
        Me.divConfirm.Visible = False
        Me.divMsg4Ader.Visible = False
        General.MyMsgBox("گزارش فوق ثبت شد و در اولین فرصت توسط مدیران سایت بررسی خواهد شد")

    End Sub

    Protected Sub lbtnReport_Click(sender As Object, e As EventArgs) Handles lbtnReport.Click
        Me.divReport.Visible = True
        Me.divConfirm.Visible = False
        Me.divMsg4Ader.Visible = False
        General.MyMsgBox("")

    End Sub

    Protected Sub lbtnBazdid_Click(sender As Object, e As EventArgs) Handles lbtnBazdid.Click
        Response.Redirect("rptAdsView.aspx?adsid=" + Request.QueryString("PrjId").ToString)

    End Sub

    Protected Sub lbtnNeshan_Click(sender As Object, e As EventArgs) Handles lbtnNeshan.Click
        Dim PrjId As String = Request.QueryString("PrjId").ToString
        If Not (Request.Cookies("Neshan") Is Nothing) Then
            If Not (Request.Cookies("Neshan").Value Is Nothing) Then
                If Request.Cookies("Neshan").Value.Contains("," + PrjId + ",") = False Then
                    Response.Cookies("Neshan").Value = Request.Cookies("Neshan").Value + "," + PrjId + ","
                End If
            Else
                Response.Cookies("Neshan").Value = "," + PrjId + ","

            End If
        Else
            Response.Cookies("Neshan").Value = "," + PrjId + ","

        End If


        If IsNothing(Session("User")) = False Then
            Try
                dbl.Insert("Neshan", "mobile", Session("User").item("Mobile").ToString, "prjid", PrjId)
            Catch ex As Exception

            End Try
        End If
        Me.divConfirm.Visible = False
        Me.divReport.Visible = False
        Me.divMsg4Ader.Visible = False

        General.MyMsgBox("این مورد به موارد نشان شده شما اضافه شد.")
    End Sub

    Protected Sub btnDel2_Click(sender As Object, e As EventArgs) Handles btnDel2.Click
        dbl.Update("Prj", "status", "3", "statusText", "حذف", "deleted", "1", , , , , , , , , , , , , , , "prjid", Request.QueryString("PrjId"))
        Me.divReport.Visible = False
        Me.divConfirm.Visible = False
        Me.divMsg4Ader.Visible = False

        General.MyMsgBox("مورد فوق حذف گردید", , 5, "default.aspx")

    End Sub

    Protected Sub lbtnMsg_Click(sender As Object, e As EventArgs) Handles lbtnMsg.Click
        Me.divReport.Visible = False
        Me.divConfirm.Visible = False
        Me.divMsg4Ader.Visible = True
        General.MyMsgBox("")

    End Sub

    Protected Sub btnSendMsg_Click(sender As Object, e As EventArgs) Handles btnSendMsg.Click
        Dim PrjId As String = Request.QueryString("PrjId").ToString
        Dim ipaddress As String = ""
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        dbl.Insert("Msg", "prjid", PrjId, "text", Me.TxtMsgText.Text, "IP", ipaddress, "Name", Me.txtmsgName.text, "address", Me.txtMsgAddress.text, "Email", Me.txtMsgEmail.Text, "Tel", Me.txtMsgTel.Text)
        Me.divReport.Visible = False
        Me.divConfirm.Visible = False
        Me.divMsg4Ader.Visible = False
        General.MyMsgBox("پیغام فوق ارسال شد")

    End Sub
End Class
