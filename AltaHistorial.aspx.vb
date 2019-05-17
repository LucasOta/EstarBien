Imports System.Data.SqlClient
Partial Class AltaHistorial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO Historiales (Fecha_Inicio, Fecha_Cierre, Kinesiologo, Cant_Sesiones, Motivo, Tratamiento, Estudios, ID_Paciente, Baja) VALUES (@FeIn, @FeCi, @Kin, @Cant, @Motivo, @Trat, @Estudios, @ID, 0)", conn)

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

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./PerfilPaciente.aspx?ID=" + Request.QueryString("ID"))
    End Sub
End Class
