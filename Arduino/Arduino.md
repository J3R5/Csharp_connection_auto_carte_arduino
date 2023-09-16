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

