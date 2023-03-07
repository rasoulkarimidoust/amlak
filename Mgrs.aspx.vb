
Partial Class Mgrs
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.divConfirm.Visible = False

        If Page.IsPostBack = False Then
            bind()
            General.setGridStyle(Me.GridView1)
        End If


    End Sub
    Public Sub bind()
        Me.GridView1.DataSource = dbl.SelectAllwhere("Admin", "deleted", "0")
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim schNo As String = GridView1.DataKeys(e.RowIndex).Value.ToString
        If schNo = 1 Then
            divConfirm.Visible = False
            General.MyMsgBox("حذف مدیر اصلی امکانپذیر نیست")
        Else
            Me.btnDel.CommandArgument = schNo
            divConfirm.Visible = True
            General.MyMsgBox("", "آیا از حذف مدیر سیستم به کد " + schNo + " مطمئن هستید؟ ")
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim schno As String = GridView1.DataKeys(GridView1.SelectedIndex).Value.ToString
        Response.Redirect("mgr.aspx?adminid=" + schno)
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim schno As String = btnDel.CommandArgument.ToString
        dbl.UpdateAField("Admin", "deleted", "1", "AdminId", schno)
        Me.divConfirm.Visible = False
        General.MyMsgBox("اطلاعات با موفقیت حذف شد", "", 4)

        bind()

    End Sub
End Class
