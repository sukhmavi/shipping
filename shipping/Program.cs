using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEB27
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor();
            var order = new Order
            {
                DatePlaced = DateTime.Now,
                TotalPrice = 100f
            };
            orderProcessor.Process();
        }

        public class OrderProcessor
        {
            private readonly ShippingCalculator _shippingcalculator;
            public OrderProcessor()
            {
                _shippingcalculator = new ShippingCalculator();
            }

            public void Process(Order order)
            {
                if (order.IsShipped)
                    throw new InvalidOperationException("This order is already processed");
                order.Shipment = new Shipment
                {
                    Cost = _shippingcalculator.CalculatorShipping(order),
                    ShippingDate = DateTime.Today.AddDays(1)
                };
            }
        }
        public class ShippingCalculator
        {
            public float CalcualtorShipping(Order order)
            {
                if (order.TotalPrice < 30f) return order.TotalPrice * 0.1f;
                return 0;
            }
        }
    }