<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <div class="input-group mb-3">
      <asp:TextBox runat="server" ID="SearchInput" CssClass="form-control" placeholder="Bus Name"></asp:TextBox>
      <asp:Button runat="server" ID="SearchButton" CssClass="btn btn-secondary" Text="Search" OnClick="SearchClick"></asp:Button>
    </div>

    <asp:ListView ID="BusList" runat="server">
        <ItemTemplate>
            <div class="row">
              <div class="col-md-8">
                <div class="row space-16">&nbsp;</div>
                <div class="row">
                  <div class="col">
                    <div class="thumbnail">
                      <a href="Bus?id=<%# Eval("busId") %>">
                      <div class="caption">
                        <h4 id="thumbnail-label" style="color: #337AB7;"><strong><%# Eval("busName") %></strong></h4>
                        <p><strong><span><%# Eval("src") %></span> - <span><%# Eval("dest") %></span></strong></p>
                        <div class="thumbnail-description smaller">Time: <%# Eval("time") %></div>
                      </div>
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <style>
        .thumbnail {
           transition: 0.3s;
           border-radius: 5px;
           box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
         }
        .thumbnail a {
            text-decoration: none;
        }
        .thumbnail-description {
          min-height: 40px;
        }
        .thumbnail:hover {
          cursor: pointer;
          box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.3);
        }
    </style>
</asp:Content>
