Imports System.Data.SqlClient
Partial Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comando As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
            conn.Open()

            comando = New SqlCommand("SELECT ID_ObraSocial, count(ID_ObraSocial) as cantPac FROM Pacientes WHERE Baja=0 group by ID_ObraSocial", conn)
            lector = comando.ExecuteReader
            Repeater1.DataSource = lector
            Repeater1.DataBind()

            conn.Close()
        End If
    End Sub

End Class
