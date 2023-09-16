# Programme Arduino

Ce markdown va expliquer le programme dans la carte arduino.

### Define

~~~C++

//------------Define------------//
#define LED 13 //Pin led interne
//-----------------------------//

~~~

Pour montrer que la connection automatique du programme C# marche on pilotera la led interne des cartes arduino qui se situe sur le pin 13
pour plus de facilité on renomme le pin 13 en LED.

### Variable

~~~C++

//-----------Variable-----------//
String receivedData;// variable qui contient les message reçue par le port série
//-----------------------------//

~~~

Le programme ne possède qu'une variable qui sera une chaine de caractère contenant les informations reçue par l'application C#.


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

Lors de la void setup on initialise le moniteur série on déclare la led interne en tant que sorti et on l'éteint 
la communication se fesant par usb il faut précisé la vitesse de communication ici 9600 bauds.

### Void loop()

~~~C++

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

~~~

Le programme de la void loop va attendre de recevoir un message sur le port série pour ensuite le récupérer et le traiter via le .trim(), après en fonction du message soit on ne fait rien si on ne reconnais pas le message soit on polite la led si le message est ON/OFF ou alors on renvoie un message pour identifié que c'est bien la carte arduino, si l'application envoie début on renvoie 7_seg les messages choisi sont arbitraire mais doivent être cohérent entre l'application et la carte.


### Conclusion 

voila le programme pour la carte arduino qui permet de li'dentifié et de piloter la led interne.

[Lien application]()

