<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ListadoKinesiologos.aspx.vb" Inherits="ListadoKinesiologos" %>

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
					<a class="nav-link" href=".\ObrasSociales.aspx" target= "_self">Obras Sociales</a>			</li>
				<li class="nav-item active">
					<a class="nav-link" href="#" target= "_self">Kinesiologos</a>
				</li>
                <li class="nav-item">
					<a class="nav-link" href="./Turnos.aspx?Ver=1" target= "_self">Turnos</a>
				</li>
			</ul>
		</div>
	</nav>

    <form id="form1" runat="server">
        <h2>Kinesiologos</h2>
        </br>
        <div>
            <asp:Button ID="BTN_Agregar" CssClass="btn btn-outline-dark" runat="server" Text="Agregar Kinesiologo" />
        </div>
     
                <table class ="table table-hover">
                  <tr>
                    <th>Nombre y Apellido</th>
                    <th>DNI</th>
                    <th>Número</th>
                    <th>Email</th>
                    <th></th>
                    <th></th>
                  </tr>
          
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItem("NyA") %></td>
                                <td><%#Container.DataItem("DNI") %></td>
                                <td><%#Container.DataItem("Numero") %></td>
                                <td><%#Container.DataItem("Mail") %></td>
                                <td><a href="./ModificacionKinesiologo.aspx?ID=<%#Container.DataItem("ID_Kin")%>">Modificar</a></td>
                                <td><a href="./BajaKinesiologo.aspx?ID=<%#Container.DataItem("ID_Kin")%>" OnClick="if (! confirm('¿Está seguro que desa borrar al Kinesiologo?')) return false;">Eliminar</a> </td>
                                
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>

    </form>
</body>
</html>