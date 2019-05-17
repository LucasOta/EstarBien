Imports System.Data.SqlClient
Partial Class ModificarTurno
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader

            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

            'Cargo los pacientes'
            conn.Open()
            comand = New SqlCommand("SELECT Id_Paciente, NyA FROM Pacientes ORDER BY NyA", conn)
            lector = comand.ExecuteReader

            ddl_Pac.DataSource = lector
            ddl_Pac.DataValueField = "Id_Paciente"
            ddl_Pac.DataTextField = "NyA"

            ddl_Pac.DataBind()
            ddl_Pac.Items.Insert(0, "Seleccionar")
            conn.Close()

            'Cargo los Kinesiologos'
            conn.Open()
            comand = New SqlCommand("SELECT ID_Kin, NyA FROM Kinesiologos ORDER BY NyA", conn)
            lector = comand.ExecuteReader

            ddl_Kin.DataSource = lector
            ddl_Kin.DataValueField = "ID_Kin"
            ddl_Kin.DataTextField = "NyA"

            ddl_Kin.DataBind()
            ddl_Kin.Items.Insert(0, "Seleccionar")
            conn.Close()

            'Cargo el turno'
            conn.Open()
            comand = New SqlCommand("SELECT * FROM Turnos WHERE ID_Turno = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            If lector.Read Then
                ddl_Pac.SelectedValue = lector("ID_Paciente")
                ddl_Kin.SelectedValue = lector("ID_Kinesiologo")
                lbl_fecha_ant.Text = lector("FechaHora").ToString
                txt_Obs.Text = lector("Observacion")
            End If
            conn.Close()
        End If
    End Sub

    Private Sub cancelar_btn_Click(sender As Object, e As EventArgs) Handles cancelar_btn.Click
        Response.Redirect("./Turnos.aspx?Ver=1")
    End Sub

    Private Sub Modificar_btn_Click(sender As Object, e As EventArgs) Handles Modificar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("UPDATE Turnos SET ID_Paciente = @IDpac, ID_Kinesiologo = @IDkin, Nom_Paciente = @Npac, Nom_Kinesiologo = @Nkin, FechaHora = @FechaHora, Fecha = @Fecha, Observacion = @Obs, Baja = 0 WHERE ID_Turno = @ID", conn)

        comand.Parameters.Add("@IDpac", Data.SqlDbType.Int)
        comand.Parameters("@IDpac").Value = Convert.ToInt32(ddl_Pac.SelectedValue)

        comand.Parameters.Add("@IDkin", Data.SqlDbType.Int)
        comand.Parameters("@IDkin").Value = Convert.ToInt32(ddl_Kin.SelectedValue)

        comand.Parameters.Add("@Npac", Data.SqlDbType.VarChar)
        comand.Parameters("@Npac").Value = ddl_Pac.Items.FindByValue(ddl_Pac.SelectedValue).ToString

        comand.Parameters.Add("@Nkin", Data.SqlDbType.VarChar)
        comand.Parameters("@Nkin").Value = ddl_Kin.Items.FindByValue(ddl_Kin.SelectedValue).ToString


        Dim fecha As String
        fecha = txt_Fecha.Text.ToString.Replace(" 00:00:00", "")
        fecha += " " + txt_Hora.Text
        comand.Parameters.Add("@FechaHora", Data.SqlDbType.DateTime)
        comand.Parameters("@FechaHora").Value = Convert.ToDateTime(fecha)

        comand.Parameters.Add("@Fecha", Data.SqlDbType.Date)
        comand.Parameters("@Fecha").Value = Convert.ToDateTime(txt_Fecha.Text)

        comand.Parameters.Add("@Obs", Data.SqlDbType.VarChar)
        comand.Parameters("@Obs").Value = txt_Obs.Text

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./Turnos.aspx?Ver=1")
    End Sub

End Class
