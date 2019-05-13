<%@ Page Title="Positions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Positions.aspx.cs" Inherits="Positions" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-6">
            <div class="card" style="margin:2%">
                <div class="card-header">
                Les positions des stations
                </div>
                <div class="card-body">
                    <h5 class="card-title">Retrouvez ici les positions de toutes les stations d'une ville.</h5>
                    <p class="card-text">Pour cela, sélectionnez une ville dans la liste suivante.</p>
                    <div class="col-4" style="align-content:center">
                        <asp:DropDownList ID="DropDownList1" AutoPostBack="True"
                                    OnSelectedIndexChanged="Selection_Change1" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-6">
            <div class="card" style="margin:2%">
                <div class="card-header">
                Les positions d'une station
                </div>
                <div class="card-body">
                    <h5 class="card-title">Retrouvez ici les positions d'une station d'une ville.</h5>
                    <p class="card-text">Pour cela, sélectionnez une ville dans la liste suivante, puis une station.</p>
                    <div class="row">
                        <div class="col-4" style="align-content:center">
                            <asp:DropDownList ID="DropDownList2" AutoPostBack="True"
                                        OnSelectedIndexChanged="Selection_Change2" class="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-8" style="align-content:center">
                            <asp:DropDownList ID="DropDownList3" AutoPostBack="True"
                                        OnSelectedIndexChanged="Selection_Change3" class="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:Table id="Table1" 
            GridLines="Both"
            HorizontalAlign="Center"
            Font-Size="10pt" 
            CellPadding="15" 
            CellSpacing="0"
            Width="80%"
            class="table"
            Runat="server">
            <asp:TableRow>
                <asp:TableHeaderCell>
                    Stations
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Latitude
                </asp:TableHeaderCell>
                <asp:TableHeaderCell>
                    Longitude
                </asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
    </div>
</asp:Content>