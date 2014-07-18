<%@ Page Title="" Language="C#" MasterPageFile="~/Privada/Site1.Master" AutoEventWireup="true" CodeBehind="gestionAccionesComerciales.aspx.cs" Inherits="GestionEmpresas.Privada.gestionAccionesComerciales" %>
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
                <asp:Button ID="bAniadirAccion" CssClass="btn btn-primary pull-right" runat="server" Text="Add Accion" OnClick="bAniadirContacto_Click" />
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvAcciones" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="gvAcciones_SelectedIndexChanged" EmptyDataText="No hay acciones en la BD" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" OnRowDeleting="gvAcciones_RowDeleting" OnRowEditing="gvAcciones_RowEditing">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="nombreEmpresa" HeaderText="Empresa" />
                                <asp:BoundField DataField="descripcionTipoAccion" HeaderText="Tipo" />
                                <asp:BoundField DataField="descripcionEstadoAccion" HeaderText="Estado" />
                                <asp:BoundField DataField="fechaHora" HeaderText="Fecha" />
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                <asp:CommandField EditText="Editar" ShowCancelButton="False" ShowEditButton="True">
                                </asp:CommandField>
                                <asp:CommandField DeleteText="Borrar" ShowDeleteButton="True">
                                </asp:CommandField>
                                <asp:CommandField SelectText="Ver comentarios" ShowCancelButton="False" ShowSelectButton="True">
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle BackColor="#99CCFF" Font-Bold="True"/>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                           <div class="panel panel-default" id="panel" runat="server">
                                <div class="panel-body">
                                    <div class="form-group">
                                        <asp:Label CssClass="col-md-2 control-label" Text="Cometarios" ID="lComentarios" runat="server" AssociatedControlID="txtComentarios"></asp:Label>
                                        <div class="col-md-10">
                                            <textarea class="form-control" id="txtComentarios" runat="server"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </div>
    </div>
</asp:Content>
