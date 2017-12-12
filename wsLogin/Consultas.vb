Imports System.Data.SqlClient
Imports System.Net

Public Class Consultas


    Private adap As SqlDataAdapter
    Private comand As SqlCommand


    Public Function Conexion() As SqlConnection
        Dim ConeCt As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("strConexion").ConnectionString)
        Return ConeCt
    End Function


    Function ValidaBD(ByVal usuario As String, ByVal password As String, ByVal IP As String, ByVal host As String) As DataSet

        Dim ds As DataSet = New DataSet
        Try
            Conexion.Open()
            Dim cmd As New SqlCommand("dbo.SPU_SEGURIDAD_INGRESAR", Conexion())
            Dim adap As SqlDataAdapter
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@USUARIO", SqlDbType.Char)).Value = usuario
            cmd.Parameters.Add(New SqlParameter("@PASSWORD", SqlDbType.Char)).Value = password
            cmd.Parameters.Add(New SqlParameter("@IP", SqlDbType.Char)).Value = IP
            cmd.Parameters.Add(New SqlParameter("@HOST", SqlDbType.Char)).Value = host

            adap = New SqlDataAdapter(cmd)
            adap.Fill(ds, "tbllogin")
            If ds Is Nothing Then
                Return ds
            Else
                Return ds
            End If
            Conexion.Close()
        Catch ex As Exception
            Return ds
        End Try

    End Function




End Class
