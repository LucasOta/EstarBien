Imports System.Data.SqlClient
Partial Class BajaTurno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comando As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()

        comando = New SqlCommand("UPDATE Turnos SET Baja = 1 WHERE ID_Turno = @ID", conn)

        comando.Parameters.Add("@ID", Data.SqlDbType.Int)
        comando.Parameters("@ID").Value = Convert.ToInt32(Request.QueryString("ID"))

        comando.ExecuteNonQuery()


        conn.Close()
        Response.Redirect("./Turnos.aspx?Ver=1")
    End Sub
End Class
