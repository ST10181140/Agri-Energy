<%@ Page Title="Farmer Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FarmerDashboard.aspx.cs" Inherits="AgriEnergy.FarmerDashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h2>Welcome to Your Farmer Dashboard</h2>
            <div>
                <!-- Display farmer-specific information -->
                <asp:Label ID="lblFarmerName" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblFarmerEmail" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblFarmerAddress" runat="server" Text=""></asp:Label>
                <!-- Add more labels for displaying other farmer details as needed -->
            </div>
            <div>
                <!-- Add buttons or links for various actions -->
                <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
                <asp:HyperLink ID="hypProfileSettings" runat="server" NavigateUrl="~/ProfileSettings.aspx" Text="Profile Settings"></asp:HyperLink>
                <!-- Add more buttons or links for other actions -->
            </div>
            <div>
                <!-- Display a gridview or other controls to show farmer's products -->
                <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="ProductionDate" HeaderText="Production Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="ProductDescription" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C2}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" DataFormatString="{0:yyyy-MM-dd}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div>
                <!-- Display error messages -->
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </main>
</asp:Content>
