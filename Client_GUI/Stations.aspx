<%@ Page Title="Stations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Stations.aspx.cs" Inherits="Stations" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="jumbotron jumbotron-fluid">
      <div class="container">
        <h1 class="display-4">Les Stations</h1>
        <p class="lead">Vous pouvez ici visualiser les stations d'une ville.</p>
        <hr class="my-4">
        <div class="row">
            <span>Pour cela, sélectionnez une ville dans la liste suivante.</span>
            <div style="margin-left:3%">
                <asp:DropDownList ID="DropDownList" AutoPostBack="True"
                            OnSelectedIndexChanged="Selection_Change" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
      </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-3">
                <asp:BulletedList id="ItemsBulletedList3" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
            <div class="col-3">
                <asp:BulletedList id="ItemsBulletedList4" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
            <div class="col-3">
                <asp:BulletedList id="ItemsBulletedList5" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
            <div class="col-3">
                <asp:BulletedList id="ItemsBulletedList6" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
        </div>
    </div>
</asp:Content>