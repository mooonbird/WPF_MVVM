using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.Client.Services
{
    internal class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> orders)
        {
            try
            {
                System.IO.File.WriteAllLines(@"order.txt", orders.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
