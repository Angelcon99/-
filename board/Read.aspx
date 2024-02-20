<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="학사관리_2023_1912053오혜성.board.Read" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/Title.css" rel="stylesheet"/>
    <link href="./css/Read.css" rel="stylesheet"/>
    
    <script type="text/javascript">
        function ConfirmDelete() {
            return confirm("정말 삭제할까요?");
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="title"> 
            <asp:Label ID="Label1" runat="server" Text="글 읽기"></asp:Label> <hr />
        </div>

        <%--스타일시트로 예쁘게 만들기--%>
        <table>
            <tr>
                <td>글쓴이 </td>
                <td><asp:Label ID="lbWriter" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>날짜</td>
                <td class="context"> 
                        <div>
                            <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
                            <span id="viewcount">조회수: <asp:Label ID="lbCount" runat="server" Text="Label"></asp:Label></span>                             
                        </div>
                </td>
            </tr>
            <tr>
                <td>제목</td>
                <td><asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>내용</td>
                <td><asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>파일</td>
                <td><asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink></td>
            </tr>

        </table>

        <%--<div>
            글쓴이: <asp:Label ID="lbWriter" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            날짜: <asp:Label ID="lbDate" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            조회수: <asp:Label ID="lbCount" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            제목: <asp:Label ID="lbTitle" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            내용: <asp:Label ID="lbMessage" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            파일: <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        </div>--%>
        <div>
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="수정" />
            <asp:Button ID="btnReply" runat="server" OnClick="btnReply_Click" Text="답변글" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="삭제" OnClientClick="return ConfirmDelete()" />
            <asp:Button ID="btnList" runat="server" OnClick="btnList_Click" Text="목록으로" />
            </div>
    </div>
</asp:Content>
