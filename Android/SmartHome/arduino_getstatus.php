<?php

include("Connection.php");
date_default_timezone_set("Asia/Bangkok");

$id = $_GET['id'];

$sql = "SELECT _status_device FROM SmartHome WHERE id = '$id'"; 

$run = $conn->prepare($sql);
$run->execute();

$fetch = array();

while($row=$run->fetch(PDO::FETCH_ASSOC)){
    $fetch['TB_NAME'][] = $row;
    echo $row['_status_device'];
}

//  echo json_encode($fetch);

?>