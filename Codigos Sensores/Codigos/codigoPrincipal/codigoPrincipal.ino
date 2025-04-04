#include <dht11.h>

#define DHT11PIN 4  // Pino do sensor DHT11
#define VENTO_PIN A0 // Pino analógico para o sensor de vento

// Constantes
const float pi = 3.14159265;     // Número de pi
int period = 5000;               // Tempo de medição (milissegundos)
int radius = 147;                // Raio do anemômetro (mm) - Não aplicável para sensor analógico
unsigned int counter = 0;        // Contador para o sensor  
unsigned int RPM = 0;            // Rotações por minuto (não utilizado)
float speedwind = 0;             // Velocidade do vento (m/s)
float windspeed = 0;             // Velocidade do vento (km/h)

// Instância do sensor DHT11
dht11 DHT11;

void setup() {
  Serial.begin(9600);  // Inicia a comunicação serial
  Serial.println("Iniciando...");
}

void loop() {
  // Leitura do sensor DHT11
  int chk = DHT11.read(DHT11PIN);
  String dados = "T:" + String((float)DHT11.temperature, 2) + "H:" + String((float)DHT11.humidity, 2);
  
  // Leitura do sensor de vento
  int vento = analogRead(VENTO_PIN);
  float ventoVolts = (vento / 1023.0) * 5.0; // Convertendo para volts (considerando Vcc = 5V)
  
  // Calcula a velocidade do vento em m/s
  speedwind = ventoVolts * 2.0; // Ajuste o fator de multiplicação conforme o datasheet do sensor

 

  // Envia os dados via serial
  String ventoDados = "V:" + String(speedwind, 2) + "m/s";
  Serial.println(dados + " " + ventoDados);  // Envia os dados no formato: "T:XX.XX H:YY.YY V:ZZ.ZZ"
  
  delay(2000);  // Aguarda 2 segundos antes de fazer a próxima leitura
}
