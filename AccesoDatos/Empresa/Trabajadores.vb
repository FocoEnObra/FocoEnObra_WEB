Imports SUL
Imports System.Data.SqlClient
Imports EL
Imports EL.Seguridad


Namespace Empresa
    Public Class Trabajadores
        Public Shared Function ListarTrabajadores(ByVal idObra As Integer, ByVal fechaCorte As Date, vUsuario As EL.Seguridad.Usuario) As DataSet
            Dim vCon As New Conexion(vUsuario.EmpresaSelected.DatosConexion.GenerarStringConexion)
            Dim vParam As New Dictionary(Of String, Object)
            With vParam
                .Add("@ID_OBR", idObra)
                .Add("@FECHA_CORTE", fechaCorte)
            End With
            Try
                ListarTrabajadores = vCon.ExecSP_DS("SP_MO_ASIG_TRABAJADORES_BUSCAR ", vParam)
            Catch ex As Exception
                Throw New Exception("No se puede listar Los Trabajadore de la Obra y fecha seleccionada.", ex)
            End Try
        End Function
    End Class
End Namespace

