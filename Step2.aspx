<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Step2.aspx.cs" Inherits="Step2" %>

<asp:Label id="ErrorLabel" runat="server"></asp:Label>
<p>We have sent you a verification code!</p>
<p>Please enter the code here:</p>
<form id="Step2Form" runat="server">
    <asp:TextBox id="CodeTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="CheckCodeButton" runat="server" Text="Check code" 
        OnClick="CheckCodeButton_Click"/>
</form>