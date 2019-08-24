#include <ESP8266WiFi.h>
#include <ESP8266HTTPClient.h>
#include "Time_tasking.h"
 
const char* ssid = "Home";
const char* password = "A12345678";
String payload;

const int ledPin16 =  16;
const int ledPin5 =  5;
const int ledPin4 =  4;
const int ledPin0 =  0;
 
void setup () {
 
  Serial.begin(115200);
  WiFi.begin(ssid, password);
  
   pinMode(ledPin16, OUTPUT);
   pinMode(ledPin5, OUTPUT);
   pinMode(ledPin4, OUTPUT);
   pinMode(ledPin0, OUTPUT);
 
  while (WiFi.status() != WL_CONNECTED) {
 
    delay(1000);
    Serial.println("Connecting..");
 
  }
  Serial.println(WiFi.localIP());   
   while (!Serial) ;
  previousTime = micros();

   digitalWrite(ledPin16, LOW);
   digitalWrite(ledPin5, LOW);
   digitalWrite(ledPin4, LOW);
   digitalWrite(ledPin0, LOW); 
}
 
void loop() {
 
   Dt_loop = micros() - previousTime;
  if(Dt_loop >= 1000) 
  {
    //1000 Hz
    previousTime = micros();
    frameCounter++;
    if(frameCounter % TASK_500HZ == 0)
    {
      //500 Hz  
    }
    if(frameCounter % TASK_200HZ == 0)
    {
      //200 Hz
          for (int i = 1;i <= 4; i++){
            
            String Get = GetHTTP(i);
          if(Get == "A1"){
             Serial.println("-----------------A1");
             digitalWrite(ledPin16, HIGH);
          }else if(Get == "A0"){
             Serial.println("A0");
              digitalWrite(ledPin16, LOW);
             
          }else if(Get == "B1"){
             Serial.println("-----------------B1");
              digitalWrite(ledPin5, HIGH);
          }else if(Get == "B0"){
             Serial.println("B0");
              digitalWrite(ledPin5, LOW);
          
          }else if(Get == "C1"){
             Serial.println("-----------------C1");
              digitalWrite(ledPin4, HIGH);
          }else if(Get == "C0"){
             Serial.println("C0");
              digitalWrite(ledPin4, LOW);
          
          }else if(Get == "D1"){
             Serial.println("-----------------D1");
              digitalWrite(ledPin0, HIGH);
          }else if(Get == "D0"){
             Serial.println("D0");
              digitalWrite(ledPin0, LOW);
          }
    }  
    }
    if(frameCounter % TASK_100HZ == 0)
    {
      //100 Hz
    }
    if(frameCounter % TASK_50HZ == 0)
    {
      //50 Hz
    }
    if(frameCounter % TASK_25HZ == 0)
    {
      //25 Hz
    }
    if(frameCounter % TASK_20HZ == 0)
    {
      //20 Hz
    }
    if(frameCounter % TASK_10HZ == 0)
    {
      //10 Hz
    }
    if(frameCounter % TASK_5HZ == 0)
    {
      //5 Hz
    }
    if(frameCounter % TASK_2HZ == 0)
    {
      //2 Hz
    }
    if (frameCounter >= TASK_1HZ) { // Reset frameCounter back to 0 after reaching (1s)
      frameCounter = 0; 
      //1 HZ (1s)
    }
  }
 
}

     String GetHTTP(int i){

       String sIndex = String(i);
  
       if (WiFi.status() == WL_CONNECTED) { //Check WiFi connection status
     
        HTTPClient http;  //Declare an object of class HTTPClient
     
        http.begin("http://nooartskyline.online/smarthome/arduino_getstatus.php?id=" + sIndex);  //Specify request destination
    //    http.begin("http://jsonplaceholder.typicode.com/users/1");  //Specify request destination
        int httpCode = http.GET();                                                                  //Send the request
     
        if (httpCode > 0) { //Check the returning code
     
          payload = http.getString();   //Get the request response payload
          Serial.println("-----------------------------------" + payload);                     //Print the response payload
     
        }
     
        http.end();   //Close connection
     
      }
     return payload;
//      delay(1000);    //Send a request every 30 seconds
  }
