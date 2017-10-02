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

namespace WebConsume
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
            string code = ((ComboBoxItem) cbProductCodes.SelectedItem).Content.ToString();

            ProductDetails.WebServiceScriptSoapClient serviceProductDetails = new ProductDetails.WebServiceScriptSoapClient();

            ProductDetails.GetProductDetailsResponse ProductDetailsResponse = await serviceProductDetails.GetProductDetailsAsync(code);

            lblProductCode.Text = "Product Code: " + ProductDetailsResponse.Body.GetProductDetailsResult.ProductCode;
            lblProuctName.Text = "Product Name: " + ProductDetailsResponse.Body.GetProductDetailsResult.Title;
            lblDescription.Text = "Description:  " + ProductDetailsResponse.Body.GetProductDetailsResult.Description;
            lblPrice.Text = "Price:        " + ProductDetailsResponse.Body.GetProductDetailsResult.Price;

        }
    }
}
