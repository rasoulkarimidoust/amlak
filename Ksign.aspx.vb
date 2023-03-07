
Partial Class Ksign
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.HyperLink1.NavigateUrl = "KRegister.aspx?PrjId=" + Request.QueryString("PrjId")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If ((Not (Request.Cookies("u")) Is Nothing) _
                        AndAlso (Not (Request.Cookies("p")) Is Nothing)) Then
                login(Request.Cookies("u").Value, Request.Cookies("p").Value)

            End If
        End If
        Me.txtUserName.Focus()

    End Sub
    Public Sub login(username As String, Pass As String)

        Dim dt As Data.DataTable
        Try
            dt = dbl.SelectAllwhere("karfarma", "UserName", username, "Pass", Pass)
            If dt.Rows.Count > 0 Then
                Session("user") = dt.Rows(0)
                Session("UserType") = "karfarma"
                If Request.QueryString("PrjId").ToString <> "" Then
                    Dim kID As String = dt.Rows(0).Item("karfarmaid").ToString
                    dbl.UpdateAField("prj", "karfarmaid", kID, "prjid", Request.QueryString("PrjId"))
                End If
                Response.Redirect("kads.aspx")
            End If




        Catch ex As Exception

        End Try



    End Sub
    Private Sub imgBtnLogin_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnLogin.Click
        Try

            Dim Enc As New Encryption.Utils
            Response.Cookies("u").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("p").Expires = DateTime.Now.AddDays(30)
            Response.Cookies("u").Value = txtUserName.Text
            Response.Cookies("p").Value = txtPass.Text

            login(Me.txtUserName.Text, Me.txtPass.Text)
        Catch ex As Exception
            ex = ex
        End Try


    End Sub



End Class
