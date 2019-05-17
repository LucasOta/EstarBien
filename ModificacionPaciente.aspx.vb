Imports System.Data.SqlClient
Partial Class ModificacionPaciente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader

            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

            'Cargo las Localidades'
            conn.Open()
            comand = New SqlCommand("SELECT * FROM Localidades;", conn)
            lector = comand.ExecuteReader

            ddl_Localidad.DataSource = lector
            ddl_Localidad.DataValueField = "Nombre"
            ddl_Localidad.DataTextField = "Nombre"

            ddl_Localidad.DataBind()
            ddl_Localidad.Items.Insert(0, New ListItem("", 0))
            conn.Close()

            'Cargo Obras Sociales'
            conn.Open()
            comand = New SqlCommand("SELECT * FROM ObrasSociales WHERE Baja=0;", conn)
            lector = comand.ExecuteReader

            ddl_OSocial.DataSource = lector
            ddl_OSocial.DataValueField = "ID_ObraSocial"
            ddl_OSocial.DataTextField = "Nombre"

            ddl_OSocial.DataBind()
            ddl_OSocial.Items.Insert(0, New ListItem("", 0))
            conn.Close()

            conn.Open()
            comand = New SqlCommand("SELECT NyA, DNI, Localidad, Domicilio, Nacimiento, Celular, Email, ID_ObraSocial, ID_PlanOS, Baja FROM Pacientes WHERE Id_Paciente = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            If lector.Read Then

                txt_NyA.Text = lector("NyA")
                txt_DNI.Text = lector("DNI")
                ddl_Localidad.SelectedValue = lector("Localidad")
                txt_Dir.Text = lector("Domicilio")

                txt_Nac.Text = formatoFecha(Convert.ToDateTime(lector("Nacimiento")))
                txt_Cel.Text = lector("Celular")
                txt_Email.Text = lector("Email")
                ddl_OSocial.SelectedValue = lector("ID_ObraSocial")
                ddl_OSocial_SelectedIndexChanged(ddl_OSocial, e)
                ddl_PlanOs.SelectedValue = lector("ID_PlanOS")
            End If
            conn.Close()
        End If
    End Sub

    Private Sub ddl_OSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_OSocial.SelectedIndexChanged

        Dim conn As SqlConnection
        Dim comand As SqlCommand
        Dim lector As SqlDataReader

        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

        conn.Open()
        comand = New SqlCommand("SELECT * FROM PlanesOS WHERE ID_ObraSocial = @IdOS ;", conn)
        comand.Parameters.AddWithValue("@IdOS", ddl_OSocial.SelectedValue)
        lector = comand.ExecuteReader

        ddl_PlanOs.DataSource = lector
        ddl_PlanOs.DataValueField = "ID_Plan"
        ddl_PlanOs.DataTextField = "Nombre"

        ddl_PlanOs.DataBind()
        conn.Close()
    End Sub



    Protected Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("UPDATE Pacientes SET NyA = @NyA, DNI = @DNI, Localidad = @Loc, Domicilio = @Dir, Nacimiento = @Nac, Celular = @Cel, Email = @Email, ID_ObraSocial = @ObSoc, ID_PlanOS = @PlanOS WHERE Id_Paciente = @ID", conn)

        comand.Parameters.Add("@NyA", Data.SqlDbType.VarChar)
        comand.Parameters("@NyA").Value = txt_NyA.Text

        comand.Parameters.Add("@DNI", Data.SqlDbType.Int)
        comand.Parameters("@DNI").Value = Convert.ToInt32(txt_DNI.Text)

        comand.Parameters.Add("@Loc", Data.SqlDbType.VarChar)
        comand.Parameters("@Loc").Value = ddl_Localidad.SelectedValue

        comand.Parameters.Add("@Dir", Data.SqlDbType.VarChar)
        comand.Parameters("@Dir").Value = txt_Dir.Text

        comand.Parameters.Add("@Nac", Data.SqlDbType.Date)
        comand.Parameters("@Nac").Value = Convert.ToDateTime(txt_Nac.Text)

        comand.Parameters.Add("@Cel", Data.SqlDbType.VarChar)
        comand.Parameters("@Cel").Value = txt_Cel.Text

        comand.Parameters.Add("@Email", Data.SqlDbType.VarChar)
        comand.Parameters("@Email").Value = txt_Email.Text

        comand.Parameters.Add("@ObSoc", Data.SqlDbType.Int)
        comand.Parameters("@ObSoc").Value = ddl_OSocial.SelectedValue

        comand.Parameters.Add("@PlanOS", Data.SqlDbType.Int)
        comand.Parameters("@PlanOS").Value = ddl_PlanOs.SelectedValue

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")


        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./ListadoPacientes.aspx")
    End Sub

    Private Sub Cancelar_btn_Click(sender As Object, e As EventArgs) Handles Cancelar_btn.Click
        Response.Redirect("./ListadoPacientes.aspx")
    End Sub

    Public Function formatoFecha(fecha_or As DateTime) As String
        Dim fecha As String
        Dim mes As Int32
        Dim dia As Int32
        fecha = fecha_or.Year.ToString + "-"
        mes = fecha_or.Month
        If mes < 10 Then
            fecha += "0" + mes.ToString

        Else
            fecha += mes.ToString
        End If
        fecha += "-"
        dia = fecha_or.Day
        If dia < 10 Then
            fecha += "0" + dia.ToString
        Else
            fecha += dia.ToString
        End If
        Return fecha
    End Function
End Class
