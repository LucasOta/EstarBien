<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificarPlan.aspx.vb" Inherits="ModificarPlan" %>

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
				<li class="nav-item">
					<a class="nav-link" href=".\Inicio.aspx" target="_self">Inicio <span class="sr-only">(current)</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href=".\ListadoPacientes.aspx" target="_self">Pacientes</a>
				</li>
				<li class="nav-item active">
					<a class="nav-link" href="#" target= "_self">Obras Sociales</a>
				</li>
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
    <h2>Obras Sociales</h2>
        </br>
        <h4>Modificar Obra Social</h4>
        </br>
        <div class="row">
		    <div class="col-md-6 ">
                <table class ="table ">
                    <tr>
                        <td>Nombre</td>
                        <td>
                            <asp:TextBox ID="txt_Nom" runat="server"></asp:TextBox> 
                            <asp:RegularExpressionValidator ID="val_Nom" runat="server" ValidateRequestMode="Disabled" ValidationExpression="([A-Z][A-Z,a-z,ñ,á,é,í,ó,ú]{1,20} {0,1}){1,4}" ControlToValidate="txt_Nom">El nombre está mal escrito</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="camp_req_Nom" runat="server" ControlToValidate="txt_Nom" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:Button ID="BTN_Modificar" CssClass="btn btn-outline-dark" runat="server" Text="Modificar Plan" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:Button CssClass="btn btn-outline-dark" ID="Cancelar_btn" runat="server" Text="Cancelar" CausesValidation="false" />
    </form>
</body>
</html>