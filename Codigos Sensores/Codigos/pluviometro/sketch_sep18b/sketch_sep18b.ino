#include <Wire.h>

const float mmPerPulse = 0.137;  // mm de chuva por pulso do sensor
float mmTotali = 0;
int sensore = 0;
int statoPrecedente = 0;

void setup() {
  pinMode(9, INPUT);
  Serial.begin(9600);  // Inicializa a comunicação serial

  Serial.println("Pluviometro Inicializado");
  Serial.println("Total de Chuva: 0.00 mm");
}

void loop() {
  sensore = digitalRead(9);  // Lê o estado do sensor
  if (sensore == HIGH && statoPrecedente == LOW) {
    mmTotali += mmPerPulse;  // Atualiza a quantidade total de chuva
    Serial.print("Total de Chuva: ");
    Serial.print(mmTotali);
    Serial.println(" mm");  // Imprime a quantidade total no Monitor Serial
  }
  statoPrecedente = sensore;  // Atualiza o estado anterior
}
