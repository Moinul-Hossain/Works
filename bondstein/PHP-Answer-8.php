<?php
// Hiding error and warnings for any exception with opening a file.
$display_errors = ini_get('display_errors');	// Get the initial value
ini_set('display_errors', 0);

// Read content from the file
$fileRead = fopen("sample.txt", "r") or die("Unable to open file!");
$content = fread($fileRead, filesize("sample.txt"));
echo $content;
fclose($fileRead);

// Write contents in the file
$fileWrite = fopen("sample.txt", "w") or die("Unable to open file!");
$new_content = 'Bondstein Technologies Ltd.';
fwrite($fileWrite, $new_content);
fclose($fileWrite);

// Reset initial settings for error and warnings
ini_set('display_errors', $display_errors);
?>