<?php

include("Connection.php");
date_default_timezone_set("Asia/Bangkok");

$sql = "SELECT * FROM SmartHome"; 

$run = $conn->prepare($sql);
$run->execute();

$fetch = array();

while($row=$run->fetch(PDO::FETCH_ASSOC)){
    $fetch['jsondata'][] = $row;
}
echo json_encode($fetch);

?>