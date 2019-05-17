Imports System.Data.SqlClient
Partial Class AltaPaciente
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
            ddl_Localidad.Items.Insert(0, "Seleccionar")
            conn.Close()

            'Cargo Obras Sociales'
            conn.Open()
            comand = New SqlCommand("SELECT * FROM ObrasSociales WHERE Baja=0;", conn)
            lector = comand.ExecuteReader

            ddl_OSocial.DataSource = lector
            ddl_OSocial.DataValueField = "ID_ObraSocial"
            ddl_OSocial.DataTextField = "Nombre"

            ddl_OSocial.DataBind()
            ddl_OSocial.Items.Insert(0, "Seleccionar")
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
        ddl_PlanOs.Items.Insert(0, "Seleccionar")
        conn.Close()
    End Sub

    Protected Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO Pacientes (NyA, DNI, Localidad, Domicilio, Nacimiento, Celular, Email, ID_ObraSocial, ID_PlanOS, Baja) VALUES (@NyA, @DNI, @Loc, @Dir, @Nac, @Cel, @Email, @ObSoc, @PlanOS, 0)", conn)

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



        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./ListadoPacientes.aspx")
    End Sub

    Private Sub Cancelar_btn_Click(sender As Object, e As EventArgs) Handles Cancelar_btn.Click
        Response.Redirect("./ListadoPacientes.aspx")
    End Sub

    Private Sub agregarLoc_btn_Click(sender As Object, e As EventArgs) Handles agregarLoc_btn.Click
        Response.Redirect("./AltaLocalidad.aspx")
    End Sub
End Class
