Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System

Public Class DataBaseLayer

    Public Connection As New SqlClient.SqlConnection
    Public Adapter As New SqlClient.SqlDataAdapter
    Public DataReader As SqlClient.SqlDataReader
    Public DataSet As DataSet
    Public DataTable As DataTable
    '  Dim Bindingsource As BindingSource
    Private _ConnectionString As String

    Public Property ConnectionString() As String
        Get
            Return _ConnectionString
        End Get
        Set(ByVal value As String)
            _ConnectionString = value
        End Set
    End Property

    Public Sub New(ByVal Cnn As String)
        Me.Connection.ConnectionString = Cnn
        Me._ConnectionString = Cnn
        Me.Adapter.SelectCommand = New SqlClient.SqlCommand
        Me.Adapter.SelectCommand.Connection = Me.Connection
        Me.Adapter.UpdateCommand = New SqlClient.SqlCommand
        Me.Adapter.UpdateCommand.Connection = Me.Connection
    End Sub
    'Public Sub ConnectTo(ByVal Ip As String)
    '    Me.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings("constr") + ";data source=" + Ip + ";"

    'End Sub
    'Public Sub ConnectToMyServer()
    '    Me.Connection.ConnectionString = System.Configuration.ConfigurationManager.AppSettings("constr") + ";data source=" + ConfigurationSettings.AppSettings("DataSource") + ";"
    'End Sub

    Public Sub DeleteFromTable(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "DELETE FROM [" + TableName + "] WHERE     ([" + FieldName + "] = N'" + FieldValue + "')"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        ''
    End Sub

    Public Sub DeleteFromTable(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "DELETE FROM [" + TableName + "] WHERE     ([" + FieldName + "] = N'" + FieldValue + "') and ([" + FieldName2 + "] = N'" + FieldValue2 + "')"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        ''
    End Sub

    Public Sub ExecCommand(ByVal CommandText As String)
        Try
            Dim viewCommand As New SqlCommand(CommandText, Connection)
            Connection.Open()
            viewCommand.ExecuteNonQuery()
            Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Connection.Close()
        End Try

    End Sub
    Public Function SelectFromCommand(ByVal SelectCommand As String, Optional ByVal TableName As String = "Select1") As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataTable = New DataTable(TableName)
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = SelectCommand
        Me.Adapter.Fill(Me.DataTable)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataTable

    End Function


    Public Function SelectAllwhereLike(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "] LIKE N'%" + FieldValue + "%') order by [" + FieldName + "]"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function

    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataTable = New DataTable
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "')"
        Me.Adapter.Fill(Me.DataTable)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataTable
        Me.DataSet.Dispose()
    End Function
    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')  AND ([" + FieldName3 + "]=N'" + FieldValue3 + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String, ByVal FieldName4 As String, ByVal FieldValue4 As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')  AND ([" + FieldName3 + "]=N'" + FieldValue3 + "')  AND ([" + FieldName4 + "]=N'" + FieldValue4 + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String, ByVal OrderBy As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "')  AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')   AND ([" + FieldName3 + "]=N'" + FieldValue3 + "')   ORDER BY " + OrderBy + " Desc"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function

    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal OrderBy As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "')  AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')  ORDER BY " + OrderBy + " Desc"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal OrderBy As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') ORDER BY " + OrderBy + " Desc"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function

    Public Function SelectTopwhereOrderBy(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal OrderBy As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') ORDER BY " + OrderBy
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectTopwhere(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectTopwhereOrderBy(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal OrderBy As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') AND ([" + FieldName2 + "]=N'" + FieldValue2 + "') ORDER BY " + OrderBy
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectTopwhere(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N'" + FieldValue + "') AND ([" + FieldName2 + "]=N'" + FieldValue2 + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function

    'Public Sub NewDataTable(ByVal TableName As String)
    '    If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
    '    Me.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '    Dim Parametr As SqlParameter
    '    Adapter.SelectCommand.Parameters.Clear()
    '    Parametr = New SqlParameter("@TableName", TableName)
    '    Parametr.SqlDbType = SqlDbType.NVarChar
    '    Me.Adapter.SelectCommand.CommandText = "NewDataTable"
    '    Me.Adapter.SelectCommand.Parameters.Add(Parametr)
    '    Me.Adapter.SelectCommand.ExecuteNonQuery()
    '    If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    'End Sub
    Public Function ExistTable(ByVal TableName As String) As Boolean
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
        Dim Parametr As SqlParameter
        Dim result As Boolean
        Adapter.SelectCommand.Parameters.Clear()
        Parametr = New SqlParameter("@TableID", TableName)
        Parametr.SqlDbType = SqlDbType.NVarChar
        Me.Adapter.SelectCommand.CommandText = "ExistTable"
        Me.Adapter.SelectCommand.Parameters.Add(Parametr)
        result = Me.Adapter.SelectCommand.ExecuteScalar
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return result
        Me.DataSet.Dispose()

    End Function
    Public Function GetImage(ByVal TableName As String, Optional ByVal IDName As String = "", Optional ByVal IDValue As String = "") As DataRow
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM [" + TableName + "]"
        If IDName <> "" Then
            Me.Adapter.SelectCommand.CommandText += " Where  ([" + IDName + "] =" + IDValue + ")"
        End If
        Me.Adapter.Fill(Me.DataSet, "image")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("image").Rows(0)
    End Function

    Public Function SelectAll(ByVal TableName As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "]"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Function SelectAll(ByVal TableName As String, ByVal OrderField As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] order by [" + OrderField + "]"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function
    Public Sub Update(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
, Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
, Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
, Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
, Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
, Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
, Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
, Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
, Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
, Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "" _
, Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
, Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
, Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = ""
)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "] SET   " + SetFieldName + " = N'" + SetFieldValue + "'"
        If SetFieldName1 <> "" Then
            If SetFieldValue1.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N'" + SetFieldValue1 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = " + SetFieldValue1
            End If
        End If
        If SetFieldName2 <> "" Then
            If SetFieldValue2.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N'" + SetFieldValue2 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = " + SetFieldValue2
            End If
        End If
        If SetFieldName3 <> "" Then
            If SetFieldValue3.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N'" + SetFieldValue3 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = " + SetFieldValue3
            End If
        End If
        If SetFieldName4 <> "" Then
            If SetFieldValue4.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N'" + SetFieldValue4 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = " + SetFieldValue4
            End If
        End If
        If SetFieldName5 <> "" Then
            If SetFieldValue5.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N'" + SetFieldValue5 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = " + SetFieldValue5
            End If
        End If
        If SetFieldName6 <> "" Then
            If SetFieldValue6.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N'" + SetFieldValue6 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = " + SetFieldValue6
            End If
        End If
        If SetFieldName7 <> "" Then
            If SetFieldValue7.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N'" + SetFieldValue7 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = " + SetFieldValue7
            End If
        End If
        If SetFieldName8 <> "" Then
            If SetFieldValue8.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N'" + SetFieldValue8 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = " + SetFieldValue8
            End If
        End If
        If SetFieldName9 <> "" Then
            If SetFieldValue9.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N'" + SetFieldValue9 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = " + SetFieldValue9
            End If
        End If
        If ConditionFieldName1 <> "" Then
            If ConditionFieldValue1.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " where (  " + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName1 + " = " + ConditionFieldValue1
            End If
        End If
        If ConditionFieldName2 <> "" Then
            If ConditionFieldValue2.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = N'" + ConditionFieldValue2 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = " + ConditionFieldValue2
            End If
        End If
        If ConditionFieldName3 <> "" Then
            If ConditionFieldValue3.ToLower <> "null" Then
                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = N'" + ConditionFieldValue3 + "'"
            Else
                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = " + ConditionFieldValue3
            End If
        End If
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " ) "
        End If

        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub BigUpdate(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
, Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
, Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
, Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
, Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
, Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
, Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
, Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
, Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
, Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "" _
, Optional ByVal SetFieldName10 As String = "", Optional ByVal SetFieldValue10 As String = "" _
, Optional ByVal SetFieldName11 As String = "", Optional ByVal SetFieldValue11 As String = "" _
, Optional ByVal SetFieldName12 As String = "", Optional ByVal SetFieldValue12 As String = "" _
, Optional ByVal SetFieldName13 As String = "", Optional ByVal SetFieldValue13 As String = "" _
, Optional ByVal SetFieldName14 As String = "", Optional ByVal SetFieldValue14 As String = "" _
, Optional ByVal SetFieldName15 As String = "", Optional ByVal SetFieldValue15 As String = "" _
, Optional ByVal SetFieldName16 As String = "", Optional ByVal SetFieldValue16 As String = "" _
, Optional ByVal SetFieldName17 As String = "", Optional ByVal SetFieldValue17 As String = "" _
, Optional ByVal SetFieldName18 As String = "", Optional ByVal SetFieldValue18 As String = "" _
, Optional ByVal SetFieldName19 As String = "", Optional ByVal SetFieldValue19 As String = "" _
, Optional ByVal SetFieldName20 As String = "", Optional ByVal SetFieldValue20 As String = "" _
, Optional ByVal SetFieldName21 As String = "", Optional ByVal SetFieldValue21 As String = "" _
, Optional ByVal SetFieldName22 As String = "", Optional ByVal SetFieldValue22 As String = "" _
, Optional ByVal SetFieldName23 As String = "", Optional ByVal SetFieldValue23 As String = "" _
, Optional ByVal SetFieldName24 As String = "", Optional ByVal SetFieldValue24 As String = "" _
, Optional ByVal SetFieldName25 As String = "", Optional ByVal SetFieldValue25 As String = "" _
, Optional ByVal SetFieldName26 As String = "", Optional ByVal SetFieldValue26 As String = "" _
, Optional ByVal SetFieldName27 As String = "", Optional ByVal SetFieldValue27 As String = "" _
, Optional ByVal SetFieldName28 As String = "", Optional ByVal SetFieldValue28 As String = "" _
, Optional ByVal SetFieldName29 As String = "", Optional ByVal SetFieldValue29 As String = "" _
, Optional ByVal SetFieldName30 As String = "", Optional ByVal SetFieldValue30 As String = "" _
, Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
, Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
, Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = ""
)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "] SET   " + SetFieldName + " = N'" + SetFieldValue + "'"
        If SetFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N'" + SetFieldValue1 + "'"
        End If
        If SetFieldName2 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N'" + SetFieldValue2 + "'"
        End If
        If SetFieldName3 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N'" + SetFieldValue3 + "'"
        End If
        If SetFieldName4 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N'" + SetFieldValue4 + "'"
        End If
        If SetFieldName5 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N'" + SetFieldValue5 + "'"
        End If
        If SetFieldName6 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N'" + SetFieldValue6 + "'"
        End If
        If SetFieldName7 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N'" + SetFieldValue7 + "'"
        End If
        If SetFieldName8 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N'" + SetFieldValue8 + "'"
        End If
        If SetFieldName9 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N'" + SetFieldValue9 + "'"
        End If
        If SetFieldName10 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName10 + " = N'" + SetFieldValue10 + "'"
        End If
        ''''''''
        If SetFieldName11 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName11 + " = N'" + SetFieldValue11 + "'"
        End If
        If SetFieldName12 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName12 + " = N'" + SetFieldValue12 + "'"
        End If
        If SetFieldName13 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName13 + " = N'" + SetFieldValue13 + "'"
        End If
        If SetFieldName14 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName14 + " = N'" + SetFieldValue14 + "'"
        End If
        If SetFieldName15 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName15 + " = N'" + SetFieldValue15 + "'"
        End If
        If SetFieldName16 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName16 + " = N'" + SetFieldValue16 + "'"
        End If
        If SetFieldName17 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName17 + " = N'" + SetFieldValue17 + "'"
        End If
        If SetFieldName18 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName18 + " = N'" + SetFieldValue18 + "'"
        End If
        If SetFieldName19 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName19 + " = N'" + SetFieldValue19 + "'"
        End If
        If SetFieldName20 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName20 + " = N'" + SetFieldValue20 + "'"
        End If
        If SetFieldName21 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName21 + " = N'" + SetFieldValue21 + "'"
        End If
        If SetFieldName22 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName22 + " = N'" + SetFieldValue22 + "'"
        End If
        If SetFieldName23 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName23 + " = N'" + SetFieldValue23 + "'"
        End If
        If SetFieldName24 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName24 + " = N'" + SetFieldValue24 + "'"
        End If
        If SetFieldName25 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName25 + " = N'" + SetFieldValue25 + "'"
        End If
        If SetFieldName26 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName26 + " = N'" + SetFieldValue26 + "'"
        End If
        If SetFieldName27 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName27 + " = N'" + SetFieldValue27 + "'"
        End If
        If SetFieldName28 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName28 + " = N'" + SetFieldValue28 + "'"
        End If
        If SetFieldName29 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName29 + " = N'" + SetFieldValue29 + "'"
        End If
        If SetFieldName30 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName30 + " = N'" + SetFieldValue30 + "'"
        End If
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " where ( " + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "'"
        End If
        If ConditionFieldName2 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = N'" + ConditionFieldValue2 + "'"
        End If
        If ConditionFieldName3 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = N'" + ConditionFieldValue3 + "'"
        End If
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " ) "
        End If

        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub UpdateAllWithOutWhere(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
    , Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
    , Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
    , Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
    , Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
    , Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
    , Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
    , Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
    , Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
    , Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "")
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N'" + SetFieldValue + "'"
        If SetFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N'" + SetFieldValue1 + "'"
        End If
        If SetFieldName2 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N'" + SetFieldValue2 + "'"
        End If
        If SetFieldName3 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N'" + SetFieldValue3 + "'"
        End If
        If SetFieldName4 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N'" + SetFieldValue4 + "'"
        End If
        If SetFieldName5 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N'" + SetFieldValue5 + "'"
        End If
        If SetFieldName6 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N'" + SetFieldValue6 + "'"
        End If
        If SetFieldName7 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N'" + SetFieldValue7 + "'"
        End If
        If SetFieldName8 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N'" + SetFieldValue8 + "'"
        End If
        If SetFieldName9 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N'" + SetFieldValue9 + "'"
        End If
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub UpdateField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N'" + SetFieldValue + "'"

        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub UpdateAField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String, ByVal ConditionFieldName1 As String, ByVal ConditionFieldValue1 As String, Optional ByVal ConditionType1 As String = "", Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "", Optional ByVal ConditionType2 As String = "", Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "", Optional ByVal ConditionType3 As String = "")
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N'" + SetFieldValue + "'"

        If ConditionFieldName1 <> "" Then
            If ConditionType1 = "" Then
                Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "')"
            Else
                If ConditionType1 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "')"
                End If
            End If
        End If

        If ConditionFieldName2 <> "" Then
            If ConditionType2 = "" Then
                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " = N'" + ConditionFieldValue2 + "')"
            Else
                If ConditionType2 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " < " + ConditionFieldValue2 + ")"
                End If
            End If
        End If

        If ConditionFieldName3 <> "" Then
            If ConditionType3 = "" Then
                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " = N'" + ConditionFieldValue3 + "')"
            Else
                If ConditionType3 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " < " + ConditionFieldValue3 + ")"
                End If
            End If
        End If

        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub InsertFile(ByVal FileType As String, ByVal FileContent As Byte())
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.Parameters.Clear()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "INSERT INTO DT_ProgramFiles  (Type,image) VALUES   ('" + FileType + "',@FileContent)"
        Me.Adapter.SelectCommand.Parameters.AddWithValue("@FileContent", FileContent)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub UpdateAnImageFieldWithOutWhere(ByVal TableName As String, ByVal ImageFieldName As String, ByVal image As Byte(), ByVal ImageTypeFieldName As String, ByVal ImageType As String)

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.Parameters.Clear()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + "  SET  " + ImageFieldName + " = @image  ," + ImageTypeFieldName + "=N'" + ImageType + "'"
        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub UpdateAnImageFieldWhere(ByVal TableName As String, ByVal ImageFieldName As String, ByVal image As Byte() _
        , Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
, Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
, Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = ""
)

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.Parameters.Clear()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "]  SET  " + ImageFieldName + " = @image  " '," + ImageTypeFieldName + "=N'" + ImageType + "'"
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " where ( [" + ConditionFieldName1 + "] = N'" + ConditionFieldValue1 + "'"
        End If
        If ConditionFieldName2 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName2 + "] = N'" + ConditionFieldValue2 + "'"
        End If
        If ConditionFieldName3 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName3 + "] = N'" + ConditionFieldValue3 + "'"
        End If
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " ) "
        End If


        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub UpdateImage(ByVal ImageCode As String, ByVal image As Byte())
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.Parameters.Clear()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    DT_Image  SET  Image = @image  WHERE     (Code = " + ImageCode + ")"
        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub InsertImage(ByVal Code As String, ByVal LogID As String, ByVal TableID As String, ByVal Type As String, ByVal image As Byte())
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.Parameters.Clear()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "INSERT INTO DT_Image  (Code, LogID, TableID,Type, [image]) VALUES   (" + Code + "," + LogID + "," + TableID + ",'" + Type + "',@image)"
        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()

        ''
    End Sub
    Public Function InsertFile(ByVal TableName As String, ByVal PKColumnName As String, ByVal FileColumnName As String, ByVal TypeColumnName As String, ByVal FileType As String, ByVal Content As Byte(), Optional ByVal ExtensionColumnName As String = "", Optional ByVal Extension As String = "") As String
        Try
            If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
            Me.Adapter.SelectCommand.Parameters.Clear()
            Me.Adapter.SelectCommand.CommandType = CommandType.Text
            If String.IsNullOrEmpty(Extension) = True Then

                Me.Adapter.SelectCommand.CommandText = "INSERT INTO [" + TableName + "]  ([" + TypeColumnName + "],[" + FileColumnName + "]) VALUES   ('" + FileType + "',@image)"
            Else
                Me.Adapter.SelectCommand.CommandText = "INSERT INTO [" + TableName + "]  ([" + TypeColumnName + "],[" + FileColumnName + "],[" + ExtensionColumnName + "]) VALUES   ('" + FileType + "',@image,'" + Extension + "')"
            End If
            Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", Content)
            Me.Adapter.SelectCommand.ExecuteNonQuery()
            If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
            Return Me.GetMax(TableName, PKColumnName)
        Catch ex As Exception
            Return "-1"
        End Try

        ''
    End Function
    Public Function GetMaxWhere(ByVal TableName As String, ByVal IDName As String _
        , Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
, Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
, Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = ""
) As String

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS MaxField FROM [" + TableName + "] "

        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " where ( [" + ConditionFieldName1 + "] = N'" + ConditionFieldValue1 + "'"
        End If
        If ConditionFieldName2 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName2 + "] = N'" + ConditionFieldValue2 + "'"
        End If
        If ConditionFieldName3 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName3 + "] = N'" + ConditionFieldValue3 + "'"
        End If
        If ConditionFieldName1 <> "" Then
            Me.Adapter.SelectCommand.CommandText += " ) "
        End If

        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return MaxCode
    End Function
    Public Function GetMax(ByVal TableName As String, ByVal IDName As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS Max FROM [" + TableName + "]"
        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return MaxCode
    End Function
    Public Function GetMax(ByVal TableName As String, ByVal IDName As String, ByVal conditionFieldName As String, ByVal ConditionFieldValue As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS Max FROM [" + TableName + "] where " + conditionFieldName + "=" + ConditionFieldValue
        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return MaxCode
    End Function
    Public Function GetMaxPlus(ByVal TableName As String, ByVal IDName As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  isnull(MAX(" + IDName + "),0)+1 AS Max FROM [" + TableName + "]"
        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return MaxCode
    End Function
    Public Function GetMaxPlus(ByVal TableName As String, ByVal IDName As String, ByVal conditionFieldName As String, ByVal ConditionFieldValue As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  isnull(MAX(" + IDName + "),0)+1 AS Max FROM [" + TableName + "] where " + conditionFieldName + "=" + ConditionFieldValue
        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()

        Return MaxCode
    End Function
    Public Function GetMaxPlusByStationCode(ByVal TableName As String, ByVal IDName As String, ByVal StationCode As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim MaxCode As String
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  isnull(MAX(" + IDName + "),0)+1 AS Max FROM [" + TableName + "]" + " where StationCode=" + StationCode
        Me.Adapter.Fill(Me.DataSet, "Max")
        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return MaxCode
    End Function

    Public Function Login(ByVal UserName As String, ByVal Password As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataTable = New DataTable("User")
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "select * from logins where username=@UserName and password=@Password"
        Dim Params(1) As SqlParameter
        Params(0) = New SqlParameter("@UserName", UserName)
        Params(1) = New SqlParameter("@Password", Password)
        Adapter.SelectCommand.Parameters.Add(Params(0))
        Adapter.SelectCommand.Parameters.Add(Params(1))
        Me.Adapter.Fill(Me.DataTable)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataTable
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function Login(ByVal UserName As String, ByVal Password As String, ByVal CMSCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataTable = New DataTable("User")
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = ("SELECT     UserName, Password, UserCode, UserType, Name,Title,Title+' '+ Name as ComplateName , UserPage FROM        DT_User  WHERE     (UserName = @UserName) AND (Password = @Password) and (CMSCode= " & CMSCode & ")")
        Dim Params(1) As SqlParameter
        Params(0) = New SqlParameter("@UserName", UserName)
        Params(1) = New SqlParameter("@Password", Password)
        Adapter.SelectCommand.Parameters.Add(Params(0))
        Adapter.SelectCommand.Parameters.Add(Params(1))
        Me.Adapter.Fill(Me.DataTable)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataTable
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function NomrehLogin(ByVal UserName As String, ByVal Password As String, ByVal FileCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Dim tempDt As Data.DataTable = SelectAllwhere("Files", "FileCode", FileCode)
        Me.DataTable = New DataTable("User")
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        With tempDt.Rows(0)
            Me.Adapter.SelectCommand.CommandText = "select * from Nomreh where " + .Item("UserField") + "=@UserName and " + .Item("PassField") + "=@Password and FileCode=@FileCode"
        End With
        Dim Params(2) As SqlParameter
        Params(0) = New SqlParameter("@UserName", UserName)
        Params(1) = New SqlParameter("@Password", Password)
        Params(2) = New SqlParameter("@FileCode", FileCode)
        Adapter.SelectCommand.Parameters.Add(Params(0))
        Adapter.SelectCommand.Parameters.Add(Params(1))
        Adapter.SelectCommand.Parameters.Add(Params(2))
        Me.Adapter.Fill(Me.DataTable)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataTable
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetUserType(ByVal UserCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        If UserCode = "" Then
            Return "Guest"
        End If
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     UserType  FROM     DT_User  WHERE     (UserCode = " + UserCode + ")"
        Me.Adapter.Fill(Me.DataSet, "UserType")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        If DataSet.Tables("UserType").Rows.Count > 0 Then
            Return Me.DataSet.Tables("UserType").Rows(0).Item("UserType").ToString
        End If
        Me.DataSet.Dispose()
    End Function

    Public Function GetTableFields(ByVal TableCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  *  FROM  DT_Field  WHERE     (TableCode = " + TableCode + ")"
        Me.Adapter.Fill(Me.DataSet, "Fields")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Fields")
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Sub SetInsertFieldValueStr(ByRef FieldValueEnd As Boolean, ByRef str As String, ByVal FieldValue As String)
        If FieldValueEnd = False Then
            If FieldValue <> "NotHasData" And FieldValue <> "" Then
                str += FieldValue + ", "
            Else
                str = str.Substring(0, str.Length - 2)
                FieldValueEnd = True
            End If
        End If


    End Sub
    Public Sub SetInsertValueStr(ByRef ValueEnd As Boolean, ByRef str As String, ByVal Value As String, ByVal Type As String)
        If ValueEnd = False Then
            If Value <> "NotHasData" And Value <> "" Then
                If Type <> "bit" Then
                    str += "N'" + Value + "', "
                Else
                    If Value = "True" Then
                        str += "1 , "

                    Else
                        str += "0 , "
                    End If

                End If
            Else

                str = str.Substring(0, str.LastIndexOf(","))
                ValueEnd = True
            End If
        End If


    End Sub
    Public Sub SetInsertValueStr(ByRef ValueEnd As Boolean, ByRef str As String, ByVal Value As String)
        If ValueEnd = False Then
            If Value <> "NotHasData" Then
                str += "N'" + Value + "', "
            Else
                str = str.Substring(0, str.Length - 2)
                ValueEnd = True
            End If
        End If


    End Sub

    Public Sub InsertViaType(ByVal TableName As String, ByVal Field1 As String, ByVal Value1 As String, Optional ByVal Type1 As String = "text",
Optional ByVal Field2 As String = "NotHasData", Optional ByVal Value2 As String = "NotHasData", Optional ByVal Type2 As String = "text",
Optional ByVal Field3 As String = "NotHasData", Optional ByVal Value3 As String = "NotHasData", Optional ByVal Type3 As String = "text",
Optional ByVal Field4 As String = "NotHasData", Optional ByVal Value4 As String = "NotHasData", Optional ByVal Type4 As String = "text",
Optional ByVal Field5 As String = "NotHasData", Optional ByVal Value5 As String = "NotHasData", Optional ByVal Type5 As String = "text",
Optional ByVal Field6 As String = "NotHasData", Optional ByVal Value6 As String = "NotHasData", Optional ByVal Type6 As String = "text",
Optional ByVal Field7 As String = "NotHasData", Optional ByVal Value7 As String = "NotHasData", Optional ByVal Type7 As String = "text",
Optional ByVal Field8 As String = "NotHasData", Optional ByVal Value8 As String = "NotHasData", Optional ByVal Type8 As String = "text",
Optional ByVal Field9 As String = "NotHasData", Optional ByVal Value9 As String = "NotHasData", Optional ByVal Type9 As String = "text",
Optional ByVal Field10 As String = "NotHasData", Optional ByVal Value10 As String = "NotHasData", Optional ByVal Type10 As String = "text",
Optional ByVal Field11 As String = "NotHasData", Optional ByVal Value11 As String = "NotHasData", Optional ByVal Type11 As String = "text",
Optional ByVal Field12 As String = "NotHasData", Optional ByVal Value12 As String = "NotHasData", Optional ByVal Type12 As String = "text",
Optional ByVal Field13 As String = "NotHasData", Optional ByVal Value13 As String = "NotHasData", Optional ByVal Type13 As String = "text",
Optional ByVal Field14 As String = "NotHasData", Optional ByVal Value14 As String = "NotHasData", Optional ByVal Type14 As String = "text",
Optional ByVal Field15 As String = "NotHasData", Optional ByVal Value15 As String = "NotHasData", Optional ByVal Type15 As String = "text",
Optional ByVal Field16 As String = "NotHasData", Optional ByVal Value16 As String = "NotHasData", Optional ByVal Type16 As String = "text")

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Dim str As String
        Dim FieldValueEnd As Boolean = False

        str = "INSERT INTO [" + TableName + "] ( "

        SetInsertFieldValueStr(FieldValueEnd, str, Field1)
        SetInsertFieldValueStr(FieldValueEnd, str, Field2)
        SetInsertFieldValueStr(FieldValueEnd, str, Field3)
        SetInsertFieldValueStr(FieldValueEnd, str, Field4)
        SetInsertFieldValueStr(FieldValueEnd, str, Field5)
        SetInsertFieldValueStr(FieldValueEnd, str, Field6)
        SetInsertFieldValueStr(FieldValueEnd, str, Field7)
        SetInsertFieldValueStr(FieldValueEnd, str, Field8)
        SetInsertFieldValueStr(FieldValueEnd, str, Field9)
        SetInsertFieldValueStr(FieldValueEnd, str, Field10)
        SetInsertFieldValueStr(FieldValueEnd, str, Field11)
        SetInsertFieldValueStr(FieldValueEnd, str, Field12)
        SetInsertFieldValueStr(FieldValueEnd, str, Field13)
        SetInsertFieldValueStr(FieldValueEnd, str, Field14)
        SetInsertFieldValueStr(FieldValueEnd, str, Field15)
        SetInsertFieldValueStr(FieldValueEnd, str, Field16)
        str = str.Substring(0, str.LastIndexOf(","))
        str += " ) VALUES  ( "
        FieldValueEnd = False

        SetInsertValueStr(FieldValueEnd, str, Value1, Type1)
        SetInsertValueStr(FieldValueEnd, str, Value2, Type2)
        SetInsertValueStr(FieldValueEnd, str, Value3, Type3)
        SetInsertValueStr(FieldValueEnd, str, Value4, Type4)
        SetInsertValueStr(FieldValueEnd, str, Value5, Type5)
        SetInsertValueStr(FieldValueEnd, str, Value6, Type6)
        SetInsertValueStr(FieldValueEnd, str, Value7, Type7)
        SetInsertValueStr(FieldValueEnd, str, Value8, Type8)
        SetInsertValueStr(FieldValueEnd, str, Value9, Type9)
        SetInsertValueStr(FieldValueEnd, str, Value10, Type10)
        SetInsertValueStr(FieldValueEnd, str, Value11, Type11)
        SetInsertValueStr(FieldValueEnd, str, Value12, Type12)
        SetInsertValueStr(FieldValueEnd, str, Value13, Type13)
        SetInsertValueStr(FieldValueEnd, str, Value14, Type14)
        SetInsertValueStr(FieldValueEnd, str, Value15, Type15)
        SetInsertValueStr(FieldValueEnd, str, Value16, Type16)

        str = str.Substring(0, str.LastIndexOf(","))
        str += " ) "
        'ModifyDate,Data, FieldCode,LogID,FarignID,InsertByUser ) VALUES  ( GETDATE(), N'" + DeleteTag(Data) + "'," + FieldCode + "," + LogID + ",N'" + FarignID + "',1)"
        Me.Adapter.SelectCommand.CommandText = str
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub Insert(ByVal TableName As String, ByVal Field1 As String, ByVal Value1 As String,
    Optional ByVal Field2 As String = "NotHasData", Optional ByVal Value2 As String = "NotHasData",
    Optional ByVal Field3 As String = "NotHasData", Optional ByVal Value3 As String = "NotHasData",
    Optional ByVal Field4 As String = "NotHasData", Optional ByVal Value4 As String = "NotHasData",
    Optional ByVal Field5 As String = "NotHasData", Optional ByVal Value5 As String = "NotHasData",
    Optional ByVal Field6 As String = "NotHasData", Optional ByVal Value6 As String = "NotHasData",
    Optional ByVal Field7 As String = "NotHasData", Optional ByVal Value7 As String = "NotHasData",
    Optional ByVal Field8 As String = "NotHasData", Optional ByVal Value8 As String = "NotHasData",
    Optional ByVal Field9 As String = "NotHasData", Optional ByVal Value9 As String = "NotHasData",
    Optional ByVal Field10 As String = "NotHasData", Optional ByVal Value10 As String = "NotHasData",
    Optional ByVal Field11 As String = "NotHasData", Optional ByVal Value11 As String = "NotHasData",
    Optional ByVal Field12 As String = "NotHasData", Optional ByVal Value12 As String = "NotHasData",
    Optional ByVal Field13 As String = "NotHasData", Optional ByVal Value13 As String = "NotHasData",
    Optional ByVal Field14 As String = "NotHasData", Optional ByVal Value14 As String = "NotHasData",
    Optional ByVal Field15 As String = "NotHasData", Optional ByVal Value15 As String = "NotHasData",
    Optional ByVal Field16 As String = "NotHasData", Optional ByVal Value16 As String = "NotHasData",
    Optional ByVal Field17 As String = "NotHasData", Optional ByVal Value17 As String = "NotHasData",
    Optional ByVal Field18 As String = "NotHasData", Optional ByVal Value18 As String = "NotHasData",
    Optional ByVal Field19 As String = "NotHasData", Optional ByVal Value19 As String = "NotHasData",
    Optional ByVal Field20 As String = "NotHasData", Optional ByVal Value20 As String = "NotHasData",
    Optional ByVal Field21 As String = "NotHasData", Optional ByVal Value21 As String = "NotHasData",
    Optional ByVal Field22 As String = "NotHasData", Optional ByVal Value22 As String = "NotHasData",
    Optional ByVal Field23 As String = "NotHasData", Optional ByVal Value23 As String = "NotHasData",
    Optional ByVal Field24 As String = "NotHasData", Optional ByVal Value24 As String = "NotHasData",
    Optional ByVal Field25 As String = "NotHasData", Optional ByVal Value25 As String = "NotHasData",
    Optional ByVal Field26 As String = "NotHasData", Optional ByVal Value26 As String = "NotHasData",
    Optional ByVal Field27 As String = "NotHasData", Optional ByVal Value27 As String = "NotHasData",
    Optional ByVal Field28 As String = "NotHasData", Optional ByVal Value28 As String = "NotHasData",
    Optional ByVal Field29 As String = "NotHasData", Optional ByVal Value29 As String = "NotHasData",
    Optional ByVal Field30 As String = "NotHasData", Optional ByVal Value30 As String = "NotHasData",
    Optional ByVal Field31 As String = "NotHasData", Optional ByVal Value31 As String = "NotHasData",
    Optional ByVal Field32 As String = "NotHasData", Optional ByVal Value32 As String = "NotHasData",
    Optional ByVal Field33 As String = "NotHasData", Optional ByVal Value33 As String = "NotHasData",
    Optional ByVal Field34 As String = "NotHasData", Optional ByVal Value34 As String = "NotHasData",
    Optional ByVal Field35 As String = "NotHasData", Optional ByVal Value35 As String = "NotHasData",
    Optional ByVal Field36 As String = "NotHasData", Optional ByVal Value36 As String = "NotHasData",
    Optional ByVal Field37 As String = "NotHasData", Optional ByVal Value37 As String = "NotHasData",
    Optional ByVal Field38 As String = "NotHasData", Optional ByVal Value38 As String = "NotHasData",
    Optional ByVal Field39 As String = "NotHasData", Optional ByVal Value39 As String = "NotHasData",
    Optional ByVal Field40 As String = "NotHasData", Optional ByVal Value40 As String = "NotHasData")

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Dim str As String
        Dim FieldValueEnd As Boolean = False

        str = "INSERT INTO [" + TableName + "] ( "

        SetInsertFieldValueStr(FieldValueEnd, str, Field1)
        SetInsertFieldValueStr(FieldValueEnd, str, Field2)
        SetInsertFieldValueStr(FieldValueEnd, str, Field3)
        SetInsertFieldValueStr(FieldValueEnd, str, Field4)
        SetInsertFieldValueStr(FieldValueEnd, str, Field5)
        SetInsertFieldValueStr(FieldValueEnd, str, Field6)
        SetInsertFieldValueStr(FieldValueEnd, str, Field7)
        SetInsertFieldValueStr(FieldValueEnd, str, Field8)
        SetInsertFieldValueStr(FieldValueEnd, str, Field9)
        SetInsertFieldValueStr(FieldValueEnd, str, Field10)
        SetInsertFieldValueStr(FieldValueEnd, str, Field11)
        SetInsertFieldValueStr(FieldValueEnd, str, Field12)
        SetInsertFieldValueStr(FieldValueEnd, str, Field13)
        SetInsertFieldValueStr(FieldValueEnd, str, Field14)
        SetInsertFieldValueStr(FieldValueEnd, str, Field15)
        SetInsertFieldValueStr(FieldValueEnd, str, Field16)
        SetInsertFieldValueStr(FieldValueEnd, str, Field17)
        SetInsertFieldValueStr(FieldValueEnd, str, Field18)
        SetInsertFieldValueStr(FieldValueEnd, str, Field19)
        SetInsertFieldValueStr(FieldValueEnd, str, Field20)
        SetInsertFieldValueStr(FieldValueEnd, str, Field21)
        SetInsertFieldValueStr(FieldValueEnd, str, Field22)
        SetInsertFieldValueStr(FieldValueEnd, str, Field23)
        SetInsertFieldValueStr(FieldValueEnd, str, Field24)
        SetInsertFieldValueStr(FieldValueEnd, str, Field25)
        SetInsertFieldValueStr(FieldValueEnd, str, Field26)
        SetInsertFieldValueStr(FieldValueEnd, str, Field27)
        SetInsertFieldValueStr(FieldValueEnd, str, Field28)
        SetInsertFieldValueStr(FieldValueEnd, str, Field29)
        SetInsertFieldValueStr(FieldValueEnd, str, Field30)
        SetInsertFieldValueStr(FieldValueEnd, str, Field31)
        SetInsertFieldValueStr(FieldValueEnd, str, Field32)
        SetInsertFieldValueStr(FieldValueEnd, str, Field33)
        SetInsertFieldValueStr(FieldValueEnd, str, Field34)
        SetInsertFieldValueStr(FieldValueEnd, str, Field35)
        SetInsertFieldValueStr(FieldValueEnd, str, Field36)
        SetInsertFieldValueStr(FieldValueEnd, str, Field37)
        SetInsertFieldValueStr(FieldValueEnd, str, Field38)
        SetInsertFieldValueStr(FieldValueEnd, str, Field39)
        SetInsertFieldValueStr(FieldValueEnd, str, Field40)

        str += " ) VALUES  ( "
        FieldValueEnd = False

        SetInsertValueStr(FieldValueEnd, str, Value1)
        SetInsertValueStr(FieldValueEnd, str, Value2)
        SetInsertValueStr(FieldValueEnd, str, Value3)
        SetInsertValueStr(FieldValueEnd, str, Value4)
        SetInsertValueStr(FieldValueEnd, str, Value5)
        SetInsertValueStr(FieldValueEnd, str, Value6)
        SetInsertValueStr(FieldValueEnd, str, Value7)
        SetInsertValueStr(FieldValueEnd, str, Value8)
        SetInsertValueStr(FieldValueEnd, str, Value9)
        SetInsertValueStr(FieldValueEnd, str, Value10)
        SetInsertValueStr(FieldValueEnd, str, Value11)
        SetInsertValueStr(FieldValueEnd, str, Value12)
        SetInsertValueStr(FieldValueEnd, str, Value13)
        SetInsertValueStr(FieldValueEnd, str, Value14)
        SetInsertValueStr(FieldValueEnd, str, Value15)
        SetInsertValueStr(FieldValueEnd, str, Value16)
        SetInsertValueStr(FieldValueEnd, str, Value17)
        SetInsertValueStr(FieldValueEnd, str, Value18)
        SetInsertValueStr(FieldValueEnd, str, Value19)
        SetInsertValueStr(FieldValueEnd, str, Value20)
        SetInsertValueStr(FieldValueEnd, str, Value21)
        SetInsertValueStr(FieldValueEnd, str, Value22)
        SetInsertValueStr(FieldValueEnd, str, Value23)
        SetInsertValueStr(FieldValueEnd, str, Value24)
        SetInsertValueStr(FieldValueEnd, str, Value25)
        SetInsertValueStr(FieldValueEnd, str, Value26)
        SetInsertValueStr(FieldValueEnd, str, Value27)
        SetInsertValueStr(FieldValueEnd, str, Value28)
        SetInsertValueStr(FieldValueEnd, str, Value29)
        SetInsertValueStr(FieldValueEnd, str, Value30)
        SetInsertValueStr(FieldValueEnd, str, Value31)
        SetInsertValueStr(FieldValueEnd, str, Value32)
        SetInsertValueStr(FieldValueEnd, str, Value33)
        SetInsertValueStr(FieldValueEnd, str, Value34)
        SetInsertValueStr(FieldValueEnd, str, Value35)
        SetInsertValueStr(FieldValueEnd, str, Value36)
        SetInsertValueStr(FieldValueEnd, str, Value37)
        SetInsertValueStr(FieldValueEnd, str, Value38)
        SetInsertValueStr(FieldValueEnd, str, Value39)
        SetInsertValueStr(FieldValueEnd, str, Value40)


        str += " ) "
        'ModifyDate,Data, FieldCode,LogID,FarignID,InsertByUser ) VALUES  ( GETDATE(), N'" + DeleteTag(Data) + "'," + FieldCode + "," + LogID + ",N'" + FarignID + "',1)"
        Me.Adapter.SelectCommand.CommandText = str
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub




    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&





    Public Function GetUserGroups(ByVal UserCode As String, ByVal CenterCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  DT_Group.GroupCode,DT_Group.GroupName FROM         DT_CenterDefaultTable INNER JOIN     DT_Table ON DT_CenterDefaultTable.TableCode = DT_Table.TableCode INNER JOIN DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode WHERE (DT_CenterDefaultTable.CenterCode = " + CenterCode + ") union SELECT  DT_Group.GroupCode, DT_Group.GroupName  FROM DT_Table INNER JOIN   DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode  WHERE     (DT_Table.Default4Insert = 1) or (DT_Table.Default4Search = 1) or (DT_Table.Default4Select = 1)  union SELECT  DT_Group.GroupCode, DT_Group.GroupName FROM         DT_UserTable INNER JOIN        DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode INNER JOIN        DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode GROUP BY DT_UserTable.UserCode, DT_Group.GroupCode, DT_Group.GroupName  HAVING      (DT_UserTable.UserCode = " + UserCode + ")"
        Me.Adapter.Fill(Me.DataSet, "menu")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("menu")
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetGroupTables(ByVal UserCode As String, ByVal GroupCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT DT_Table.GroupCode, DT_Group.GroupName, DT_Table.TableDesc, DT_Table.TableCode, DT_CenterDefaultTable.Default4Insert, DT_CenterDefaultTable.Default4Search, DT_CenterDefaultTable.Default4Select  FROM         DT_CenterDefaultTable INNER JOIN  DT_Table ON DT_CenterDefaultTable.TableCode = DT_Table.TableCode INNER JOIN  DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode WHERE     (DT_Table.GroupCode = " + GroupCode + ")union "
        Me.Adapter.SelectCommand.CommandText += "SELECT DT_Group.GroupCode, DT_Group.GroupName, DT_Table.TableDesc,DT_Table.TableCode, DT_Table.Default4Insert, DT_Table.Default4Search, DT_Table.Default4Select FROM DT_UserTable INNER JOIN      DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode INNER JOIN     DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode GROUP BY DT_UserTable.UserCode, DT_Group.GroupCode, DT_Group.GroupName, DT_Table.TableDesc, DT_Table.TableCode, DT_Table.Default4Insert, DT_Table.Default4Search, DT_Table.Default4Select  HAVING      (DT_UserTable.UserCode = " + UserCode + ") AND (DT_Group.GroupCode = " + GroupCode + ") union SELECT   DT_Table.GroupCode, DT_Group.GroupName,   DT_Table.TableDesc, DT_Table.TableCode, DT_Table.Default4Insert, DT_Table.Default4Search, DT_Table.Default4Select  FROM         DT_Table INNER JOIN     DT_Group ON DT_Table.GroupCode = DT_Group.GroupCode  WHERE      (DT_Table.Default4Insert = 1) or (DT_Table.Default4Search = 1) or (DT_Table.Default4Select = 1) "
        Me.Adapter.Fill(Me.DataSet, "GroupTables")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("GroupTables")
        Return Nothing
        Me.DataSet.Dispose()
    End Function

    Public Function GetUserAllFields(ByVal TableCode As String, ByVal UserCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Field.*,DT_UserField.*  FROM     DT_Field INNER JOIN        DT_UserField ON DT_Field.FieldCode = DT_UserField.FieldCode  WHERE     (DT_Field.TableCode = " + TableCode + ") AND (DT_UserField.UserCode = " + UserCode + ") ORDER BY DT_Field.Sort"
        Me.Adapter.Fill(Me.DataSet, "Fields")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Fields")
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetUserFields4Search(ByVal TableCode As String, ByVal UserCode As String, ByVal PermissionType As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        If GetUserType(UserCode) = "admin" Or CBool(Me.SelectAll("DT_Setting").Rows(0).Item("SearchPermission4All")) = True Then
            Me.Adapter.SelectCommand.CommandText = "SELECT *  FROM  DT_Field WHERE (DT_Field.DataType <> N'image') AND (DT_Field.TableCode = " + TableCode + ") ORDER BY Sort"
        Else
            Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Field.*  FROM     DT_Field INNER JOIN        DT_UserField ON DT_Field.FieldCode = DT_UserField.FieldCode  WHERE   (DT_Field.DataType <> N'image') AND   (DT_Field.TableCode = " + TableCode + ") AND (DT_UserField.UserCode = " + UserCode + ") AND (DT_UserField.PermissionType='" + PermissionType + "' ) ORDER BY DT_Field.Sort"
        End If

        Me.Adapter.Fill(Me.DataSet, "Fields")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Fields")
        Return Nothing
        Me.DataSet.Dispose()
    End Function

    Public Function GetUserFields(ByVal TableCode As String, ByVal UserCode As String, ByVal PermissionType As String, Optional ByVal ViaCodeType As String = "No")
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        If GetUserType(UserCode) = "admin" Or CBool(Me.SelectAll("DT_Setting").Rows(0).Item("SearchPermission4All")) = True Then
            If ViaCodeType = "Yes" Then
                Me.Adapter.SelectCommand.CommandText = "SELECT *  FROM  DT_Field WHERE (DT_Field.TableCode = " + TableCode + ")  ORDER BY Sort"
            Else
                Me.Adapter.SelectCommand.CommandText = "SELECT *  FROM  DT_Field WHERE (DT_Field.TableCode = " + TableCode + ") and   (CodeType = N'NotCode') ORDER BY Sort"
            End If
        Else

            If ViaCodeType = "Yes" Then
                Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Field.*  FROM     DT_Field INNER JOIN        DT_UserField ON DT_Field.FieldCode = DT_UserField.FieldCode  WHERE     (DT_Field.TableCode = " + TableCode + ") AND (DT_UserField.UserCode = " + UserCode + ") AND (DT_UserField.PermissionType='" + PermissionType + "' )  ORDER BY DT_Field.Sort"
            Else
                Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Field.*  FROM     DT_Field INNER JOIN        DT_UserField ON DT_Field.FieldCode = DT_UserField.FieldCode  WHERE     (DT_Field.TableCode = " + TableCode + ") AND (DT_UserField.UserCode = " + UserCode + ") AND (DT_UserField.PermissionType='" + PermissionType + "' ) and   (CodeType = N'NotCode') ORDER BY DT_Field.Sort"
            End If


        End If

        Me.Adapter.Fill(Me.DataSet, "Fields")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Fields")
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetUserAllTables(ByVal UserCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Table.*,DT_UserTable.* FROM         DT_UserTable INNER JOIN   DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode  WHERE     (DT_UserTable.UserCode = " + UserCode + " ) ORDER BY Sort"
        Me.Adapter.Fill(Me.DataSet, "UserTable")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("UserTable")
        Return Nothing
        Me.DataSet.Dispose()
    End Function

    Public Function GetUserTables(ByVal UserCode As String, ByVal PermissionType As String, ByVal ParentCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        If GetUserType(UserCode) = "admin" Then
            'Me.Adapter.SelectCommand.CommandText = "SELECT *  FROM  DT_Table  ORDER BY Sort"
            Me.Adapter.SelectCommand.CommandText = String.Format(
            " SELECT     GroupCode AS TableCode, GroupName AS TableDesc, ParentCode AS GroupCode, - 1 AS Sort, '' AS [Default], 0 AS HasImage, 100 AS imageWidth,  " &
            "                      100 AS imageHeight, - 1 AS imageCode, HasIcon, IconCode, - 1 AS MasterTableCode,0 as Default4Insert, 0 AS Default4Search, 0 AS Default4Select,  " &
            "                      0 AS HasDetailSource, - 1 AS DetailSourceTableCode, 1 AS IsSystemTable,1 as IsGroup " &
            " FROM         DT_Group " &
            " where ParentCode={0}" &
            " UNION " &
            " SELECT     TableCode, TableDesc, GroupCode, Sort, [Default], HasImage, imageWidth, imageHeight, imageCode, HasIcon, IconCode, MasterTableCode,  " &
            "                      Default4Insert, Default4Search, Default4Select, HasDetailSource, DetailSourceTableCode, IsSystemTable,0 as IsGroup " &
            " FROM         DT_Table " &
            " where GroupCode={0}" &
            " ORDER BY Sort ", ParentCode)
        Else
            'Me.Adapter.SelectCommand.CommandText = "(SELECT   DT_Table.HasIcon,DT_Table.HasBackgrund ,DT_Table.TableDesc,DT_Table.TableCode, DT_Table.Sort FROM   DT_Table WHERE   ([Default] = 1) union SELECT      DT_Table.HasIcon,DT_Table.HasBackgrund,DT_Table.TableDesc, DT_Table.TableCode,DT_Table.Sort FROM         DT_UserTable INNER JOIN   DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode  WHERE     (DT_UserTable.UserCode = " + UserCode + " )AND( DT_UserTable.PermissionType='" + PermissionType + "'  ) )ORDER BY Sort"
            Dim InsertOrSearch As String

            If PermissionType = "Search" Then
                InsertOrSearch = "Search"
                ' Me.Adapter.SelectCommand.CommandText = "(SELECT   DT_Table.* FROM   DT_Table WHERE   (Default4Search = 1) union SELECT      DT_Table.* FROM         DT_UserTable INNER JOIN   DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode  WHERE     (DT_UserTable.UserCode = " + UserCode + " )AND( DT_UserTable.PermissionType='" + PermissionType + "'  ) )ORDER BY Sort"
            End If

            If PermissionType = "Modify" Then
                InsertOrSearch = "Insert"

            End If
            Me.Adapter.SelectCommand.CommandText = String.Format(
" SELECT     GroupCode AS TableCode, GroupName AS TableDesc, ParentCode AS GroupCode, - 1 AS Sort, '' AS [Default], 0 AS HasImage, 100 AS imageWidth,  " &
"                      100 AS imageHeight, - 1 AS imageCode, HasIcon, IconCode, - 1 AS MasterTableCode,0 as Default4Insert, 0 AS Default4Search, 0 AS Default4Select,  " &
"                      0 AS HasDetailSource, - 1 AS DetailSourceTableCode, 1 AS IsSystemTable,1 as IsGroup " &
" FROM         DT_Group " &
" where ParentCode={0}" &
" UNION " &
" SELECT     TableCode, TableDesc, GroupCode, Sort, [Default], HasImage, imageWidth, imageHeight, imageCode, HasIcon, IconCode, MasterTableCode,  " &
"                      Default4Insert, Default4Search, Default4Select, HasDetailSource, DetailSourceTableCode, IsSystemTable,0 as IsGroup " &
" FROM         DT_Table " &
    " where (GroupCode={0} and ([Default]=1 or Default4{1}=1))" &
" UNION " &
" SELECT     DT_Table.TableCode, TableDesc, GroupCode, Sort, [Default], HasImage, imageWidth, imageHeight, imageCode, HasIcon, IconCode, MasterTableCode,  " &
"                      Default4Insert, Default4Search, Default4Select, HasDetailSource, DetailSourceTableCode, IsSystemTable,0 as IsGroup " &
" FROM          DT_UserTable INNER JOIN   DT_Table ON DT_UserTable.TableCode = DT_Table.TableCode  WHERE     (DT_Table.GroupCode={0}) and (DT_UserTable.UserCode = " + UserCode + " )AND( DT_UserTable.PermissionType='" + PermissionType + "'  ) " &
" ORDER BY Sort ", ParentCode, InsertOrSearch)


        End If
        Me.Adapter.Fill(Me.DataSet, "UserTable")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("UserTable")
        Return Nothing
        Me.DataSet.Dispose()
    End Function

    Public Function GetLogsFromTableName(ByVal TableName As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT DISTINCT LogID FROM " + TableName + " WHERE     (Deleted = 0)"
        Me.Adapter.Fill(Me.DataSet, "LogTable")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("LogTable")
        Me.DataSet.Dispose()
        Return Nothing

    End Function

    Public Sub InsertKartable(ByVal SenderUserCode As String, ByVal ReciverUserCode As String, ByVal LogID As String, ByVal Description As String, ByVal tabaghe As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()

        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "INSERT INTO DT_Kartabl  (SenderUserCode, ReciverUserCode, LogID,Description,tabaghe) VALUES (" + SenderUserCode + "," + ReciverUserCode + "," + LogID + ",N'" + Description + "',N'" + tabaghe + "')"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()

    End Sub
    Public Sub InsertUserTablePermission(ByVal UserCode As String, ByVal TableCode As String, ByVal PermissionType As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "INSERT INTO DT_UserTable   (UserCode, TableCode, PermissionType)  VALUES(" + UserCode + "," + TableCode + ",N'" + PermissionType + "')"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub DeletUserTablePermission(ByVal UserTableCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "DELETE FROM DT_UserTable  WHERE   (UserTableCode = " + UserTableCode + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub Log(ByVal ShamsiDate As String, ByVal UserCode As String, ByVal TableCode As String, ByVal TableAutoNumber As String, ByVal GroupAutoNumber As String, ByVal GroupCode As String, ByVal FileCode As String, ByVal EditLogID As String, ByVal MasterLogID As String, ByVal CenterCode As String)

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "INSERT INTO DT_Log ( ModifyDate, ShamsiDate, UserCode,TableCode,TableAutoNumber,GroupAutoNumber,GroupCode,FileCode,EditLogID,MasterLogID,CenterCode) VALUES     (GETDATE(),N'" + ShamsiDate + "'," + UserCode + "," + TableCode + "," + TableAutoNumber + "," + GroupAutoNumber + "," + GroupCode + "," + FileCode + "," + EditLogID + "," + MasterLogID + "," + CenterCode + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub DeleteLog(ByVal LogID As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    DT_Log SET   Deleted = 1  WHERE     (LogID = " + LogID + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Sub UpdateUser(ByVal UserName As String, ByVal Password As String, ByVal Name As String, ByVal Title As String, ByVal Rool As String, ByVal UserCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE DT_User SET UserName =N'" + UserName + "', Password =N'" + Password + "', Name =N'" + Name + "', Title =N'" + Title + "', Rool =N'" + Rool + "' WHERE     (UserCode =" + UserCode + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    'Public Function GetAdvByAdvCode(ByVal AdvCode As String) As DataRow
    '    If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
    '    Me.DataSet = New DataSet
    '    Me.Adapter.SelectCommand.CommandType = CommandType.Text
    '    Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  Adv where (AdvCode=" + AdvCode + ")"
    '    Me.Adapter.Fill(Me.DataSet)
    '    If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    '    Return Me.DataSet.Tables(0).Rows(0)

    '    Me.DataSet.Dispose()
    'End Function
    'Public Sub UpdateAdvWithImage(ByVal AdvCode As String, ByVal Title As String, ByVal Subject As String, ByVal Text As String, ByVal Image As Byte(), ByVal Type As String)
    '    If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
    '    Adapter.SelectCommand.Parameters.Clear()
    '    Dim sqlparams(5) As SqlParameter
    '    sqlparams(0) = New SqlParameter("@AdvCode", AdvCode)
    '    sqlparams(0).SqlDbType = Data.SqlDbType.Decimal
    '    sqlparams(1) = New SqlParameter("@Title", Title)
    '    sqlparams(1).SqlDbType = Data.SqlDbType.NVarChar
    '    sqlparams(2) = New SqlParameter("@Subject", Subject)
    '    sqlparams(2).SqlDbType = Data.SqlDbType.NVarChar
    '    sqlparams(3) = New SqlParameter("@Text", Text)
    '    sqlparams(3).SqlDbType = Data.SqlDbType.NText
    '    sqlparams(4) = New SqlParameter("@Image", Image)
    '    sqlparams(4).SqlDbType = Data.SqlDbType.Image
    '    sqlparams(5) = New SqlParameter("@Type", Type)
    '    sqlparams(5).SqlDbType = Data.SqlDbType.NVarChar
    '    Dim i As Integer = 0
    '    Dim x As SqlParameter
    '    For Each x In sqlparams
    '        Adapter.SelectCommand.Parameters.Add(sqlparams(i))
    '        i += 1
    '    Next
    '    Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
    '    Adapter.SelectCommand.CommandText = "UpdateAdvWithImage"
    '    Adapter.SelectCommand.ExecuteNonQuery()
    '    If Me.Connection.State = ConnectionState.Open Then Me.Connection.Close()
    'End Sub
    'Public Sub UpdateAdvWithoutImage(ByVal AdvCode As String, ByVal Title As String, ByVal Subject As String, ByVal Text As String)
    '    If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
    '    Me.Adapter.SelectCommand.CommandType = CommandType.Text
    '    Me.Adapter.SelectCommand.CommandText = "UPDATE    Adv SET  Title = N'" + Title + "', Subject = N'" + Subject + "', Text = N'" + Text + "', InsertDate ='" + Today.ToString("d") + "', HasImage = 0 WHERE     (AdvCode = " + AdvCode + ")"
    '    Me.Adapter.SelectCommand.ExecuteNonQuery()
    '    If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    'End Sub
    Public Function GetMaxPlusTableAutoNumber(ByVal TableCode As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  ISNULL(MAX(TableAutoNumber), 0)+1 AS d  FROM   DT_Log  WHERE  (TableCode =  " + TableCode + ") and DT_Log.deleted=0 "
        Me.Adapter.Fill(Me.DataSet, "MaxLogTableID")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("MaxLogTableID").Rows(0).Item(0).ToString
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetMaxPlusGroupAutoNumber(ByVal GroupCode As String) As String
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  ISNULL(MAX(GroupAutoNumber), 0)+1 AS d  FROM    DT_Log  WHERE     (GroupCode = " + GroupCode + ")"
        Me.Adapter.Fill(Me.DataSet, "MaxLogTableID")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("MaxLogTableID").Rows(0).Item(0).ToString
        Return Nothing
        Me.DataSet.Dispose()
    End Function
    Public Function GetTableByTableCode(ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     TableCode, GroupCode, TableDesc FROM         DT_Table WHERE     (TableCode = " + TableCode + ")"
        Me.Adapter.Fill(Me.DataSet, "Table")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Table")
        Me.DataSet.Dispose()

    End Function
    Public Function GetGruopByTableCode(ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Group.GroupCode, DT_Group.GroupName  FROM         DT_Group INNER JOIN       DT_Table ON DT_Group.GroupCode = DT_Table.GroupCode  WHERE     (DT_Table.TableCode = " + TableCode + ")"
        Me.Adapter.Fill(Me.DataSet, "Group")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Group")
        Me.DataSet.Dispose()

    End Function
    Public Function GetLastActionsbyUserCode(ByVal UserCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT    df.radif, df.RootLogID, DT_Log_1.LogID, DT_Log_1.ModifyDate, DT_Log_1.ShamsiDate, DT_Log_1.UserCode, DT_Log_1.TableCode, DT_Log_1.GroupCode,  " &
 "                     DT_Log_1.TableAutoNumber, DT_Log_1.GroupAutoNumber, DT_Log_1.Deleted, DT_Log_1.FileCode, DT_Log_1.CenterCode, DT_Log_1.EditLogId,  " &
  "                    DT_Log_1.MasterLogId, DT_Log_1.LogID2, DT_Table.TableCode AS Expr1, DT_Table.TableDesc, DT_Table.GroupCode AS Expr2, DT_Table.Sort,  " &
   "                   DT_Table.TableName, DT_Table.[Default], DT_Table.HasImage, DT_Table.imageWidth, DT_Table.imageHeight, DT_Table.imageCode,  " &
    "                  DT_Table.HasIcon, DT_Table.IconCode, DT_Table.MasterTableCode, DT_Table.Default4Insert, DT_Table.Default4Search, DT_Table.Default4Select,  " &
     "                 DT_Table.HasDetailSource, DT_Table.DetailSourceTableCode, DT_Table.IsSystemTable, DT_User.UserCode AS Expr3, DT_User.UserName,  " &
      "                DT_User.Password, DT_User.FirstName, DT_User.Name, DT_User.Title, DT_User.UserPage, DT_User.UserType, DT_User.ParentUserCode,  " &
       "               DT_User.Rool, DT_User.SendToAll, DT_User.CenterCode AS Expr4, DT_User.GiveFromAll, DT_User.HasSignature, DT_User.Signature,  " &
        "              CONVERT(char(5), DT_Log_1.ModifyDate, 14) AS ModifyTime, DT_User.Title + ' ' + DT_User.Name AS FullName " &
"FROM         DT_Table INNER JOIN " &
 "                     DT_Log AS DT_Log_1 ON DT_Table.TableCode = DT_Log_1.TableCode INNER JOIN " &
  "                    DT_User ON DT_Log_1.UserCode = DT_User.UserCode INNER JOIN " &
   "                       (SELECT     TOP (10) dbo.GetParentLogID(LogID) AS RootLogID, row_number() over(order by logid) as radif " &
    "                         FROM         DT_Log " &
     "                        WHERE     (UserCode = " + UserCode + " and Deleted=0 ) " &
      "                       ORDER BY LogID DESC) AS df ON DT_Log_1.LogID = df.RootLogID order by radif  desc "
        Me.Adapter.Fill(Me.DataSet, "LastActions")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("LastActions")
        Me.DataSet.Dispose()

    End Function
    Public Function GetUsersDownLevel1AndUp(ByVal UserCode As String, ByVal CenterCode As String, ByVal Dabir As Boolean) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT Name, Name+' : '+Title + ' ' + Name+' - '+Rool AS NameRool,1 as Parent, *  FROM  DT_User where(GiveFromAll = 1) and (CenterCode=" + CenterCode + ") union SELECT     Name, Name+' : '+Title + ' ' + Name+' - '+Rool AS NameRool,1 as Parent, *  FROM  DT_User where(ParentUserCode = " + UserCode + ")and (CenterCode=" + CenterCode + ") union SELECT  DT_User_1.Name, DT_User_1.Name+' : '+DT_User_1.Title + ' ' + DT_User_1.Name+' - '+ DT_User_1.Rool  AS FullName,0 as Parent,  DT_User_1.* FROM         DT_User INNER JOIN   DT_User DT_User_1 ON DT_User.ParentUserCode = DT_User_1.UserCode WHERE     (DT_User.UserCode = " + UserCode + ") and (DT_User.CenterCode=" + CenterCode + ")"
        If Dabir = True Then
            Me.Adapter.SelectCommand.CommandText += " union select SELECT      Name+' : '+Title + ' ' + Name+' '+Rool AS NameRool, *  FROM  DT_User where (UserType=Dabir)"
        End If
        Me.Adapter.SelectCommand.CommandText += " order by  Parent,Name"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing

    End Function
    Public Function GetAllUsers(ByVal CenterCode As String, ByVal Dabir As Boolean) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT     Name+' : '+Title + ' ' + Name+' '+Rool AS NameRool, UserCode, UserName, Password, FirstName, Name, Title, UserPage, UserType, ParentUserCode, Rool, SendToAll, CenterCode, GiveFromAll  FROM  DT_User where (CenterCode=" + CenterCode + ")"
        If Dabir = True Then
            Me.Adapter.SelectCommand.CommandText += " union  SELECT     Name+' : '+ Title + ' ' + Name+' '+Rool AS NameRool, UserCode, UserName, Password, FirstName, Name, Title, UserPage, UserType, ParentUserCode, Rool, SendToAll, CenterCode, GiveFromAll  FROM  DT_User where (UserType=N'Dabir')"
        End If
        Me.Adapter.SelectCommand.CommandText += " order by Name"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing

    End Function
    Public Function GetFieldXY(ByVal ReportCode As String, ByVal UserCode As String, ByVal FieldCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT     flipv,x, y,width,height, FieldCode FROM  DT_PrintConfig WHERE     (ReportCode = " + ReportCode + ") AND (UserCode = " + UserCode + ") AND (FieldCode = " + FieldCode + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        'If Me.DataSet.Tables(0).Rows.Count > 0 Then
        Return Me.DataSet.Tables(0)
        'End If
        Me.DataSet.Dispose()
        Return Nothing

    End Function
    Public Sub DeleteFromKartabl(ByVal KartablId As String, ByVal ResponceLogID As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " UPDATE DT_Kartabl SET  Deleted = 1 ,  ResponceLogID = " + ResponceLogID + " WHERE (KartablID = " + KartablId + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
    Public Function GetUserKartabl(ByVal UserCode As String, Optional ByVal tabaghe As String = "0") As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        If tabaghe = "0" Then
            Me.Adapter.SelectCommand.CommandText = " SELECT     DT_User.Name AS Fullname, DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_Kartabl.*, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Kartabl INNER JOIN    DT_Log ON DT_Kartabl.LogID = DT_Log.LogID INNER JOIN   DT_User ON DT_Kartabl.SenderUserCode = DT_User.UserCode WHERE     (DT_Kartabl.ReciverUserCode = " + UserCode + ") AND (DT_Log.Deleted = 0)AND (DT_Kartabl.Deleted = 0)  ORDER BY DT_Log.ModifyDate DESC"
        Else
            Me.Adapter.SelectCommand.CommandText = " SELECT     DT_User.Name AS Fullname, DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_Kartabl.*, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Kartabl INNER JOIN    DT_Log ON DT_Kartabl.LogID = DT_Log.LogID INNER JOIN   DT_User ON DT_Kartabl.SenderUserCode = DT_User.UserCode WHERE     (DT_Kartabl.ReciverUserCode = " + UserCode + ") AND (DT_Log.Deleted = 0)AND (DT_Kartabl.Deleted = 0) and (DT_Kartabl.tabaghe = " + tabaghe + ") ORDER BY DT_Log.ModifyDate DESC"
        End If
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetFileState(ByVal FileCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT     DT_User.Name  FROM         DT_Kartabl INNER JOIN     DT_Log ON DT_Kartabl.LogID = DT_Log.LogID INNER JOIN   DT_User ON DT_Kartabl.ReciverUserCode = DT_User.UserCode  WHERE     (DT_Kartabl.Deleted = 0) AND (DT_Log.FileCode = " + FileCode + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    '
    Public Function GetSameLevelUsers(ByVal UserCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT     DT_User_1.Name+' : '+ DT_User_1.Title + ' ' + DT_User_1.Name+' '+DT_User_1.Rool AS NameRool,DT_User_1.UserCode, DT_User_1.Name  FROM         DT_User INNER JOIN   DT_User DT_User_1 ON DT_User.ParentUserCode = DT_User_1.ParentUserCode  WHERE     (DT_User.UserCode = " + UserCode + ") AND (DT_User_1.UserCode <> " + UserCode + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function

    Public Function GetPrintConfigByUserCode(ByVal UserCode As String, ByVal ReportCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT  DT_Field.FieldDesc, DT_PrintConfig.ConfigID, DT_PrintConfig.flipv, DT_PrintConfig.x, DT_PrintConfig.y, DT_PrintConfig.width, DT_PrintConfig.height FROM DT_PrintConfig INNER JOIN    DT_Field ON DT_PrintConfig.FieldCode = DT_Field.FieldCode  WHERE (DT_PrintConfig.ReportCode = " + ReportCode + ") AND (DT_PrintConfig.UserCode = " + UserCode + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Sub InsertPrintConfig(ByVal ReportCode As String, ByVal UserCode As String, ByVal FieldCode As String, ByVal x As String, ByVal y As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " INSERT INTO DT_PrintConfig    (ReportCode, UserCode, FieldCode, x, y) VALUES     (" + ReportCode + "," + UserCode + "," + FieldCode + "," + x + "," + y + ")"
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    'INSERT INTO DT_PrintConfig    (ReportCode, UserCode, FieldCode, x, y) VALUES     ("+ReportCode+","+ UserCode+","+ FieldCode+","+ x+","+ y)
    Public Function GetLogByFieldCode(ByVal FieldCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text

        Me.Adapter.SelectCommand.CommandText = " SELECT     *, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Title + ' ' + DT_User.Name AS FullName, DT_Table.TableDesc  FROM         DT_Log INNER JOIN     DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE     (DT_Log.FileCode = " + FieldCode + " and DT_Log.Deleted=0)"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByTableAutoNumber(ByVal TableAutoNumber As String, ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT   DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName, DT_Table.TableDesc, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Log INNER JOIN  DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE   (DT_Log.TableAutoNumber = " + TableAutoNumber + ")  AND(DT_Log.TableCode=" + TableCode + ") AND (DT_Log.Deleted = 0)"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByGroupAutoNumber(ByVal GroupAutoNumber As String, ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT   DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName, DT_Table.TableDesc, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Log INNER JOIN  DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE   (DT_Log.GroupAutoNumber = " + GroupAutoNumber + ") AND(DT_Log.TableCode=" + TableCode + ") AND (DT_Log.Deleted = 0)"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByLogID(ByVal LogID As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT   DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName, DT_Table.TableDesc, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Log INNER JOIN  DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE   (DT_Log.LogID = " + LogID + ") AND (DT_Log.Deleted = 0)"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByLogIDViaDeleted(ByVal LogID As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = " SELECT   DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName, DT_Table.TableDesc, 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url  FROM   DT_Log INNER JOIN  DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE   (DT_Log.LogID = " + LogID + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByDataAndFieldCodeInKartable(ByVal TableCode As String, ByVal TableName As String, ByVal Data As String, ByVal FieldCode As String, ByVal CenterCode As String, ByVal SearchType As String, ByVal UserCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text

        Select Case SearchType
            Case "Normal"
                Me.Adapter.SelectCommand.CommandText = "SELECT    DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName,DT_Table.TableCode, DT_Table.TableDesc , 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url" &
                     " FROM         DT_Log INNER JOIN      DT_Log DT_Log_1 ON DT_Log.FileCode = DT_Log_1.FileCode INNER JOIN              DT_Table ON DT_Log.TableCode = DT_Table.TableCode INNER JOIN DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN  " + TableName + " ON DT_Log.LogID = " + TableName + ".LogID  " &
                     " WHERE     (DT_Log.TableCode = " + TableCode + ") AND (DT_Log_1.UserCode = " + UserCode + ") AND (DT_Log_1.Deleted = 0) AND (DT_Log.Deleted = 0) AND     (DT_Log_1.CenterCode =  " + CenterCode + ") AND (DT_Log.CenterCode = " + CenterCode + ") AND (" + TableName + ".Deleted = 0) AND (" + TableName + ".Data LIKE N'%" + Data + "%') AND (" + TableName + ".FieldCode = " + FieldCode + ")"

            Case "Exact"
                Me.Adapter.SelectCommand.CommandText = "SELECT    DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName,DT_Table.TableCode, DT_Table.TableDesc , 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url" &
                     " FROM         DT_Log INNER JOIN      DT_Log DT_Log_1 ON DT_Log.FileCode = DT_Log_1.FileCode INNER JOIN              DT_Table ON DT_Log.TableCode = DT_Table.TableCode INNER JOIN DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN  " + TableName + " ON DT_Log.LogID = " + TableName + ".LogID  " &
                     " WHERE     (DT_Log.TableCode = " + TableCode + ") AND (DT_Log_1.UserCode = " + UserCode + ") AND (DT_Log_1.Deleted = 0) AND (DT_Log.Deleted = 0) AND     (DT_Log_1.CenterCode =  " + CenterCode + ") AND (DT_Log.CenterCode = " + CenterCode + ") AND (" + TableName + ".Deleted = 0) AND (" + TableName + ".Data =N'" + Data + "') AND (" + TableName + ".FieldCode = " + FieldCode + ")"
        End Select
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetLogByDataAndFieldCode(ByVal TableName As String, ByVal Data As String, ByVal FieldCode As String, ByVal CenterCode As String, ByVal SearchType As String, ByVal UserCode As String) As DataTable

        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text

        Select Case SearchType
            Case "Normal"
                Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName,DT_Table.TableCode, DT_Table.TableDesc , 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url" &
                  " FROM         DT_Log INNER JOIN    " + TableName + " ON DT_Log.LogID = " + TableName + ".LogID INNER JOIN   DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN  DT_Table ON DT_Log.TableCode = DT_Table.TableCode " &
                  " WHERE     (" + TableName + ".Data LIKE N'%" + Data + "%') AND (" + TableName + ".FieldCode = " + FieldCode + ")  AND (DT_Log.Deleted= 0 ) AND (" + TableName + ".Deleted = 0) AND (DT_Log.CenterCode=" + CenterCode + ")"
            Case "Exact"
                Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Log.*, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Name AS FullName,DT_Table.TableCode, DT_Table.TableDesc , 'FileActions.aspx?FileCode=' + CAST(DT_Log.FileCode AS nvarchar) AS Url" &
                  " FROM         DT_Log INNER JOIN    " + TableName + " ON DT_Log.LogID = " + TableName + ".LogID INNER JOIN   DT_User ON DT_Log.UserCode = DT_User.UserCode INNER JOIN  DT_Table ON DT_Log.TableCode = DT_Table.TableCode " &
                  " WHERE     (" + TableName + ".Data =N'" + Data + "') AND (" + TableName + ".FieldCode = " + FieldCode + ")  AND (DT_Log.Deleted= 0 ) AND (" + TableName + ".Deleted = 0) AND (DT_Log.CenterCode=" + CenterCode + ")"

        End Select
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function
    Public Function GetServerDate() As Date
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT GETDATE() AS ServerDate"
        Me.Adapter.Fill(Me.DataSet, "Date")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("Date").Rows(0).Item("ServerDate").ToString
        Me.DataSet.Dispose()
    End Function
    Public Sub UpdateMasterLogID4Transaction(ByVal TableCode As String, ByVal UserCode As String, ByVal LogID As String)
        Me.ExecCommand("alter VIEW dbo.Updates as  ( SELECT DT_Log.MasterLogID  FROM  DT_Log INNER JOIN DT_Table ON DT_Log.TableCode = DT_Table.TableCode WHERE (DT_Table.MasterTableCode = " + TableCode + ") AND (DT_Log.UserCode = " + UserCode + ") AND (DT_Log.Deleted = 0) AND (DT_Log.MasterLogID <-1 ))")
        Me.ExecCommand("UPDATE Updates SET   MasterLogID = " + LogID)
    End Sub

    Public Function GetDetails(ByVal TableDesc As String, ByVal UserCode As String, ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT  [" + TableDesc + "].*  FROM   DT_Log INNER JOIN   [" + TableDesc + "] ON DT_Log.LogID = [" + TableDesc + "].[شناسه]  WHERE     (DT_Log.MasterLogID <-1) AND (DT_Log.Deleted = 0) AND (DT_Log.TableCode = " + TableCode + ") AND (DT_Log.UserCode = " + UserCode + ")"
        Me.Adapter.Fill(Me.DataSet)
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables(0)
        Me.DataSet.Dispose()
        Return Nothing
    End Function

    Public Function GetLastActions() As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT TOP 20 *, DT_Table.TableDesc, CONVERT(char(5), DT_Log.ModifyDate, 14) AS ModifyTime, DT_User.Title + ' ' + DT_User.Name AS FullName FROM DT_Log INNER JOIN    DT_Table ON DT_Log.TableCode = DT_Table.TableCode INNER JOIN DT_User ON DT_Log.UserCode = DT_User.UserCode  WHERE (DT_Log.Deleted = 0) ORDER BY LogID DESC"
        Me.Adapter.Fill(Me.DataSet, "LastActions")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("LastActions")
        Me.DataSet.Dispose()

    End Function

    Public Function GetCodeFields(ByVal TableCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM DT_Field WHERE (TableCode = " + TableCode + ") AND (CodeType <> N'notcode')"
        Me.Adapter.Fill(Me.DataSet, "CodeFields")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("CodeFields")
        Me.DataSet.Dispose()

    End Function
    Public Function Select1LevelDownUsers(ByVal UserCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT Name+' : '+Title + ' ' + Name+' '+Rool AS NameRool,* FROM  DT_User where (ParentUserCode=N'" + UserCode + "')"
        Me.Adapter.Fill(Me.DataSet, "All")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("All")
        Me.DataSet.Dispose()
    End Function

    Public Function GetServerShamsiDateTodayString() As String
        Dim ServerDate As Date
        Dim DateStr As String = "امروز "
        ServerDate = GetServerDate()
        Dim a As BijanComponents.DateTimeFarsi
        a = BijanComponents.ShamsiDate.GetShamsiDateValue(ServerDate)
        Select Case a.Day
            Case 1
                DateStr += "اول"
            Case 2
                DateStr += "دوم"
            Case 3
                DateStr += "سوم"
            Case 4
                DateStr += "چهارم"
            Case 5
                DateStr += "پنجم"
            Case 6
                DateStr += "ششم"
            Case 7
                DateStr += "هفتم"
            Case 8
                DateStr += "هشتم"
            Case 9
                DateStr += "نهم"
            Case 10
                DateStr += "دهم"
            Case 11
                DateStr += "یازدهم"
            Case 12
                DateStr += "دوازدهم"
            Case 13
                DateStr += "سیزدهم"
            Case 14
                DateStr += "چهاردهم"
            Case 15
                DateStr += "پانزدهم"
            Case 16
                DateStr += "شانزدهم"
            Case 17
                DateStr += "هفدهم"
            Case 18
                DateStr += "هجدهم"
            Case 19
                DateStr += "نوزدهم"
            Case 20
                DateStr += "بیستم"
            Case 21
                DateStr += "بیست ویکم"
            Case 22
                DateStr += "بیست و دوم"
            Case 23
                DateStr += "بیست و سوم"
            Case 24
                DateStr += "بیست و چهارم"
            Case 25
                DateStr += "بیست و پنجم"
            Case 26
                DateStr += "بیست و ششم"
            Case 27
                DateStr += "بیست و هفتم"
            Case 28
                DateStr += "بیست و هشتم"
            Case 29
                DateStr += "بیست و نهم"
            Case 30
                DateStr += "سی ام"
            Case 31
                DateStr += "سی و یکم"
        End Select
        Select Case a.Month
            Case 1
                DateStr += " فروردین ماه  "
            Case 2
                DateStr += " اردیبهشت ماه  "
            Case 3
                DateStr += " خرداد ماه  "
            Case 4
                DateStr += " تیر ماه  "
            Case 5
                DateStr += " مرداد ماه  "
            Case 6
                DateStr += " شهریور ماه  "
            Case 7
                DateStr += " مهر ماه  "
            Case 8
                DateStr += " آبان ماه  "
            Case 9
                DateStr += " آذر ماه  "
            Case 10
                DateStr += " دی ماه  "
            Case 11
                DateStr += " بهمن ماه  "
            Case 12
                DateStr += " اسفند ماه  "
        End Select
        Select Case a.Year
            Case 1386
                DateStr += "هشتاد و شش"
            Case 1387
                DateStr += "هشتاد و هفت"
            Case 1388
                DateStr += "هشتاد و هشت"
            Case 1389
                DateStr += "هشتاد و نه"
            Case 1390
                DateStr += "نود"
            Case 1391
                DateStr += "نود و یک"
            Case 1392
                DateStr += "نود و دو"
            Case 1393
                DateStr += "نود و سه"
            Case 1394
                DateStr += "نود و چهار"
            Case 1395
                DateStr += "نود و پنج"
            Case 1396
                DateStr += "نود و شش"
            Case 1397
                DateStr += "نود و هفت"
            Case 1398
                DateStr += "نود و هشت"
            Case 1399
                DateStr += "نود و نه"
        End Select
        DateStr += " " + BijanComponents.ShamsiDate.GetShamsiDate(ServerDate)
        Return DateStr
    End Function

    Public Function GetAllMyWorks(ByVal UserCode As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT DT_Table.TableDesc, COUNT(DT_Log.TableCode) as Qty FROM   DT_Log INNER JOIN   DT_Table ON DT_Log.TableCode = DT_Table.TableCode WHERE     (DT_Log.UserCode = " + UserCode + ")  GROUP BY DT_Table.TableDesc"
        Me.Adapter.Fill(Me.DataSet, "AllMyWorks")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("AllMyWorks")
        Me.DataSet.Dispose()

    End Function
    Public Function GetMyWorksByDate(ByVal UserCode As String, ByVal BefoureDate As String) As DataTable
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.DataSet = New DataSet
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "SELECT     DT_Table.TableDesc, COUNT(DT_Log.TableCode) AS Qty  FROM         DT_Log INNER JOIN   DT_Table ON DT_Log.TableCode = DT_Table.TableCode  WHERE     (DT_Log.UserCode = " + UserCode + ") AND (DT_Log.ModifyDate < GETDATE()) AND (DT_Log.ModifyDate > GETDATE() - " + BefoureDate + ") GROUP BY DT_Table.TableDesc"
        Me.Adapter.Fill(Me.DataSet, "AllMyWorks")
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
        Return Me.DataSet.Tables("AllMyWorks")
        Me.DataSet.Dispose()

    End Function

    Public Function GetFieldsAndDataByLogId(ByVal LogID As String, ByVal userCode As String) As DataTable


        Dim TableCode As String
        Dim TableDesc As String
        TableCode = Me.SelectAllwhere("DT_Log", "LogID", LogID).Rows(0).Item("TableCode").ToString

        With Me.SelectAllwhere("DT_Table", "TableCode", TableCode).Rows(0)
            TableDesc = .Item("TableDesc")
        End With

        Dim tblData As Data.DataTable
        tblData = SelectAllwhere(TableDesc, "شناسه", LogID)

        Dim DataField As New DataTable

        DataField = Me.SelectAllwhere("DT_Field", "TableCode", TableCode)

        Dim colData As New Data.DataColumn("Data")
        Dim colFarign As New Data.DataColumn("FarignID")

        DataField.Columns.Add(colData)
        DataField.Columns.Add(colFarign)
        Dim FieldDesc As String

        For i As Integer = 0 To DataField.Rows.Count - 1
            FieldDesc = DataField.Rows(i).Item("FieldDesc")
            DataField.Rows(i).Item("Data") = tblData.Rows(0).Item(FieldDesc)
            If DataField.Rows(i).Item("IsFarign") Then
                DataField.Rows(i).Item("FarignID") = tblData.Rows(0).Item("مشخصه " + FieldDesc)

            End If
        Next


        Return DataField
    End Function
    Public Sub DeleteData(ByVal TableDesc As String, ByVal LogID As String, ByVal UserCode As String)
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = String.Format(
        " INSERT INTO [{0}_Deleted] " &
        " SELECT     *,{1} " &
        " FROM         [{0}] " &
        " WHERE     ([شناسه] = {2}) ", TableDesc, UserCode, LogID)
        Me.Adapter.SelectCommand.ExecuteNonQuery()
        DeleteFromTable(TableDesc, "شناسه", LogID)

        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub

    Public Sub AddToField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String, ByVal ConditionFieldName1 As String, ByVal ConditionFieldValue1 As String, Optional ByVal ConditionType1 As String = "", Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "", Optional ByVal ConditionType2 As String = "", Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "", Optional ByVal ConditionType3 As String = "")
        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
        Me.Adapter.SelectCommand.CommandType = CommandType.Text
        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " =isnull(" + SetFieldName + ",0)+" + SetFieldValue

        If ConditionFieldName1 <> "" Then
            If ConditionType1 = "" Then
                Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "')"
            Else
                If ConditionType1 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N'" + ConditionFieldValue1 + "')"
                End If
            End If
        End If

        If ConditionFieldName2 <> "" Then
            If ConditionType2 = "" Then
                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " = N'" + ConditionFieldValue2 + "')"
            Else
                If ConditionType2 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " < " + ConditionFieldValue2 + ")"
                End If
            End If
        End If

        If ConditionFieldName3 <> "" Then
            If ConditionType3 = "" Then
                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " = N'" + ConditionFieldValue3 + "')"
            Else
                If ConditionType3 = "<" Then
                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " < " + ConditionFieldValue3 + ")"
                End If
            End If
        End If

        Me.Adapter.SelectCommand.ExecuteNonQuery()
        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
    End Sub
End Class

'Public Class DataBaseLayer

'    Public Connection As New SqlClient.SqlConnection
'    Public Adapter As New SqlClient.SqlDataAdapter
'    Public DataReader As SqlClient.SqlDataReader
'    Public DataSet As DataSet
'    Public DataTable As DataTable

'    Private _ConnectionString As String

'    Public Property ConnectionString() As String
'        Get
'            Return _ConnectionString
'        End Get
'        Set(ByVal value As String)
'            _ConnectionString = value
'        End Set
'    End Property
'    '"Public Property ThisPrj() As ThisPrj
'    '"    Get
'    '"        Return _ThisPrj
'    '"    End Get
'    '"    Set(ByVal value As ThisPrj)
'    '"        Me._ThisPrj = value
'    '"    End Set
'    '"End Property
'    Public Sub New(ByVal Cnn As String)
'        Me.Connection.ConnectionString = Cnn
'        Me._ConnectionString = Cnn
'        'Me._ThisPrj = New ThisPrj(Cnn)
'        Me.Adapter.SelectCommand = New SqlClient.SqlCommand
'        Me.Adapter.SelectCommand.Connection = Me.Connection
'        Me.Adapter.UpdateCommand = New SqlClient.SqlCommand
'        Me.Adapter.UpdateCommand.Connection = Me.Connection
'    End Sub



'    Public Sub DeleteFromTable(ByVal TableName As String, ByVal FieldName1 As String, ByVal FieldValue1 As String, Optional ByVal FieldName2 As String = "", Optional ByVal FieldValue2 As String = "", Optional ByVal FieldName3 As String = "", Optional ByVal FieldValue3 As String = "")
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "DELETE FROM [" + TableName + "] WHERE     ([" + FieldName1 + "] = N"" + FieldValue1 + "")"
'        If FieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and ([" + FieldName2 + "] = N"" + FieldValue2 + "")"
'        End If
'        If FieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and ([" + FieldName3 + "] = N"" + FieldValue3 + "")"
'        End If

'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()

'    End Sub
'    Public Sub ExecCommand(ByVal CommandText As String)
'        Try
'            Dim viewCommand As New SqlCommand(CommandText, Connection)
'            Connection.Open()
'            viewCommand.ExecuteNonQuery()
'            Connection.Close()

'        Catch ex As Exception
'            MsgBox(ex.Message)
'            Connection.Close()
'        End Try

'    End Sub
'    Public Function SelectFromCommand(ByVal SelectCommand As String, Optional ByVal TableName As String = "Select1") As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataTable = New DataTable(TableName)
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = SelectCommand
'        Me.Adapter.Fill(Me.DataTable)
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataTable

'    End Function


'    Public Function SelectAllwhereLike(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "] LIKE N"%" + FieldValue + "%") order by [" + FieldName + "]"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal OrderBy As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") ORDER BY " + OrderBy + " Desc"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal OrderBy As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") and  ([" + FieldName2 + "]=N"" + FieldValue2 + "") ORDER BY " + OrderBy + " Desc"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhereOrderByDesc(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String, ByVal OrderBy As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") and  ([" + FieldName2 + "]=N"" + FieldValue2 + "") and  ([" + FieldName3 + "]=N"" + FieldValue3 + "")  ORDER BY " + OrderBy + " Desc"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhereOrderBy(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal OrderBy As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") ORDER BY " + OrderBy
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhere(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhereOrderBy(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal OrderBy As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "") ORDER BY " + OrderBy
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectTopwhere(ByVal topCount As String, ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT top(" + topCount + ") * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function

'    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "")  AND ([" + FieldName3 + "]=N"" + FieldValue3 + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String, ByVal FieldName4 As String, ByVal FieldValue4 As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "")  AND ([" + FieldName3 + "]=N"" + FieldValue3 + "")  AND ([" + FieldName4 + "]=N"" + FieldValue4 + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectAllwhere(ByVal TableName As String, ByVal FieldName As String, ByVal FieldValue As String, ByVal FieldName2 As String, ByVal FieldValue2 As String, ByVal FieldName3 As String, ByVal FieldValue3 As String, ByVal FieldName4 As String, ByVal FieldValue4 As String, ByVal FieldName5 As String, ByVal FieldValue5 As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] where ([" + FieldName + "]=N"" + FieldValue + "") AND ([" + FieldName2 + "]=N"" + FieldValue2 + "")  AND ([" + FieldName3 + "]=N"" + FieldValue3 + "")  AND ([" + FieldName4 + "]=N"" + FieldValue4 + "")  AND ([" + FieldName5 + "]=N"" + FieldValue5 + "")"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function


'    Public Function ExistTable(ByVal TableName As String) As Boolean
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure
'        Dim Parametr As SqlParameter
'        Dim result As Boolean
'        Adapter.SelectCommand.Parameters.Clear()
'        Parametr = New SqlParameter("@TableID", TableName)
'        Parametr.SqlDbType = SqlDbType.NVarChar
'        Me.Adapter.SelectCommand.CommandText = "ExistTable"
'        Me.Adapter.SelectCommand.Parameters.Add(Parametr)
'        result = Me.Adapter.SelectCommand.ExecuteScalar
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return result
'        Me.DataSet.Dispose()

'    End Function
'    Public Function GetImage(ByVal TableName As String, Optional ByVal IDName As String = "", Optional ByVal IDValue As String = "") As DataRow
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM [" + TableName + "]"
'        If IDName <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " Where  ([" + IDName + "] =" + IDValue + ")"
'        End If
'        Me.Adapter.Fill(Me.DataSet, "image")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("image").Rows(0)
'    End Function

'    Public Function SelectAll(ByVal TableName As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "]"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Function SelectAll(ByVal TableName As String, ByVal OrderField As String) As DataTable
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT * FROM  [" + TableName + "] order by [" + OrderField + "]"
'        Me.Adapter.Fill(Me.DataSet, "All")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("All")
'        Me.DataSet.Dispose()
'    End Function
'    Public Sub Update(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
', Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
', Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
', Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
', Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
', Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
', Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
', Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
', Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
', Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "" _
', Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
', Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
', Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "" _
')
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "] SET   " + SetFieldName + " = N"" + SetFieldValue + """
'        If SetFieldName1 <> "" Then
'            If SetFieldValue1.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N"" + SetFieldValue1 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = " + SetFieldValue1
'            End If
'        End If
'        If SetFieldName2 <> "" Then
'            If SetFieldValue2.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N"" + SetFieldValue2 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = " + SetFieldValue2
'            End If
'        End If
'        If SetFieldName3 <> "" Then
'            If SetFieldValue3.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N"" + SetFieldValue3 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = " + SetFieldValue3
'            End If
'        End If
'        If SetFieldName4 <> "" Then
'            If SetFieldValue4.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N"" + SetFieldValue4 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = " + SetFieldValue4
'            End If
'        End If
'        If SetFieldName5 <> "" Then
'            If SetFieldValue5.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N"" + SetFieldValue5 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = " + SetFieldValue5
'            End If
'        End If
'        If SetFieldName6 <> "" Then
'            If SetFieldValue6.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N"" + SetFieldValue6 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = " + SetFieldValue6
'            End If
'        End If
'        If SetFieldName7 <> "" Then
'            If SetFieldValue7.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N"" + SetFieldValue7 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = " + SetFieldValue7
'            End If
'        End If
'        If SetFieldName8 <> "" Then
'            If SetFieldValue8.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N"" + SetFieldValue8 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = " + SetFieldValue8
'            End If
'        End If
'        If SetFieldName9 <> "" Then
'            If SetFieldValue9.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N"" + SetFieldValue9 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = " + SetFieldValue9
'            End If
'        End If
'        If ConditionFieldName1 <> "" Then
'            If ConditionFieldValue1.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " where (  " + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName1 + " = " + ConditionFieldValue1
'            End If
'        End If
'        If ConditionFieldName2 <> "" Then
'            If ConditionFieldValue2.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = N"" + ConditionFieldValue2 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = " + ConditionFieldValue2
'            End If
'        End If
'        If ConditionFieldName3 <> "" Then
'            If ConditionFieldValue3.ToLower <> "null" Then
'                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = N"" + ConditionFieldValue3 + """
'            Else
'                Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = " + ConditionFieldValue3
'            End If
'        End If
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " ) "
'        End If

'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub
'    Public Sub BigUpdate(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
', Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
', Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
', Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
', Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
', Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
', Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
', Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
', Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
', Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "" _
', Optional ByVal SetFieldName10 As String = "", Optional ByVal SetFieldValue10 As String = "" _
', Optional ByVal SetFieldName11 As String = "", Optional ByVal SetFieldValue11 As String = "" _
', Optional ByVal SetFieldName12 As String = "", Optional ByVal SetFieldValue12 As String = "" _
', Optional ByVal SetFieldName13 As String = "", Optional ByVal SetFieldValue13 As String = "" _
', Optional ByVal SetFieldName14 As String = "", Optional ByVal SetFieldValue14 As String = "" _
', Optional ByVal SetFieldName15 As String = "", Optional ByVal SetFieldValue15 As String = "" _
', Optional ByVal SetFieldName16 As String = "", Optional ByVal SetFieldValue16 As String = "" _
', Optional ByVal SetFieldName17 As String = "", Optional ByVal SetFieldValue17 As String = "" _
', Optional ByVal SetFieldName18 As String = "", Optional ByVal SetFieldValue18 As String = "" _
', Optional ByVal SetFieldName19 As String = "", Optional ByVal SetFieldValue19 As String = "" _
', Optional ByVal SetFieldName20 As String = "", Optional ByVal SetFieldValue20 As String = "" _
', Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
', Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
', Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "" _
')
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "] SET   " + SetFieldName + " = N"" + SetFieldValue + """
'        If SetFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N"" + SetFieldValue1 + """
'        End If
'        If SetFieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N"" + SetFieldValue2 + """
'        End If
'        If SetFieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N"" + SetFieldValue3 + """
'        End If
'        If SetFieldName4 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N"" + SetFieldValue4 + """
'        End If
'        If SetFieldName5 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N"" + SetFieldValue5 + """
'        End If
'        If SetFieldName6 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N"" + SetFieldValue6 + """
'        End If
'        If SetFieldName7 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N"" + SetFieldValue7 + """
'        End If
'        If SetFieldName8 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N"" + SetFieldValue8 + """
'        End If
'        If SetFieldName9 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N"" + SetFieldValue9 + """
'        End If
'        If SetFieldName10 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName10 + " = N"" + SetFieldValue10 + """
'        End If

'        If SetFieldName11 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName11 + " = N"" + SetFieldValue11 + """
'        End If
'        If SetFieldName12 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName12 + " = N"" + SetFieldValue12 + """
'        End If
'        If SetFieldName13 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName13 + " = N"" + SetFieldValue13 + """
'        End If
'        If SetFieldName14 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName14 + " = N"" + SetFieldValue14 + """
'        End If
'        If SetFieldName15 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName15 + " = N"" + SetFieldValue15 + """
'        End If
'        If SetFieldName16 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName16 + " = N"" + SetFieldValue16 + """
'        End If
'        If SetFieldName17 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName17 + " = N"" + SetFieldValue17 + """
'        End If
'        If SetFieldName18 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName18 + " = N"" + SetFieldValue18 + """
'        End If
'        If SetFieldName19 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName19 + " = N"" + SetFieldValue19 + """
'        End If
'        If SetFieldName20 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName20 + " = N"" + SetFieldValue20 + """
'        End If
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " where ( " + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + """
'        End If
'        If ConditionFieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName2 + " = N"" + ConditionFieldValue2 + """
'        End If
'        If ConditionFieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and " + ConditionFieldName3 + " = N"" + ConditionFieldValue3 + """
'        End If
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " ) "
'        End If

'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub

'    Public Sub UpdateAllWithOutWhere(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String _
'    , Optional ByVal SetFieldName1 As String = "", Optional ByVal SetFieldValue1 As String = "" _
'    , Optional ByVal SetFieldName2 As String = "", Optional ByVal SetFieldValue2 As String = "" _
'    , Optional ByVal SetFieldName3 As String = "", Optional ByVal SetFieldValue3 As String = "" _
'    , Optional ByVal SetFieldName4 As String = "", Optional ByVal SetFieldValue4 As String = "" _
'    , Optional ByVal SetFieldName5 As String = "", Optional ByVal SetFieldValue5 As String = "" _
'    , Optional ByVal SetFieldName6 As String = "", Optional ByVal SetFieldValue6 As String = "" _
'    , Optional ByVal SetFieldName7 As String = "", Optional ByVal SetFieldValue7 As String = "" _
'    , Optional ByVal SetFieldName8 As String = "", Optional ByVal SetFieldValue8 As String = "" _
'    , Optional ByVal SetFieldName9 As String = "", Optional ByVal SetFieldValue9 As String = "")
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N"" + SetFieldValue + """
'        If SetFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName1 + " = N"" + SetFieldValue1 + """
'        End If
'        If SetFieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName2 + " = N"" + SetFieldValue2 + """
'        End If
'        If SetFieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName3 + " = N"" + SetFieldValue3 + """
'        End If
'        If SetFieldName4 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName4 + " = N"" + SetFieldValue4 + """
'        End If
'        If SetFieldName5 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName5 + " = N"" + SetFieldValue5 + """
'        End If
'        If SetFieldName6 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName6 + " = N"" + SetFieldValue6 + """
'        End If
'        If SetFieldName7 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName7 + " = N"" + SetFieldValue7 + """
'        End If
'        If SetFieldName8 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName8 + " = N"" + SetFieldValue8 + """
'        End If
'        If SetFieldName9 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " , " + SetFieldName9 + " = N"" + SetFieldValue9 + """
'        End If
'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub
'    Public Sub UpdateField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String)
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N"" + SetFieldValue + """

'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub

'    Public Sub UpdateAField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String, ByVal ConditionFieldName1 As String, ByVal ConditionFieldValue1 As String, Optional ByVal ConditionType1 As String = "", Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "", Optional ByVal ConditionType2 As String = "", Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "", Optional ByVal ConditionType3 As String = "", Optional ByVal ConditionFieldName4 As String = "", Optional ByVal ConditionFieldValue4 As String = "", Optional ByVal ConditionType4 As String = "", Optional ByVal ConditionFieldName5 As String = "", Optional ByVal ConditionFieldValue5 As String = "", Optional ByVal ConditionType5 As String = "")
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " = N"" + SetFieldValue + """

'        If ConditionFieldName1 <> "" Then
'            If ConditionType1 = "" Then
'                Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + "")"
'            Else
'                If ConditionType1 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + "")"
'                End If
'            End If
'        End If

'        If ConditionFieldName2 <> "" Then
'            If ConditionType2 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " = N"" + ConditionFieldValue2 + "")"
'            Else
'                If ConditionType2 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " < " + ConditionFieldValue2 + ")"
'                End If
'            End If
'        End If

'        If ConditionFieldName3 <> "" Then
'            If ConditionType3 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " = N"" + ConditionFieldValue3 + "")"
'            Else
'                If ConditionType3 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " < " + ConditionFieldValue3 + ")"
'                End If
'            End If
'        End If

'        If ConditionFieldName4 <> "" Then
'            If ConditionType4 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName4 + " = N"" + ConditionFieldValue4 + "")"
'            Else
'                If ConditionType4 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName4 + " < " + ConditionFieldValue4 + ")"
'                End If
'            End If
'        End If

'        If ConditionFieldName5 <> "" Then
'            If ConditionType5 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName5 + " = N"" + ConditionFieldValue5 + "")"
'            Else
'                If ConditionType5 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName5 + " < " + ConditionFieldValue5 + ")"
'                End If
'            End If
'        End If


'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub


'    Public Sub UpdateAnImageFieldWithOutWhere(ByVal TableName As String, ByVal ImageFieldName As String, ByVal image As Byte(), ByVal ImageTypeFieldName As String, ByVal ImageType As String)

'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.Parameters.Clear()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + "  SET  " + ImageFieldName + " = @image  ," + ImageTypeFieldName + "=N"" + ImageType + """
'        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub
'    Public Sub UpdateAnImageFieldWhere(ByVal TableName As String, ByVal ImageFieldName As String, ByVal image As Byte() _
'        , Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
', Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
', Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "" _
')

'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.Parameters.Clear()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    [" + TableName + "]  SET  " + ImageFieldName + " = @image  " "," + ImageTypeFieldName + "=N"" + ImageType + """
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " where ( [" + ConditionFieldName1 + "] = N"" + ConditionFieldValue1 + """
'        End If
'        If ConditionFieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName2 + "] = N"" + ConditionFieldValue2 + """
'        End If
'        If ConditionFieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName3 + "] = N"" + ConditionFieldValue3 + """
'        End If
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " ) "
'        End If


'        Me.Adapter.SelectCommand.Parameters.AddWithValue("@image", image)
'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub

'    Public Function GetMaxWhere(ByVal TableName As String, ByVal IDName As String _
'        , Optional ByVal ConditionFieldName1 As String = "", Optional ByVal ConditionFieldValue1 As String = "" _
', Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "" _
', Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "" _
') As String

'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Dim MaxCode As String
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS MaxField FROM [" + TableName + "] "

'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " where ( [" + ConditionFieldName1 + "] = N"" + ConditionFieldValue1 + """
'        End If
'        If ConditionFieldName2 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName2 + "] = N"" + ConditionFieldValue2 + """
'        End If
'        If ConditionFieldName3 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " and [" + ConditionFieldName3 + "] = N"" + ConditionFieldValue3 + """
'        End If
'        If ConditionFieldName1 <> "" Then
'            Me.Adapter.SelectCommand.CommandText += " ) "
'        End If

'        Me.Adapter.Fill(Me.DataSet, "Max")
'        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return MaxCode
'    End Function
'    Public Function GetMax(ByVal TableName As String, ByVal IDName As String) As String
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Dim MaxCode As String
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS Max FROM [" + TableName + "]"
'        Me.Adapter.Fill(Me.DataSet, "Max")
'        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return MaxCode
'    End Function
'    Public Function GetMax(ByVal TableName As String, ByVal IDName As String, ByVal conditionFieldName As String, ByVal ConditionFieldValue As String) As String
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Dim MaxCode As String
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT  MAX(" + IDName + ") AS Max FROM [" + TableName + "] where " + conditionFieldName + "=" + ConditionFieldValue
'        Me.Adapter.Fill(Me.DataSet, "Max")
'        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return MaxCode
'    End Function
'    Public Function GetMaxPlus(ByVal TableName As String, ByVal IDName As String) As String
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Dim MaxCode As String
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT  isnull(MAX(" + IDName + "),0)+1 AS Max FROM [" + TableName + "]"
'        Me.Adapter.Fill(Me.DataSet, "Max")
'        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return MaxCode
'    End Function
'    Public Function GetMaxPlus(ByVal TableName As String, ByVal IDName As String, ByVal conditionFieldName As String, ByVal ConditionFieldValue As String) As String
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Dim MaxCode As String
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT  isnull(MAX(" + IDName + "),0)+1 AS Max FROM [" + TableName + "] where " + conditionFieldName + "=" + ConditionFieldValue
'        Me.Adapter.Fill(Me.DataSet, "Max")
'        MaxCode = (Me.DataSet.Tables("Max").Rows(0).Item(0)).ToString
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()

'        Return MaxCode
'    End Function

'    Public Sub SetInsertFieldValueStr(ByRef FieldValueEnd As Boolean, ByRef str As String, ByVal FieldValue As String)
'        If FieldValueEnd = False Then
'            If FieldValue <> "NotHasData" And FieldValue <> "" Then
'                str += FieldValue + ", "
'            Else
'                str = str.Substring(0, str.Length - 2)
'                FieldValueEnd = True
'            End If
'        End If


'    End Sub
'    Public Sub SetInsertValueStr(ByRef ValueEnd As Boolean, ByRef str As String, ByVal Value As String, ByVal Type As String)
'        If ValueEnd = False Then
'            If Value <> "NotHasData" And Value <> "" Then
'                If Type <> "bit" Then
'                    str += "N"" + Value + "", "
'                Else
'                    If Value = "True" Then
'                        str += "1 , "

'                    Else
'                        str += "0 , "
'                    End If

'                End If
'            Else

'                str = str.Substring(0, str.LastIndexOf(","))
'                ValueEnd = True
'            End If
'        End If


'    End Sub
'    Public Sub SetInsertValueStr(ByRef ValueEnd As Boolean, ByRef str As String, ByVal Value As String)
'        If ValueEnd = False Then
'            If Value <> "NotHasData" Then
'                str += "N"" + Value + "", "
'            Else
'                str = str.Substring(0, str.Length - 2)
'                ValueEnd = True
'            End If
'        End If


'    End Sub

'    Public Sub InsertViaType(ByVal TableName As String, ByVal Field1 As String, ByVal Value1 As String, Optional ByVal Type1 As String = "text", _
'Optional ByVal Field2 As String = "NotHasData", Optional ByVal Value2 As String = "NotHasData", Optional ByVal Type2 As String = "text", _
'Optional ByVal Field3 As String = "NotHasData", Optional ByVal Value3 As String = "NotHasData", Optional ByVal Type3 As String = "text", _
'Optional ByVal Field4 As String = "NotHasData", Optional ByVal Value4 As String = "NotHasData", Optional ByVal Type4 As String = "text", _
'Optional ByVal Field5 As String = "NotHasData", Optional ByVal Value5 As String = "NotHasData", Optional ByVal Type5 As String = "text", _
'Optional ByVal Field6 As String = "NotHasData", Optional ByVal Value6 As String = "NotHasData", Optional ByVal Type6 As String = "text", _
'Optional ByVal Field7 As String = "NotHasData", Optional ByVal Value7 As String = "NotHasData", Optional ByVal Type7 As String = "text", _
'Optional ByVal Field8 As String = "NotHasData", Optional ByVal Value8 As String = "NotHasData", Optional ByVal Type8 As String = "text", _
'Optional ByVal Field9 As String = "NotHasData", Optional ByVal Value9 As String = "NotHasData", Optional ByVal Type9 As String = "text", _
'Optional ByVal Field10 As String = "NotHasData", Optional ByVal Value10 As String = "NotHasData", Optional ByVal Type10 As String = "text", _
'Optional ByVal Field11 As String = "NotHasData", Optional ByVal Value11 As String = "NotHasData", Optional ByVal Type11 As String = "text", _
'Optional ByVal Field12 As String = "NotHasData", Optional ByVal Value12 As String = "NotHasData", Optional ByVal Type12 As String = "text", _
'Optional ByVal Field13 As String = "NotHasData", Optional ByVal Value13 As String = "NotHasData", Optional ByVal Type13 As String = "text", _
'Optional ByVal Field14 As String = "NotHasData", Optional ByVal Value14 As String = "NotHasData", Optional ByVal Type14 As String = "text", _
'Optional ByVal Field15 As String = "NotHasData", Optional ByVal Value15 As String = "NotHasData", Optional ByVal Type15 As String = "text", _
'Optional ByVal Field16 As String = "NotHasData", Optional ByVal Value16 As String = "NotHasData", Optional ByVal Type16 As String = "text")

'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Dim str As String
'        Dim FieldValueEnd As Boolean = False

'        str = "INSERT INTO [" + TableName + "] ( "

'        SetInsertFieldValueStr(FieldValueEnd, str, Field1)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field2)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field3)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field4)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field5)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field6)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field7)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field8)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field9)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field10)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field11)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field12)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field13)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field14)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field15)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field16)
'        str = str.Substring(0, str.LastIndexOf(","))
'        str += " ) VALUES  ( "
'        FieldValueEnd = False

'        SetInsertValueStr(FieldValueEnd, str, Value1, Type1)
'        SetInsertValueStr(FieldValueEnd, str, Value2, Type2)
'        SetInsertValueStr(FieldValueEnd, str, Value3, Type3)
'        SetInsertValueStr(FieldValueEnd, str, Value4, Type4)
'        SetInsertValueStr(FieldValueEnd, str, Value5, Type5)
'        SetInsertValueStr(FieldValueEnd, str, Value6, Type6)
'        SetInsertValueStr(FieldValueEnd, str, Value7, Type7)
'        SetInsertValueStr(FieldValueEnd, str, Value8, Type8)
'        SetInsertValueStr(FieldValueEnd, str, Value9, Type9)
'        SetInsertValueStr(FieldValueEnd, str, Value10, Type10)
'        SetInsertValueStr(FieldValueEnd, str, Value11, Type11)
'        SetInsertValueStr(FieldValueEnd, str, Value12, Type12)
'        SetInsertValueStr(FieldValueEnd, str, Value13, Type13)
'        SetInsertValueStr(FieldValueEnd, str, Value14, Type14)
'        SetInsertValueStr(FieldValueEnd, str, Value15, Type15)
'        SetInsertValueStr(FieldValueEnd, str, Value16, Type16)

'        str = str.Substring(0, str.LastIndexOf(","))
'        str += " ) "
'        'ModifyDate,Data, FieldCode,LogID,FarignID,InsertByUser ) VALUES  ( GETDATE(), N"" + DeleteTag(Data) + ""," + FieldCode + "," + LogID + ",N"" + FarignID + "",1)"
'        Me.Adapter.SelectCommand.CommandText = str
'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub

'    Public Sub Insert(ByVal TableName As String, ByVal Field1 As String, ByVal Value1 As String, _
'    Optional ByVal Field2 As String = "NotHasData", Optional ByVal Value2 As String = "NotHasData", _
'    Optional ByVal Field3 As String = "NotHasData", Optional ByVal Value3 As String = "NotHasData", _
'    Optional ByVal Field4 As String = "NotHasData", Optional ByVal Value4 As String = "NotHasData", _
'    Optional ByVal Field5 As String = "NotHasData", Optional ByVal Value5 As String = "NotHasData", _
'    Optional ByVal Field6 As String = "NotHasData", Optional ByVal Value6 As String = "NotHasData", _
'    Optional ByVal Field7 As String = "NotHasData", Optional ByVal Value7 As String = "NotHasData", _
'    Optional ByVal Field8 As String = "NotHasData", Optional ByVal Value8 As String = "NotHasData", _
'    Optional ByVal Field9 As String = "NotHasData", Optional ByVal Value9 As String = "NotHasData", _
'    Optional ByVal Field10 As String = "NotHasData", Optional ByVal Value10 As String = "NotHasData", _
'    Optional ByVal Field11 As String = "NotHasData", Optional ByVal Value11 As String = "NotHasData", _
'    Optional ByVal Field12 As String = "NotHasData", Optional ByVal Value12 As String = "NotHasData", _
'    Optional ByVal Field13 As String = "NotHasData", Optional ByVal Value13 As String = "NotHasData", _
'    Optional ByVal Field14 As String = "NotHasData", Optional ByVal Value14 As String = "NotHasData", _
'    Optional ByVal Field15 As String = "NotHasData", Optional ByVal Value15 As String = "NotHasData", _
'    Optional ByVal Field16 As String = "NotHasData", Optional ByVal Value16 As String = "NotHasData", _
'    Optional ByVal Field17 As String = "NotHasData", Optional ByVal Value17 As String = "NotHasData", _
'    Optional ByVal Field18 As String = "NotHasData", Optional ByVal Value18 As String = "NotHasData", _
'    Optional ByVal Field19 As String = "NotHasData", Optional ByVal Value19 As String = "NotHasData", _
'    Optional ByVal Field20 As String = "NotHasData", Optional ByVal Value20 As String = "NotHasData")

'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Dim str As String
'        Dim FieldValueEnd As Boolean = False

'        str = "INSERT INTO [" + TableName + "] ( "

'        SetInsertFieldValueStr(FieldValueEnd, str, Field1)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field2)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field3)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field4)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field5)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field6)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field7)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field8)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field9)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field10)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field11)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field12)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field13)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field14)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field15)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field16)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field17)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field18)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field19)
'        SetInsertFieldValueStr(FieldValueEnd, str, Field20)

'        str += " ) VALUES  ( "
'        FieldValueEnd = False

'        SetInsertValueStr(FieldValueEnd, str, Value1)
'        SetInsertValueStr(FieldValueEnd, str, Value2)
'        SetInsertValueStr(FieldValueEnd, str, Value3)
'        SetInsertValueStr(FieldValueEnd, str, Value4)
'        SetInsertValueStr(FieldValueEnd, str, Value5)
'        SetInsertValueStr(FieldValueEnd, str, Value6)
'        SetInsertValueStr(FieldValueEnd, str, Value7)
'        SetInsertValueStr(FieldValueEnd, str, Value8)
'        SetInsertValueStr(FieldValueEnd, str, Value9)
'        SetInsertValueStr(FieldValueEnd, str, Value10)
'        SetInsertValueStr(FieldValueEnd, str, Value11)
'        SetInsertValueStr(FieldValueEnd, str, Value12)
'        SetInsertValueStr(FieldValueEnd, str, Value13)
'        SetInsertValueStr(FieldValueEnd, str, Value14)
'        SetInsertValueStr(FieldValueEnd, str, Value15)
'        SetInsertValueStr(FieldValueEnd, str, Value16)
'        SetInsertValueStr(FieldValueEnd, str, Value17)
'        SetInsertValueStr(FieldValueEnd, str, Value18)
'        SetInsertValueStr(FieldValueEnd, str, Value19)
'        SetInsertValueStr(FieldValueEnd, str, Value20)


'        str += " ) "
'        'ModifyDate,Data, FieldCode,LogID,FarignID,InsertByUser ) VALUES  ( GETDATE(), N"" + DeleteTag(Data) + ""," + FieldCode + "," + LogID + ",N"" + FarignID + "",1)"
'        Me.Adapter.SelectCommand.CommandText = str
'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub




'    Public Function GetServerDate() As Date
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.DataSet = New DataSet
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "SELECT GETDATE() AS ServerDate"
'        Me.Adapter.Fill(Me.DataSet, "Date")
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'        Return Me.DataSet.Tables("Date").Rows(0).Item("ServerDate").ToString
'        Me.DataSet.Dispose()
'    End Function

'    Public Function GetServerShamsiDateTodayString() As String
'        Dim ServerDate As Date
'        Dim DateStr As String = "امروز "
'        ServerDate = GetServerDate()
'        Dim a As BijanComponents.DateTimeFarsi
'        a = BijanComponents.ShamsiDate.GetShamsiDateValue(ServerDate)
'        Select Case a.Day
'            Case 1
'                DateStr += "اول"
'            Case 2
'                DateStr += "دوم"
'            Case 3
'                DateStr += "سوم"
'            Case 4
'                DateStr += "چهارم"
'            Case 5
'                DateStr += "پنجم"
'            Case 6
'                DateStr += "ششم"
'            Case 7
'                DateStr += "هفتم"
'            Case 8
'                DateStr += "هشتم"
'            Case 9
'                DateStr += "نهم"
'            Case 10
'                DateStr += "دهم"
'            Case 11
'                DateStr += "یازدهم"
'            Case 12
'                DateStr += "دوازدهم"
'            Case 13
'                DateStr += "سیزدهم"
'            Case 14
'                DateStr += "چهاردهم"
'            Case 15
'                DateStr += "پانزدهم"
'            Case 16
'                DateStr += "شانزدهم"
'            Case 17
'                DateStr += "هفدهم"
'            Case 18
'                DateStr += "هجدهم"
'            Case 19
'                DateStr += "نوزدهم"
'            Case 20
'                DateStr += "بیستم"
'            Case 21
'                DateStr += "بیست ویکم"
'            Case 22
'                DateStr += "بیست و دوم"
'            Case 23
'                DateStr += "بیست و سوم"
'            Case 24
'                DateStr += "بیست و چهارم"
'            Case 25
'                DateStr += "بیست و پنجم"
'            Case 26
'                DateStr += "بیست و ششم"
'            Case 27
'                DateStr += "بیست و هفتم"
'            Case 28
'                DateStr += "بیست و هشتم"
'            Case 29
'                DateStr += "بیست و نهم"
'            Case 30
'                DateStr += "سی ام"
'            Case 31
'                DateStr += "سی و یکم"
'        End Select
'        Select Case a.Month
'            Case 1
'                DateStr += " فروردین ماه  "
'            Case 2
'                DateStr += " اردیبهشت ماه  "
'            Case 3
'                DateStr += " خرداد ماه  "
'            Case 4
'                DateStr += " تیر ماه  "
'            Case 5
'                DateStr += " مرداد ماه  "
'            Case 6
'                DateStr += " شهریور ماه  "
'            Case 7
'                DateStr += " مهر ماه  "
'            Case 8
'                DateStr += " آبان ماه  "
'            Case 9
'                DateStr += " آذر ماه  "
'            Case 10
'                DateStr += " دی ماه  "
'            Case 11
'                DateStr += " بهمن ماه  "
'            Case 12
'                DateStr += " اسفند ماه  "
'        End Select
'        Select Case a.Year
'            Case 1386
'                DateStr += "هشتاد و شش"
'            Case 1387
'                DateStr += "هشتاد و هفت"
'            Case 1388
'                DateStr += "هشتاد و هشت"
'            Case 1389
'                DateStr += "هشتاد و نه"
'            Case 1390
'                DateStr += "نود"
'            Case 1391
'                DateStr += "نود و یک"
'            Case 1392
'                DateStr += "نود و دو"
'            Case 1393
'                DateStr += "نود و سه"
'            Case 1394
'                DateStr += "نود و چهار"
'            Case 1395
'                DateStr += "نود و پنج"
'            Case 1396
'                DateStr += "نود و شش"
'            Case 1397
'                DateStr += "نود و هفت"
'            Case 1398
'                DateStr += "نود و هشت"
'            Case 1399
'                DateStr += "نود و نه"
'        End Select
'        DateStr += " " + BijanComponents.ShamsiDate.GetShamsiDate(ServerDate)
'        Return DateStr
'    End Function

'    Public Sub AddToField(ByVal TableName As String, ByVal SetFieldName As String, ByVal SetFieldValue As String, ByVal ConditionFieldName1 As String, ByVal ConditionFieldValue1 As String, Optional ByVal ConditionType1 As String = "", Optional ByVal ConditionFieldName2 As String = "", Optional ByVal ConditionFieldValue2 As String = "", Optional ByVal ConditionType2 As String = "", Optional ByVal ConditionFieldName3 As String = "", Optional ByVal ConditionFieldValue3 As String = "", Optional ByVal ConditionType3 As String = "")
'        If Me.Connection.State <> ConnectionState.Open Then Me.Connection.Open()
'        Me.Adapter.SelectCommand.CommandType = CommandType.Text
'        Me.Adapter.SelectCommand.CommandText = "UPDATE    " + TableName + " SET   " + SetFieldName + " =isnull(" + SetFieldName + ",0)+" + SetFieldValue

'        If ConditionFieldName1 <> "" Then
'            If ConditionType1 = "" Then
'                Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + "")"
'            Else
'                If ConditionType1 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += "  WHERE     (" + ConditionFieldName1 + " = N"" + ConditionFieldValue1 + "")"
'                End If
'            End If
'        End If

'        If ConditionFieldName2 <> "" Then
'            If ConditionType2 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " = N"" + ConditionFieldValue2 + "")"
'            Else
'                If ConditionType2 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName2 + " < " + ConditionFieldValue2 + ")"
'                End If
'            End If
'        End If

'        If ConditionFieldName3 <> "" Then
'            If ConditionType3 = "" Then
'                Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " = N"" + ConditionFieldValue3 + "")"
'            Else
'                If ConditionType3 = "<" Then
'                    Me.Adapter.SelectCommand.CommandText += " AND (" + ConditionFieldName3 + " < " + ConditionFieldValue3 + ")"
'                End If
'            End If
'        End If

'        Me.Adapter.SelectCommand.ExecuteNonQuery()
'        If Me.Connection.State <> ConnectionState.Closed Then Me.Connection.Close()
'    End Sub

'End Class
