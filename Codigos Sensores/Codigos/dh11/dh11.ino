#include <dht.h>
#include <SoftwareSerial.h> // Inclua a biblioteca SoftwareSerial

dht DHT;
#define DHT11_PIN 4

// Defina os pinos RX e TX para o módulo Bluetooth
SoftwareSerial bluetoothSerial(10, 11); // RX, TX

void setup() {
  bluetoothSerial.begin(9600); // Inicializa a comunicação serial via Bluetooth
  delay(2000); // Aguarde para estabilizar o sensor
}

void loop() {
  int chk = DHT.read11(DHT11_PIN); // Leia os dados do sensor

  // Envia os dados de temperatura e umidade via Bluetooth
  bluetoothSerial.print("Temperature: ");
  bluetoothSerial.print(DHT.temperature);
  bluetoothSerial.print(" C, Humidity: ");
  bluetoothSerial.print(DHT.humidity);
  bluetoothSerial.println(" %");

  delay(2000); // Aguarde 2 segundos antes da próxima leitura
}
