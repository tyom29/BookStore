using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Abstract;
using OnlineShop.Domain.Entities;
using System.Net;
using System.Net.Mail;

namespace OnlineShop.Domain.Concrete
{
    public class EmailSettings
    {
        public string mailToAdress = "Orders@example.com";
        public string mailFromAdress = "OnlineShop@example.com";
        public string userName = "MySmtpUserName";
        public string password = "MySmtpPassword";
        public string fileLocation = @"C:\Users\Dell\Desktop\OnlineShop-Mail";
        public bool useSsl = true;
        public bool writeAsFie = false;
        public int serverPort = 587;
        public string serverName = "Smtp.examples.com";
    }
    public class EmailOrderProcessor : IOrderProcesore
    {
        private EmailSettings settings;
        public EmailOrderProcessor(EmailSettings sett)
        {
            settings = sett;
        }
        public void ProceseOrder(Cart cart, SheepingDetails details)
        {
            using (SmtpClient smtp=new SmtpClient())
            {
                smtp.EnableSsl = settings.useSsl;
                smtp.Host = settings.serverName;
                smtp.Port = settings.serverPort;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(settings.userName, settings.password);
                if(settings.writeAsFie)
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = settings.fileLocation;
                    smtp.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder().AppendLine("Your Order is ready")
                    .AppendLine("--------")
                    .AppendLine("items");
                foreach(var line in cart.Lines)
                {
                    decimal subTotal = line.Product.Price * line.Quantity;
                    body.AppendFormat(" {0} items of {1} Coast {2}", line.Quantity, line.Product.Name, subTotal);
                }
                body.AppendFormat("{0}", cart.TotalCoast()).AppendLine("-------")
                    .AppendLine("Ship To " + details.Name)
                    .AppendLine(details.Line_1).AppendLine(details.Line_2).AppendLine(details.Line_3)
                    .AppendLine(details.State).AppendLine(details.Country).AppendLine(details.City)
                    .AppendLine(details.Zip).AppendLine("--------")
                    .AppendFormat(details.GiftWrap == true ? "Yes" : "No");
                MailMessage mm = new MailMessage(settings.mailFromAdress, settings.mailToAdress, "Some Text", body.ToString());
                if(settings.writeAsFie)
                {
                    mm.BodyEncoding = Encoding.ASCII;
                }
                smtp.Send(mm);
            }
        }
    }
}
