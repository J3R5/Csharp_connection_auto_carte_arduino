using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;
using System.Reflection.Emit;
using System.Threading;

namespace Led_1
{
    public partial class Arduino_Connexion : Form
    {
        SerialPort Arduino;

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
            Connexion_L.Text = "Ordinateur Non Connectée";
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

        public void ArduinoMsg(string msg)
        {
            /*
             * fonction pour envoie
             * des message a l'arduino
             * via communication série
             * 
             * Jérémy Clémente 10/08/2023
             */

            //Début

            try
            {
                if (Connexion_L.Text == "Ordinateur Connectée")
                {
                    Arduino.Open();
                    Arduino.WriteLine(msg);
                    Arduino.Close();

                    ON_OFF_TB.Text += $"Message envoyé {msg}" + Environment.NewLine;
                }
                else
                {
                    ON_OFF_TB.Text += "Carte non connecté" + Environment.NewLine;
                }
            }
            catch (Exception Error)
            {
                ON_OFF_TB.Text += $"Erreur {Error.Message}" + Environment.NewLine;
            }

            //Fin
        }
    }
}
