# Programme Arduino

Ce markdown va expliquer le programme dans la carte arduino.

### Define

~~~C++

//------------Define------------//
#define LED 13 //Pin led interne
//-----------------------------//

~~~

Pour montrer que la connection automatique du programme C# marche, on pilotera la led interne des cartes arduino qui se situe sur le pin 13.
pour plus de facilité on renomme le pin 13 en LED.

### Variable

~~~C++

//-----------Variable-----------//
String receivedData;// variable qui contient les messages reçus par le port série
//-----------------------------//

~~~

Le programme ne possède qu'une variable qui sera une chaine de caractères contenant les informations reçues par l'application C#.


### Void setup()

~~~C++

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


~~~

Lors de la void setup() on initialise le moniteur série, on déclare la led interne en tant que sortie et on l'éteint. 
La communication se faisant par usb, il faut préciser la vitesse de communication ici 9600 bauds.

### Void loop()

~~~C++

void loop() {
  /*
   * Ce programme permet de se connecter
   * à une application PC pour recevoir des
   * messages et allumer ou éteindre la led 
   * interne en conséquence.
   *
   *  Jérémy Clémente 10/08/2023
  */

  //Début

  if (Serial.available() > 0) {//vérifie si on a un message
    receivedData = Serial.readStringUntil("\n");//récupère le message transmis 
    receivedData.trim();//traite le message

    //message pour identifier la carte 
    if (receivedData == "Debut") {
      Serial.println("7_seg");//renvoit un message spécifique
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

~~~

Le programme de la void loop() va attendre de recevoir un message sur le port série pour ensuite le récupérer et le traiter via le .trim(), après en fonction du message; soit on ne fait rien si on ne reconnait pas le message soit on pilote la led si le message est ON/OFF ou alors on renvoit un message pour identifier que c'est bien la carte arduino, si l'application envoit Debut on renvoit 7_seg les messages choisis sont arbitraires mais ils doivent être cohérents entre l'application et la carte.


### Conclusion 

Voilà le programme pour la carte arduino qui permet de l'identifier et de piloter la led interne.

[Lien application](https://github.com/J3R5/Csharp_connection_auto_carte_arduino/blob/main/Application/Application.md)

