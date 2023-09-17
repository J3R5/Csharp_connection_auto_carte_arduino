# Application C# Window form

Ce markdown va expliquer l'application C# et comment elle fonctionnne.

![Application]()

L'application window form contient deux zones une de connection automatique, et un autre pour piloter la led interne.

### Arduino connexion

La partie de connexion automatique possède 

4 label :

* 1 pour définir le port COM de l'arduino auquelle l'application est connecté.
* 1 pour savoir combien de port serié COM a trouvé le programme.
* 1 pour dire si l'application est connecté ou non.
* 1 dernier qui sert à préciser que la textbox contient les potentiels erreurs.

1 textbox : 

* la textbox envoie les erreurs protentiel lié à la connexion avec les port COM.

1 bouton :

* Le bouton sert a connecté automatiquement l'application à une carte arduino.

### Pilotage Led interne

La zone du pilotage de la led interne contient 

2 boutons :

* 1 sert à envoyer un message pour allumer la led interne de l'arduino
* 1 sert à envoyer un message pour éteindre la led interne de l'arduino

1 textbox : 

* Elle sert à afficher les erreurs potentiel de l'allumage de la communication ou a dire si un message à été envoyer
 
### Code 

~~~C++



~~~




