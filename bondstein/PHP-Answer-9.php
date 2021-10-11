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
<hr/>
<?php
// a. Have an array of [first_name, last_name, age]
$array = [	
			['first_name'=>'Joe',	'email'=>'joe@hmail.com',	'age'=>24], 
			['first_name'=>'Doe',	'email'=>'doe@hmail.com',	'age'=>25], 
			['first_name'=>'Dane',	'email'=>'dane@hmail.com',	'age'=>20] 
		];

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
    echo '<td>' . $row['first_name'] . '</td>';
	echo '<td>' . $row['email'] . '</td>';
	echo '<td>' . $row['age'] . '</td>';
	echo '</tr>';
}
echo '</table>';
?>