 <?php 
if ($argc > 1) {
  $json_str = $argv[1];
  $_GET = json_decode($json_str);
}
echo 
'<html>
 <head>
  <title>Test PHP</title>
 </head>
 <body>
	<p>'+$_GET['prenom']+' '+$_GET['nom']+'</p>
 </body>
</html>';
