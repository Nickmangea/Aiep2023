using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-4VR9CQO;Initial Catalog=MULTISYSTEM;User ID=sa;Password=1234";
        public LoginForm()
        {
            InitializeComponent();
        }
        private bool AutenticarUsuario(string nombreUsuario, string clave, ref string messageReturn)
        {
            // Establece la cadena de conexión a tu base de datos SQL Server
            //string connectionString = "Data Source=Nombre_PC;Initial Catalog=Login3;User ID=USER_BBDD;Password=CLAVE_USER_BBDD";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Password_Hash, Intentos_Fallidos FROM UsuariosMS WHERE Username = @NombreUsuario AND Estado = 1";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == false)
                        {
                            messageReturn = "¡Atención! usuario no habilitado. \nContactese con el administrador";
                            return false;
                        }
                            

                        else
                        {

                            reader.Read();
                        
                            string claveHashbbdd = reader["Password_Hash"].ToString();
                            int intentosFallidos = Convert.ToInt32(reader["Intentos_Fallidos"]);
                            string claveIngresada = AplicarHash(clave);

                            if (claveHashbbdd == claveIngresada)
                            {
                                return true;
                            }
                            else
                            {
                                intentosFallidos++;
                                if (intentosFallidos > 3)
                                {
                                    BloquearUsuario(nombreUsuario);
                                }
                                else
                                {
                                    int AuInt = intentosFallidos++;
                                    SumarIntento(nombreUsuario, AuInt);
                                }      
                            }
                        }
                    }
                }
            }
            messageReturn = "Usuario o Clave Incorrecta";
            return false;
        }

        private string AplicarHash(string contrasena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contrasena);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void BloquearUsuario(string nombreUsuario)
        {
            // Primero, verifica si el usuario no está bloqueado
            //string checkBlockedQuery = "SELECT Estado FROM Usuarios WHERE Username = @NombreUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                        // Si el usuario no está bloqueado, procede a bloquearlo
                string updateQuery = "UPDATE UsuariosMS SET Estado = 0 WHERE Username = '" + nombreUsuario + "'";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.ExecuteNonQuery();
                }
                    
                
            }
        }

        private void SumarIntento(string nombreUsuario, int intentosFallidos)
        {
            // Primero, verifica si el usuario no está bloqueado
            //string checkBlockedQuery = "SELECT Estado FROM Usuarios WHERE Username = @NombreUsuario";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Si el usuario no está bloqueado, procede a bloquearlo
                string updateQuery = "UPDATE UsuariosMS SET Intentos_Fallidos = " + intentosFallidos + " WHERE Username = '" + nombreUsuario + "'";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    command.ExecuteNonQuery();
                }


            }
        }

        private void btnIniciarSesion_Click_1(object sender, EventArgs e)
        {
            string nombreUsuario = this.nombreUsuario.Text;
            string contrasena = this.contrasena.Text;
            string mensaje = "";

            if (AutenticarUsuario(nombreUsuario, contrasena, ref mensaje))
            {
                MessageBox.Show("Inicio de sesión exitoso");
                // Abre el formulario principal de la aplicación o realiza otras acciones necesarias.
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (contrasena.PasswordChar != '\0')
                contrasena.PasswordChar = '\0';
            else
                contrasena.PasswordChar = '*';
        }




        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryEmp = "SELECT top 1 Nombre_Empresa, ruta_logo FROM Configuracion WHERE estado_Empresa = 1";

                SqlCommand command = new SqlCommand(queryEmp, connection);
                SqlDataReader regEmpresa = command.ExecuteReader();

                if(regEmpresa.Read())
                {
                    string nombre_empresa_MS = regEmpresa["Nombre_Empresa"].ToString();
                    string ruta_empresa_MS = regEmpresa["ruta_logo"].ToString();
                    //MessageBox.Show(ruta_empresa_MS);
                    this.Text = nombre_empresa_MS;
                    pbox_logo.Image = Image.FromFile(ruta_empresa_MS);
                }





            }
            //pbox_logo.Image = Image.FromFile(@"C:\APPAIEP\Login\LoginForm\LoginForm\nincat.png");
        }

        private void verClave_Click(object sender, EventArgs e)
        {
            if (contrasena.PasswordChar != '\0')
            { 
                contrasena.PasswordChar = '\0';
                verClave.Image = Image.FromFile(@"C:\APPAIEP\Login\LoginForm\LoginForm\ocultar-50.png");
            }
            else
            {
                contrasena.PasswordChar = '*';
                verClave.Image = Image.FromFile(@"C:\APPAIEP\Login\LoginForm\LoginForm\visible-50.png");
            }
               
        }
    }
}
