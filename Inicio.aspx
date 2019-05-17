<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Inicio.aspx.vb" Inherits="Inicio" %>

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
				<li class="nav-item active">
					<a class="nav-link" href="#" target="_self">Inicio <span class="sr-only">(current)</span></a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href=".\ListadoPacientes.aspx" target="_self">Pacientes</a>
				</li>
				<li class="nav-item">
					<a class="nav-link" href=".\ObrasSociales.aspx" target= "_self">Obras Sociales</a>
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
        
        <h4>Pacientes por Obra Social</h4>
        <div class="row">
		    <div class="col-md-6 ">
                <table class ="table table-hover">
                  <tr>
                    <th>Obra Social</th>
                    <th>Cantidad de Pacientes</th>
                  </tr>
          
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Container.DataItem("ID_ObraSocial") %></td>
                                <td><%#Container.DataItem("cantPac") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </table>
            </div>
        </div>
    </form>
</body>
</html>
