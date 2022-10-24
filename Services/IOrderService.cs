using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.Services
{
    internal interface IOrderService
    {
        void PlaceOrder(List<string> orders);
    }
}
