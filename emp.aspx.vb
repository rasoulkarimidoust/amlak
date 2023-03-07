
Partial Class collaboration
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    'Public Function check() As String

    '    If txtName.Text = "" Then
    '        Return "لطفا نام خود را وارد نمائید"
    '    End If
    '    If txtLastName.Text = "" Then
    '        Return "لطفا نام خانوادگی را وارد کنید."
    '    End If
    '    If txtAddress.Text = "" Then
    '        Return "لطفا آدرس را وارد کنید."
    '    End If
    '    If txtEmail.Text = "" Then
    '        Return "لطفا ایمیل خود را وارد کنید"
    '    End If
    '    If txtMobile.Text = "" Then
    '        Return "لطفا موبایل خود را وارد نمائید"
    '    End If

    '    Return ""
    'End Function
    'Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    Dim err As String = check()
    '    If err <> "" Then
    '        General.MyMsgBox(err, " ")
    '    Else
    '        dbl.Insert("emp", "fname", txtName.Text, "lname", txtLastName.Text, "fatherName", txtFatherName.Text, "tel", Me.txtTel.Text, "mobile", Me.txtMobile.Text, "Email", txtEmail.Text, "description", txtDescription.Text, "address", txtAddress.Text, "tahsilat", Me.ddTahsilat.SelectedItem.Text, "jobtitle", txtjobtitle.Text)
    '        Dim empId As String = dbl.GetMax("emp", "empId")
    '        If fuPic.HasFile Then
    '            Me.fuPic.SaveAs(Server.MapPath("UserFiles") + "/emp" + empId + ".png")
    '        End If
    '        If fuResume.HasFile Then
    '            Me.fuResume.SaveAs(Server.MapPath("UserFiles") + "/empRes" + empId + ".pdf")
    '        End If

    '        General.MyMsgBox("اطلاعات شما ثبت شد", " ", 3, "default.aspx")
    '    End If
    'End Sub
End Class
