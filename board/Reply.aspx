<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reply.aspx.cs" Inherits="학사관리_2023_1912053오혜성.board.Reply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/Title.css" rel="stylesheet"/>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
            <asp:Label ID="Label1" runat="server" Text="답변글 쓰기"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="제목"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" Width="600px"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="내용"></asp:Label>
            <asp:TextBox ID="txtMessage" runat="server" Height="50px" TextMode="MultiLine" Width="600px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="저장" OnClick="btnSave_Click" />
        </div>
</asp:Content>
