using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
    internal class Controller : IController
    {
        private Application app;
        private List<string> emails;
        public Controller()
        {
            app = new Application();
            emails = new List<string>();
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (productType != typeof(Item).Name && productType != typeof(Service).Name)
            {
                return $"{productType} is not a valid type for the application.";
            }
            if (app.Products.Exists(productName))
            {
                return $"{productName} already exists in the application.";
            }
            if (!app.Users.Exists(userName))
            {
                return $"{userName} has no data access.";
            }
            if (app.Users.GetByName(userName).GetType() == typeof(Client))
            {
                return $"{userName} has no data access.";
            }
            IProduct product;
            if (productType == typeof(Item).Name)
            {
                product = new Item(productName, basePrice);
            }
            else
            {
                product = new Service(productName, basePrice);
            }
            app.Products.AddNew(product);
            return $"{productType}: {productName} is added in the application. Price: {basePrice:F2}";
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Application administration:");
            foreach (IUser a in app.Users.Models.Where(x => x.GetType() == typeof(Admin)).OrderBy(x => x.UserName))
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("Clients:");
            foreach (Client a in app.Users.Models.Where(x => x.GetType() == typeof(Client)).OrderBy(x => x.UserName))
            {
                sb.AppendLine(a.ToString());
                int count = a.Purchases.Where(x => x.Value == true).Count();
                if (count > 0)
                {

                    sb.AppendLine($"-Black Friday Purchases: {count}");
                    foreach (string productName in a.Purchases.Where(x => x.Value == true).Select(x => x.Key))
                    {
                        sb.AppendLine($"--{productName}");
                    }
                }

            }



            return sb.ToString().TrimEnd();
        }
        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            if (!app.Users.Exists(userName))
            {
                return $"{userName} has no authorization for this functionality.";
            }

            if (app.Users.GetByName(userName).GetType() == typeof(Admin))
            {
                return $"{userName} has no authorization for this functionality.";
            }
            if (!app.Products.Exists(productName))
            {
                return $"{productName} does not exist in the application.";
            }
            IProduct product = app.Products.GetByName(productName);

            if (product.IsSold)
            {
                return $"{productName} is out of stock.";

            }
            Client client = (Client)app.Users.GetByName(userName);
            client.PurchaseProduct(productName, blackFridayFlag);
            product.ToggleStatus();
            double price = blackFridayFlag ? product.BlackFridayPrice : product.BasePrice;
            return $"{userName} purchased {productName}. Price: {price:F2}";
        }

        public string RefreshSalesList(string userName)
        {
            if (!app.Users.Exists(userName))
            {
                return $"{userName} has no data access.";
            }
            if (app.Users.GetByName(userName).GetType() == typeof(Client))
            {
                return $"{userName} has no data access.";
            }
            int count = 0;
            foreach (IProduct product in app.Products.Models.Where(p => p.IsSold))
            {
                count++;
                product.ToggleStatus();
            }
            return $"{count} products are listed again.";
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            if (app.Users.Exists(userName))
            {
                return $"{userName} is already registered.";
            }
            if (emails.Contains(email))
            {
                return $"{email} is already used by another user.";
            }
            if (hasDataAccess)
            {
                if (app.Users.Models.Where(x => x.GetType().Name == "Admin").Count() == 2)
                {
                    return "The number of application administrators is limited.";
                }
                app.Users.AddNew(new Admin(userName, email));
                emails.Add(email);
                return $"Admin {userName} is successfully registered with data access.";
            }
            else
            {
                app.Users.AddNew(new Client(userName, email));

                emails.Add(email);
                return $"Client {userName} is successfully registered.";
            }
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!app.Products.Exists(productName))
            {
                return $"{productName} does not exist in the application.";
            }
            if (!app.Users.Exists(userName))
            {
                return $"{userName} has no data access.";
            }
            if (app.Users.GetByName(userName).GetType() == typeof(Client))
            {
                return $"{userName} has no data access.";
            }
            IProduct product = app.Products.GetByName(productName);
            double oldPriceValue = product.BasePrice;
            product.UpdatePrice(newPriceValue);
            return $"{productName} -> Price is updated: {oldPriceValue:F2} -> {newPriceValue:F2}";
        }
    }
}
