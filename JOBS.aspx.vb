Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Partial Class Service
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)


    
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '        Response.Redirect("jobEdit.aspx?jobCode=" + schno)
        Dim err As String = ""

        Me.divStudent.Visible = False
        Try
            dbl.UpdateAField("Job", "Jobname", txtName.Text, "JobCode", Me.TreeView1.SelectedValue.ToString)
            dbl.UpdateAField("Job", "Rootname", txtName.Text, "RootCode", Me.TreeView1.SelectedValue.ToString)
        Catch ex As Exception
            err = "خطا در ثبت اطلاعات:" + ex.Message

        End Try

        If err = "" Then
            Me.divStudent.Visible = False
            Me.txtName.Text = ""
            General.MyMsgBox("اطلاعات با موفقیت ثبت شد", "", 4)
            bind()
        Else
            Me.divStudent.Visible = True
            General.SetError(err)

        End If


    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.divStudent.Visible = False
        Me.divConfirm.Visible = False

        If Page.IsPostBack = False Then
            bind()
        End If

    End Sub
    Private Sub PopulateTreeView(dtParent As DataTable, parentId As Integer, treeNode As TreeNode)
        For Each row As DataRow In dtParent.Rows

            Dim node As New TreeNode() With {.Text = row("JobName").ToString(), .Value = row("JobCode").ToString()}

            If parentId = 0 Then
                TreeView1.Nodes.Add(node)
            Else
                treeNode.ChildNodes.Add(node)
            End If
            Dim dtChild As DataTable = dbl.SelectFromCommand("SELECT JobCode, JobName FROM job WHERE RootCode = " + node.Value)
            PopulateTreeView(dtChild, Integer.Parse(node.Value), node)

        Next
    End Sub







    Public Sub bind()
        Me.TreeView1.Nodes.Clear()
        Dim dt As DataTable = dbl.SelectFromCommand("SELECT JobCode, JobName FROM job WHERE RootCode =0 ")
        Me.PopulateTreeView(dt, 0, Nothing)
    End Sub


    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim schno As String = TreeView1.SelectedNode.Value
        If schno = "1" Then
            General.MyMsgBox("نود ریشه قابل حذف نیست", "", 4)
        Else
            dbl.DeleteFromTable("Job", "JobCode", schno)
            Me.divConfirm.Visible = False
            General.MyMsgBox("اطلاعات با موفقیت حذف شد", "", 4)

            bind()

        End If

    End Sub



    Protected Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Me.divStudent.Visible = True
        Me.txtName.Text = Me.TreeView1.SelectedNode.Text
        Me.txtChildName.Text = ""
        Session("JobCode") = Me.TreeView1.SelectedNode.Value.ToString
        General.MyMsgBox("لطفا فیلدهای زیر را وارد نمائید:", "ویرایش دسته بندی")
    End Sub

    Protected Sub BtnDel1_Click(sender As Object, e As EventArgs) Handles BtnDel1.Click
        divConfirm.Visible = True
        General.MyMsgBox("", "آیا از حذف دسته بندی : " + Me.TreeView1.SelectedNode.Text + " مطمئن هستید؟ ")

    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim err As String = ""

        Me.divStudent.Visible = False
        Try
            dbl.Insert("Job", "Jobname", txtChildName.Text, "RootName", Me.TreeView1.SelectedNode.Text, "RootCode", Me.TreeView1.SelectedValue.ToString)
        Catch ex As Exception
            err = "خطا در ثبت اطلاعات:" + ex.Message

        End Try

        If err = "" Then
            Me.divStudent.Visible = False
            Me.txtName.Text = ""
            General.MyMsgBox("اطلاعات با موفقیت ثبت شد", "", 4)
            bind()
        Else
            Me.divStudent.Visible = True
            General.SetError(err)

        End If

    End Sub
End Class
