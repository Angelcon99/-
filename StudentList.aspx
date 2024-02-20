<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="학사관리_2023_1912053오혜성.StudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />
    <hr />

    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="hakbun" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="hakbun" HeaderText="hakbun" ReadOnly="True" SortExpression="hakbun" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="sx" HeaderText="sx" SortExpression="sx" />
            <asp:BoundField DataField="birthday" HeaderText="birthday" SortExpression="birthday" />
            <asp:BoundField DataField="deptCD" HeaderText="deptCD" SortExpression="deptCD" />
            <asp:BoundField DataField="s_year" HeaderText="s_year" SortExpression="s_year" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:haksaConnectionString %>" ProviderName="<%$ ConnectionStrings:haksaConnectionString.ProviderName %>" SelectCommand="SELECT [hakbun], [name], [sx], [birthday], [deptCD], [s_year] FROM [student]"></asp:SqlDataSource>
    <asp:Button ID="btnStudentInfo" runat="server" Text="학생 정보 조회" OnClick="btnStudentInfo_Click" />
</asp:Content>
