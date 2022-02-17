<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bus.aspx.cs" Inherits="WebClient.Bus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <asp:ListView ID="Seats" runat="server">
        <ItemTemplate>
            <%# Eval("seatId") %>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
