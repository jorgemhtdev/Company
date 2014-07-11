<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="gestionEmpresas.aspx.cs" Inherits="GestionEmpresas.Privada.gestionEmpresas" %>
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
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
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
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                    </div>
                    <div class="col-md-3">
                        <asp:GridView ID="GridView3" runat="server"></asp:GridView>
                    </div>
                    <div class="col-md-3">
                        <asp:GridView ID="GridView4" runat="server"></asp:GridView>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <div class="container-fluid">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Button ID="Button1" runat="server" Text="Button" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Button2" runat="server" Text="Button" />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="Button3" runat="server" Text="Button" />
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </fieldset>
        </div>
        <div class="col-md-1"></div>
    </div>
</asp:Content>