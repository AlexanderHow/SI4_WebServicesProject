<%@ Page Title="Villes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Cities.aspx.cs" Inherits="Cities" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron jumbotron-fluid">
        <div class="container">
        <h1 class="display-4">Les villes</h1>
        <p class="lead">Voici toutes les villes disponibles sur la passerelle.</p>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-6">
                <asp:BulletedList id="ItemsBulletedList1" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
            <div class="col-sm-6">
                <asp:BulletedList id="ItemsBulletedList2" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
        </div>
    </div>
</asp:Content>