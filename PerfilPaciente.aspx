<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PerfilPaciente.aspx.vb" Inherits="PerfilPaciente" %>

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
    </br>
    <h2><asp:Label ID="nombre_lbl" runat="server" Text="Label"></asp:Label></h2>
    </br>
    <form id="form1" runat="server">
    <div>
     <table class ="table table-hover">
            <tr>
                <th>DNI</th>
                <td>
                    <asp:Label ID="dni_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Nacimiento</th>
                <td>
                    <asp:Label ID="nac_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Número</th>
                <td>
                    <asp:Label ID="num_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Localidad</th>
                <td>
                    <asp:Label ID="localidad_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Domicilio</th>
                <td>
                    <asp:Label ID="domicilio_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Email</th>
                <td>
                    <asp:Label ID="email_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Obra Social</th>
                <td>
                    <asp:Label ID="obsoc_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Plan</th>
                <td>
                    <asp:Label ID="plan_lbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
           
     </table>
    </div>
    </br>
    <h3>Historial</h3> <asp:Button ID="BTN_Agregar" CssClass="btn btn-outline-dark" runat="server" Text="Agregar Elemento" />
    </br>
        <table class ="table table-hover">
                  <tr>
                    <th>Fecha Inicio</th>
                    <th>Fecha Cierre</th>
                    <th>Kinesiologo</th>
                    <th>Sesiones</th>
                    <th>Motivo</th>
                    <th>Tratamiento</th>
                    <th>Estudios</th>
                    <th></th>
                  </tr>
                  <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItem("Fecha_Inicio").ToString.Replace(" 00:00:00", "") %></td>
                                <td><%#Container.DataItem("Fecha_Cierre").ToString.Replace(" 00:00:00", "") %></td>
                                <td><%#Container.DataItem("Kinesiologo") %></td>
                                <td><%#Container.DataItem("Cant_Sesiones") %></td>
                                <td><%#Container.DataItem("Motivo") %></td>
                                <td><%#Container.DataItem("Tratamiento") %></td>
                                <td><%#Container.DataItem("Estudios") %></td>
                                <td><a href="./BajaHistorial.aspx?ID=<%#Container.DataItem("ID_Historial")%>&IDpac=<%#Container.DataItem("ID_Paciente")%>">Eliminar</a></td>
                                <td><a href="./ModificarHistorial.aspx?ID=<%#Container.DataItem("ID_Historial")%>&IDpac=<%#Container.DataItem("ID_Paciente")%>">Modificar</a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>           
     </table>
    </form>
</body>
</html>
