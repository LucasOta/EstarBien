﻿Imports System.Data.SqlClient
Partial Class ModificarPlan
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim conn As SqlConnection
            Dim comand As SqlCommand
            Dim lector As SqlDataReader

            conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))

            conn.Open()
            comand = New SqlCommand("SELECT Nombre FROM PlanesOS WHERE ID_Plan = @ID", conn)

            comand.Parameters.Add("@ID", Data.SqlDbType.Int)
            comand.Parameters("@ID").Value = Request.QueryString("ID")
            lector = comand.ExecuteReader
            If lector.Read Then
                txt_Nom.Text = lector("Nombre")
            End If
            conn.Close()
        End If
    End Sub

    Private Sub BTN_Modificar_Click(sender As Object, e As EventArgs) Handles BTN_Modificar.Click
        Dim conn As SqlConnection
        Dim comand As SqlCommand
        conn = New SqlConnection(ConfigurationManager.AppSettings("ConnSTR"))
        conn.Open()
        comand = New SqlCommand("UPDATE PlanesOS SET Nombre = @Nom WHERE ID_Plan = @ID", conn)

        comand.Parameters.Add("@Nom", Data.SqlDbType.VarChar)
        comand.Parameters("@Nom").Value = txt_Nom.Text
        comand.Parameters.Add("@ID", Data.SqlDbType.Int)
        comand.Parameters("@ID").Value = Request.QueryString("ID")

        comand.ExecuteNonQuery()
        conn.Close()
        Response.Redirect("./Planes.aspx?ID=" + Request.QueryString("IDos"))
    End Sub

    Private Sub Cancelar_btn_Click(sender As Object, e As EventArgs) Handles Cancelar_btn.Click
        Response.Redirect("./Planes.aspx?ID=" + Request.QueryString("IDos"))
    End Sub
End Class
