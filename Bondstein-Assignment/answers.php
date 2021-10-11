
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

<?php
// a. Have an array of [first_name, last_name, age]
$array = [ ['Joe', 'joe@hmail.com', 24], ['Doe', 'doe@hmail.com', 25], ['Dane', 'dane@hmail.com', 20] ];

// b. Print this array in html table

echo '<table border="1" cellpadding="5" cellspacing="0" width="60%">';
echo '<tr>';
echo '<th>First Name</th>';
echo '<th>Email</th>';
echo '<th>Age</th>';
echo '</tr>';
foreach ($array as $row)
{
	echo '<tr>';
    echo '<td>' . $row[0] . '</td>';
	echo '<td>' . $row[1] . '</td>';
	echo '<td>' . $row[2] . '</td>';
	echo '</tr>';
}
echo '</table>';

?>

