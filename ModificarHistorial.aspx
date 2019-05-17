<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificarHistorial.aspx.vb" Inherits="ModificarHistorial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Estar Bien</title>
    <link rel="shortcut icon" href="./Imagenes/logo.png" />
    <link rel="stylesheet" type="text/css" href="Estilo.css"/>
	<meta charset="utf-8"/>
	<meta name="viewport" content="width=device-width, initial-scale=1"/>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
</head>
<body>

    <nav class="navbar navbar-expand-lg navbar-dark bg-inverse" id="nav">
		<a class="navbar-brand titulo" href="#">Estar Bien</a>
		<button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
			<span class="navbar-toggler-icon"></span>
		</button>

		<div class="collapse navbar-collapse" id="navbarSupportedContent">
			<ul class="navbar-nav mr-auto">
				<li class="nav-item ">
					<a class="nav-link" href=".\Inicio.aspx" target="_self">Inicio <span class="sr-only">(current)</span></a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href=".\ListadoPacientes.aspx" target="_self">Pacientes</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href=".\ObrasSociales.aspx" target= "_self">Obras Sociales</a>			</li>
				<li class="nav-item">
					<a class="nav-link" href="./ListadoKinesiologos.aspx" target= "_self">Kinesiologos</a>
				</li>
                <li class="nav-item">
					<a class="nav-link" href="./Turnos.aspx?Ver=1" target= "_self">Turnos</a>
				</li>
			</ul>
		</div>
	</nav>

    <form id="form1" runat="server">
        <h2>Agregar Elemento a Historial</h2>
        <br>
        <table class ="table table-hover">
            <tr>
                <th>Fecha Inicio</th>
                <th>
                    <asp:TextBox ID="txt_fInicio" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_fInicio" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Fecha Cierre</th>
                <th>
                    <asp:TextBox ID="txt_fCierre" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_fCierre" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Kinesiologo</th>
                <th>
                    <asp:TextBox ID="txt_Kinesiologo" runat="server" MaxLength="49"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="camp_req_Dir" runat="server" ControlToValidate="txt_Kinesiologo" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Cantidad de Sesiones</th>
                <th>
                    <asp:TextBox ID="txt_CantSesiones" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="exSesiones" runat="server" ValidateRequestMode="Disabled" ValidationExpression="\d{0,3}" ControlToValidate="txt_CantSesiones">Número inválido.</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="camp_req_Ses" runat="server" ControlToValidate="txt_CantSesiones" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Motivo</th>
                <th>
                    <asp:TextBox ID="txt_Motivo" runat="server" MaxLength="249"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Motivo" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Tratamientos</th>
                <th>
                    <asp:TextBox ID="txt_Tratamientos" runat="server" MaxLength="249"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Tratamientos" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Estudios</th>
                <th>
                    <asp:TextBox ID="txt_Estudios" runat="server" MaxLength="249"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Estudios" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
        </table>

        <br />
        <asp:Button CssClass="btn btn-outline-dark" ID="Guardar_btn" runat="server" Text="Guardar" />
        <asp:Button CssClass="btn btn-outline-dark" ID="Cancelar_btn" runat="server" Text="Cancelar" CausesValidation="false" />
        <br />
    
    </form>
</body>
</html>