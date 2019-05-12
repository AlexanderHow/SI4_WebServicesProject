<%@ Application Language="C#" %>
<%@ Import Namespace="Client_GUI" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="VelibSOAP" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e)
    {
        // Code qui s’exécute au démarrage de l’application
        AuthConfig.RegisterOpenAuth();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code qui s’exécute à l’arrêt de l’application

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code qui s'exécute lorsqu'une erreur non gérée se produit

    }

</script>
