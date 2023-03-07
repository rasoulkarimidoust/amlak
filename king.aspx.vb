
Partial Class admin
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim pageName As String = IO.Path.GetFileName(Request.PhysicalPath)

            If IsNothing(Session("user")) = False Then
                If Session("UserType") = "admin" Then
                    divMenuAdmin.Visible = True
                    Me.divJob.Visible = Session("User").item("JobPerm")
                    Me.divnet.Visible = Session("User").item("netPerm")
                    Me.divOffer1.Visible = Session("User").item("offerPerm")
                    Me.divOffer2.Visible = Session("User").item("offerPerm")
                    Me.divOffer3.Visible = Session("User").item("offerPerm")
                    Me.divContact1.Visible = Session("User").item("contactPerm")
                    Me.divContact2.Visible = Session("User").item("contactPerm")
                    Me.divEmp1.Visible = Session("User").item("empPerm")
                    Me.divEmp2.Visible = Session("User").item("empPerm")
                    Me.divEmp3.Visible = Session("User").item("empPerm")
                    Me.divUser.Visible = Session("User").item("userPerm")
                    'Me.divFaq.Visible = Session("User").item("faqPerm")
                    Me.divMgrs1.Visible = Session("User").item("UserName").ToString.ToLower = "admin"
                    Me.divMgrs2.Visible = Session("User").item("UserName").ToString.ToLower = "admin"
                    Me.divMgrs3.Visible = Session("User").item("UserName").ToString.ToLower = "admin"
                    Me.divAds.Visible = Session("User").item("UserName").ToString.ToLower = "admin"

                End If

                If Session("UserType") = "karfarma" Then
                    divMenuKarfama.Visible = True

                End If
            Else
                divMenuGeneral.Visible = True
            End If


        End If

    End Sub


End Class
