<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="학사관리_2023_1912053오혜성.board.Write" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/Title.css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        <asp:Label ID="lbTitle" runat="server" Text="글쓰기"></asp:Label>
    </div>    
    <hr />
    <table>
        <tr>
            <td>제목</td>
            <td><asp:TextBox ID="txtTitle" runat="server" Width="600px" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>내용</td>
            <td><asp:TextBox ID="txtMessage" runat="server" Height="150px" Width="600px" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        <tr>
            <td>첨부파일</td>
            <td><asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <asp:Label ID="lbFile1" runat="server" Text="lbFile1"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>                            
            <td><asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/board/img/btn_save.gif" OnClick="btnSave_Click" />&nbsp;<asp:Label ID="ref_id" runat="server" Text="0"></asp:Label>
&nbsp;<asp:Label ID="inner_id" runat="server" Text="0"></asp:Label>
&nbsp;<asp:Label ID="depth" runat="server" Text="0"></asp:Label>
&nbsp;<asp:Label ID="read_count" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
    <hr />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/home.png" PostBackUrl="~/" />
</asp:Content>
