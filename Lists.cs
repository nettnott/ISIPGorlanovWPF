using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIPGorlanovWPF
{
    internal class Lists
    {
        public static List<User> usersBDL = Core.Context.User.ToList();
        public static List<Appointment> appointmentsBDL = Core.Context.Appointment.ToList();
        public static List<Manufacturer> manufacturersBDL = Core.Context.Manufacturer.ToList();
        public static List<Order> ordersBDL = Core.Context.Order.ToList();
        public static List<Product> productsBDL = Core.Context.Product.ToList();
        public static List<Service> servicesBDL = Core.Context.Service.ToList();
    }
}
