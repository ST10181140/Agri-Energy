<%@ Page Title="Add Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="AgriEnergy.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Add New Product</h2>
    <div>
        <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblProductionDate" runat="server" Text="Production Date:"></asp:Label>
        <asp:TextBox ID="txtProductionDate" runat="server"></asp:TextBox>
        <!-- You can use a calendar control for selecting dates -->
        <!--<asp:Calendar ID="calProductionDate" runat="server"></asp:Calendar>-->
    </div>
    <div>
        <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblExpirationDate" runat="server" Text="Expiration Date:"></asp:Label>
        <asp:TextBox ID="txtExpirationDate" runat="server"></asp:TextBox>
        <!-- You can use a calendar control for selecting dates -->
        <!--<asp:Calendar ID="calExpirationDate" runat="server"></asp:Calendar>-->
    </div>
    <div>
        <asp:Button ID="btnAdd" runat="server" Text="Add Product" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
