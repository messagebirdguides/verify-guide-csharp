<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Step1.aspx.cs" Inherits="Step1" %>

<asp:Label id="ErrorLabel" runat="server"></asp:Label>
<p>Please enter your phone number (in international format, starting with +) to receive a verification code:</p>
<form id="Step1Form" runat="server">
    <asp:TextBox id="PhoneNumberTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="SendCodeButton" runat="server" Text="Send code" 
        OnClick="SendCodeButton_Click"/>
</form>