<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AgriEnergy.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h2>Welcome to AgriEnergy Connect</h2>
            <p>Are you a Farmer or an Employee?</p>
            <asp:Button ID="btnFarmer" runat="server" Text="Farmer" OnClick="btnFarmer_Click" />
            <asp:Button ID="btnEmployee" runat="server" Text="Employee" OnClick="btnEmployee_Click" />
        </div>
    </main>
</asp:Content>
