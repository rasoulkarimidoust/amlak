
Partial Class help
    Inherits System.Web.UI.UserControl
    Dim dbl As New DataBaseLayer(General.GetConnectionString)



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim pageName As String = Request.Url.Segments(Request.Url.Segments.Length - 1).Split(".")(0)
        Dim drs() As Data.DataRow = Session("tblHelp").Select("ControlName='" + Me.ID + "'")

        If drs.Length > 0 Then
            If drs(0).Item("text").ToString <> "" Then
                Me.anchor.Title = drs(0).Item("text").ToString
            End If
        Else
            If IsNothing(Session("UserType")) = False Then
                If Session("UserType") <> "admin" Then
                    Me.Visible = False
                End If
            Else
                Me.Visible = False
            End If
        End If
        If IsNothing(Session("UserType")) = False Then
            If Session("UserType") = "admin" Then
                Me.anchor.HRef = "~/SetHelp4Controls.aspx?PageName=" + pageName + "&ControlName=" + Me.ID
            End If

        End If


    End Sub
End Class
