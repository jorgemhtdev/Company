<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="gestionUsuarios.aspx.cs" Inherits="GestionEmpresas.Privada.gestionUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
            <div class="form col-md-4">
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbLogin" CssClass="control-label" runat="server" Text="Login"></asp:Label>
                        <asp:TextBox ID="txtLogin" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <asp:Label ID="lbNombre" CssClass="control-label" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="bBusqueda" CssClass="btn btn-primary pull-left" runat="server" Text="Buscar" OnClick="bBusqueda_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            <div class="col-md-2 col-md-offset-4">
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
