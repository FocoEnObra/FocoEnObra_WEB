Imports SUL
Imports System.Data.SqlClient
Imports EL
Imports EL.Seguridad
Namespace Empresa


    'Public Class Areas

    '    Public Shared Function ListarAreas(ByVal idObra As Integer, vUsuario As EL.Seguridad.Usuario) As DataSet
    '        Dim vCon As New Conexion(vUsuario.EmpresaSelected.DatosConexion.GenerarStringConexion)
    '        Dim vParam As New Dictionary(Of String, Object)
    '        With vParam
    '            .Add("@ID_OBR", idObra)

    '        End With
    '        Try
    '            ListarAreas = vCon.ExecSP_DS("SP_MO_AREAS_BUSCAR", vParam)
    '        Catch ex As Exception
    '            Throw New Exception("No se puede listar Las Areas de la Obra seleccionada.", ex)
    '        End Try
    '    End Function



    'End Class

End Namespace

