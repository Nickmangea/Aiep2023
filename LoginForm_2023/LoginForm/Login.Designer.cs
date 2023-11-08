namespace LoginForm
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.TextBox();
            this.contrasena = new System.Windows.Forms.TextBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.verClave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verClave)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUser.Location = new System.Drawing.Point(29, 120);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(50, 15);
            this.labelUser.TabIndex = 0;
            this.labelUser.Text = "Usuario";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPass.Location = new System.Drawing.Point(31, 200);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(37, 15);
            this.labelPass.TabIndex = 1;
            this.labelPass.Text = "Clave";
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreUsuario.Location = new System.Drawing.Point(32, 138);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(254, 26);
            this.nombreUsuario.TabIndex = 2;
            // 
            // contrasena
            // 
            this.contrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrasena.Location = new System.Drawing.Point(32, 218);
            this.contrasena.Name = "contrasena";
            this.contrasena.PasswordChar = '*';
            this.contrasena.Size = new System.Drawing.Size(249, 26);
            this.contrasena.TabIndex = 3;
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIniciarSesion.Location = new System.Drawing.Point(32, 273);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(254, 28);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Ingresar";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click_1);
            // 
            // pbox_logo
            // 
            this.pbox_logo.Location = new System.Drawing.Point(32, 23);
            this.pbox_logo.Name = "pbox_logo";
            this.pbox_logo.Size = new System.Drawing.Size(254, 55);
            this.pbox_logo.TabIndex = 6;
            this.pbox_logo.TabStop = false;
            // 
            // verClave
            // 
            this.verClave.Image = ((System.Drawing.Image)(resources.GetObject("verClave.Image")));
            this.verClave.Location = new System.Drawing.Point(245, 196);
            this.verClave.Name = "verClave";
            this.verClave.Size = new System.Drawing.Size(36, 21);
            this.verClave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.verClave.TabIndex = 7;
            this.verClave.TabStop = false;
            this.verClave.Click += new System.EventHandler(this.verClave_Click);
            // 
            // LoginForm
            // 
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(309, 330);
            this.Controls.Add(this.verClave);
            this.Controls.Add(this.pbox_logo);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.contrasena);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verClave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox nombreUsuario;
        private System.Windows.Forms.TextBox contrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.PictureBox verClave;
    }
}

