<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="학사관리_2023_1912053오혜성.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="암호화" OnClick="Button1_Click" />
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Width="655px"></asp:TextBox>
    <br />
</asp:Content>
