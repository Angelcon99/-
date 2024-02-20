<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="학사관리_2023_1912053오혜성.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/css/Title.css" rel="stylesheet"/>
    <style>      
        .Panel{
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 id="title">환영합니다</h1>
    <br />
    <asp:Panel ID="Panel1" runat="server" CssClass="Panel"></asp:Panel>
    <asp:Panel ID="Panel2" runat="server" CssClass="Panel"></asp:Panel>
    <br />
    <br />
</asp:Content>
