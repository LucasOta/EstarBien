Imports System.Data.SqlClient
Partial Class ModificacionKinesiologo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        Dim lector As SqlDataReader
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

        conn.Open()
        comand = New SqlCommand("SELECT NyA, DNI, Direccion, Nacimiento, Numero, Mail, Carrera, Especialidad, Baja FROM Kinesiologos WHERE ID_Kin = @ID", conn)

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")
        lector = comand.ExecuteReader
        If lector.Read Then
            Dim fecha As String
            txt_NyA.Text = lector("NyA")
            txt_DNI.Text = lector("DNI")
            txt_Dir.Text = lector("Direccion")

            txt_Cel.Text = lector("Numero")
            txt_Email.Text = lector("Mail")
            txt_Titulo.Text = lector("Carrera")
            txt_Especialidad.Text = lector("Especialidad")
        End If
        conn.Close()
    End Sub

    Private Sub Cancelar_btn_Click(sender As Object, e As EventArgs) Handles Cancelar_btn.Click
        Response.Redirect("./ListadoKinesiologos.aspx")
    End Sub

    Private Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("UPDATE Kinesiologos SET NyA = @NyA, DNI = @DNI, Direccion = @Dir, Nacimiento = @Nac, Numero = @Cel, Mail = @Email, Carrera = @Tit, Especialidad = @Esp WHERE ID_Kin = @ID", conn)

        comand.Parameters.Add("@NyA", Data.SqlDbType.VarChar)
        comand.Parameters("@NyA").Value = txt_NyA.Text

        comand.Parameters.Add("@DNI", Data.SqlDbType.Int)
        comand.Parameters("@DNI").Value = Convert.ToInt32(txt_DNI.Text)

        comand.Parameters.Add("@Dir", Data.SqlDbType.VarChar)
        comand.Parameters("@Dir").Value = txt_Dir.Text

        comand.Parameters.Add("@Nac", Data.SqlDbType.Date)
        comand.Parameters("@Nac").Value = Convert.ToDateTime(txt_Nac.Text)

        comand.Parameters.Add("@Cel", Data.SqlDbType.VarChar)
        comand.Parameters("@Cel").Value = txt_Cel.Text

        comand.Parameters.Add("@Email", Data.SqlDbType.VarChar)
        comand.Parameters("@Email").Value = txt_Email.Text

        comand.Parameters.Add("@Tit", Data.SqlDbType.VarChar)
        comand.Parameters("@Tit").Value = txt_Titulo.Text

        comand.Parameters.Add("@Esp", Data.SqlDbType.VarChar)
        comand.Parameters("@Esp").Value = txt_Especialidad.Text

        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./ListadoKinesiologos.aspx")
    End Sub


End Class
