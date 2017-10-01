using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Comsume_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            webService.WebService1SoapClient serviceWebService = new webService.WebService1SoapClient();

            webService.GetProductDetailsResponse WebService1Response = await serviceWebService.GetProductDetailsAsync(txtProductCode.Text);

            lblProductCode.Text = "Product Code: " + WebService1Response.Body.GetProductDetailsResult.ProductCode;
            lblProuctName.Text =  "Product Name: " + WebService1Response.Body.GetProductDetailsResult.Title;
            lblDescription.Text = "Description:  " + WebService1Response.Body.GetProductDetailsResult.Description;
            lblPrice.Text =       "Price:        " + WebService1Response.Body.GetProductDetailsResult.Price;

        }
    }
}
