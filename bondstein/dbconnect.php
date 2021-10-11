<?php
if (defined('ALLOW_INCLUDE') === false) die('no direct access!');
?>
<?php
$servername = "localhost";
$username = "root";
$password = "";

try {
  $conn = new PDO("mysql:host=$servername;dbname=bondstein_db", $username, $password);
  // set the PDO error mode to exception
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch(PDOException $e) {
  echo "<h2>Internal Server Error!</h2>" . $e->getMessage(); die;
}
?>