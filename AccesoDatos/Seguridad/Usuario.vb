Imports SUL
Imports System.Data.SqlClient
Imports EL.Seguridad


Namespace Seguridad
    Public Class Usuario

        Public Shared Function Ingresar(vUsuario As String, vPassword As String, vStrConexion As String,
                                        ip As String, host As String) As UsuarioSistema
            Dim vCon As New Conexion(vStrConexion)
            Dim vParam As New Dictionary(Of String, Object)
            Dim vTablas As DataSet = Nothing
            Dim vEnc As New Encriptacion
            With vParam
                .Add("@USUARIO", vUsuario)
                .Add("@PASSWORD", vEnc.SHA256Hash(vPassword))
                .Add("@IP", ip)
                .Add("@HOST", host)
            End With
            Try
                vTablas = vCon.ExecSP_DS("SP_SEGURIDAD_INGRESAR", vParam)
            Catch ex As SqlException
                If ex.Number = 50000 And ex.Class = 16 Then
                    Throw ex
                    Return Nothing
                End If
            Catch ex As Exception
                Throw New Exception("No se ha podido validar el ingreso. Intente más tarde.", ex)
            End Try
            If vTablas IsNot Nothing AndAlso vTablas.Tables.Count = 2 Then
                Ingresar = New UsuarioSistema
                UsuarioSistema.StrCon = vStrConexion
                Ingresar.NickName = vTablas.Tables(0).Rows(0).Item("NOMBRE_USU")
                Ingresar.Estado = EL.Seguridad.EstadoUsuario.Activo
                Ingresar.ID_MAESTRO = vTablas.Tables(0).Rows(0).Item("ID_USU")

                Ingresar.ip = ip
                Ingresar.hostName = host
                Ingresar.UsuarioTest = vTablas.Tables(0).Rows(0).Item("USUARIO_TEST")
                If Not IsDBNull(vTablas.Tables(0).Rows(0).Item("ES_ADMIN_USU")) Then _
                    Ingresar.EsAdmin = vTablas.Tables(0).Rows(0).Item("ES_ADMIN_USU")
                'Ingresar.Empresas = vTablas.Tables(1)
                'If Ingresar.Empresas.Rows.Count = 1 Then
                '    Ingresar.EmpresaSelected = New EL.Empresa.Empresa(Ingresar.Empresas.Rows(0))
                'End If
            Else
                Ingresar = Nothing
            End If
        End Function




    End Class
End Namespace