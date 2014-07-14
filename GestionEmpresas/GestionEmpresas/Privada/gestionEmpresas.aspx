<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="gestionEmpresas.aspx.cs" Inherits="GestionEmpresas.Privada.gestionEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="col-md-1"></div>
        <div class="col-md-3">
            <div class="form-horizontal">
                <div class="form-group">
                    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="bBusqueda" runat="server" Text="Busqueda avanzada" />
                </div>
            </div>
        </div>
        <div class="col-md-4">

        </div>
        <div class="col-md-3">
            <asp:Button ID="bAniadirEmpresa" CssClass="btn btn-primary" runat="server" Text="Add Company" />
        </div>
        <div class="col-md-1"></div>
    </div>
    <div class="container-fluid">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvEmpresas" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="gvEmpresas_SelectedIndexChanged" EmptyDataText="No hay empresas en la BD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="nombreComercial" HeaderText="Nombre" />
                            <asp:BoundField DataField="cif" HeaderText="CIF" />
                            <asp:BoundField DataField="Sector" HeaderText="Sector" />
                            <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                            <asp:BoundField DataField="web" HeaderText="Web" />
                            <asp:ButtonField ButtonType="Button" Text="Contactos">
                            <ControlStyle CssClass="btn btn-warning" />
                            </asp:ButtonField>
                            <asp:CommandField ButtonType="Button" EditText="Editar" ShowCancelButton="False" ShowEditButton="True">
                            <ControlStyle CssClass="btn btn-primary" />
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Button" DeleteText="Borrar" ShowDeleteButton="True">
                            <ControlStyle CssClass="btn btn-danger" />
                            </asp:CommandField>
                            <asp:CommandField ButtonType="Button" SelectText="Seleccionar" ShowCancelButton="False" ShowSelectButton="True">
                            <ControlStyle CssClass="btn btn-default" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-1"></div>
    </div>
    <div class="container-fluid">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <fieldset>
                <legend>Empresa</legend>
                <div class="container-fluid">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="col-md-4">
                                <asp:GridView ID="gvTelefonos" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="False">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <Columns>
                                        <asp:BoundField DataField="numero" HeaderText="Numero" />
                                        <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowEditButton="True">
                                        <ControlStyle CssClass="btn btn-primary" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Button" DeleteText="Borrar" ShowDeleteButton="True">
                                        <ControlStyle CssClass="btn btn-danger" />
                                        </asp:CommandField>
                                    </Columns>
                                    <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                </asp:GridView>
                            </div>
                            <div class="col-md-4">
                                <asp:GridView ID="gvEmails" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                </asp:GridView>
                            </div>
                            <div class="col-md-4">
                                <asp:GridView ID="gvDirecciones" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="container-fluid">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Button ID="btnAddTelefono" CssClass="btn btn-primary" runat="server" Text="Añadir Telefono" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnAddEmail" CssClass="btn btn-primary" runat="server" Text="Añadir Email" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnAddDireccion" CssClass="btn btn-primary" runat="server" Text="Añadir Direccion" />
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </fieldset>
        </div>
        <div class="col-md-1"></div>
    </div>
</asp:Content>