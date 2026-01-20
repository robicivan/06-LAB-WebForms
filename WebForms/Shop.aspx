﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="WebForms.Shop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Shop</h2>

  <asp:Label ID="lblWelcome" runat="server" />
  <hr />

  <div>
    Naziv:
    <asp:TextBox ID="tbName" runat="server" />
    <br /><br />

    Opis:
    <asp:TextBox ID="tbDesc" runat="server" Width="350px" />
    <br /><br />

    <asp:Button ID="btnSave" runat="server" Text="Spremi" OnClick="btnSave_Click" />
    <br /><br />

    <asp:Label ID="lblMsg" runat="server" />
    <hr />

    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="true" />
  </div>
</asp:Content>