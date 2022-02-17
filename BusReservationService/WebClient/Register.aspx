<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebClient.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div style="margin: 4rem 0px;">
      <div class="form-group">
        <label>Username</label>
        <asp:TextBox runat="server" CssClass="form-control" ID="Username" />
      </div>
      <div class="form-group">
        <label>Email</label>
        <asp:TextBox runat="server" CssClass="form-control" TextMode="Email" ID="Email" />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Password</label>
        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="Password" />
      </div>
      <div class="form-group">
        <label for="exampleInputPassword1">Repeat Password</label>
        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="PasswordRepeat" />
      </div>
      <asp:Button runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="RegisterClick"  />
  </div>
</asp:Content>
