<?php
session_start();
?>

<?php
define('ALLOW_INCLUDE', true);
require_once 'dbconnect.php';

$login_id		= strip_tags(trim($_POST["login_id"]));
$password		= strip_tags(trim($_POST["password"]));

try 
{
  $statement = $conn->prepare("SELECT * FROM users WHERE login_id = :login_id AND password = MD5(:password)");
  $statement->bindValue(':login_id', $login_id,		 	PDO::PARAM_STR);
  $statement->bindValue(':password', $password, 		PDO::PARAM_STR);
  
  $statement->execute();
  $count = $statement->rowCount();
  $rows = $statement->fetchAll(PDO::FETCH_ASSOC);
  
  $conn = NULL;
  
  if($count>0)
  {
	   $_SESSION["login_id"] = $_POST["login_id"];
	   $_SESSION["user_category"] = $rows[0]['user_category'];
       header('location: home.php');
  }
  else
  {
	  if(!isset($_SESSION['message']))
	  {
		$_SESSION['message'] = array(
										'type' => 'danger',
										'text' => 'Login failed! Please enter correct Login ID and password.'
								);  
	  }
	  
	  header('location: Technical-Test-Part-3.php');
  }
} 
catch(PDOException $e) 
{
  if(!isset($_SESSION['message']))
  {
	$_SESSION['message'] = array(
									'type' => 'danger',
									'text' => 'Internal Server Error!' . '<br/>' . $e->getMessage()
							);  
  }
  
  header('location: Technical-Test-Part-3.php');
}
?>