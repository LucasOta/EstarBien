Imports System.Data.SqlClient
Partial Class AltaLocalidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO Localidades (Nombre, Baja) VALUES (@Nom, 0)", conn)

        comand.Parameters.Add("@Nom", Data.SqlDbType.VarChar)
        comand.Parameters("@Nom").Value = txt_Nom.Text

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./AltaPaciente.aspx")
    End Sub
End Class
