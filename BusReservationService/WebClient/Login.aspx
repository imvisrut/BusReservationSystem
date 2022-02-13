<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebClient.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div style="margin: 4rem 0px;">
      <div class="form-group">
        <label>Username</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Username" />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="Password" />
      </div>
      <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="LoginClick"  />
  </div>
</asp:Content>
