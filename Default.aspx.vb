Imports System.IO
Imports System.Data
Imports System.Web.Services

Partial Class Default2
    Inherits System.Web.UI.Page
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

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
                    Return imgfiles(0).Substring(imgfiles(0).IndexOf("UserFiles"))
                End If
            Next

        Catch ex As Exception
            Return "images/thumb_User.png"

        End Try

        Return "images/thumb_User.png"

    End Function
    Public Function DisplayIsFori(cond As String, insertDate As String) As String
        Dim span As TimeSpan = Now.Subtract(insertDate)
        Dim str As String = ""
        If span.Days < 3 Then
            If cond = "True" Then
                Return "inline"
            End If
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
    'Public Function GetPrice(price As String) As String
    '    Dim EditedPrice As String = price
    '    Try
    '        EditedPrice = EditedPrice.Insert(EditedPrice.Length - 3, ".")
    '        If EditedPrice.Length > 7 Then
    '            EditedPrice = EditedPrice.Insert(EditedPrice.Length - 7, ".")
    '        End If
    '        If EditedPrice.Length > 11 Then
    '            EditedPrice = EditedPrice.Insert(EditedPrice.Length - 11, ".")

    '        End If
    '    Catch ex As Exception

    '    End Try
    '    EditedPrice += " تومان "
    '    Return EditedPrice
    'End Function
    Public Function GetRate(val As Integer, count As Integer) As String
        Dim stars As String = ""
        If count = 0 Then
            For i = 1 To 5
                stars += "<span class=""ratingEmpty"" style=""float:left;"">&nbsp;</span>"
            Next
            Return stars
        End If
        Dim rate As Integer = val / count
        For i = 1 To 5
            If i <= rate Then
                stars += "<span class=""ratingFilled"" style=""float:left;"">&nbsp;</span>"
            Else
                stars += "<span class=""ratingEmpty"" style=""float:left;"">&nbsp;</span>"
            End If
        Next
        Return stars
    End Function
    <WebMethod>
    Public Shared Function BindDataAsync(ByVal pageIndex As Integer) As String
        Dim sb As New StringBuilder
        Dim d As New Default2
        Dim dbl As New DataBaseLayer(General.GetConnectionString)
        Using dt As Data.DataTable = dbl.SelectFromCommand(cmd + "  OFFSET " + ((pageIndex - 1) * 4).ToString + " ROWS  FETCH NEXT 4 ROWS ONLY")
            For Each r As DataRow In dt.Rows

                sb.Append("<div class=""col-md-3 col-sm-6 col-xs-12""> " & _
                          "<div class=""ads"" alt=""" + r.Item("description") + """    title =""" + r.Item("description") + """ >" + _
                          "<div class=""img-hover""><img width=""100%""  height=""240""  src=""" + d.GetImage(r.Item("prjid").ToString()) + """>" & _
                          "<img id=""image2"" style=""position: absolute; top: 0px; left: 0px; display:" + d.DisplayIsFori(r("chkFori").ToString(), r("InsertDate").ToString()) + """ src=""img/fori3.png"" />" & _
                           "<div class=""overlay""><a href=""AdsView.aspx?prjid=" + r("prjid").ToString() + """    ></a></div>" & _
                "</div>" & _
                "<div class=""title-ads"" style=""height: 120px;"">" & _
                "<h6><a  href=""AdsView.aspx?prjid=" + r("prjid").ToString() + """   style=""font-size:medium; font-weight:600; color:#0088c0 ;"" >" + r("title").ToString() + "</a></h6>" & _
                "<h6 class=""price"" style="" color:black "">" + r("PriceText").ToString() + " تومان</h6>" & _
                "</div>" & _
                "<div class=""times-ads"">" & _
                "<h6 class=""location""><img src=""img/loc-ic.png""><span>" + d.GetLocation(r("SectorCode").ToString, r("CityName")) + "</span></h6>" & _
                "<h6 class=""time""  style=""font-weight:bold "" >" + General.GetDateSpan(r("insertDate").ToString()) + "</h5>" & _
                "</div>" & _
                "<div class=""stars"">" & _
                "<a href=""#"" OnClick=""neshan(" + r("prjid").ToString() + ")""   style=""color:#843FB8;font-size:X-Large;"" class=""" + d.getEmptyOrFill(r("prjid").ToString()) + """ ID=""lbtnNeshan"" ForeColor=""#843fb8"" ></a>" + d.GetRate(r("rate"), r("rateCount")) & _
                "<img src=""img/play.png"" style=""height:20px; width:20px; margin-top:-5px; display:" + d.DisplayHasFilm(r("Filmdar").ToString()) + """  />" & _
                "<div style="" text-align:left; float:left; padding-top:8px  "" >" & _
                "</div></div></div></div>")
            Next
        End Using

        Return sb.ToString
    End Function
    Public Function GetLocation(SectorCode As String, CityName As String) As String
        Dim str As String = CityName
        If SectorCode <> "" And SectorCode <> "0" Then
            str = dbl.SelectAllwhere("Sector", "SectorCode", SectorCode).Rows(0).Item("SectorName")
        End If

        Return str
    End Function
    Protected Sub lbtnNeshan_Click(sender As Object, e As EventArgs)
        Dim btn As LinkButton = sender
        Dim PrjId As String = btn.CommandArgument.ToString

        If btn.CssClass = "fa fa-bookmark" Then
            Dim w1 As String = Request.Cookies("Neshan").Value
            Response.Cookies("Neshan").Value = w1.Replace("," + PrjId + ",", "")
            btn.CssClass = "fa fa-bookmark-o"
            Try
                dbl.DeleteFromTable("Neshan", "mobile", Session("User").item("Mobile").ToString, "prjid", PrjId)
            Catch ex As Exception

            End Try

            General.MyMsgBox("این مورد از نشان های شما حذف شد.")
        Else
            btn.CssClass = "fa fa-bookmark"
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
            General.MyMsgBox("این مورد به نشان های شما اضافه شد.")

        End If


    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init


        Dim rootCode As Integer = 1
        Try
            If Request.QueryString("jobCode").ToString <> "" Then
                rootCode = Request.QueryString("jobCode").ToString
            End If
        Catch ex As Exception
        End Try
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootCode", rootCode)
        If tbl.Rows.Count > 0 Then
            Me.ddJobs.DataSource = tbl
            Me.ddJobs.DataTextField = "JobName"
            Me.ddJobs.DataValueField = "JobCode"
            Me.ddJobs.DataBind()
            Me.ddJobs.Visible = True
            ddJobs.Items.Insert(0, New ListItem("دسته بندی", 0))

        Else
            Me.ddJobs.Visible = False
        End If

        Me.html1.InnerHtml = map(rootCode)
        If Page.IsPostBack = False Then
            Me.txtTags.Text = Session("txtSearch")
        End If


        bind()

    End Sub
    Protected Sub ddJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddJobs.SelectedIndexChanged
        Response.Redirect("default.aspx?jobCode=" + Me.ddJobs.SelectedValue.ToString)
    End Sub
    Public Function map(code As String) As String
        Try
            With dbl.SelectAllwhere("job", "jobcode", code).Rows(0)
                Return map(dbl.SelectAllwhere("job", "jobcode", code).Rows(0).Item("rootcode").ToString) + "<a href=""default.aspx?jobCode=" + code + """>" + .Item("JobName") + " > " + "</a>"
            End With

        Catch ex As Exception

        End Try
        Return ""
    End Function
    Public Shared cmd As String
    Public Sub SetCMD(Optional fromBtn As String = "")
        Dim strSearch() As String = Me.txtTags.Text.Split(" ")
        cmd = ""
        Dim tbl As New Data.DataTable
        If Me.txtTags.Text <> "" Then
            tbl = General.solrSearch(Me.txtTags.Text, 100)
        End If

        Dim jobCode As String = "1"
        If IsNothing(Request.QueryString("jobcode")) = False Then
            jobCode = Request.QueryString("jobcode")
        End If
        '"
        Dim expDay As String = dbl.SelectAllwhere("txtSetting", "id", "1").Rows(0).Item("expDay").ToString
        cmd = " select * from prj  where insertDate>=dateadd(day, -" + expDay + ", getdate()) and  status=1 and deleted=0  "

        If txtFrom.Text <> "" Then
            cmd += " and price>=" + txtFrom.Text
        End If
        If txtUntil.Text <> "" Then
            cmd += " and price<=" + txtUntil.Text
        End If
        If chkNew.Checked Then
            cmd += " and chkNew=1 "
        End If
        If chkFori.Checked Then
            cmd += " and chkFori=1 "
        End If
        If chkAx.Checked Then
            cmd += " and axdar=1 "
        End If
        If chkFilm.Checked Then
            cmd += " and filmdar=1 "
        End If
        If IsNothing(Request.QueryString("Nardban")) = False Then
            If Request.QueryString("Nardban") = "1" Then
                cmd += " and chkNardban=1 "
            End If

        End If
        If fromBtn = "btn" Then
            cmd += searchFields()
        End If
        cmd += " and  (jobid=" + jobCode + ChildjobsStr(jobCode) + ")"
        Dim solrcmd As String = " prjid=1 "
        For i = 0 To tbl.Rows.Count - 1
            solrcmd += " or prjid=" + tbl.Rows(i).Item("prjid").ToString
        Next
        If Me.txtTags.Text <> "" Then
            cmd += " and (" + solrcmd + ")"
        End If
        cmd += " order by " + Me.ddOrder.SelectedValue
    End Sub
    Public Sub bind(Optional fromBtn As String = "")
        SetCMD(fromBtn)
        Dim tbl As Data.DataTable = dbl.SelectFromCommand(cmd + "  OFFSET 0 ROWS  FETCH NEXT 4 ROWS ONLY")
        If Me.ibtnView.CommandArgument = "1" Then
            Me.rptThumb.DataSource = tbl
            Me.rptThumb.DataBind()
            If tbl.Rows.Count > 0 Then
                Me.lblNoAds.Visible = False
            Else
                Me.lblNoAds.Visible = True
            End If
            Me.rptRow.Visible = False
            Me.rptThumb.Visible = True
        Else
            Me.rptRow.Visible = True
            Me.rptThumb.Visible = False
            Me.rptRow.DataSource = tbl
            Me.rptRow.DataBind()

            If tbl.Rows.Count > 0 Then
                Me.lblNoAds.Visible = False
            Else
                Me.lblNoAds.Visible = True
            End If

        End If

    End Sub
    Public Function ChildjobsStr(code As String) As String
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootcode", code)
        Dim cmd As String = ""
        For i = 0 To tbl.Rows.Count - 1
            cmd += " or jobid=" + tbl.Rows(i).Item("jobCode").ToString + ChildjobsStr(tbl.Rows(i).Item("jobCode").ToString)
        Next

        Return cmd
    End Function
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        bind("btn")
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Session("txtSearch") = ""
        Response.Redirect("default.aspx")
    End Sub
    Public Sub EnableDisable(ibtn As ImageButton)
        If ibtn.CommandArgument = "1" Then
            ibtn.CommandArgument = "0"
            ibtn.ImageUrl = "img/disable.png"
        Else
            ibtn.CommandArgument = "1"
            ibtn.ImageUrl = "img/enable.png"
        End If
        bind()
    End Sub

    'Protected Sub ibtnAx_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAx.Click
    '    EnableDisable(sender)
    'End Sub

    'Protected Sub ibtnFilm_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnFilm.Click
    '    EnableDisable(sender)
    'End Sub

    'Protected Sub ibtnFori_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnFori.Click
    '    EnableDisable(sender)
    'End Sub

    'Protected Sub ibtnNo_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnNo.Click
    '    EnableDisable(sender)
    'End Sub

    Protected Sub ibtnView_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnView.Click
        If ibtnView.CommandArgument = "1" Then
            ibtnView.CommandArgument = "0"
            ibtnView.ImageUrl = "img/thumb.png"
        Else
            ibtnView.CommandArgument = "1"
            ibtnView.ImageUrl = "img/row.png"
        End If
        bind()
    End Sub

    Protected Sub ddOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddOrder.SelectedIndexChanged
        bind()
    End Sub

    Protected Sub chkAx_ServerChange(sender As Object, e As EventArgs) Handles chkAx.ServerChange
        bind()
    End Sub
    Protected Sub Server_Changed(sender As Object, e As EventArgs)
        bind()
    End Sub
    Public Sub getFields()
        Me.divFields.Controls.Clear()
        If IsNothing(Request.QueryString("jobCode")) = False Then

            If Request.QueryString("jobCode") <> "" Then
                Dim tblFields As Data.DataTable = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", Request.QueryString("jobCode"), "isControlic", "1", "sort")
                Me.divFields.Controls.Add(New LiteralControl("<div  class=""row"" >"))

                For i = 0 To tblFields.Rows.Count - 1
                    If i Mod 2 = 1 Then
                        Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" ></div>"))
                    Else
                        Me.divFields.Controls.Add(New LiteralControl("</div><div  class=""row"" >"))
                    End If
                    If tblFields.Rows(i).Item("dataType") = "bit" Then
                        Dim chk As New CheckBox
                        chk.ID = "chk" + i.ToString
                        Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >"))
                        chk.Text = tblFields.Rows(i).Item("title")
                        Me.divFields.Controls.Add(chk)
                        Me.divFields.Controls.Add(New LiteralControl("</div>"))
                    End If
                    If tblFields.Rows(i).Item("dataType") = "string" Then
                        Dim txt As New TextBox
                        txt.ID = "txt" + i.ToString
                        txt.Width = 120

                        txt.CssClass = "textbox"
                        Dim desc As String = ""
                        If tblFields.Rows(i).Item("FieldDescription") <> "" Then
                            desc = "<img  src=""img/q2.png"" title=""" + tblFields.Rows(i).Item("FieldDescription") + """ style=""width:15px;height:15px"" />"
                        End If
                        Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + desc + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >"))
                        Me.divFields.Controls.Add(txt)


                        Me.divFields.Controls.Add(New LiteralControl("</div>"))

                    End If
                    If tblFields.Rows(i).Item("dataType") = "number" Then
                        Dim txtFr As New TextBox
                        txtFr.ID = "txtFr" + i.ToString
                        txtFr.TextMode = TextBoxMode.Number
                        txtFr.CssClass = "textbox"
                        Dim desc As String = ""
                        If tblFields.Rows(i).Item("FieldDescription") <> "" Then
                            desc = "<img  src=""img/q2.png"" title=""" + tblFields.Rows(i).Item("FieldDescription") + """ style=""width:15px;height:15px"" />"
                        End If
                        txtFr.Width = 50
                        Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + desc + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >از:"))
                        Me.divFields.Controls.Add(txtFr)
                        Dim txtTo As New TextBox
                        txtTo.ID = "txtTo" + i.ToString
                        txtTo.TextMode = TextBoxMode.Number
                        txtTo.CssClass = "textbox"
                        txtTo.Width = 50
                        Me.divFields.Controls.Add(New LiteralControl("تا:"))
                        Me.divFields.Controls.Add(txtTo)


                        Me.divFields.Controls.Add(New LiteralControl("</div>"))

                    End If

                Next
                Me.divFields.Controls.Add(New LiteralControl("</div>"))
            End If
        End If

    End Sub

    Public Function searchFields() As String
        Dim cmd As String
        If IsNothing(Request.QueryString("jobCode")) = False Then

            If Request.QueryString("jobCode") <> "" Then
                Dim tblFields As Data.DataTable = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", Request.QueryString("jobCode"), "isControlic", "1", "sort")

                For i = 0 To tblFields.Rows.Count - 1
                    If tblFields.Rows(i).Item("dataType") = "bit" Then
                        Dim chk As New CheckBox
                        chk = Me.divFields.FindControl("chk" + i.ToString)
                        If chk.Checked Then
                            cmd += " and val" + tblFields.Rows(i).Item("sort").ToString + "=N'1'"
                        End If
                    End If
                    If tblFields.Rows(i).Item("dataType") = "string" Then
                        Dim txt As New TextBox
                        txt = Me.divFields.FindControl("txt" + i.ToString)
                        If txt.Text <> "" Then
                            cmd += " and val" + tblFields.Rows(i).Item("sort").ToString + " LIKE N'%" + txt.Text + "%'"
                        End If
                    End If

                    If tblFields.Rows(i).Item("dataType") = "number" Then
                        Dim txtFr As New TextBox
                        txtFr = Me.divFields.FindControl("txtFr" + i.ToString)
                        If txtFr.Text <> "" Then
                            cmd += " and val" + tblFields.Rows(i).Item("sort").ToString + ">= N'" + txtFr.Text + "'"
                        End If
                        Dim txtTo As New TextBox
                        txtTo = Me.divFields.FindControl("txtTo" + i.ToString)
                        If txtTo.Text <> "" Then
                            cmd += " and val" + tblFields.Rows(i).Item("sort").ToString + "<= N'" + txtTo.Text + "'"
                        End If

                    End If

                Next
            End If
        End If
        Return cmd
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        getFields()
    End Sub
End Class
