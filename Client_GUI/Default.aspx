<%@ Page Title="Velib WS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="row" style="margin-top: 1%">
            <div class="col-sm-3">
                <div class="card">
                  <img src="/Images/city.png" class="card-img-top" alt="City">
                  <div class="card-body">
                    <h5 class="card-title">Connaître les villes</h5>
                    <p class="card-text">Si vous voulez quelles sont les villes où se trouvent des vélibs pour pouvoir effectuer des recherches dessus.</p>
                    <a class="btn btn-success" runat="server" href="~/Cities">Voir</a>
                  </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card">
                  <img src="/Images/bike.png" class="card-img-top" alt="GreenPin">
                  <div class="card-body">
                    <h5 class="card-title">Connaître les stations</h5>
                    <p class="card-text">Si vous voulez savoir quelles sont les stations d'une ville.</p>
                    <a class="btn btn-success" runat="server" href="~/Stations">Voir</a>
                  </div>
                </div>
            </div>
            <div class="col-sm-3">
                <div class="card">
                  <img src="/Images/greenPin.png" class="card-img-top" alt="GreenPin">
                  <div class="card-body">
                    <h5 class="card-title">Obtenir une position</h5>
                    <p class="card-text">A partir du nom d'une ville, localisez vos stations.</p>
                    <a class="btn btn-success" runat="server" href="~/Positions">Voir</a>
                  </div>
                </div>
            </div>
             <div class="col-sm-3">
                <div class="card">
                  <img src="/Images/mark.png" class="card-img-top" alt="GreenPin">
                  <div class="card-body">
                    <h5 class="card-title">Connaître les disponibilités</h5>
                    <p class="card-text">A partir d'une ville ou du nom d'une station, obtenez le nombre de vélibs disponibles.</p>
                    <a class="btn btn-success" runat="server" href="~/Disponibilites">Voir</a>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>