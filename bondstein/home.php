<?php
session_start();
if(!isset($_SESSION['login_id']) || $_SESSION['login_id'] == NULL) header('location: Technical-Test-Part-3.php');
?>
<DOCTYPE! html>
<html>
<head>
	<title>Authenticate User - Home</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/css/bootstrap.min.css" rel="stylesheet">
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.1/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
<?php
define('ALLOW_INCLUDE', true);
include_once "nav.php";
?>
<h2>Welcome <?=ucwords($_SESSION['login_id'])?>!</h2><hr/>
<div style="text-align:right; margin-right:10px;">
<?php if(isset($_SESSION['login_id']) && $_SESSION['login_id'] != NULL && $_SESSION['user_category'] == 'Admin'): ?>
<button type="button" class="btn btn-primary" onclick="createUser()">Create User</button>
<?php endif ?> 
<a class="btn btn-danger" href="logout.php">Logout</a></div>
</body>

<script>
function createUser()
{
	location.href = 'create_user.php';
}
</script>
</html>