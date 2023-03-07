
Partial Class map
    Inherits System.Web.UI.Page
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Private Sub map_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub
    Public Sub bindMap(code As String)
        Dim cmd As String = ""
        Dim jobCode As String = "1"
        If IsNothing(Request.QueryString("jobcode")) = False Then
            jobCode = Request.QueryString("jobcode")
        End If
        '"
        Dim expDay As String = dbl.SelectAllwhere("txtSetting", "id", "1").Rows(0).Item("expDay").ToString
        cmd = " select * from prj  where insertDate>=dateadd(day, -" + expDay + ", getdate()) and  status=1 and deleted=0  "

        cmd += " and  (jobid=" + jobCode + ChildjobsStr(jobCode) + ")"
        Dim tbl As Data.DataTable = dbl.SelectFromCommand(cmd)
        Me.N.Value = ""
        Me.E.Value = ""
        Me.AdsName.Value = ""
        For i = 0 To tbl.Rows.Count - 1
            If i > 0 Then
                Me.N.Value += "-"
                Me.E.Value += "-"
                Me.AdsName.Value += "-"
                Me.AdsID.Value += "-"

            End If
            Me.N.Value += tbl.Rows(i).Item("N").ToString
            Me.E.Value += tbl.Rows(i).Item("E").ToString
            Me.AdsName.Value += tbl.Rows(i).Item("title").ToString
            Me.AdsID.Value += tbl.Rows(i).Item("prjid").ToString

        Next
        Try

        Catch ex As Exception

        End Try
    End Sub
    Public Function ChildjobsStr(code As String) As String
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("job", "rootcode", code)
        Dim cmd As String = ""
        For i = 0 To tbl.Rows.Count - 1
            cmd += " or jobid=" + tbl.Rows(i).Item("jobCode").ToString + ChildjobsStr(tbl.Rows(i).Item("jobCode").ToString)
        Next

        Return cmd
    End Function
    Protected Sub ddJobs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddJobs.SelectedIndexChanged
        Response.Redirect("map.aspx?jobCode=" + Me.ddJobs.SelectedValue.ToString)
    End Sub
    Public Function SetGroup(code As String) As String
        Try
            With dbl.SelectAllwhere("job", "jobcode", code).Rows(0)
                Return SetGroup(dbl.SelectAllwhere("job", "jobcode", code).Rows(0).Item("rootcode").ToString) + "<a href=""map.aspx?jobCode=" + code + """>" + .Item("JobName") + " > " + "</a>"
            End With

        Catch ex As Exception

        End Try
        Return ""
    End Function

    Private Sub map_Init(sender As Object, e As EventArgs) Handles Me.Init
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

        Me.html1.InnerHtml = SetGroup(rootCode)
        bindMap(rootCode)
    End Sub
End Class
