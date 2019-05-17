Imports System.Data.SqlClient
Partial Class BajaPaciente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comando As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()

        comando = New SqlCommand("UPDATE Pacientes SET Baja = 1 WHERE Id_Paciente = @ID", conn)

        comando.Parameters.Add("@ID", Data.SqlDbType.Int)
        comando.Parameters("@ID").Value = Request.QueryString("ID")

        comando.ExecuteNonQuery()


        conn.Close()

        Response.Redirect("./ListadoPacientes.aspx")
    End Sub
End Class
