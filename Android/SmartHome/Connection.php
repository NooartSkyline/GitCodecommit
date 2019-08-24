<?php
$servername = "localhost";
$username = "u821757134_admin";
$password = "skyline!@#";

try {
    $conn = new PDO("mysql:host=$servername;dbname=u821757134_home", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "Connected successfully"; 
    }
catch(PDOException $e)
    {
    echo "Connection failed: " . $e->getMessage();
    }
?>