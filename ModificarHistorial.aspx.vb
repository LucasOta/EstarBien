Imports System.Data.SqlClient
Partial Class ModificarHistorial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

            conn.Open()
            comand = New SqlCommand("SELECT ID_Historial, ID_Paciente, Fecha_Inicio, Fecha_Cierre, Kinesiologo, Cant_Sesiones, Motivo, Tratamiento, Estudios FROM Historiales WHERE ID_Historial = @ID", conn)
            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")

            lector = comand.ExecuteReader
            If lector.Read Then
                txt_Kinesiologo.Text = lector("Kinesiologo")
                txt_CantSesiones.Text = lector("Cant_Sesiones")
                txt_Motivo.Text = lector("Motivo")
                txt_Tratamientos.Text = lector("Tratamiento")
                txt_Estudios.Text = lector("Estudios")
            End If
        End If
    End Sub

    Private Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("UPDATE Historiales SET ID_Paciente = @IDpac, Fecha_Inicio = @FeIn, Fecha_Cierre = @FeCi, Kinesiologo = @Kin, Cant_Sesiones = @Cant, Motivo = @Motivo, Tratamiento = @Trat, Estudios = @Estudios WHERE ID_Historial = @ID", conn)

        comand.Parameters.Add("@FeIn", Data.SqlDbType.Date)
        comand.Parameters("@FeIn").Value = Convert.ToDateTime(txt_fInicio.Text)

        comand.Parameters.Add("@FeCi", Data.SqlDbType.Date)
        comand.Parameters("@FeCi").Value = Convert.ToDateTime(txt_fCierre.Text)

        comand.Parameters.Add("@Kin", Data.SqlDbType.VarChar)
        comand.Parameters("@Kin").Value = txt_Kinesiologo.Text

        comand.Parameters.Add("@Cant", Data.SqlDbType.Int)
        comand.Parameters("@Cant").Value = Convert.ToInt32(txt_CantSesiones.Text)

        comand.Parameters.Add("@Motivo", Data.SqlDbType.VarChar)
        comand.Parameters("@Motivo").Value = txt_Motivo.Text

        comand.Parameters.Add("@Trat", Data.SqlDbType.VarChar)
        comand.Parameters("@Trat").Value = txt_Tratamientos.Text

        comand.Parameters.Add("@Estudios", Data.SqlDbType.VarChar)
        comand.Parameters("@Estudios").Value = txt_Estudios.Text

        comand.Parameters.Add("@IDpac", Data.SqlDbType.Int)
        comand.Parameters("@IDpac").Value = Request.QueryString("IDpac")

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")


        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./PerfilPaciente.aspx?ID=" + Request.QueryString("IDpac"))
    End Sub
End Class
