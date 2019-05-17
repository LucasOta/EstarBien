Imports System.Data.SqlClient
Partial Class BajaKinesiologo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comando As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()

        comando = New SqlCommand("UPDATE Kinesiologos SET Baja = 1 WHERE ID_Kin = @ID", conn)

        comando.Parameters.Add("@ID", Data.SqlDbType.Int)
        comando.Parameters("@ID").Value = Request.QueryString("ID")

        comando.ExecuteNonQuery()


        conn.Close()

        Response.Redirect("./ListadoKinesiologos.aspx")
    End Sub
End Class
