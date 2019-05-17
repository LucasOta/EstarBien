Imports System.Data.SqlClient
Partial Class BajaPlan
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comando As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()

        comando = New SqlCommand("UPDATE PlanesOS SET Baja = 1 WHERE ID_Plan = @ID", conn)

        comando.Parameters.Add("@ID", Data.SqlDbType.Int)
        comando.Parameters("@ID").Value = Request.QueryString("ID")

        comando.ExecuteNonQuery()

        conn.Close()

        Response.Redirect("./Planes.aspx?ID=" + Request.QueryString("IDos"))
    End Sub
End Class
