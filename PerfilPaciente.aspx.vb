Imports System.Data.SqlClient
Partial Class PerfilPaciente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader
            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

            Dim ob_Soc As Int32
            Dim plan As Int32
            conn.Open()
            comand = New SqlCommand("SELECT NyA, DNI, Localidad, Domicilio, Nacimiento, Celular, Email, ID_ObraSocial, ID_PlanOS, Baja FROM Pacientes WHERE Id_Paciente = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            If lector.Read Then
                Dim fecha As String
                nombre_lbl.Text = lector("NyA")
                dni_lbl.Text = lector("DNI")
                localidad_lbl.Text = lector("Localidad")
                domicilio_lbl.Text = lector("Domicilio")
                fecha = Convert.ToDateTime(lector("Nacimiento")).Day.ToString + "/"
                fecha += Convert.ToDateTime(lector("Nacimiento")).Month.ToString + "/"
                fecha += Convert.ToDateTime(lector("Nacimiento")).Year.ToString
                nac_lbl.Text = fecha
                num_lbl.Text = lector("Celular")
                email_lbl.Text = lector("Email")
                ob_Soc = lector("ID_ObraSocial")
                plan = lector("ID_PlanOS")
            End If
            conn.Close()

            conn.Open()
            comand = New SqlCommand("SELECT Nombre FROM ObrasSociales WHERE ID_ObraSocial = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = ob_Soc
            lector = comand.ExecuteReader
            If lector.Read Then
                obsoc_lbl.Text = lector("Nombre")
            End If
            conn.Close()

            conn.Open()
            comand = New SqlCommand("SELECT Nombre FROM PlanesOS WHERE ID_Plan = @ID", conn)
            comand.Parameters.Add("@ID", Data.SqlDbType.VarChar)
            comand.Parameters("@ID").Value = plan
            lector = comand.ExecuteReader
            If lector.Read Then
                plan_lbl.Text = lector("Nombre")
            End If
            conn.Close()

            conn.Open()
            comand = New SqlCommand("SELECT ID_Historial, ID_Paciente, Fecha_Inicio, Fecha_Cierre, Kinesiologo, Cant_Sesiones, Motivo, Tratamiento, Estudios FROM Historiales WHERE ID_Paciente = @ID AND Baja = 0 ORDER BY Fecha_Inicio", conn)
            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")

            lector = comand.ExecuteReader

            Repeater1.DataSource = lector
                Repeater1.DataBind()


        End If
    End Sub

    Private Sub BTN_Agregar_Click(sender As Object, e As EventArgs) Handles BTN_Agregar.Click
        Response.Redirect("./AltaHistorial.aspx?ID=" + Request.QueryString("ID"))
    End Sub
End Class
