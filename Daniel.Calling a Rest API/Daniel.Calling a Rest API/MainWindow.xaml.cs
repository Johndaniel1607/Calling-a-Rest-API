using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Daniel.Calling_a_Rest_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }
        private void ShowData()
        {
            var Client = new RestClient("https://reqres.in/api/products/2");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);

            var content = response.Content;

            var data = JsonConvert.DeserializeObject<Data>(content);
            lblid.Content = "id:" + data.id;
            lblname.Content = "name:" + data.name;
            lblyear.Content = "year:" + data.year;
            lblcolor.Content = "color:" + data.color;
            lblpantone_value.Content = "pantone_value:" + data.pantone_value;
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            ShowData();
        }
    }
}
