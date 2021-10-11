<DOCTYPE! html>
<html>
<head>
	<title>Technical Test - MySQL</title>
	<style>
		*{
				font-family: Helvetica, Arial, sans-serif;
				font-size:1em;
		 }
	</style>
</head>
<body>
<?php
define('ALLOW_INCLUDE', true);
include_once "nav.php";
?>
<h2>MySQL</h2><hr/>
<p>Reference SQL File: <a href="bondstein_db.sql">bondstein_db.sql</a></p>
<p>
<img src = "images/part-2-php-question-no-1.png" alt="Part 2 - MySQL - Question - 1" />
</p>
<h3>Answer</h3>
<dl>
<dd>
A relational database is a type of database that stores and provides access to data points that are related to one another. The software used to store, manage, query, and retrieve data stored in a relational database is called a relational database management system (RDBMS).
</dd>
<dd>
RDBMS Features:
<ul>
<li>All data stored in the tables are provided by an RDBMS.</li>
<li>Ensures that all data stored are in the form of rows and columns.</li>
<li>Facilitates primary key, which helps in unique identification of the rows.</li>
<li>Index creation for retrieving data at a higher speed.</li>
<li>Facilitates a common column to be shared amid two or more tables.</li>
<li>Multi-user accessibility is facilitated to be controlled by individual users.</li>
</ul>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-2-php-question-no-2.png" alt="Part 2 - MySQL - Question - 2" />
</p>
<h3>Answer</h3>
<dl>
<dd>Table: <strong>people</strong></dd>
<dd>
<img src = "images/part-2-php-answer-no-2.png" alt="Part 2 - MySQL - Answer - 2" />
</dd>
<dd>
<ol type="a">
<li>
<p><strong>SQL:<strong></p>
<p>
<img src = "images/part-2-php-answer-no-2-a-1.png" alt="Part 2 - MySQL - Answer - 2 (a) - SQL" />
</p>
<p>
<img src = "images/part-2-php-answer-no-2-a-2.png" alt="Part 2 - MySQL - Answer - 2 (a) - Result" />
</p>
</li>

<li>
<p><strong>SQL:<strong></p>
<p>
<img src = "images/part-2-php-answer-no-2-b-1.png" alt="Part 2 - MySQL - Answer - 2 (b) - SQL" />
</p>
<p>
<img src = "images/part-2-php-answer-no-2-b-2.png" alt="Part 2 - MySQL - Answer - 2 (b) - Result" />
</p>
</li>
</ol>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-2-php-question-no-3.png" alt="Part 2 - MySQL - Question - 3" />
</p>
<h3>Answer</h3>
<dl>
<dd><p>Table: <strong>person and person_address</strong></p></dd>
<dd>
<img src = "images/part-2-php-answer-no-3.png" alt="Part 2 - MySQL - Answer - 3" />
</dd>
<dd><p>Table: <strong>person</strong></p></dd>
<dd>
<p>
<img src = "images/part-2-php-answer-no-3-a-1.png" alt="Part 2 - MySQL - Answer - 3 (a) - person table" />
</p>
</dd>
<dd><p>Table: <strong>person_address</strong></p></dd>
<dd>
<p>
<img src = "images/part-2-php-answer-no-3-a-1-2.png" alt="Part 2 - MySQL - Answer - 3 (a) - person_address table" />
</p>
</dd>
<dd>
<ol type="a">
<li>
<p><strong>SQL:<strong></p>
<p>
<img src = "images/part-2-php-answer-no-3-a-2.png" alt="Part 2 - MySQL - Answer - 2 (a) - SQL" />
</p>
<p>
<img src = "images/part-2-php-answer-no-3-a-3.png" alt="Part 2 - MySQL - Answer - 2 (a) - Result" />
</p>
</li>
</dd>
</dl>
</body>
</html>