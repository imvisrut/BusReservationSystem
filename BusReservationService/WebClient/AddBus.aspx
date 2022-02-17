<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBus.aspx.cs" Inherits="WebClient.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin: 4rem 0px;">
      <div class="form-group">
        <label>Bus Name</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="BusName" />
      </div>
      <div class="form-group">
        <label>Source</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Source" />
      </div>
      <div class="form-group">
        <label>Destination</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Destination" />
      </div>
      <div class="form-group">
        <label>Time</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Time" />
      </div>
      <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="AddBusClick"  />
    </div>
</asp:Content>
