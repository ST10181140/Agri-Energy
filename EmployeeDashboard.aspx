<%@ Page Title="Employee Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDashboard.aspx.cs" Inherits="AgriEnergy.EmployeeDashboard" %><asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h2>Employee Dashboard</h2>

            <div>
                <h3>Add New Farmer Profile</h3>
                <asp:Label ID="lblAddFarmerMessage" runat="server" Text=""></asp:Label>
                <div>
                    <asp:Label ID="lblFarmerName" runat="server" Text="Farmer Name"></asp:Label>
                    <asp:TextBox ID="txtFarmerName" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblFarmerSurname" runat="server" Text="Farmer Surname"></asp:Label>
                    <asp:TextBox ID="txtFarmerSurname" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblFarmerEmail" runat="server" Text="Farmer Email"></asp:Label>
                    <asp:TextBox ID="txtFarmerEmail" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblFarmerAddress" runat="server" Text="Farmer Address"></asp:Label>
                    <asp:TextBox ID="txtFarmerAddress" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblFarmerPhone" runat="server" Text="Farmer Phone"></asp:Label>
                    <asp:TextBox ID="txtFarmerPhone" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblFarmerPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtFarmerPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth"></asp:Label>
                    <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="lblJoinDate" runat="server" Text="Join Date"></asp:Label>
                    <asp:TextBox ID="txtJoinDate" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" OnClick="btnAddFarmer_Click" />
                </div>
            </div>

            <div>
                <h3>View Products from Specific Farmer</h3>
                <asp:Label ID="lblFarmerProducts" runat="server" Text=""></asp:Label>
                <asp:DropDownList ID="ddlFarmers" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFarmers_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView ID="gvFarmerProducts" runat="server" AutoGenerateColumns="false">
                    <columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="ProductionDate" HeaderText="Production Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="ProductDescription" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price (USD)" DataFormatString="{0:C2}" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="ExpirationDate" HeaderText="Expiration Date" DataFormatString="{0:yyyy-MM-dd}" />
                        <asp:BoundField DataField="FarmerID" HeaderText="Farmer ID" />
                    </columns>
                </asp:GridView>
            </div>
        </div>
    </main>
</asp:Content>
