/*
  SDA/SS d4
  SCK d5
  MOSI d7
  MISO d6
  RST RST
  GND GND
  3.3V 3.3V
*/
#include <SPI.h>
#include <MFRC522.h>
#include <ESP8266WiFi.h>
#define SERVER_PORT 80          //กำหนดใช้ Port 80

const char* ssid = "POOPA_ICT";               //กำหนด SSID
const char* password = "52251185";     //กำหนด Password

const char* server_ip = "192.168.1.105";   //กำหนดชื่อ Server ที่ต้องการเชื่อมต่อ

WiFiServer server(SERVER_PORT);     //เปิดใช้งาน TCP Port 80
WiFiClient client;              //ประกาศใช้  client

unsigned long previousMillis = 0;       //กำหนดตัวแปรเก็บค่า เวลาสุดท้ายที่ทำงาน
const long interval = 10000;            //กำหนดค่าตัวแปร ให้ทำงานทุกๆ 10 วินาที

#define SS_PIN D4
#define RST_PIN D8

MFRC522 rfid(SS_PIN, RST_PIN); // Instance of the class

MFRC522::MIFARE_Key key;

// Init array that will store new NUID
byte nuidPICC[4];

void setup() {
  Serial.begin(115200);
  SPI.begin(); // Init SPI bus
  rfid.PCD_Init(); // Init MFRC522

  for (byte i = 0; i < 6; i++) {
    key.keyByte[i] = 0xFF;
  }

  Serial.println(F("This code scan the MIFARE Classsic NUID."));
  Serial.print(F("Using the following key:"));

  WiFi.begin(ssid, password);                   //เชื่อมต่อกับ AP
  while (WiFi.status() != WL_CONNECTED)         //ตรวจเช็ค และ รอจนเชื่อมต่อ AP สำเร็จ
  {
    delay(300);
    Serial.print(".");
  }
}

void loop() {
  // Look for new cards
  if ( ! rfid.PICC_IsNewCardPresent())
    return;

  // Verify if the NUID has been readed
  if ( ! rfid.PICC_ReadCardSerial())
    return;

  String uid = printDec(rfid.uid.uidByte, rfid.uid.size);
  Serial.println(uid);

  while (client.available())                          //ตรวจเช็คว่ามีการส่งค่ากลับมาจาก Server หรือไม่
  {
    String line = client.readStringUntil('\n');       //อ่านค่าที่ Server ตอบหลับมาทีละบรรทัด
    Serial.println(line);                             //แสดงค่าที่ได้ทาง Serial Port
  }
  Client_Request(uid);                                 //เรียกใช้งานฟังก์ชั่น Client_Request

  // Halt PICC
  rfid.PICC_HaltA();
  // Stop encryption on PCD
  rfid.PCD_StopCrypto1();
}

String printDec(byte *buffer, byte bufferSize) {
  String result = "";
  for (byte i = 0; i < bufferSize; i++) {
    result += buffer[i];
  }
  return result;
}

void Client_Request(String uid)
{
  int cnt = 0;
  while (!client.connect(server_ip, SERVER_PORT)) //เชื่อมต่อกับ Server และรอจนกว่าเชื่อมต่อสำเร็จ
  {
    Serial.print(".");
    delay(100);
    cnt++;
    if (cnt > 50)              //ถ้าหากใช้เวลาเชื่อมต่อเกิน 5 วินาที ให้ออกจากฟังก์ชั่น
      return;
  }
  /* กำหนดค่าคำสั่ง HTTP GET */
  String str_url  = "GET /CarParking/RfidStamp/Save?uid=" + uid + " HTTP/1.1\r\n Host: 192.168.1.105\r\n\r\n";
  client.print(str_url);     //ส่งคำสั่ง HTTP GET ไปยัง Server
}

