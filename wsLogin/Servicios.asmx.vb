Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services
Imports DAL.Seguridad



' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService
    Dim Consultas As Consultas = New Consultas

    <WebMethod()>
    Public Function Login(vUsuario As String, vPassword As String, vStrConexion As String, ip As String, host As String) As UsuarioSistema
        Dim vUser As UsuarioSistema = Nothing
        'comentario mjeldres
        Try
            vUser = Usuario.Ingresar(vUsuario, vPassword, vStrConexion, ip, host)
        Catch sqlEx As SqlException
            Alerta("error sql.")
            Exit Function
        Catch ex As Exception
            Alerta("error ws")
            Exit Function
        End Try

        Return vUser

    End Function

    Private Sub Alerta(vMensaje As String)
        'litError.Text = vMensaje
        'pError.CssClass = CajaError
        'pError.Visible = True
        'div_msj.Attributes.Add("style", "visibility:visible")
        'msg.InnerText = vMensaje
    End Sub

End Class