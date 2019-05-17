Imports System.Data.SqlClient
Partial Class ListadoPacientes
    Inherits System.Web.UI.Page

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Response.Redirect("./AltaPaciente.aspx")
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comando As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
            conn.Open()

            comando = New SqlCommand("SELECT Id_Paciente, NyA, DNI, Celular, Email FROM Pacientes WHERE Baja = 0 ORDER BY NyA", conn)
            lector = comando.ExecuteReader
            Repeater1.DataSource = lector
            Repeater1.DataBind()

            conn.Close()
        End If
    End Sub
End Class
