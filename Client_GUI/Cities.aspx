<%@ Page Title="Villes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Cities.aspx.cs" Inherits="Cities" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="card" style="margin:2%">
            <div class="card-header">
            Les villes disponibles
            </div>
            <div class="card-body">
                <h5 class="card-title">Voici toutes les villes disponibles sur la passerelle.</h5>
                <div class="card-text">
                    <div class="container">
                        <div class="row">
                            <div class="col-4" style="margin-left:10%">
                                <asp:BulletedList id="ItemsBulletedList1"
                                    runat="server"
                                    class="list-group">
                                </asp:BulletedList>
                            </div>
                            <div class="col-4">
                                <asp:BulletedList id="ItemsBulletedList2"
                                    runat="server"
                                    class="list-group">
                                </asp:BulletedList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>