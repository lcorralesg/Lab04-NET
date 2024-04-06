using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "Server=(localdb)\\local;Database=Neptuno;Integrated Security=true;";
            string query = "USP_ListadoProductos";

            List<Productos> productos = new List<Productos>();

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read()) {
                    Productos producto = new Productos();
                    producto.nombreProducto= dataReader["nombreProducto"].ToString();
                    producto.cantidadPorUnidad= dataReader["cantidadPorUnidad"].ToString();
                    producto.precioUnidad= Convert.ToDecimal(dataReader["precioUnidad"]);
                    producto.categoriaProducto= dataReader["categoriaProducto"].ToString();
                    producto.unidadesEnExistencia= Convert.ToInt16(dataReader["unidadesEnExistencia"]);
                    productos.Add(producto);
                }
                connection.Close();

                dataGrid3.ItemsSource = productos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void changeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            ListarCat listarCat = new ListarCat();
            listarCat.Show();
            this.Close();
        }
    }
}