﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="WebForms.Registracija" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registriraj se</h2>

  <div>
    Korisničko ime:
    <asp:TextBox ID="tbUserName" runat="server" />
    <br /><br />

    Puno ime:
    <asp:TextBox ID="tbFullName" runat="server" />
    <br /><br />

    Lozinka:
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" />
    <br /><br />

    Ponovljena lozinka:
    <asp:TextBox ID="tbPassword2" runat="server" TextMode="Password" />
    <br /><br />

    <asp:Button ID="btnRegister" runat="server" Text="Registriraj" OnClick="btnRegister_Click" />
    <br /><br />

    <asp:Label ID="lblMsg" runat="server" />
  </div>
</asp:Content>