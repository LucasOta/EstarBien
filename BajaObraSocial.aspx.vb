Imports System.Data.SqlClient
Partial Class BajaObraSocial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comando As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()

        comando = New SqlCommand("UPDATE ObrasSociales SET Baja = 1 WHERE ID_ObraSocial = @ID", conn)

        comando.Parameters.Add("@ID", Data.SqlDbType.Int)
        comando.Parameters("@ID").Value = Request.QueryString("ID")

        comando.ExecuteNonQuery()

        conn.Close()

        Response.Redirect("./ObrasSociales.aspx")
    End Sub
End Class
