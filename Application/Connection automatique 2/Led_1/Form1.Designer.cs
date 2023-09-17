namespace Led_1
{
    partial class Arduino_Connexion
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.COM_arduino_L = new System.Windows.Forms.Label();
            this.Connexion_L = new System.Windows.Forms.Label();
            this.Arduino_COM_BP = new System.Windows.Forms.Button();
            this.Connexion_Error_L = new System.Windows.Forms.Label();
            this.ON_BP = new System.Windows.Forms.Button();
            this.OFF_BP = new System.Windows.Forms.Button();
            this.Arduino_GB = new System.Windows.Forms.GroupBox();
            this.ON_OFF_TB = new System.Windows.Forms.TextBox();
            this.Connexion_GP = new System.Windows.Forms.GroupBox();
            this.Nbre_COM_L = new System.Windows.Forms.Label();
            this.Connexion_Error_TB = new System.Windows.Forms.TextBox();
            this.Arduino_GB.SuspendLayout();
            this.Connexion_GP.SuspendLayout();
            this.SuspendLayout();
            // 
            // COM_arduino_L
            // 
            this.COM_arduino_L.AutoSize = true;
            this.COM_arduino_L.Location = new System.Drawing.Point(12, 31);
            this.COM_arduino_L.Name = "COM_arduino_L";
            this.COM_arduino_L.Size = new System.Drawing.Size(43, 16);
            this.COM_arduino_L.TabIndex = 3;
            this.COM_arduino_L.Text = "COM :";
            // 
            // Connexion_L
            // 
            this.Connexion_L.AutoSize = true;
            this.Connexion_L.Location = new System.Drawing.Point(12, 87);
            this.Connexion_L.Name = "Connexion_L";
            this.Connexion_L.Size = new System.Drawing.Size(96, 16);
            this.Connexion_L.TabIndex = 4;
            this.Connexion_L.Text = "Non Connecter";
            // 
            // Arduino_COM_BP
            // 
            this.Arduino_COM_BP.Location = new System.Drawing.Point(67, 190);
            this.Arduino_COM_BP.Name = "Arduino_COM_BP";
            this.Arduino_COM_BP.Size = new System.Drawing.Size(108, 71);
            this.Arduino_COM_BP.TabIndex = 5;
            this.Arduino_COM_BP.Text = "Connexion ";
            this.Arduino_COM_BP.UseVisualStyleBackColor = true;
            this.Arduino_COM_BP.Click += new System.EventHandler(this.Arduino_COM_Click);
            // 
            // Connexion_Error_L
            // 
            this.Connexion_Error_L.AutoSize = true;
            this.Connexion_Error_L.Location = new System.Drawing.Point(12, 116);
            this.Connexion_Error_L.Name = "Connexion_Error_L";
            this.Connexion_Error_L.Size = new System.Drawing.Size(49, 16);
            this.Connexion_Error_L.TabIndex = 6;
            this.Connexion_Error_L.Text = "Erreur :";
            // 
            // ON_BP
            // 
            this.ON_BP.Location = new System.Drawing.Point(25, 48);
            this.ON_BP.Name = "ON_BP";
            this.ON_BP.Size = new System.Drawing.Size(126, 87);
            this.ON_BP.TabIndex = 7;
            this.ON_BP.Text = "ON";
            this.ON_BP.UseVisualStyleBackColor = true;
            this.ON_BP.Click += new System.EventHandler(this.ON_BP_Click);
            // 
            // OFF_BP
            // 
            this.OFF_BP.Location = new System.Drawing.Point(25, 154);
            this.OFF_BP.Name = "OFF_BP";
            this.OFF_BP.Size = new System.Drawing.Size(126, 87);
            this.OFF_BP.TabIndex = 8;
            this.OFF_BP.Text = "OFF";
            this.OFF_BP.UseVisualStyleBackColor = true;
            this.OFF_BP.Click += new System.EventHandler(this.OFF_BP_Click);
            // 
            // Arduino_GB
            // 
            this.Arduino_GB.Controls.Add(this.ON_OFF_TB);
            this.Arduino_GB.Controls.Add(this.OFF_BP);
            this.Arduino_GB.Controls.Add(this.ON_BP);
            this.Arduino_GB.Location = new System.Drawing.Point(284, 23);
            this.Arduino_GB.Name = "Arduino_GB";
            this.Arduino_GB.Size = new System.Drawing.Size(358, 277);
            this.Arduino_GB.TabIndex = 10;
            this.Arduino_GB.TabStop = false;
            this.Arduino_GB.Text = "Arduino Led";
            // 
            // ON_OFF_TB
            // 
            this.ON_OFF_TB.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.ON_OFF_TB.BackColor = System.Drawing.SystemColors.MenuText;
            this.ON_OFF_TB.ForeColor = System.Drawing.Color.White;
            this.ON_OFF_TB.Location = new System.Drawing.Point(175, 48);
            this.ON_OFF_TB.Multiline = true;
            this.ON_OFF_TB.Name = "ON_OFF_TB";
            this.ON_OFF_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ON_OFF_TB.Size = new System.Drawing.Size(166, 193);
            this.ON_OFF_TB.TabIndex = 9;
            // 
            // Connexion_GP
            // 
            this.Connexion_GP.Controls.Add(this.Connexion_Error_TB);
            this.Connexion_GP.Controls.Add(this.Nbre_COM_L);
            this.Connexion_GP.Controls.Add(this.Connexion_Error_L);
            this.Connexion_GP.Controls.Add(this.Arduino_COM_BP);
            this.Connexion_GP.Controls.Add(this.Connexion_L);
            this.Connexion_GP.Controls.Add(this.COM_arduino_L);
            this.Connexion_GP.Location = new System.Drawing.Point(8, 23);
            this.Connexion_GP.Name = "Connexion_GP";
            this.Connexion_GP.Size = new System.Drawing.Size(270, 277);
            this.Connexion_GP.TabIndex = 11;
            this.Connexion_GP.TabStop = false;
            this.Connexion_GP.Text = "Arduino connexion";
            // 
            // Nbre_COM_L
            // 
            this.Nbre_COM_L.AutoSize = true;
            this.Nbre_COM_L.Location = new System.Drawing.Point(12, 63);
            this.Nbre_COM_L.Name = "Nbre_COM_L";
            this.Nbre_COM_L.Size = new System.Drawing.Size(121, 16);
            this.Nbre_COM_L.TabIndex = 7;
            this.Nbre_COM_L.Text = "Nombre port série :";
            // 
            // Connexion_Error_TB
            // 
            this.Connexion_Error_TB.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.Connexion_Error_TB.BackColor = System.Drawing.SystemColors.MenuText;
            this.Connexion_Error_TB.ForeColor = System.Drawing.Color.White;
            this.Connexion_Error_TB.Location = new System.Drawing.Point(15, 135);
            this.Connexion_Error_TB.Multiline = true;
            this.Connexion_Error_TB.Name = "Connexion_Error_TB";
            this.Connexion_Error_TB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Connexion_Error_TB.Size = new System.Drawing.Size(249, 49);
            this.Connexion_Error_TB.TabIndex = 10;
            // 
            // Arduino_Connexion
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 328);
            this.Controls.Add(this.Connexion_GP);
            this.Controls.Add(this.Arduino_GB);
            this.Name = "Arduino_Connexion";
            this.Text = "Arduino Connexion";
            this.Arduino_GB.ResumeLayout(false);
            this.Arduino_GB.PerformLayout();
            this.Connexion_GP.ResumeLayout(false);
            this.Connexion_GP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label COM_arduino_L;
        private System.Windows.Forms.Label Connexion_L;
        private System.Windows.Forms.Button Arduino_COM_BP;
        private System.Windows.Forms.Label Connexion_Error_L;
        private System.Windows.Forms.Button ON_BP;
        private System.Windows.Forms.Button OFF_BP;
        private System.Windows.Forms.GroupBox Arduino_GB;
        private System.Windows.Forms.TextBox ON_OFF_TB;
        private System.Windows.Forms.GroupBox Connexion_GP;
        private System.Windows.Forms.Label Nbre_COM_L;
        private System.Windows.Forms.TextBox Connexion_Error_TB;
    }
}

