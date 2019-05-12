<%@ Page Title="Velib WS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="VelibSOAP" %>

<script runat="server">
    IntermediaryServiceClient client = new IntermediaryServiceClient();
    void GreetingBtn_Click(Object sender,
                           EventArgs e)
    {
        // When the button is clicked,
        // change the button text, and disable it
        Button clickedButton = (Button)sender;
        clickedButton.Text = "...button clicked...";
        clickedButton.Enabled = false;
        // Display the greeting label text.
        //GreetingLabel.Visible = true;
    }

</script>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-sm-3">
            <div class="card" style="width: 18rem;">
              <img src="/Images/city.png" class="card-img-top" alt="City">
              <div class="card-body">
                <h5 class="card-title">Trouver une ville</h5>
                <p class="card-text" style="margin-bottom: 5px">Si vous voulez connaitre toutes les villes où se trouvent des vélibs.</p>
                <a href="#" class="btn btn-success">Chercher</a>
              </div>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="card" style="width: 18rem;">
              <img src="/Images/bike.png" class="card-img-top" alt="GreenPin">
              <div class="card-body">
                <h5 class="card-title">Trouver une station</h5>
                <p class="card-text">Si vous voulez connaitres toutes les stations d'une ville, ou une en particulier.</p>
                <a href="#" class="btn btn-success">Chercher</a>
              </div>
            </div>
        </div>
        <div class="col-sm-3">
            <div class="card" style="width: 18rem;">
              <img src="/Images/greenPin.png" class="card-img-top" alt="GreenPin">
              <div class="card-body">
                <h5 class="card-title">Obtenir une position</h5>
                <p class="card-text">A partir d'une ville ou du nom d'une station, localisez vos stations.</p>
                <a href="#" class="btn btn-success">Chercher</a>
              </div>
            </div>
        </div>
         <div class="col-sm-3">
            <div class="card" style="width: 18rem;">
              <img src="/Images/mark.png" class="card-img-top" alt="GreenPin">
              <div class="card-body">
                <h5 class="card-title">Connaître les disponibilités</h5>
                <p class="card-text">A partir d'une ville ou du nom d'une station, obtenez le nombre de vélibs disponibles.</p>
                <a href="#" class="btn btn-success">Chercher</a>
              </div>
            </div>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">Content
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
</asp:Content>