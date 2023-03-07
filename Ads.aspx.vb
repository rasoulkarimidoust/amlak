Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Net.Mime.MediaTypeNames
Imports Microsoft.WindowsAzure.Storage

Partial Class Ads
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public Shared dr As Data.DataRow
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.IsPostBack = False Then

            Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootCode", "1")
            Me.ddjob.DataSource = tbl
            Me.ddjob.DataTextField = "JobName"
            Me.ddjob.DataValueField = "JobCode"
            Me.ddjob.DataBind()
            ddjob.Items.Insert(0, New ListItem("انتخاب کنید:", 0))
            'city
            Dim tblcity As Data.DataTable = dbl.SelectAll("City", "CityCode")
            ' DataTable.Rows("value3").Item("ColumnName2) 
            Me.ddcity.DataSource = tblcity
            Me.ddcity.DataTextField = "CityName"
            Me.ddcity.DataValueField = "CityCode"
            'Me.ddcity.Attributes.Add("data-latitude", tblcity.Columns(2).DefaultValue.ToString)
            'Me.ddcity.Attributes.Add("data-longitude", tblcity.Columns(3).ToString)
            Me.ddcity.DataBind()
            For i = 0 To ddcity.Items.Count - 1
                ddcity.Items(i).Attributes.Add("data-latitude", tblcity.Rows(i).Item(2).ToString.Trim)
                ddcity.Items(i).Attributes.Add("data-longitude", tblcity.Rows(i).Item(3).ToString.Trim)
            Next
            ddcity.Items.Insert(0, New ListItem("انتخاب شهر:", 0))

            If IsNothing(Request.QueryString("Code")) = False Then
                bind()
            Else

            End If
        End If

    End Sub
    Public Sub bind()
        dr = dbl.SelectAllwhere("Prj", "prjId", Request.QueryString("Code").ToString).Rows(0)
        Me.N.Text = dr.Item("N").ToString
        Me.E.Text = dr.Item("E").ToString
        '  System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "bindmarker('" + Me.N.Text + "','" + Me.E.Text + "');", True)
        ScriptManager.RegisterStartupScript(Me, [GetType](), "TestFunction", "bindmarker('" + Me.N.Text + "','" + Me.E.Text + "');", True)

        Me.txtDesc.Text = dr.Item("description").ToString
        Me.txtEmail.Text = dr.Item("Email").ToString
        Me.txtPrice.Text = dr.Item("PriceText").ToString
        Me.txtTel.Text = dr.Item("tel").ToString
        Me.txtTelegram.Text = dr.Item("telegram").ToString
        Me.txtSite.Text = dr.Item("Site").ToString
        Me.txtTitle.Text = dr.Item("title").ToString
        Me.txtCity.Text = dr.Item("CityName").ToString
        Me.btnUp.Visible = True
        'Me.ddPricetype.Items.FindByText(dr.Item("PriceType").ToString).Selected = True
        Me.ddjob.Visible = False
        Me.txtRootJobCode.Value = dr.Item("JobId").ToString

        Me.chkEmail.Checked = dr.Item("chkEmail")
        Me.chkFori.Checked = dr.Item("chkFori")
        ' Me.txtMobile.Text = dr.Item("mobile")
        Me.chkNardban.Checked = dr.Item("chkNardban")
        'Me.chkNew.Checked = dr.Item("chkNew")
        If IsNothing(dr.Item("tags")) = False Then
            Me.txtTags.Text = dr.Item("tags").ToString
        End If
        Me.txtPic.Text = Request.QueryString("Code").ToString
        If Session("UserType") = "admin" Then
            Me.divOnly4Insert.Visible = False
            If dr.Item("Reported") Then
                Me.lblReport.Text = "این مورد گزارش شده است. " + dbl.SelectAllwhere("Report", "prjId", dr.Item("prjId").ToString).Rows(0).Item("text")
                Me.divReport.Visible = True
            End If
        End If
        'Me.txtMobile.Enabled = False

        Me.btnSave.Text = "ویرایش "
        If IsNothing(Session("UserType")) = False Then
            If Session("UserType").ToString.ToLower = "admin" Then
                Me.btnSave.Text = "تائید"
                Me.btnCancel.Visible = True
            Else
                Me.btnCancel.Visible = False
                Me.btnVizheh.Visible = True

                Dim insertDate As Date = Convert.ToDateTime(dr.Item("InsertDate").ToString)
                Dim expDay As Integer = dbl.SelectAllwhere("txtSetting", "id", "1").Rows(0).Item("expDay")
                Dim span As TimeSpan = Now.Subtract(insertDate)
                If span.Days > expDay Then
                    Me.btnTamdid.Visible = True
                End If
                Me.btnFrokhtehShod.Visible = True

            End If
        Else
            Me.btnCancel.Visible = False
            Me.btnVizheh.Visible = True

            Dim insertDate As Date = Convert.ToDateTime(dr.Item("InsertDate").ToString)
            Dim expDay As Integer = dbl.SelectAllwhere("txtSetting", "id", "1").Rows(0).Item("expDay")
            Dim span As TimeSpan = Now.Subtract(insertDate)
            If span.Days > expDay Then
                Me.btnTamdid.Visible = True
            End If
            Me.btnFrokhtehShod.Visible = True

        End If

        bindPics()
    End Sub
    Public Sub bindOldPics()
        Try
            Dim files As String() = IO.Directory.GetFiles(Server.MapPath("userfiles/" + Request.QueryString("Code").ToString))
            For i = 0 To files.Length - 1
                Me.divPics4Edit.Controls.Add(New LiteralControl("<br /><img class='img' src='" + files(i).Substring(files(i).ToLower.IndexOf("userfiles")) + "' />"))
                Dim lnkBtnDel As New LinkButton
                lnkBtnDel.Text = "حذف"
                lnkBtnDel.ID = "lbtnn" + i.ToString
                lnkBtnDel.CommandArgument = files(i).Substring(files(i).ToLower.IndexOf("userfiles"))
                AddHandler lnkBtnDel.Click, AddressOf DeleteLinkButton4OldPics_Click
                Me.divPics4Edit.Controls.Add(lnkBtnDel)

            Next
            Me.divOldPics.Visible = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub DeleteLinkButton4OldPics_Click(sender As Object, e As EventArgs)
        Dim lbtn As LinkButton = sender
        Dim filename As String = lbtn.CommandArgument.ToString
        IO.File.Delete(Server.MapPath(filename))
        bindOldPics()
    End Sub
    Protected Sub ddjob_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddjob.SelectedIndexChanged
        getFields()
        upFields.Update()

        If Me.ddjob.SelectedValue.ToString <> "0" Then
            Me.btnUp.CommandArgument = Me.txtRootJobCode.Value
            Me.txtRootJobCode.Value = Me.ddjob.SelectedValue.ToString
            Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootCode", Me.txtRootJobCode.Value)
            If tbl.Rows.Count = 0 Then
                Me.ddjob.Visible = False
            End If
            Me.btnUp.Visible = Not Me.ddjob.Visible
            Me.html.Controls.Clear()
            map(Me.txtRootJobCode.Value)
            Me.ddjob.DataSource = tbl
            Me.ddjob.DataTextField = "JobName"
            Me.ddjob.DataValueField = "JobCode"
            Me.ddjob.DataBind()
            ddjob.Items.Insert(0, New ListItem("انتخاب کنید:", 0))


        End If

    End Sub
    Protected Sub ddcity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddcity.SelectedIndexChanged


        If Me.ddcity.SelectedValue.ToString <> "0" Then
            ScriptManager.RegisterStartupScript(Me, [GetType](), "gotocity", "gotocity('" + Me.ddcity.SelectedItem.Text.ToString + "');", True)


            Dim tbl As Data.DataTable = dbl.SelectAllwhere("Sector", "CityCode", Me.ddcity.SelectedValue.ToString)


            Me.ddsector.DataSource = tbl
            Me.ddsector.DataTextField = "SectorName"
            Me.ddsector.DataValueField = "SectorCode"
            Me.ddsector.DataBind()
            ddsector.Items.Insert(0, New ListItem("انتخاب منطقه:", 0))


        End If

    End Sub
    Protected Sub ddsector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddsector.SelectedIndexChanged


        If Me.ddsector.SelectedValue.ToString <> "0" Then
            ScriptManager.RegisterStartupScript(Me, [GetType](), "gotoarea", "gotoarea('" + Me.ddcity.SelectedItem.Text.ToString + "','" + Me.ddsector.SelectedItem.Text.ToString + "');", True)



        End If

    End Sub
    Public Function map(code As String) As String
        Try
            With dbl.SelectAllwhere("job", "jobcode", code).Rows(0)
                map(dbl.SelectAllwhere("job", "jobcode", code).Rows(0).Item("rootcode").ToString)
                Dim lbtn As New LinkButton()
                lbtn.ID = "lbtn" + code
                lbtn.Text = .Item("JobName")
                lbtn.CommandArgument = code
                AddHandler lbtn.Click, AddressOf LinkButton_Click
                Me.html.Controls.Add(lbtn)
                Me.html.Controls.Add(New LiteralControl("/"))

            End With

        Catch ex As Exception

        End Try
        Return ""
    End Function

    Protected Sub DeleteLinkButton_Click(sender As Object, e As EventArgs)
        Dim lbtn As LinkButton = sender
        Dim filename As String = lbtn.CommandArgument.ToString
        IO.File.Delete(Server.MapPath(filename))
        bindPics()
    End Sub

    Protected Sub LinkButton_Click(sender As Object, e As EventArgs)
        Me.ddjob.Visible = True
        Dim lbtn As LinkButton = sender
        Dim code As String = lbtn.CommandArgument.ToString
        Me.txtRootJobCode.Value = code
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootCode", code)
        Me.html.Controls.Clear()
        map(Me.txtRootJobCode.Value)
        Me.ddjob.DataSource = tbl
        Me.ddjob.DataTextField = "JobName"
        Me.ddjob.DataValueField = "JobCode"
        Me.ddjob.DataBind()
        ddjob.Items.Insert(0, New ListItem("انتخاب کنید:", 0))
        btnUp.Visible = False

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.html.Controls.Clear()
        map(Me.txtRootJobCode.Value)
        'bindPics()

        bindOldPics()

        getFields()
        bindTags()



    End Sub
    Public Sub bindPics()
        Try

            Dim videoCount As Integer = 0
            Dim picCount As Integer = 0

            If txtPic.Text <> "" Then
                Dim filePaths As String() = Directory.GetFiles(Server.MapPath("userFiles/") + txtPic.Text)
                For i = 0 To filePaths.Length - 1
                    filePaths(i) = filePaths(i).Substring(filePaths(i).IndexOf("userFiles"))
                    Dim ext As String = filePaths(i).Substring(filePaths(i).LastIndexOf(".") + 1).ToLower

                    If ext = "mpg" Or ext = "mpeg" Or ext = "mp4" Or ext = "wma" Or ext = "mov" Then
                        videoCount += 1
                    Else
                        picCount += 1
                    End If

                Next

            End If
            Me.txtVideoCount.Text = videoCount
            Me.txtPicCount.Text = picCount
        Catch ex As Exception

        End Try



    End Sub

    'Protected Sub btnUploadImage_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
    '    Try
    '        If txtPic.Text = "" Then
    '            txtPic.Text = "temp" + Now.Ticks.ToString
    '            IO.Directory.CreateDirectory(Server.MapPath("UserFiles") + "/" + txtPic.Text)

    '        End If
    '        Me.FileUpload1.SaveAs(Server.MapPath("UserFiles") + "/" + txtPic.Text + "/" + FileUpload1.FileName)
    '        bindPics()

    '    Catch ex As Exception
    '        divConfirm.Visible = False

    '        General.MyMsgBox("لطفا فایل خود را بصورت صحیح انتخاب نمائید")
    '    End Try


    '  End Sub
    Public Function check() As String
        If txtRootJobCode.Value = "" Or txtRootJobCode.Value = "0" Or txtRootJobCode.Value = "1" Then
            Return "لطفا دسته بندی را انتخاب نمائید"
        End If
        If txtTitle.Text = "" Then
            Return "لطفا فیلد عنوان را وارد نمائید"
        End If
        If txtPrice.Text = "" Then
            Return "لطفا فیلد قیمت را وارد نمائید"
        End If
        If txtDesc.Text = "" Then
            Return "لطفا فیلد توضیحات را پر نمائید"
        End If


        If txtMobile.Text = "" Then
            Return "لطفا فیلد موبایل را وارد نمائید"
        End If
        Try
            If Me.txtMobile.Text(0) = "0" Then
                Me.txtMobile.Text = Me.txtMobile.Text.Substring(1)
            End If
            Dim mobile As Int64 = Convert.ToInt64(Me.txtMobile.Text)
        Catch ex As Exception
            Return "شماره موبایل را بصورت صحیح وارد کنید"
        End Try

        If Session("UserType") <> "admin" Then
            If txtCaptcha.Text = "" Then
                Return "لطفا کد تصویر را وارد کنید"
            End If
            If Session("captcha") <> txtCaptcha.Text Then
                Return "کد شکل صحیح نیست."
            End If
            If chklaws.Checked = False Then
                Return "شما باید قوانین سایت را مطالعه کرده و بپذیرید"
            End If

        End If
        Return ""
    End Function
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim err As String = check()
        Dim prjid As String
        If err = "" Then
            Dim jobName As String = dbl.SelectAllwhere("job", "jobCode", txtRootJobCode.Value).Rows(0).Item("JobName")
            If IsNothing(Request.QueryString("Code")) Then
                Dim filmdar As String = "0"
                If FilmUpload1.HasFile Then
                    filmdar = "1"
                End If
                Dim axdar As String = "1"
                If TextBox1.Value = "" And TextBox2.Value = "" And TextBox3.Value = "" And TextBox4.Value = "" Then
                    axdar = "0"
                End If

                Dim ipaddress As String = ""
                ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
                If ipaddress = "" Or ipaddress Is Nothing Then
                    ipaddress = Request.ServerVariables("REMOTE_ADDR")
                End If
                Dim status As String = "0"
                Dim statusString As String = "ثبت"
                If dbl.SelectAllwhere("txtSetting", "id", "1").Rows(0).Item("AdsAutoCheckDate") > Now Then
                    status = "1"
                    statusString = "تائید"
                End If

                dbl.Insert("prj", "title", txtTitle.Text, "description", txtDesc.Text, "jobID", txtRootJobCode.Value, "Price", txtPrice.Text.Replace(",", "") _
                           , "cityName", Me.txtCity.Text, "chkNew", IIf(chkNew.Checked, "1", "0"), "chkEmail", IIf(chkEmail.Checked, "1", "0"),
                           "PriceType", Me.ddPricetype.SelectedItem.Text, "Email", txtEmail.Text, "site", txtSite.Text,
                            "Mobile", txtMobile.Text, "JobName", jobName, "PriceText", txtPrice.Text, "Tel", Me.txtTel.Text, "Telegram", txtTelegram.Text _
                           , "N", Me.N.Text, "E", Me.E.Text, "tags", Me.txtTags.Text, "ip", ipaddress, "status", status, "statusText", statusString, "filmdar", filmdar, "axdar", axdar)


                Response.Cookies("Mobile").Value = txtMobile.Text
                prjid = dbl.GetMax("prj", "prjId")


                setFields(prjid)

                FileIO.FileSystem.CreateDirectory(Server.MapPath("userfiles/" + prjid))

                If FilmUpload1.HasFile Then
                    FilmUpload1.SaveAs(Server.MapPath("userfiles/" + prjid) + "/" + FilmUpload1.FileName)
                End If

                For Each postedFile As HttpPostedFile In files.PostedFiles
                    Dim fileName As String = Path.GetFileName(postedFile.FileName)
                    postedFile.SaveAs(Server.MapPath("userfiles/" + prjid) + "/" + fileName)

                Next

                'Dim ImageFiles As HttpFileCollection = Request.Files
                'For i As Integer = 0 To ImageFiles.Count - 1
                '    Dim file As HttpPostedFile = ImageFiles(i)
                '    file.SaveAs(Server.MapPath("Uploads/") & ImageFiles(i).FileName)
                'Next

                Me.txtPic.Text = prjid
                bindPics()
                saveImages(prjid)

            Else
                prjid = Request.QueryString("Code").ToString
                If IO.Directory.Exists(Server.MapPath("userfiles/" + prjid)) = False Then
                    FileIO.FileSystem.CreateDirectory(Server.MapPath("userfiles/" + prjid))

                End If


                Try
                    General.solrDelById(prjid)

                Catch ex As Exception

                End Try
                Try
                    Dim lbtn As LinkButton = Me.html.Controls(Me.html.Controls.Count - 2)
                    Dim group As String = lbtn.Text
                    General.solrInsert(prjid, Me.txtTags.Text, Me.txtTitle.Text, Me.txtDesc.Text, Me.txtCity.Text, group)

                Catch ex As Exception

                End Try



                setFields(prjid)
                saveImages(prjid)

                dbl.BigUpdate("prj", "title", txtTitle.Text, "description", txtDesc.Text, "jobID", txtRootJobCode.Value, "Price", txtPrice.Text.Replace(",", ""), "cityName", Me.txtCity.Text, "chkfori", IIf(chkFori.Checked, "1", "0"), "chkNew", IIf(chkNew.Checked, "1", "0"), "chkEmail", IIf(chkEmail.Checked, "1", "0"), "chkNardban", IIf(chkNardban.Checked, "1", "0"), "PriceType", Me.ddPricetype.SelectedItem.Text, "Email", txtEmail.Text, "site", txtSite.Text, "Mobile", txtMobile.Text, "JobName", jobName, "PriceText", txtPrice.Text, "Tel", Me.txtTel.Text, "Telegram", txtTelegram.Text, "N", Me.N.Text, "E", Me.E.Text, "Reported", "0", "tags", Me.txtTags.Text, , , , , , , , , , , , , , , , ,,,,, "prjId", prjid)
                If IsNothing(Session("UserType")) = False Then
                    If Session("UserType").ToString.ToLower = "admin" Then
                        dbl.ExecCommand("update Admin set  OkadsCount=OKadsCount+1 ,adsCount=adsCount+1 where adminid=" + Session("User").item("adminId").ToString)

                        dbl.Update("Prj", "status", "1", "statusText", "تائید", "Reported", "0", , , , , , , , , , , , , , , "prjId", prjid)
                    End If

                End If

            End If


            General.SendMail("ثبت موفقیت آمیز ", "اطلاعات شما ثبت شد ", Me.txtEmail.Text)
                divConfirm.Visible = False
                Dim redirect As String = "default.aspx"
                If chkFori.Checked Then
                    redirect = "Pay.aspx?Code=1&prjid=" + prjid
                End If
                If chkNardban.Checked Then
                    redirect = "Pay.aspx?Code=2&prjid=" + prjid
                End If
                If chkFori.Checked And chkNardban.Checked Then
                    redirect = "Pay.aspx?Code=3&prjid=" + prjid
                End If
                General.MyMsgBox("اطلاعات با موفقیت ثبت شد", "", 5, redirect)
            Else
                divConfirm.Visible = False
            General.MyMsgBox(err)
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        divConfirm.Visible = True
        General.MyMsgBox("", "آیا از رد اطلاعات  مطمئن هستید؟ ")


    End Sub

    Protected Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        dbl.ExecCommand("update Admin set  NOKadsCount=NOKadsCount+1 ,adsCount=adsCount+1 where adminid=" + Session("User").item("adminId").ToString)
        dbl.Update("Prj", "status", "2", "statusText", "رد", "deleted", "1", "Reported", "0", , , , , , , , , , , , , "prjId", Request.QueryString("Code"))
        divConfirm.Visible = False
        General.SendMail("ثبت ناموفق", "اطلاعات شما بدلیل  " + Me.txtDel.Text + " ثبت نشد لطفا مجددا با رعابت مورد فوق اقدام نمائید. ", Me.txtEmail.Text)
        General.MyMsgBox("اطلاعات مورد نظر رد گردید", "", "5", "prjManage.aspx")
    End Sub

    Protected Sub btnTamdid_Click(sender As Object, e As EventArgs) Handles btnTamdid.Click
        Response.Redirect("Services.aspx?actionCode=1&Code=" + Request.QueryString("Code"))
    End Sub

    Protected Sub btnVizheh_Click(sender As Object, e As EventArgs) Handles btnVizheh.Click
        Response.Redirect("Services.aspx?actionCode=1&Code=" + Request.QueryString("Code"))
    End Sub

    Protected Sub btnFrokhtehShod_Click(sender As Object, e As EventArgs) Handles btnFrokhtehShod.Click
        dbl.Update("Prj", "status", "4", "statusText", "فروخته", "deleted", "1", "Reported", "0", , , , , , , , , , , , , "prjId", Request.QueryString("Code"))
        divConfirm.Visible = False

        General.MyMsgBox("اطلاعات مورد نظر به وضعیت 'ناموجود' بروز گردید", "", "5", "KAds.aspx")

    End Sub
    Public Function getImage(src As String) As String
        Dim ext As String = src.Substring(src.LastIndexOf(".") + 1).ToLower
        If ext = "png" Or ext = "jpg" Or ext = "gif" Or ext = "jpeg" Or ext = "bmp" Then
            Return src
        End If
        Return "/images/film.png"
    End Function

    Public Sub saveImages(prjId As String)
        Dim binaryString As String
        binaryString = ""

        If Me.TextBox1.Value <> "" Then
            binaryString = Me.TextBox1.Value.Substring(Me.TextBox1.Value.IndexOf(",") + 1)
            Dim bytes() As Byte = Convert.FromBase64String(binaryString)
            Dim image1 As Drawing.Image
            Dim ms As New MemoryStream(bytes)
            image1 = Drawing.Image.FromStream(ms)
            image1.Save(Server.MapPath("userfiles/" + prjId + "/1.png"))
        End If
        If Me.TextBox2.Value <> "" Then
            binaryString = Me.TextBox2.Value.Substring(Me.TextBox2.Value.IndexOf(",") + 1)
            Dim bytes() As Byte = Convert.FromBase64String(binaryString)
            Dim image1 As Drawing.Image
            Dim ms As New MemoryStream(bytes)
            image1 = Drawing.Image.FromStream(ms)
            image1.Save(Server.MapPath("userfiles/" + prjId + "/2.png"))

        End If
        If Me.TextBox3.Value <> "" Then
            binaryString = Me.TextBox3.Value.Substring(Me.TextBox3.Value.IndexOf(",") + 1)
            Dim bytes() As Byte = Convert.FromBase64String(binaryString)
            Dim image1 As Drawing.Image
            Dim ms As New MemoryStream(bytes)
            image1 = Drawing.Image.FromStream(ms)
            image1.Save(Server.MapPath("userfiles/" + prjId + "/3.png"))

        End If
        If Me.TextBox4.Value <> "" Then
            binaryString = Me.TextBox4.Value.Substring(Me.TextBox4.Value.IndexOf(",") + 1)
            Dim bytes() As Byte = Convert.FromBase64String(binaryString)
            Dim image1 As Drawing.Image
            Dim ms As New MemoryStream(bytes)
            image1 = Drawing.Image.FromStream(ms)
            image1.Save(Server.MapPath("userfiles/" + prjId + "/4.png"))

        End If


    End Sub
    Public Sub getFields()
        Dim GroupId As String = ""
        If ddjob.Visible = True And ddjob.SelectedIndex > 0 Then
            GroupId = ddjob.SelectedValue.ToString
        Else
            GroupId = Me.txtRootJobCode.Value.ToString
        End If
        If GroupId = "" Then
            Exit Sub
        End If
        Me.divFields.Controls.Clear()
        Dim tblFields As Data.DataTable = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", GroupId, "sort")
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
                chk.Checked = False
                Me.divFields.Controls.Add(chk)
                If IsNothing(Request.QueryString("code")) = False Then
                    Try
                        If dr.Item("val" + tblFields.Rows(i).Item("sort").ToString) = "1" Then
                            chk.Checked = True
                        End If
                    Catch ex As Exception

                    End Try
                End If
                Me.divFields.Controls.Add(New LiteralControl("</div>"))
            End If
            ' Me.divFields.Controls.Add(New LiteralControl("</div>"))

            If tblFields.Rows(i).Item("dataType") = "string" Or tblFields.Rows(i).Item("dataType") = "number" Then
                Dim txt As New TextBox
                txt.ID = "txt" + i.ToString
                If tblFields.Rows(i).Item("dataType") = "number" And tblFields.Rows(i).Item("title") <> "قیمت" Then
                    txt.TextMode = TextBoxMode.Number
                End If
                txt.CssClass = "textbox"
                Dim desc As String = ""
                If tblFields.Rows(i).Item("FieldDescription") <> "" Then
                    desc = "<img  src=""img/q2.png"" title=""" + tblFields.Rows(i).Item("FieldDescription") + """ style=""width:15px;height:15px"" />"
                End If
                If IsNothing(Request.QueryString("code")) = False Then
                    Try
                        txt.Text = dr.Item("val" + tblFields.Rows(i).Item("sort").ToString)
                    Catch ex As Exception

                    End Try
                End If
                Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + desc + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >"))
                Me.divFields.Controls.Add(txt)


                Me.divFields.Controls.Add(New LiteralControl("</div>"))

            End If
            ' price
            If tblFields.Rows(i).Item("dataType") = "price" Then
                Dim txt As New TextBox
                txt.ID = "txt" + i.ToString
                txt.Attributes.Add("onkeyup", "javascript:this.value=Comma(this.value);")
                txt.CssClass = "textbox price"

                Dim desc As String = ""
                If tblFields.Rows(i).Item("FieldDescription") <> "" Then
                    desc = "<img  src=""img/q2.png"" title=""" + tblFields.Rows(i).Item("FieldDescription") + """ style=""width:15px;height:15px"" />"
                End If
                If IsNothing(Request.QueryString("code")) = False Then
                    Try
                        Dim value As Integer = Integer.Parse(dr.Item("val" + tblFields.Rows(i).Item("sort").ToString), System.Globalization.NumberStyles.Integer Or System.Globalization.NumberStyles.AllowThousands)
                        txt.Text = value.ToString("N0")
                        ' txt.Text = (dr.Item("val" + tblFields.Rows(i).Item("sort").ToString)).ToString("N0")
                    Catch ex As Exception

                    End Try
                End If
                Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + desc + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >"))
                Me.divFields.Controls.Add(txt)


                Me.divFields.Controls.Add(New LiteralControl("</div>"))

            End If
            ' list
            If tblFields.Rows(i).Item("dataType") = "list" Then
                Dim ddlist As New DropDownList
                ddlist.ID = "dd" + i.ToString

                ddlist.CssClass = "textbox"
                Dim desc As String = ""
                If tblFields.Rows(i).Item("FieldDescription") <> "" Then
                    desc = "<img  src=""img/q2.png"" title=""" + tblFields.Rows(i).Item("FieldDescription") + """ style=""width:15px;height:15px"" />"
                End If
                ' Split string based on comma   1,2,3
                Dim lists As String() = tblFields.Rows(i).Item("items").Split(New Char() {","c})
                ' Use For Each loop over words and display them
                Dim word As String
                For Each word In lists

                    Dim newListItem As ListItem
                    newListItem = New ListItem(word, word)
                    ddlist.Items.Add(newListItem)
                Next
                If IsNothing(Request.QueryString("code")) = False Then
                    Try
                        ' set selected index
                        ddlist.SelectedValue = dr.Item("val" + tblFields.Rows(i).Item("sort").ToString)

                    Catch ex As Exception

                    End Try
                End If
                Me.divFields.Controls.Add(New LiteralControl("<div  class=""col-xs-12 col-sm-2 col-md-2"" >" + tblFields.Rows(i).Item("title") + ":" + desc + "</div><div  class=""col-xs-12 col-sm-2 col-md-2"" >"))
                Me.divFields.Controls.Add(ddlist)


                Me.divFields.Controls.Add(New LiteralControl("</div>"))

            End If
        Next
        Me.divFields.Controls.Add(New LiteralControl("</div>"))
    End Sub
    Public Sub setFields(prjId As String)

        Dim cmd As String = "update prj set "
        Dim setVal As String = ""
        Dim tblFields As Data.DataTable = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", Me.txtRootJobCode.Value, "sort")
        For i = 0 To tblFields.Rows.Count - 1
            If tblFields.Rows(i).Item("dataType") = "bit" Then
                Dim chk As CheckBox
                chk = Me.divFields.FindControl("chk" + i.ToString)
                If chk.Checked Then
                    setVal += ", val" + (i + 1).ToString + "=N'1'"
                Else
                    setVal += ", val" + (i + 1).ToString + "=N'0'"
                End If
            End If
            If tblFields.Rows(i).Item("dataType") = "string" Or tblFields.Rows(i).Item("dataType") = "number" Then
                Dim txt As TextBox
                txt = Me.divFields.FindControl("txt" + i.ToString)
                setVal += ", val" + (i + 1).ToString + "=N'" + txt.Text + "'"
            End If
            ' price
            If tblFields.Rows(i).Item("dataType") = "price" Then
                Dim txt As TextBox
                txt = Me.divFields.FindControl("txt" + i.ToString)
                setVal += ", val" + (i + 1).ToString + "=N'" + txt.Text.Replace(",", "") + "'"

            End If
            ' list
            If tblFields.Rows(i).Item("dataType") = "list" Then
                Dim dd As DropDownList
                dd = Me.divFields.FindControl("dd" + i.ToString)
                setVal += ", val" + (i + 1).ToString + "=N'" + dd.SelectedValue + "'"

            End If
        Next
        If setVal <> "" Then
            cmd += setVal.Substring(1) + " where prjid=" + prjId
            dbl.ExecCommand(cmd)
        End If

    End Sub
    Protected Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        Me.ddjob.Visible = True
        Dim lbtn As LinkButton = sender
        Dim code As String = lbtn.CommandArgument.ToString
        Me.txtRootJobCode.Value = code
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootCode", code)
        Me.html.Controls.Clear()
        map(Me.txtRootJobCode.Value)
        Me.ddjob.DataSource = tbl
        Me.ddjob.DataTextField = "JobName"
        Me.ddjob.DataValueField = "JobCode"
        Me.ddjob.DataBind()
        ddjob.Items.Insert(0, New ListItem("انتخاب کنید:", 0))
        btnUp.Visible = False
    End Sub

    Protected Sub ibtnAddTag_Click(sender As Object, e As ImageClickEventArgs) Handles ibtnAddTag.Click
        Me.txtTags.Text += Me.txtTag.Text + ";"
        Me.txtTag.Text = ""
        bindTags()
    End Sub
    Protected Sub ibtnRemoveTag_Click(sender As Object, e As ImageClickEventArgs)
        Dim btn As ImageButton = sender
        Dim tags() As String = Me.txtTags.Text.Split(";")
        Me.txtTags.Text = ""
        For i = 0 To tags.Length - 2
            If i.ToString <> btn.CommandArgument Then
                Me.txtTags.Text += tags(i) + ";"
            End If
        Next
        bindTags()
    End Sub
    Public Sub bindTags()

        Me.divTags.Controls.Clear()
        Dim tags() As String = Me.txtTags.Text.Split(";")
        For i = 0 To tags.Length - 2
            Dim lbl As New Label

            lbl.Text = tags(i)
            Me.divTags.Controls.Add(lbl)
            Dim btn As New ImageButton
            btn.ID = "btnRemove" + i.ToString
            AddHandler btn.Click, AddressOf Me.ibtnRemoveTag_Click
            btn.ImageUrl = "~/images/cancel.png"
            btn.Height = 12
            btn.Width = 12
            Me.divTags.Controls.Add(New LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"))
            Me.divTags.Controls.Add(lbl)
            btn.CommandArgument = i.ToString
            btn.ToolTip = i.ToString
            Me.divTags.Controls.Add(btn)

        Next

    End Sub


End Class
