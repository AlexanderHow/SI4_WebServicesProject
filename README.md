# SI4_WebServicesProject
Project linked to the Service oriented computing and web services 2019's course at Polytech Nice Sophia. During this course, students groups have to developp step by step a complete project using a web service architecture.

Ceci est un projet Visual Studio et contient 3 solutions : Un serveur avec les services de Velib et de monitoring, un client console qui permet de faire des requêtes à notre serveur (dont du monitoring) et un client graphique (Sur Google Chrome !!! Par défaut à cause de Visual Studio. Si un probleme de version de .NET est soulevé au lancement, séléctionnez la votre, ca modifiera automatiquement le projet pour que tout soit fonctionnel) qui permet d'afficher le résultat des requêtes Velib de notre serveur
Il suffit donc de vérifier dans les paramêtres de lancement du projet dans Visual Studio pour que les 3 solutions sont cochées pour être lancées au démarrage du projet, ensuite il suffit de démarrer le projet et un client console ainsi qu'un client graphique vous permettent de tester les diverses fonctionnalités de notre application. Une fenêtre de débug du serveur est aussi lancé par Visual Studio et montre les méthodes offertes par nos services, vous pouvez donc également requêter notre serveur via cette interface et voir le resultat s'afficher et le contrôler via le service de monitoring, utile notamment pour savoir si le resultat obtenu provient de notre cache ou d'une requête REST à JCDCeau.

Axes séléctionnés :
 - Graphical User Interface for the client (Olivia Osgart 100% - Alexandre Howard 0%)
 - Asynchronous access to Web Services (Olivia Osgart 0% - Alexandre Howard 100%)
 - Monitoring (Olivia Osgart 50% - Alexandre Howard 50%)
 - Cache Management (Olivia Osgart 0% - Alexandre Howard 100%)
 