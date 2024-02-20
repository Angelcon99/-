<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="학사관리_2023_1912053오혜성.board.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./css/Title.css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        <asp:Label ID="Label3" runat="server" Text="게시판"></asp:Label>
    </div>   
    <hr />
    <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" AllowSorting="True">--%>
        <%--<Columns>
            <asp:BoundField DataField="writer" HeaderText="writer" SortExpression="writer" />
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="read_count" HeaderText="read_count" SortExpression="read_count" />
            <asp:BoundField DataField="ref_id" HeaderText="ref_id" SortExpression="ref_id" />
            <asp:BoundField DataField="inner_id" HeaderText="inner_id" SortExpression="inner_id" />
            <asp:BoundField DataField="depth" HeaderText="depth" SortExpression="depth" />
            <asp:BoundField DataField="reg_date" HeaderText="reg_date" SortExpression="reg_date" />
        </Columns>--%>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource1" GridLines="None" ForeColor="#333333" Width="100%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />             
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="번호">
                        <HeaderStyle Width="60px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="제목" >
                    <ItemTemplate>
                        <%# ShowDepth((int)Eval("depth")) %>
                        <%# ShowReplayIcon((int)Eval("inner_id")) %>
                        <%# ShowTitle( Eval("id").ToString(),
                            Eval("title").ToString(),
                            Eval("del_flag").ToString()) %>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="writer" HeaderText="이름">
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="날짜" HeaderStyle-Width="86px">
                        <ItemTemplate>
                        <%# ShowDate(Eval("reg_date").ToString()) %>
                    </ItemTemplate>

                    <HeaderStyle Width="86px"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:BoundField DataField="read_count" HeaderText="조회">
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
        <EmptyDataTemplate>
            작성된 글이 없습니다.<br />
        </EmptyDataTemplate>
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
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:haksaConnectionString2 %>" ProviderName="<%$ ConnectionStrings:haksaConnectionString2.ProviderName %>" SelectCommand="SELECT [writer], [title], [read_count], [ref_id], [inner_id], [depth], [reg_date] FROM [board]"></asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:haksaConnectionString2 %>" ProviderName="<%$ ConnectionStrings:haksaConnectionString2.ProviderName %>" SelectCommand="SELECT [ID], [writer], [title], [ref_id], [inner_id], [depth], [read_count], [del_flag], [reg_date] FROM [board] order by ref_id DESC, inner_id ASC"></asp:SqlDataSource>
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/board/img/btn_write.gif" PostBackUrl="~/board/Write.aspx" />
    <hr />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/" ImageUrl="~/img/home.png">HyperLink</asp:HyperLink>
</asp:Content>
