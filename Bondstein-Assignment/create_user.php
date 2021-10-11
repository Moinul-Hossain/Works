<?php
session_start();
if(!isset($_SESSION['login_id']) || $_SESSION['login_id'] == NULL) header('location: Technical-Test-Part-3.php');
else if(isset($_SESSION['login_id']) && $_SESSION['login_id'] != NULL && $_SESSION['user_category'] != 'Admin') header('location: home.php');
?>

<?php
define('ALLOW_INCLUDE', true);
require_once 'dbconnect.php';
?>

<DOCTYPE! html>
<html>
<head>
	<title>Authenticate User - Create User</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet">
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
<?php
include_once "nav.php";
?>
<h2>Welcome <?=ucwords($_SESSION['login_id'])?>!</h2><hr/>
<div style="text-align:right; margin-right:10px;">
	<a class="btn btn-primary" href="home.php">Home</a>
	<a class="btn btn-danger" href="logout.php">Logout</a>
</div>

<div class="row">
<div class="col-3"></div>
<div class="col-6 d-grid gap-3">
<?php if(isset($_SESSION['message']) && $_SESSION['message'] != null): ?>
<div class="alert alert-<?=$_SESSION['message']['type']?>">
    <strong><?=$_SESSION['message']['type'] == 'danger' ? 'Error!' : 'Success!'?></strong> <?=$_SESSION['message']['text']?>
</div>
<?php endif; ?>
<h3>Create User</h3>
<form method="post" action="save_user.php" autocomplete="off" >
<div class="p-2 row">
<input class="form-control" type="text" id="loginId" name= "login_id" placeholder="Enter login id..." required />
</div>
<div class="p-2 row">
<input class="form-control" type="password" id="password" name= "password" placeholder="Enter password..." size="60" required />
</div>
<div class="p-2 row">
<select class="form-control" id="userCategory" name= "user_category" required size="3">
	<optgroup label="Select User Category">
	<option value="Customer">Customer</option>
	<option value="Admin">Admin</option>
	</optgroup>
</select>
</div>
<div class="p-2 row">
<button type="submit" class="btn btn-primary">Create</button>
</div>
</form>
<table class="table table-hover" border="1">
<thead>
<tr>
	<th>Sl.</th>
	<th>Login ID</th>
	<th>User Category</th>
</tr>
</thead>
<tbody>
<?php
$sql = 'SELECT login_id, user_category 
		FROM users';

$statement = $conn->query($sql);

// get all users
$users = $statement->fetchAll(PDO::FETCH_ASSOC);
$count = 0;
if ($users):
foreach ($users as $user):
$count++;
?>
	<tr>
		<td><?=$count?></td>
		<td><?=$user['login_id']?></td>
		<td><?=$user['user_category']?></td>
	</tr>
<?php endforeach; ?>	
<?php endif; ?>
</tbody>
</table>
</div>
<div class="col-3"></div>
</div>

</body>
</html>

<?php 
$conn = null; 
if(isset($_SESSION['message'])) unset($_SESSION['message']);
?>