<%@ Page Title="Disponibilites" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Disponibilites.aspx.cs" Inherits="Disponibilites" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <div class="card" style="margin:2%">
          <div class="card-header">
            Les vélibs disponibles
          </div>
          <div class="card-body">
            <h5 class="card-title">Retrouvez ici le nombre de vélibs disponibles pour toutes les stations d'une ville.</h5>
            <p class="card-text">Pour cela, sélectionnez une ville dans la liste suivante.</p>
            <div class="row">
                <div class="col-4" style="align-content:center">
                    <asp:DropDownList ID="DropDownList" AutoPostBack="True"
                            OnSelectedIndexChanged="Selection_Change" class="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-4" style="align-content:center">
                    <asp:Label ID="Total" runat="server" CssClass="card-text" style="font-weight:bold"></asp:Label>
                </div>
            </div>
          </div>
        </div>

        <asp:Table id="Table1" 
            GridLines="Both"
            HorizontalAlign="Center"
            Font-Size="10pt" 
            CellPadding="15" 
            CellSpacing="0"
            Width="80%"
            Runat="server">
            <asp:TableRow>
                <asp:TableHeaderCell>
                    Stations
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Disponibilités
                </asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>