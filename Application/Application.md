# Application C# Window form

Ce markdown va expliquer l'application C# et comment elle fonctionnne.

![Application](https://github.com/J3R5/Csharp_connection_auto_carte_arduino/blob/main/Application/Connection%20automatique%202/Led_1/bin/Debug/Led_1.exe)

L'application WindForm contient deux zones, une de connection automatique et une autre pour piloter la led interne.

### Arduino connexion

La partie de connexion automatique possède 

4 labels :

* 1 pour définir le port COM de l'arduino auquelle l'application est connectée.
* 1 pour savoir combien de ports séries COM a trouvé le programme.
* 1 pour dire si l'application est connectée ou non.
* 1 dernier qui sert à préciser que la textbox contient les potentielles erreurs.

1 textbox : 

* la textbox envoie les erreurs protentielles liées à la connexion avec les ports COM.

1 bouton :

* Le bouton sert à connecter automatiquement l'application à une carte arduino.

### Pilotage Led interne

La zone du pilotage de la led interne contient 

2 boutons :

* 1 sert à envoyer un message pour allumer la led interne de l'arduino.
* 1 sert à envoyer un message pour éteindre la led interne de l'arduino.

1 textbox : 

* Elle sert à afficher les erreurs potentielles de l'allumage de la communication ou à dire si un message a été envoyé.
 
### Code initialisation :

Avant de pouvoir utiliser l'application, il faut initialiser le port série et les éléments du formulaire.

~~~C#

        public Arduino_Connexion()
        {
            InitializeComponent();
            Init_Port();
        }

        void Init_Port()
        {
            Arduino = new SerialPort();
            Arduino.BaudRate = 9600;
            Arduino.ReadTimeout = 2000;
            Arduino.WriteTimeout = 2000;
        }

~~~

L'initialisation se fait dans le constructeur du WinForm avec les deux fonctions InitializeComponent() et Init_Port(). La deuxième fonction, créer un port série et règle son débit à 9600 bauds ainsi que son timeout à 2 secondes, il est important d'avoir les timeouts pour ne pas rester bloqué dans la suite du programme. Il est possible de les diminuer ou de les augmenter mais si on les diminue trop, l'arduino n'aura plus le temps de répondre.

### Code connexion :

Le code suivant est dans le bouton de connexion automatique à une carte arduino.

~~~C#

        private void Arduino_COM_Click(object sender, EventArgs e)
        {
            /*
             * Fonction de connexion à une
             * arduino en testant les ports
             * 1 à 1 sans système de vérification
             * à qui le système se connecte
             * 
             * Jérémy Clémente 10/06/2023
             */

            //Variable

            string[] Port_Dispo;
            int i;
            string Verif;

            //Initialisation

            Port_Dispo = SerialPort.GetPortNames();
            Verif = null;
            i = 0;

            COM_arduino_L.Text = "COMX";
            Connexion_L.Text = "Ordinateur Non Connecté";
            Nbre_COM_L.Text = $"Nombre port série : {Port_Dispo.Length}";
            Connexion_Error_TB.Clear();

            //Début

            if (Port_Dispo.Length > 0)
            { 
                do
                {
                    try
                    {
                        Arduino.PortName = Port_Dispo[i];

                        Arduino.Open();
                        Arduino.WriteLine("Debut");
                        Verif = Arduino.ReadLine();
                        Verif = Verif.Trim();

                        if (Verif == "7_seg")
                        {
                            Connexion_L.Text = "Ordinateur Connecté";
                            COM_arduino_L.Text = Port_Dispo[i];
                            Connexion_Error_TB.Clear();
                        }
                        else
                        {
                            Connexion_Error_TB.Text += $"Erreur : Mauvais message : {Verif} ";
                        }

                    }   
                    catch (Exception Error)
                    {
                       Connexion_Error_TB.Text += $"Erreur {Port_Dispo[i]} :  {Error.Message}" + Environment.NewLine;
                    }

                    Arduino.Close();

                    i++;

                } while (i < Port_Dispo.Length && Connexion_L.Text == "Ordinateur Non Connectée") ;

            }
            else
            {
                Connexion_Error_TB.Text += "Erreur : aucun port série détecté" + Environment.NewLine;
            }

            //Fin
        }

~~~

La fonction possède 2 variables, Port_dispo qui est un tableau qui contient tous les noms des différents ports séries disponibles sur l'ordinateur et Verif qui est une variable qui contient la réponse envoyée par la carte arduino.

Le début du programme commence par initialiser les variables et composants présent sur le form.

On regarde d'abord si l'ordinateur à des ports séries sinon on affiche un message d'erreur dans la textbox d'erreur. 

On rentre dans une boucle puis un try catch pour passer en revue tous les ports séries trouvés en se connectant 1 à 1. On sort de la boucle, si on est connecté à la carte ou si on a parcouru tous ports existant.

A chaque passage, on tente d'ouvrir la connection puis d'envoyer un message ici Debut et on attend la réponse, ensuite on traite la réponse avec un .Trim() puis on regarde si le message reçu est égal à celui qui doit normalement être envoyer; si oui, on a trouvé la carte arduino et la fonction s'arrête.

Dans le cas d'une erreur de timeout, non connection ou autre on les affiche dans la textbox d'erreur.

La fonction affiche dans la groupe box de connexion le nombre de ports COM trouvés si le pc est connecté à un port série et lequel ainsi que les erreurs potentielles des autres ports séries en cas où le PC n'est pas connecté.

### Code led interne.

Pour allumer et éteindre la led interne, on va utiliser la fonction suivante.

~~~C#

        public void ArduinoMsg(string msg)
        {
            /*
             * fonction pour envoyer
             * des messages à l'arduino
             * via communication série
             * 
             * Jérémy Clémente 10/08/2023
             */

            //Début

            try
            {
                if (Connexion_L.Text == "Ordinateur Connecté")
                {
                    Arduino.Open();
                    Arduino.WriteLine(msg);
                    Arduino.Close();

                    ON_OFF_TB.Text += $"Message envoyé {msg}" + Environment.NewLine;
                }
                else
                {
                    ON_OFF_TB.Text += "Carte non connecter" + Environment.NewLine;
                }
            }
            catch (Exception Error)
            {
                ON_OFF_TB.Text += $"Erreur {Error.Message}" + Environment.NewLine;
            }

            //Fin
        }

~~~

Cette fonction prend en paramètre le message à envoyer puis on regarde si on est connecté à la carte et si oui, on essaye d'envoyer le message. En cas de carte non connectée ou d'erreur lors de l'envoi on l'affiche dans une textbox d'erreur. En cas de réussite d'envoi du message, on ne précise seulement que le message a été envoyé.

#### Allumer/Eteindre la led

Pour allumer et éteindre la led, on va utiliser la fonction précédante dans les boutons ON/OFF.

~~~C#

        private void ON_BP_Click(object sender, EventArgs e)
        {
            /*
             * fonction allumage une led
             * sur arduino uno en 
             * via communication série
             * 
             * Jérémy Clémente 10/08/2023
             */

            //Début

            ArduinoMsg("ON");

            //Fin
        }

        private void OFF_BP_Click(object sender, EventArgs e)
        {
            /*
             * fonction éteindre une led
             * sur arduino uno en 
             * via communication série
             * 
             * Jérémy Clémente 10/08/2023
             */

            //Début

            ArduinoMsg("OFF");

            //Fin
        }

~~~

Pour allumer la led on envoit le message ON et pour l'éteindre on envoit le message OFF.

### Conclusion

Voici la fin du markdown sur la partie de l'application WinForm C# pour aller voir le code dans la carte arduino il faut aller voir [ce markdown](https://github.com/J3R5/Csharp_connection_auto_carte_arduino/blob/main/Arduino/Arduino.md).
