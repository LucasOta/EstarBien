Imports System.Data.SqlClient
Partial Class Planes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
            conn.Open()

            comand = New SqlCommand("SELECT ID_Plan, ID_ObraSocial, Nombre FROM PlanesOS WHERE Baja = 0 AND ID_ObraSocial= @ID ORDER BY Nombre", conn)
            comand.Parameters.Add("@ID", Data.SqlDbType.VarChar)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            Repeater1.DataSource = lector
            Repeater1.DataBind()
            conn.Close()

            conn.Open()
            comand = New SqlCommand("SELECT Nombre FROM ObrasSociales WHERE ID_ObraSocial = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            If lector.Read Then
                lbl_OS.Text = lector("Nombre")
            End If
            conn.Close()
        End If
    End Sub

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO PlanesOS (Nombre, ID_ObraSocial, Baja) VALUES (@Nom, @ID, 0)", conn)

        comand.Parameters.Add("@Nom", Data.SqlDbType.VarChar)
        comand.Parameters("@Nom").Value = txt_Nom.Text
        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
    End Sub

    Private Sub Volver_btn_Click(sender As Object, e As EventArgs) Handles Volver_btn.Click
        Response.Redirect(".\ObrasSociales.aspx")
    End Sub
End Class
