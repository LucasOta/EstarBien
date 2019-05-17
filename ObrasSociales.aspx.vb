Imports System.Data.SqlClient
Partial Class ObrasSociales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comando As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
            conn.Open()

            comando = New SqlCommand("SELECT ID_ObraSocial, Nombre FROM ObrasSociales WHERE Baja = 0 ORDER BY Nombre", conn)
            lector = comando.ExecuteReader
            Repeater1.DataSource = lector
            Repeater1.DataBind()

            conn.Close()
        End If
    End Sub

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        Dim lector As SqlDataReader
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO ObrasSociales (Nombre, Baja) VALUES (@Nom, 0)", conn)

        comand.Parameters.Add("@Nom", Data.SqlDbType.VarChar)
        comand.Parameters("@Nom").Value = txt_Nom.Text

        comand.ExecuteNonQuery()
        conn.Close()
        conn.Open()
        comand = New SqlCommand("SELECT Max(ID_ObraSocial) AS Max FROM ObrasSociales", conn)
        lector = comand.ExecuteReader
        Dim ID_OS As String
        If lector.Read Then
            ID_OS = lector("Max")
        End If
        conn.Close()

        conn.Open()
        comand = New SqlCommand("INSERT INTO PlanesOS (Nombre, ID_ObraSocial, Baja) VALUES ('Sin Plan', @ID_ObSoc, 0);", conn)

        comand.Parameters.Add("@ID_ObSoc", Data.SqlDbType.VarChar)
        comand.Parameters("@ID_ObSoc").Value = ID_OS

        comand.ExecuteNonQuery()
        conn.Close()

        Response.Redirect("./ObrasSociales.aspx")
    End Sub
End Class
