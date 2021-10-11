<DOCTYPE! html>
<html>
<head>
	<title>Technical Test - PHP</title>
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
<h2>PHP</h2><hr/>
<p>
<img src = "images/part-1-php-question-no-1.png" alt="Part 1 - PHP - Question - 1" />
</p>
<h3>Answer</h3>
<dl>
<dd>
<img src = "images/part-1-php-answer-no-1.png" alt="Part 1 - PHP - Answer - 1" />
</dd>
<dd>
<p>
<a href="PHP-Answer-1.php" target="_blank">Show Result (New Browser)</a>
</p>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-2.png" alt="Part 1 - PHP - Question - 2" />
</p>
<h3>Answer</h3>
<dl>
<dd>
<p>
A <dfn>constant</dfn> is a value that cannot be altered by the program during normal execution, i.e., the value is constant. In versions prior to PHP 8.0, it was possible to define case-insensitive constants by passing true as third parameter of the function. Then it was possible to redeclare define, when it was previously defined as case_insensitive constant (3rd parameter). For example, in PHP 5.x,
</p>
</dd>
<dd>
<p>
<img src = "images/part-1-php-answer-no-2.png" alt="Part 1 - PHP - Answer - 2" />
</p>
<p>
But, case-insensitive constants is no longer supported in PHP 8 and in PHP 7.3 and 7.4, the ability to define case-insensitive constants is deprecated.
</p>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-3.png" alt="Part 1 - PHP - Question - 3" />
</p>
<h3>Answer</h3>
<dl>
<dd>
<p>We can pass info by the navigation between the pages in PHP via GET method and session.</p><br/>
</dd>
</dl>
<p>
<img src = "images/part-1-php-question-no-4.png" alt="Part 1 - PHP - Question - 4" />
</p>
<h3>Answer</h3>
<dl>
<dd>
<p>We can pass data from a PHP variable into JavaScript variable:</p>
</dd>
<dd>
<ol type="i">
<li>
<p>Using AJAX to pass the PHP variable to JavaScript.</p>
<img src = "images/part-1-php-answer-no-4-1.png" alt="Part 1 - PHP - Answer - 4 - 1" />
</li>
<li>
<p>
Using JavaScript to escape the PHP scripts to pass the PHP Variable to JavaScript.
</p>
<img src = "images/part-1-php-answer-no-4-2.png" alt="Part 1 - PHP - Answer - 4 - 2" />
</li>
<li>
<p>
Using the short PHP echo tag, &lt;?=?&gt; inside the JavaScript to pass the PHP Variable to JavaScript.
</p>
<img src = "images/part-1-php-answer-no-4-3.png" alt="Part 1 - PHP - Answer - 4 - 3" />
</li>
</ol>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-5.png" alt="Part 1 - PHP - Question - 5" />
</p>
<h3>Answer</h3>
<dl>
<dd>We can use super global variables in PHP to receive or extract values from a HTTP request as follows:</dd>
<dd>
<ul>
	<li>
		<dfn>$_SERVER</dfn>
		<p>
		We can use the PHP super global variable <strong>$_SERVER</strong> which holds information about HTTP headers, paths, and script locations.
		</p>
	</li>
	<li>
		<dfn>$_REQUEST</dfn>
		<p>
		We can use the PHP super global variable <strong>$_REQUEST</strong> to collect data after submitting an HTML form or to collect data sent in the URL.
		</p>
	</li>
	<li>
		<dfn>$_GET</dfn>
		<p>
		We can use the PHP super global variable <strong>$_GET</strong> to collect form data after submitting an HTML form with method = "GET" or to collect data sent in the URL. <strong>$_GET</strong> is an array of variables passed to the current script via the URL parameters or the form data submitted by the GET method.
		</p>
	</li>
	<li>
		<dfn>$_POST</dfn>
		<p>
		We can use the PHP super global variable <strong>$_POST</strong> to collect form data after submitting an HTML form with method = "POST". <strong>$_POST</strong> is an array of variables passed to the current script via the HTTP POST method.
		</p>
	</li>
	<li>
		<dfn>$_FILES</dfn>
		<p>
		The global predefined variable <strong>$_FILES</strong> is an associative array containing items uploaded via HTTP POST method. Uploading a file requires HTML form with method="POST" and enctype attribute set to multipart/form-data.
		</p>
	</li>
</ul>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-6.png" alt="Part 1 - PHP - Question - 6" />
</p>
<h3>Answer</h3>
<dl>
	<dd>An HTML form should have the following attributes with predefined value to be submitted:</dd>
	<dd>
		<ul>
			<li>The action attribute to send the request to another PHP file.</li>
			<li>The method to GET the information or POST the information as entered in the form.</li>
			<li>The enctype attribute set to "multipart/form-data" with method="POST" to upload file with form submission.</li>
		</ul>
	</dd>
	<dd>When the user fills out a form and clicks the submit button, the form data is sent for processing to a server-side script (e.g.: a PHP file). The form data is sent with the HTTP POST method.</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-7.png" alt="Part 1 - PHP - Question - 7" />
</p>
<h3>Answer</h3>
<dl>
	<dd>
	<ol type="a">
	<li>
	<strong>Session</strong>
	<p>Sessions are a simple way to store data for individual users against a unique session ID. This can be used to persist state information between page requests. A PHP session is used to store data on a server rather than the computer of the user. Session identifiers or SID is a unique number which is used to identify every user in a session based environment.</p>
	</li>
	<li>
	<strong>AJAX</strong>
	<p>
	AJAX stands for Asynchronous JavaScript And XML. This is a set of web development techniques that uses various web technologies on the client-side to create asynchronous web applications. With AJAX, web applications can send and retrieve data from a server asynchronously without interfering with the display and behaviour of the existing page. In a nutshell, it is the use of the XMLHttpRequest object to communicate with servers. It can send and receive information in various formats, including JSON, XML, HTML, and text files.
	</p>
	</li>
	<li>
	<strong>SQL Injection</strong>
	<p>
	SQL injection  also known as SQLI, is a code injection technique where malicious SQL statements are inserted into an entry field for execution.
	</p>
	</li>
	<li>
	<strong>Dynamic Websites</strong>
	<p>
	A dynamic website is a website that displays different types of content every time a user views it. The construction of a dynamic website is controlled by an application server processing server-side scripts. In server-side scripting, parameters determine how a new web page proceeds.
	</p>
	</li>
	</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-8.png" alt="Part 1 - PHP - Question - 8" />
</p>
<h3>Answer</h3>
<dl>
<dd>
<img src = "images/part-1-php-answer-no-8.png" alt="Part 1 - PHP - Answer - 8" />
</dd>
<dd>
<p>
<a href="PHP-Answer-8.php" target="_blank">Show Result (New Browser)</a>
</p>
</dd>
</dl>
<br/>
<p>
<img src = "images/part-1-php-question-no-9.png" alt="Part 1 - PHP - Question - 9" />
</p>
<h3>Answer</h3>
<dl>
<dd>Example 1</dd>
<dd>
<p>
<img src = "images/part-1-php-answer-no-9.png" alt="Part 1 - PHP - Answer - 9" />
</p>
</dd>
<dd>Example 2</dd>
<dd>
<p>
<img src = "images/part-1-php-answer-no-9-b.png" alt="Part 1 - PHP - Answer - 9 - B" />
</p>
</dd>
<dd>
<p>
<a href="PHP-Answer-9.php" target="_blank">Show Result (New Browser)</a>
</p>
</dd>
</dl>

</body>
</html>