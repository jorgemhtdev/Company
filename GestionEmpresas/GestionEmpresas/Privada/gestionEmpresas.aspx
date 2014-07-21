<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="gestionEmpresas.aspx.cs" Inherits="GestionEmpresas.Privada.gestionEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
            
                <div class="form col-md-8">
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbCif" runat="server" Text="Cif"></asp:Label>
                        <asp:TextBox ID="txtCif" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbSector" runat="server" Text="Sector"></asp:Label>
                        <asp:TextBox ID="txtSector" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbProvincia" runat="server" Text="Provincia"></asp:Label>
                        <asp:TextBox ID="txtProvincia" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group col-md-2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="bBusqueda" CssClass="btn btn-primary pull-left" runat="server" Text="Buscar" OnClick="bBusqueda_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            <div class="col-md-2">
                <asp:Button ID="bAniadirEmpresa" CssClass="btn btn-primary pull-right" runat="server" Text="Añadir Empresa" OnClick="bAniadirEmpresa_Click" />
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvEmpresas" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="gvEmpresas_SelectedIndexChanged" EmptyDataText="No hay empresas en la BD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowCommand="gvEmpresas_RowCommand" OnRowDeleting="gvEmpresas_RowDeleting" OnRowEditing="gvEmpresas_RowEditing">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombreComercial" HeaderText="Nombre" />
                                <asp:BoundField DataField="cif" HeaderText="CIF" />
                                <asp:BoundField DataField="sector" HeaderText="Sector" />
                                <asp:BoundField DataField="razonSocial" HeaderText="Razon Social" />
                                <asp:BoundField DataField="web" HeaderText="Web" />
                                <asp:ButtonField CommandName="contactos" Text="Contactos">
                                </asp:ButtonField>
                                <asp:CommandField EditText="Editar" ShowCancelButton="False" ShowEditButton="True">
                                </asp:CommandField>
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                                </asp:CommandField>
                                <asp:CommandField SelectText="Ver" ShowCancelButton="False" ShowSelectButton="True">
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                           <div class="panel panel-default" id="panel" runat="server">
                            <div class="panel-body">
                                <div class="col-md-3 text-right">
                                    <asp:Button ID="btnAddTelefono" CssClass="btn btn-primary" runat="server" Text="Añadir Telefono" OnClick="btnAddTelefono_Click" />
                                </div>
                                <div class="col-md-4 text-right">
                                    <asp:Button ID="btnAddEmail" CssClass="btn btn-primary" runat="server" Text="Añadir Email" OnClick="btnAddEmail_Click" />
                                </div>
                                <div class="col-md-5 text-right">
                                    <asp:Button ID="btnAddDireccion" CssClass="btn btn-primary" runat="server" Text="Añadir Direccion" OnClick="btnAddDireccion_Click" />
                                </div>
                                <div class="col-md-3">
                                    <asp:GridView ID="gvTelefonos" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="gvTelefonos_RowDeleting" OnRowEditing="gvTelefonos_RowEditing">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:BoundField DataField="numero" HeaderText="Numero" />
                                            <asp:CommandField ShowCancelButton="False" ShowEditButton="True">
                                            </asp:CommandField>
                                            <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                                            </asp:CommandField>
                                        </Columns>
                                        <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                    </asp:GridView>               
                                </div>
                                <div class="col-md-4">
                                    <asp:GridView ID="gvEmails" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="gvEmails_RowDeleting" OnRowEditing="gvEmails_RowEditing">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:BoundField DataField="correo" HeaderText="Correo" />
                                            <asp:CommandField EditText="Editar" ShowEditButton="True" />
                                            <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" />
                                         </Columns>
                                        <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                    </asp:GridView>
                                </div>
                                <div class="col-md-5">
                                    <asp:GridView ID="gvDirecciones" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="gvDirecciones_RowDeleting" OnRowEditing="gvDirecciones_RowEditing">
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                        <Columns>
                                            <asp:BoundField DataField="domicilio" HeaderText="Domicilio" />
                                            <asp:BoundField DataField="poblacion" HeaderText="Poblacion" />
                                            <asp:BoundField DataField="codPostal" HeaderText="Codigo Postal" />
                                            <asp:BoundField DataField="provincia" HeaderText="Provincia" />
                                            <asp:CommandField EditText="Editar" ShowEditButton="True" />
                                            <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True" />
                                        </Columns>
                                        <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>         
</asp:Content>