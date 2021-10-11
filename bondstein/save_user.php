<?php
session_start();
if(!isset($_SESSION['login_id']) || $_SESSION['login_id'] == NULL) header('location: Technical-Test-Part-3.php');
else if(isset($_SESSION['login_id']) && $_SESSION['login_id'] != NULL && $_SESSION['user_category'] != 'Admin') header('location: home.php');
?>

<?php
define('ALLOW_INCLUDE', true);
require_once 'dbconnect.php';

$login_id		= strip_tags(trim($_POST["login_id"]));
$password		= strip_tags(trim($_POST["password"]));
$user_category	= strip_tags(trim($_POST["user_category"]));

try 
{
  $statement = $conn->prepare("INSERT INTO users (login_id, password, user_category)	VALUES (?, ?, ?)");
  $statement->bindValue(1, $login_id,		 PDO::PARAM_STR);
  $statement->bindValue(2, MD5($password), 	 PDO::PARAM_STR);
  $statement->bindValue(3, $user_category,	 PDO::PARAM_STR);
  
  // use exec() because no results are returned
  $statement->execute();
  
  if(!isset($_SESSION['message']))
  {
	$_SESSION['message'] = array(
									'type' => 'success',
									'text' => 'Login ID, ' . $login_id . ' created successfully!'
							);  
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
}

$conn = null;
header('location: create_user.php');
?>