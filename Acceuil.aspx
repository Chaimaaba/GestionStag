<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Acceuil.aspx.cs" Inherits="WebApplication.Acceuil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Login ID="Login1" runat="server"
        PasswordRecoveryText="Mot de passe oublié" 
        PasswordRecoveryUrl="~/ModifierMDP.aspx" 
        DestinationPageUrl="~/Test.aspx" 
        OnAuthenticate="Login1_Authenticate">
        

    </asp:Login>
</asp:Content>
