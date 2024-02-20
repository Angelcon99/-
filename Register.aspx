<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="학사관리_2023_1912053오혜성.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="회원가입"></asp:Label>
    <hr />
    <asp:Label runat="server" Text="아이디" Width="70px"></asp:Label>
    <asp:TextBox runat="server" ID="txtID" MaxLength="20"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="암호" Width="70px"></asp:Label>
    <asp:TextBox ID="txtPwd" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox>
    <asp:CheckBox ID="chkPwd" runat="server" AutoPostBack="True" OnCheckedChanged="chkPwd_CheckedChanged" Text="암호 보이기" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="이름" Width="70px"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
    <br />
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="저장" />
    <hr />
    <asp:ImageButton runat="server" ImageUrl="~/img/home.png" PostBackUrl="~/"></asp:ImageButton>
</asp:Content>
