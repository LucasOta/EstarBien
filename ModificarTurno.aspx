<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ModificarTurno.aspx.vb" Inherits="ModificarTurno" %>

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
				<li class="nav-item">
					<a class="nav-link" href="#" target= "_self">Obras Sociales</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href="./ListadoKinesiologos.aspx" target= "_self">Kinesiologos</a>
				</li>
                <li class="nav-item active">
					<a class="nav-link" href="./Turnos.aspx?Ver=1" target= "_self">Turnos</a>
				</li>
			</ul>
		</div>
	</nav>

    <form id="form1" runat="server">
    <h2>Turnos</h2>
        </br>
        <h3>Modificar Turno</h3>
        <div>
            <table class ="table table-hover">
                  <tr>
                    <th>Fecha y Hora</th>
                    <th>Paciente</th>
                    <th>Kinesiologo</th>
                    <th>Observaciones</th>
                    <th></th>
                   </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txt_Fecha" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:TextBox ID="txt_Hora" runat="server" TextMode="Time"></asp:TextBox>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Pac" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_Kin" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Obs" runat="server"> </asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="Modificar_btn" CssClass="btn btn-outline-dark" runat="server" Text="Modificar" />
                        </td>
                    </tr>
                    <tr>
                        
                            
                       
                        <td>
                            <asp:Label ID="lbl_fecha_ant" runat="server" Text="Label"></asp:Label></br>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Fecha" ErrorMessage="RequiredFieldValidator">Falta la fecha.</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_Hora" ErrorMessage="RequiredFieldValidator">Falta la hora.</asp:RequiredFieldValidator>
                        </td>
                        <td><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddl_Pac" InitialValue="Seleccionar" ErrorMessage="Por favor seleccione una opción" /></td>
                        <td><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="ddl_Kin" InitialValue="Seleccionar" ErrorMessage="Por favor seleccione una opción" /></td>
                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Obs" ErrorMessage="RequiredFieldValidator">Por favor complete este campo.</asp:RequiredFieldValidator></td>
                   
                    </tr>
            </table>
            <asp:Button ID="cancelar_btn" CssClass="btn btn-outline-dark" runat="server" Text="Cancelar" />
        </form>
</body>
</html>