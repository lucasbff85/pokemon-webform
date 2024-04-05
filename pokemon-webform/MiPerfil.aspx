<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="pokemon_webform.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .validacion{
            color: red;
            font-size: 12px;
        }
    </style>
    <script>
        function validar() {
            //capturar el control
            const txtNombre = documen.getElementById("txtNombre");
            const txtApellido = document.getElementById("txtApellido");
            if (txtApellido.value == "") {
                //alert("Debes cargar el apellido");
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                txtNombre.classList.add("is-invalid");
                txtNombre.classList.remove("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            txtNombre.classList.remove("is-invalid");
            txtNombre.classList.add("is-valid");
            return true;
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                <%--<asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control" ID="txtApellido" />
                <%--<asp:RegularExpressionValidator ErrorMessage="errormessage" ControlToValidate="txtApellido" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
                <%--este input es de html, pero le podemos agregar la propiedad runat="server, la cual nos da la posibilidad de contar con el elemento en el code behind--%>
            </div>
            <asp:Image ImageUrl="data:image/jpeg;base64,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" 
                ID="imgNuevoPerfil" runat="server" CssClass="img-fluid mb-3" />
            <%--usamos una img de asp, porque si ponemos la de html, desp hay que incrustar codigo de c# para manejar la url--%>
        </div>

    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClientClick="return validar()" OnClick="btnGuardar_Click" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
