
Partial Class KAds
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public Sub bind()
        Dim mobile As String = ""
        Dim ok As Boolean = False
        If IsNothing(Session("User")) Then
            If Not (Request.Cookies("Mobile") Is Nothing) Then
                If Not (Request.Cookies("Mobile").Value Is Nothing) Then
                    mobile = Request.Cookies("Mobile").Value.ToString

                End If
            End If
            If mobile <> "" Then
                Me.GridView1.DataSource = dbl.SelectFromCommand(" select * from Prj where deleted=0 and  mobile=" + mobile)
                Me.GridView1.DataBind()
                ok = True
            End If

        Else
            Try
                Me.GridView1.DataSource = dbl.SelectFromCommand(" select * from Prj where deleted=0 and  karfarmaId=" + Session("User").item("karfarmaid").ToString)
                Me.GridView1.DataBind()
                ok = True

            Catch ex As Exception

            End Try

        End If
        If ok = False Then
            Me.Label1.Text = "اگر آکهی های خود را مشاهده نمیکنید وارد پنل خود شوید"
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            bind()
            General.setGridStyle(Me.GridView1)
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim No As String = GridView1.DataKeys(e.RowIndex).Value.ToString
        Me.btnDel.CommandArgument = No
        divConfirm.Visible = True
        General.MyMsgBox("", "آیا از حذف آگهی کد " + No + " مطمئن هستید؟ ")
    End Sub
    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim schno As String = btnDel.CommandArgument.ToString
        Dim delText As String = ddDel.SelectedItem.Text
        If ddDel.SelectedValue = 3 Then
            delText += " / " + Me.txtDel.Text
        End If
        dbl.Update("prj", "deleted", "1", "DelText", delText, , , , , , , , , , , , , , , , , "prjid", schno)
        Me.divConfirm.Visible = False
        General.MyMsgBox("اطلاعات با موفقیت حذف شد", "", 4)

        bind()

    End Sub
End Class
