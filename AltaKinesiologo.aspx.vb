Imports System.Data.SqlClient
Partial Class AltaKinesiologo
    Inherits System.Web.UI.Page

    Private Sub Cancelar_btn_Click(sender As Object, e As EventArgs) Handles Cancelar_btn.Click
        Response.Redirect("./ListadoKinesiologos.aspx")
    End Sub

    Private Sub Guardar_btn_Click(sender As Object, e As EventArgs) Handles Guardar_btn.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("INSERT INTO Kinesiologos (NyA, DNI, Direccion, Nacimiento, Numero, Mail, Carrera, Especialidad, Baja) VALUES (@NyA, @DNI, @Dir, @Nac, @Cel, @Email, @Tit, @Esp, 0)", conn)

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


        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./ListadoKinesiologos.aspx")
    End Sub


End Class
