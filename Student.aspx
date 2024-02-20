<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="학사관리_2023_1912053오혜성.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">  // 삭제버튼 onClientClick 속성에 등록
        function confirmDelete()
        {
            return confirm("삭제하면 복구할 수 없습니다.\n삭제할까요?");
        }
    </script>
    <style>
        #title{
            text-align: center;
            font-size: 36px;            
            text-shadow: 4px 2px 2px gray; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title"><asp:Label runat="server" Text="학적 관리"></asp:Label></div>
    <hr />
    <asp:Label ID="Label3" runat="server" Text="학번"></asp:Label>
    <asp:TextBox ID="txtHakbun" runat="server" MaxLength="7"></asp:TextBox>
    <asp:Button ID="btnFind_Student" runat="server" Text="검색" OnClick="btnFind_Student_Click" />
    <br />
    <asp:Label ID="Label4" runat="server" Text="이름"></asp:Label>
    <asp:TextBox ID="txtName" runat="server" MaxLength="20"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="성별"></asp:Label>
<asp:RadioButton ID="rdM" runat="server" GroupName="sx" Text="남" />
<asp:RadioButton ID="rdW" runat="server" GroupName="sx" Text="여" />
    <br />
    <asp:Label ID="Label6" runat="server" Text="생년월일"></asp:Label>
<asp:TextBox ID="txtBirth" runat="server" TextMode="Date"></asp:TextBox>
<br />
<asp:Label ID="Label7" runat="server" Text="학과(부)"></asp:Label>
<asp:DropDownList ID="ddlDept" runat="server">
</asp:DropDownList>
<br />
<asp:Label ID="Label8" runat="server" Text="학년"></asp:Label>
<asp:DropDownList ID="ddlSYear" runat="server">
</asp:DropDownList>
<br />
<asp:Label ID="Label9" runat="server" Text="사진"></asp:Label>
<asp:FileUpload ID="FileUpload1" runat="server" />
<br />
<asp:Image ID="Image2" runat="server" Height="200px" Width="150px" />
<br />
<asp:Label ID="Label10" runat="server" Text="전화"></asp:Label>
<asp:TextBox ID="txtTel" runat="server" MaxLength="15" Width="180px"></asp:TextBox>
<br />
<asp:Label ID="Label11" runat="server" Text="주소"></asp:Label>
<asp:TextBox ID="txtAddr" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
<br />
<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="저장" />
<asp:Button ID="btnDelete" runat="server" Text="삭제" OnClientClick="return confirmDelete()" OnClick="btnDelete_Click" />
<asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="초기화" />
    <br />
    <hr />
<br />
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="./img/home.png" PostBackUrl="~/" />
</asp:Content>
