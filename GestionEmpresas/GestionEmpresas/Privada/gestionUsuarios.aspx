<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="gestionUsuarios.aspx.cs" Inherits="GestionEmpresas.Privada.gestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
            <div class="col-md-2">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="bBusqueda" runat="server" Text="Busqueda avanzada" />
                    </div>
                </div>
            </div>
            <div class="col-md-2 col-md-offset-8">
                <asp:Button ID="bAniadirUsuario" CssClass="btn btn-primary pull-right" runat="server" Text="Añadir Usuario" OnClick="bAniadirUsuario_Click" />
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-hover" GridLines="None" EmptyDataText="No hay usuarios en la BD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="gvUsuarios_RowDeleting" OnRowEditing="gvUsuarios_RowEditing">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="login" HeaderText="Login" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="password" HeaderText="Password" />
                                <asp:CommandField EditText="Editar" ShowCancelButton="False" ShowEditButton="True">
                                </asp:CommandField>
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </div>
</asp:Content>
