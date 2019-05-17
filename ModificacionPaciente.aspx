<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificacionPaciente.aspx.vb" Inherits="ModificacionPaciente" %>

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
        <h2>Modificar Paciente</h2>
        <br>
        <table class ="table table-hover">
            <tr>
                <th>Nombre y Apellido</th>
                <th>
                    <asp:TextBox ID="txt_NyA" runat="server"></asp:TextBox> 
                    <asp:RegularExpressionValidator ID="val_NyA" runat="server" ValidateRequestMode="Disabled" ValidationExpression="([A-Z][a-z,ñ,á,é,í,ó,ú]{2,11} {0,1}){2,4}" ControlToValidate="txt_NyA">El nombre está mal escrito</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="camp_req_NyA" runat="server" ControlToValidate="txt_NyA" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>DNI</th>
                <th>
                    <asp:TextBox ID="txt_DNI" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_DNI" ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{8}">Está mal escrito</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_DNI" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Localidad</th>
                <th>
                    <asp:DropDownList ID="ddl_Localidad" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddl_Localidad" InitialValue="Seleccionar" ErrorMessage="Por favor seleccione una opción" />
                </th>
            </tr>
            <tr>
                <th>Domicilio</th>
                <th>
                    <asp:TextBox ID="txt_Dir" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="camp_req_Dir" runat="server" ControlToValidate="txt_Dir" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Nacimiento</th>
                <th>
                    <asp:TextBox ID="txt_Nac" TextMode="Date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Nac" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Celular</th>
                <th>
                    <asp:TextBox ID="txt_Cel" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="val_Cel" runat="server" ValidateRequestMode="Disabled" ValidationExpression="\d{4} \d{6}" ControlToValidate="txt_Cel">El teléfono está mal escrito</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="camp_req_Cel" runat="server" ControlToValidate="txt_Cel" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Email</th>
                <th>
                    <asp:TextBox ID="txt_Email" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="val_Email" runat="server" ValidateRequestMode="Disabled" ValidationExpression="^([0-9a-zA-Z]+[-._+&amp;])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$" ControlToValidate="txt_Email">El mail está mal escrito</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="camp_req_Email" runat="server" ControlToValidate="txt_Email" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                </th>
            </tr>
            <tr>
                <th>Obra Social</th>
                <th>
                    <asp:DropDownList ID="ddl_OSocial" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_OSocial" InitialValue="Seleccionar" ErrorMessage="Por favor seleccione una opción" />
                </th>
            </tr>
            <tr>
                <th>Plan</th>
                <th>
                    <asp:DropDownList ID="ddl_PlanOs" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_PlanOs" InitialValue="Seleccionar" ErrorMessage="Por favor seleccione una opción" />
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