using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web_Service_PC
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        public struct ProductDetails
        {
            public string ProductCode;
            public string Title;
            public string Description;
            public string Price;
        }

        private ProductDetails Products;

        public void pcProductDetails()
        {
            Products.ProductCode = "";
            Products.Title = "";
            Products.Description = "";
            Products.Price = "";
        }

        private void AssignValues(string ProductCode)
        {

            Products.ProductCode = ProductCode;

            if (ProductCode == "UG1")
            {
                Products.Title = "UG Hunter";
                Products.Description = "Intel I7 / 3.4GHZ, 8GB RAM, 32GB SSD, 1TB HHD, Gigabyte GeForce GT710";
                Products.Price = "$1,999";
            }
            else if (ProductCode == "UG2")
            {
                Products.Title = "UG Predator";
                Products.Description = "Intel I7/4GHZ, 16GB RAM, 128GB SSD, 2TB HHD, Gigabyte GeForce GT730";
                Products.Price = "$2,499";
            }
            else if (ProductCode == "UG3")
            {
                Products.Title = "UG Beast";
                Products.Description = "Intel I7/4GHZ, 32GB RAM, 256GB SSD, 2TB HHD, Gigabyte GeForce GT750";
                Products.Price = "$2,999";
            }
            else
            {
                Products.Title = "Product Not Found";
                Products.Description = "";
                Products.Price = "";
            }
        }

        [WebMethod(Description = "This method call will get the product name, Description and Price for a given product code.", EnableSession = false)]
        public ProductDetails GetProductDetails(string ProductCode)
        {
            AssignValues(ProductCode);
            ProductDetails RequestedProductDetails = new ProductDetails();
            RequestedProductDetails.ProductCode = Products.ProductCode;
            RequestedProductDetails.Title = Products.Title;
            RequestedProductDetails.Description = Products.Description;
            RequestedProductDetails.Price = Products.Price;
            return RequestedProductDetails;
        }
    }
}
