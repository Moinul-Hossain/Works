
<?php
$str = "('apple','orange','banana'), ";
echo "<p>A string is: " . $str . "</p>";

// a. Removing the trailing “, ”
$str = rtrim($str, ", ");
echo "<p>a. The string after removing the trailing comma: " . $str . "</p>";

// b. Adding ";"
$str .= ";" ;
echo "<p>b. The string after adding semicolon: " . $str . "</p>";
?>

