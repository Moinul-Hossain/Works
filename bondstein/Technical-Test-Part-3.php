<?php
session_start();
if(isset($_SESSION['login_id']) && $_SESSION['login_id'] != NULL) header('location: home.php');
?>
<DOCTYPE! html>
<html>
<head>
	<title>Technical Test - Authenticate User</title>
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
<h2>Authenticate User</h2><hr/>
<div class="row">
<div class="col-4"></div>
<div class="col-4 d-grid gap-3">

<?php if(isset($_SESSION['message']) && $_SESSION['message'] != null): ?>
<div class="alert alert-<?=$_SESSION['message']['type']?>">
    <strong><?=$_SESSION['message']['type'] == 'danger' ? 'Error!' : 'Success!'?></strong> <?=$_SESSION['message']['text']?>
</div>
<?php endif; ?>

<form method="post" action="auth.php" autocomplete="off" >
<div class="p-2 row">
<input class="form-control" type="text" id="loginId" name= "login_id" placeholder="Enter login id..." required />
</div>
<div class="p-2 row">
<input class="form-control" type="password" id="password" name= "password" placeholder="Enter password..." size="60" required />
</div>
<div class="p-2 row">
<button type="submit" class="btn btn-danger">Login</button>
</div>
</form>
</div>
<div class="col-4"></div>
</div>
</body>
</html>
<?php
if(isset($_SESSION['message'])) unset($_SESSION['message']);
?>