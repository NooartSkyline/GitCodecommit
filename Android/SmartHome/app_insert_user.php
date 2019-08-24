<?php

include("Connection.php");
date_default_timezone_set("Asia/Bangkok");

$_user_code = $_GET['_user_code'];
$_user_name = $_GET['_user_name'];
$_password = $_GET['_password'];
$getdate = date("Y-m-d H:i:s");

try {
   
    // set the PDO error mode to exception
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $sql = "INSERT INTO User (_user_code,_user_name,_password,_datetime_create)
    VALUES ('$_user_code','$_user_name','$_password','$getdate')";
    // use exec() because no results are returned
    $conn->exec($sql);
    echo "successfully";
    }
catch(PDOException $e)
    {
    echo $sql . "<br>" . $e->getMessage();
    }

$conn = null;
?>
