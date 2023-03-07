
Partial Class offers
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public dr As Data.DataRow

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.GridView1.DataSource = dbl.SelectAllwhere("emp", "Archived", "0", "ok", "0")
        Me.GridView1.DataBind()
        General.setGridStyle(GridView1)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim No As String = GridView1.DataKeys(Me.GridView1.SelectedIndex).Value.ToString
        Me.lblCode.Text = No
        dr = dbl.SelectAllwhere("emp", "empid", No).Rows(0)
        Me.divDetail.Visible = True
        General.MyMsgBox("")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        dbl.ExecCommand("update Admin set NOKempCount=NOKempCount+1,empCount=empCount+1 where adminid=" + Session("User").item("adminId").ToString)

        dbl.DeleteFromTable("emp", "empid", lblCode.Text)
        Response.Redirect("emps.aspx")
    End Sub

    Protected Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        dbl.ExecCommand("update Admin set  ARCempCount=ARCempCount+1, empCount=empCount+1 where adminid=" + Session("User").item("adminId").ToString)
        Dim ArchiveType As String = "بایگانی مستقیم"
        If dbl.SelectAllwhere("contacts", "offerid", lblCode.Text).Rows(0).Item("responce").ToString <> "" Then
            ArchiveType = "بایگانی با پاسخ"
        End If

        dbl.Update("emp", "archived", "1", "ArchiveType", ArchiveType, , , , , , , , , , , , , , , , , "empid", lblCode.Text)

        Response.Redirect("emps.aspx")

    End Sub

    Protected Sub btnAnswer_Click(sender As Object, e As EventArgs) Handles btnAnswer.Click
        General.SendMail("پاسخ ادورت منو ", txtRes.Text, dbl.SelectAllwhere("emp", "empid", Me.lblCode.Text).Rows(0).Item("Email"))
        General.SendMail("پاسخ ادورت منو ", txtRes.Text, dbl.SelectAllwhere("admin", "adminid", "1").Rows(0).Item("Email"))
        dbl.ExecCommand("update Admin set  ARCempCount=ARCempCount+1, empCount=empCount+1 where adminid=" + Session("User").item("adminId").ToString)
        dbl.UpdateAField("emp", "responce", txtRes.Text, "empid", lblCode.Text)
        Response.Redirect("emps.aspx")

    End Sub

    Protected Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        dbl.ExecCommand("update Admin set empCount=empCount+1 where adminid=" + Session("User").item("adminId").ToString)
        dbl.UpdateAField("emp", "ok", "1", "empid", lblCode.Text)

        Response.Redirect("emps.aspx")

    End Sub
End Class
