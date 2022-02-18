<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bus.aspx.cs" Inherits="WebClient.Bus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container__">
        <asp:ListView ID="Seats" runat="server">
            <ItemTemplate>
                <button value="<%# Eval("seatId") %>" class="seat" <%# Eval("isAvailable").ToString() == "False" ? "disabled" : "" %>></button>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <asp:HiddenField runat="server" value="[]" ID="SeatData" ClientIDMode="Static" />
    <% if(Session["isAuth"].ToString() == "true") {%>
        <asp:Button runat="server" Text="Book Seat" CssClass="btn btn-primary" OnClick="BookSelectedSeats"></asp:Button>
    <% } %>
    <script>
        const seats = document.querySelectorAll(".seat");
        const seatData = document.querySelector("#SeatData");
        const bookedSeats = new Set();
        for (let i = 0; i < seats.length; i++) {
            seats[i].addEventListener('click', (e) => {
                const seatId = e.target.value;
                if (e.target.classList.contains('booked')) {
                    e.target.classList.remove('booked');
                    bookedSeats.delete(seatId);
                } else {
                    e.target.classList.add('booked');
                    bookedSeats.add(seatId);
                }
                seatData.value = JSON.stringify([...bookedSeats]);
                console.log(seatData);
                e.preventDefault();
            });
        }
    </script>

    <style>
        .container__ {
            left: 50%;
            width: 120px;
            margin-top: 20px;
            position: relative;
        }
        button {
            width: 25px;
            height: 25px;
            border: 0px;
            border-radius: 3px;
            background-color: gray;
        }
        button[disabled=disabled], button:disabled {
            background-color: #ddd;
            cursor: no-drop;
        }
        .booked {
            background-color: green;
        }
    </style>

</asp:Content>
