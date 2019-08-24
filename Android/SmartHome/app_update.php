<?php
include("Connection.php");
date_default_timezone_set("Asia/Bangkok");

$id = $_GET['id'];
$_status_device = $_GET['_status_device'];
$_user_update = $_GET['_user_update'];
$_datetime_update = date("Y-m-d H:i:s");

try {
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $sql = "UPDATE SmartHome SET _status_device ='$_status_device',_datetime_update = '$_datetime_update',_user_update = '$_user_update' WHERE id = $id";

    // Prepare statement
    $stmt = $conn->prepare($sql);

    // execute the query
    $stmt->execute();

    // echo a message to say the UPDATE succeeded
    echo $stmt->rowCount() . " UPDATED successfully";
} catch (PDOException $e) {
    echo $sql . "<br>" . $e->getMessage();
}

$conn = null;
?>


<!-- http://localhost/SmartHome/update.php?status_device=000999&id=1&user_update=10303086 -->