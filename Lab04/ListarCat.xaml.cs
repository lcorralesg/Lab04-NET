using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab04
{
    /// <summary>
    /// Lógica de interacción para ListarCat.xaml
    /// </summary>
    public partial class ListarCat : Window
    {
        public ListarCat()
        {
            InitializeComponent();

            string connectionString = "Server=(localdb)\\local;Database=Neptuno;Integrated Security=true;";
            string query = "USP_ListadoCategorias";

            List<Categoria> categorias = new List<Categoria>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())

                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = Convert.ToInt32(dataReader["idcategoria"]);
                    categoria.NombreCategoria = dataReader["nombrecategoria"].ToString();
                    categoria.Descripcion = dataReader["descripcion"].ToString();
                    categoria.Activo = Convert.ToBoolean(dataReader["Activo"]);
                    categoria.CodCategoria = dataReader["CodCategoria"].ToString();
                    categorias.Add(categoria);
                }
                connection.Close();

                dataGrid4.ItemsSource = categorias;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void changeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
