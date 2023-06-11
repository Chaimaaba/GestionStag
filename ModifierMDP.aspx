<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifierMDP.aspx.cs" Inherits="WebApplication.ModifierMDP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <h3>Modification du mot de passe</h3>
            <asp:ChangePassword ID="ChangePassword1" runat="server"
                OnChangedPassword="ChangePassword1_ChangedPassword">

            </asp:ChangePassword>
     
</asp:Content>


