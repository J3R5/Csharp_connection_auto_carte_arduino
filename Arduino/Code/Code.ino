//------------Define------------//
#define LED 13 //Pin led interne
//-----------------------------//

//-----------Variable-----------//
String receivedData;// variable qui contient les message reçue par le port série
//-----------------------------//

void setup() {
  //-----------Initialisation-----------//
  Serial.begin(9600);
  //activation du moniteur série à 9600 bauds
  //-----------------------------------//

  //-----------Entrée/Sortie------------//
  pinMode(LED, OUTPUT);
  //-----------------------------------//

  //--------Initialisation-Sortie------//
  digitalWrite(LED, LOW);
  //-----------------------------------//
}

void loop() {
  /*
   * Ce programme permet de se connecter
   * a une application PC pour recevoir des
   * messages et allumer ou eteindre la led 
   * interne en conséquence.
   *
   *  Jérémy Clémente 10/08/2023
  */

  //Début

  if (Serial.available() > 0) {//vérifie si on as un message
    receivedData = Serial.readStringUntil("\n");//récupère le message transmis 
    receivedData.trim();//traite le message

    //message pour identifié la carte 
    if (receivedData == "Debut") {
      Serial.println("7_seg");//renvoie un message spécifique
    }

    //piloté la led interne arduino
    if (receivedData == "ON") {
      digitalWrite(LED, HIGH);
    }
    else if (receivedData == "OFF") {
      digitalWrite(LED, LOW);
    }

  }

  //Fin
}
