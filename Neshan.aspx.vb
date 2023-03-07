
Partial Class Neshan
    Inherits System.Web.UI.Page
    Public dr As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public Function GetImage(id As String) As String
        Dim path As String = Server.MapPath("UserFiles\" + id.ToString)
        If IO.Directory.Exists(path) Then
            Dim imgfiles() As String = IO.Directory.GetFiles(path)
            If imgfiles.Length > 0 Then
                Return imgfiles(0).Substring(imgfiles(0).IndexOf("UserFiles"))
            End If
        End If

        Return "images/thumb_User.png"

    End Function
    Public Function GetLocation(SectorCode As String, CityName As String) As String
        Dim str As String = CityName
        If SectorCode <> "" And SectorCode <> "0" Then
            str = dbl.SelectAllwhere("Sector", "SectorCode", SectorCode).Rows(0).Item("SectorName")
        End If

        Return str
    End Function
    Public Function DisplayIsFori(cond As String) As String
        If cond = "True" Then
            Return "inline"
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
        If count = 0 Then
            Return "0"
        End If
        Return (val / count).ToString
    End Function



    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        bind()
    End Sub

    Protected Sub LinkButtonClick(sender As Object, e As EventArgs)
        Dim lb As LinkButton = sender
        Dim prjId As String = lb.CommandArgument
        Dim w1 As String = Request.Cookies("Neshan").Value
        Response.Cookies("Neshan").Value = w1.Replace("," + prjId + ",", "")
        Try
            dbl.DeleteFromTable("Neshan", "mobile", Session("User").item("Mobile").ToString, "prjid", prjId)
        Catch ex As Exception

        End Try

        Response.Redirect("neshan.aspx")
    End Sub
    Public Sub bind()
        Try
            Dim cmd As String = " select * from prj where  deleted=0 and  prjid="
            Dim w As String = Request.Cookies("Neshan").Value
            w = w.Replace(",,", " or prjid=").Replace(",", "")
            cmd += w
            Dim tbl As Data.DataTable
            tbl = dbl.SelectFromCommand(cmd)
            Me.ads1.DataSource = tbl
            Me.ads1.DataBind()
            If tbl.Rows.Count > 0 Then
                Me.lblNoData.Visible = False
            Else
                Me.lblNoData.Visible = True
            End If
        Catch ex As Exception
            Me.lblNoData.Visible = True
            Me.lbtnDelcookie.Visible = False
        End Try

    End Sub

    Protected Sub lbtnDelcookie_Click(sender As Object, e As EventArgs) Handles lbtnDelcookie.Click
        Response.Cookies("Neshan").Values.Clear()
        Response.Redirect("neshan.aspx")

    End Sub
End Class
