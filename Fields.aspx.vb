
Partial Class Fields
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            hfJobCode.Value = Session("JobCode")
            Me.lblJobName.Text = dbl.SelectAllwhere("job", "jobCode", hfJobCode.Value).Rows(0).Item("JobName")
            Me.GridView1.DataSource = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", hfJobCode.Value, "sort")
            Me.GridView1.DataBind()
            General.setGridStyle(Me.GridView1)
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        hfEditId.Value = ""
        Me.divStudent.Visible = True
        Me.divConfirm.Visible = False
        Me.txtFieldDescription.Text = ""
        Me.txtSort.Text = ""
        Me.txtSort.Enabled = True
        Me.txtTitle.Text = ""
        Me.txtSort.Focus()
        Me.ddDataType.Enabled = True
        'Me.ddDataType.Items(0).Selected = True
        Me.chkIsControlic.Checked = False
        General.MyMsgBox("لطفا مشخصات فیلد را وارد کنید")
    End Sub
    Public Sub Icon(fildId As String)
        If FuIcon.HasFile Then
            If IO.File.Exists(Server.MapPath("icons/f" + fildId + ".png")) Then
                Try
                    IO.File.Delete(Server.MapPath("icons/f" + fildId + ".png"))
                Catch ex As Exception

                End Try
            End If
            Try
                Me.FuIcon.SaveAs(Server.MapPath("icons/f" + fildId + ".png"))
            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim isControlic As String = "0"
        If chkIsControlic.Checked Then
            isControlic = "1"
        End If
        If hfEditId.Value = "" Then
            dbl.Insert("field", "title", Me.txtTitle.Text, "dataType", Me.ddDataType.SelectedValue, "FieldDescription", Me.txtFieldDescription.Text, "isControlic", isControlic, "sort", txtSort.Text, "GroupId", Me.hfJobCode.Value, "items", txtListitem.Text)
            Icon(dbl.GetMax("field", "id"))
        Else
            dbl.Update("field", "title", Me.txtTitle.Text, "dataType", Me.ddDataType.SelectedValue, "FieldDescription", Me.txtFieldDescription.Text, "isControlic", isControlic, "sort", txtSort.Text, "GroupId", Me.hfJobCode.Value, "items", txtListitem.Text, , , , , , , , "id", hfEditId.Value)
            Icon(hfEditId.Value)
        End If
        Me.divStudent.Visible = False
        General.MyMsgBox("اطلاعات با موفقیت ثبت شد", "", 4)
        Me.GridView1.DataSource = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", hfJobCode.Value, "sort")
        Me.GridView1.DataBind()


    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Me.hfEditId.Value = e.Keys(0)
        Me.divStudent.Visible = False
        Me.divConfirm.Visible = True
        General.MyMsgBox("آیا از حذف مورد فوق اطمینان دارید؟")

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Me.hfEditId.Value = Me.GridView1.SelectedRow.Cells(0).Text
        Me.divStudent.Visible = True
        Me.divConfirm.Visible = False
        Dim dr As Data.DataRow = dbl.SelectAllwhere("field", "id", Me.hfEditId.Value).Rows(0)
        With dr
            Me.txtFieldDescription.Text = .Item("FieldDescription")
            Me.txtSort.Text = .Item("sort")
            Me.txtTitle.Text = .Item("title")
            If dbl.SelectFromCommand("select * from prj where   (NOT (val" + .Item("sort").ToString + " IS NULL)) AND (jobID = " + hfJobCode.Value + ") ").Rows.Count > 0 Then
                Me.ddDataType.Enabled = False
                Me.txtSort.Enabled = False
            End If
            Me.ddDataType.DataBind()
            Me.ddDataType.SelectedValue = .Item("dataType")
            Me.chkIsControlic.Checked = .Item("IsControlic")
        End With
        General.MyMsgBox("لطفا مشخصات فیلد را وارد کنید")

    End Sub





    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        dbl.DeleteFromTable("field", "id", hfEditId.Value)
        Me.divConfirm.Visible = False
        Me.divStudent.Visible = False
        General.MyMsgBox("اطلاعات با موفقیت حذف شد", "")
        Me.GridView1.DataSource = dbl.SelectTopwhereOrderBy("30", "field", "GroupId", hfJobCode.Value, "sort")
        Me.GridView1.DataBind()

    End Sub

    Protected Sub ddDataType_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim message As String = ddDataType.SelectedItem.Text & " - " & ddDataType.SelectedItem.Value
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('" & message & "');", True)
    End Sub
End Class
