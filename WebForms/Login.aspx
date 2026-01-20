﻿﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2>

  <div>
    Korisničko ime:
    <asp:TextBox ID="tbUserName" runat="server" />
    <br /><br />

    Lozinka:
    <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" />
    <br /><br />

    <asp:Button ID="btnLogin" runat="server" Text="Prijava" OnClick="btnLogin_Click" />
    <br /><br />

    <asp:Label ID="lblMsg" runat="server" />
  </div>
</asp:Content>