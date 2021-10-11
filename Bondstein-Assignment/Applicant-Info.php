<DOCTYPE! html>
<html>
<head>
	<title>Applicant Info - Md. Moinul Hossain</title>
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

<h2>Applicant Information</h2><hr/>
<script src="https://platform.linkedin.com/badges/js/profile.js" async defer type="text/javascript"></script>
              
<div class="row">
<div class="col-4"></div>
<div class="col-4 d-grid gap-3">
<div style="text-align:center">
  <div class="badge-base LI-profile-badge" data-locale="en_US" data-size="large" data-theme="dark" data-type="HORIZONTAL" data-vanity="emoinul" data-version="v1"><a class="badge-base__link LI-simple-link" href="https://bd.linkedin.com/in/emoinul?trk=profile-badge">&nbsp;</a></div>             
</div>
<table width="100%">
<tr>
<td width="32">
<img src="images/linkedin.png">
</td>
<td>
<a href="https://linkedin.com/in/emoinul" target="_blank">https://linkedin.com/in/emoinul</a>
</td>
</tr>
<tr>
<td width="32">
<img src="images/github.png">
</td>
<td>
<a href="https://github.com/moinul-hossain/works" target="_blank">https://github.com/moinul-hossain/works</a>
</td>
</tr>
</table>
</div>

<div class="col-4"></div>

</div>

</body>
</html>

<?php 
$conn = null; 
if(isset($_SESSION['message'])) unset($_SESSION['message']);
?>