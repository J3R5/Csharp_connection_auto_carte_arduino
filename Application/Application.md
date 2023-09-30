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
 
### Code initialisation :

Avant de pouvoir utiliser l'application il faut initialiser le port série et les élements formulaire.

~~~C++

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

L'initialisation se fait dans le constructeur du WinForm avec les deux fonctions InitializeComponent() et Init_Port(). La deuxième fonction, créer un port série et régle son débit à 9600 bauds ainsi que son timeout à 2 second, il est importer d'avoir les timeouts pour ne pas rester bloquer dans la suite du programme. Il est possible de les diminuer ou les augmenter mais si on les diminue trop l'arduino n'aura plus le temps de répondre.

### Code connexion :

Le code suivant est dans le bouton de connexion automatique à une carte arduino.

~~~C++

        private void Arduino_COM_Click(object sender, EventArgs e)
        {
            /*
             * Fonction de connexion a une
             * arduino en testant les ports
             * 1 à 1 sans système de verification
             * a qui le système se connecte
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
                            Connexion_L.Text = "Ordinateur Connectée";
                            COM_arduino_L.Text = Port_Dispo[i];
                            Connexion_Error_TB.Clear();
                        }
                        else
                        {
                            Connexion_Error_TB.Text += $"Erreur : Mauvaise message : {Verif} ";
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

La fonction possède 2 variables, Port_dispo qui est un tableaux qui contient tous les noms des différent port série disponible sur l'ordinateur et Verif qui est une variable qui contient la réponse envoyer par la carte arduino.
