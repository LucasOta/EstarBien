Imports System.Data.SqlClient
Partial Class Turnos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
            conn.Open()

            Select Case Request.QueryString("Ver")
                Case 1
                    comand = New SqlCommand("SELECT ID_Turno, ID_Paciente, ID_Kinesiologo, Nom_Paciente, Nom_Kinesiologo, FechaHora, Fecha, Observacion FROM Turnos WHERE Baja = 0 ORDER BY FechaHora", conn)

                Case 2
                    comand = New SqlCommand("SELECT ID_Turno, ID_Paciente, ID_Kinesiologo, Nom_Paciente, Nom_Kinesiologo, FechaHora, Fecha, Observacion FROM Turnos WHERE Baja = 0 AND Fecha = @Fecha ORDER BY FechaHora", conn)
                    comand.Parameters.Add("@Fecha", Data.SqlDbType.DateTime)
                    comand.Parameters("@Fecha").Value = Convert.ToDateTime(Request.QueryString("Fecha"))
                Case 3
                    comand = New SqlCommand("SELECT ID_Turno, ID_Paciente, ID_Kinesiologo, Nom_Paciente, Nom_Kinesiologo, FechaHora, Fecha, Observacion FROM Turnos WHERE Baja = 0 AND ID_Kinesiologo = @Kin ORDER BY FechaHora", conn)
                    comand.Parameters.Add("@Kin", Data.SqlDbType.Int)
                    comand.Parameters("@Kin").Value = Request.QueryString("Kin")
                Case 4
                    comand = New SqlCommand("SELECT ID_Turno, ID_Paciente, ID_Kinesiologo, Nom_Paciente, Nom_Kinesiologo, FechaHora, Fecha, Observacion FROM Turnos WHERE Baja = 0 AND ID_Kinesiologo = @Kin AND Fecha = @Fecha ORDER BY FechaHora", conn)
                    comand.Parameters.Add("@Kin", Data.SqlDbType.Int)
                    comand.Parameters("@Kin").Value = Request.QueryString("Kin")
                    comand.Parameters.Add("@Fecha", Data.SqlDbType.DateTime)
                    comand.Parameters("@Fecha").Value = Convert.ToDateTime(Request.QueryString("Fecha"))
            End Select
            lector = comand.ExecuteReader
            Repeater1.DataSource = lector
            Repeater1.DataBind()

            conn.Close()

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

            'Cargo los Kinesiologos(Filtro)'
            conn.Open()
            comand = New SqlCommand("SELECT ID_Kin, NyA FROM Kinesiologos ORDER BY NyA", conn)
            lector = comand.ExecuteReader

            ddl_filtro.DataSource = lector
            ddl_filtro.DataValueField = "ID_Kin"
            ddl_filtro.DataTextField = "NyA"

            ddl_filtro.DataBind()
            ddl_filtro.Items.Insert(0, "Seleccionar")
            conn.Close()
        End If
    End Sub

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO Turnos (ID_Paciente, ID_Kinesiologo, Nom_Paciente, Nom_Kinesiologo, FechaHora, Fecha, Observacion, Baja) VALUES (@IDpac, @IDkin, @Npac, @Nkin, @FechaHora, @Fecha, @Obs, 0)", conn)


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

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./Turnos.aspx?Ver=1")
    End Sub

    Private Sub filtrar_btn_Click(sender As Object, e As EventArgs) Handles filtrar_btn.Click
        Dim fecha As Boolean
        fecha = False
        Dim kin As Boolean
        kin = False
        If txt_Filtro.Text IsNot "" Then
            fecha = True
        End If

        If Not ddl_filtro.SelectedIndex = 0 Then
            kin = True
        End If
        If fecha And kin Then
            Response.Redirect("./Turnos.aspx?Ver=4&Fecha=" + txt_Filtro.Text.Replace(" ", "") + "&Kin=" + ddl_filtro.SelectedValue)
        ElseIf fecha Then
            Response.Redirect("./Turnos.aspx?Ver=2&Fecha=" + txt_Filtro.Text.Replace(" ", ""))
        ElseIf kin Then
            Response.Redirect("./Turnos.aspx?Ver=3&Kin=" + ddl_filtro.SelectedValue)
        End If
    End Sub
End Class
