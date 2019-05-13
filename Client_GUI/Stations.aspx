<%@ Page Title="Stations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Stations.aspx.cs" Inherits="Stations" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="card" style="margin:2%">
          <div class="card-header">
            Les stations disponibles
          </div>
          <div class="card-body">
            <h5 class="card-title">Vous pouvez ici visualiser les stations d'une ville.</h5>
            <p class="card-text">Pour cela, sélectionnez une ville dans la liste suivante.</p>
            <div class="col-4" style="align-content:center">
                <asp:DropDownList ID="DropDownList" AutoPostBack="True"
                            OnSelectedIndexChanged="Selection_Change" class="form-control" runat="server">
                </asp:DropDownList>
            </div>
          </div>
        </div>

        <div class="row">
            <div class="col-5" style="margin: 3%">
                <asp:BulletedList id="ItemsBulletedList3" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
            <div class="col-5" style="margin: 3%">
                <asp:BulletedList id="ItemsBulletedList4" 
                    BulletStyle="Circle"
                    runat="server"
                    class="list-group">
                </asp:BulletedList>
            </div>
        </div>
    </div>
</asp:Content>