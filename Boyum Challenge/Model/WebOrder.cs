using System;
using System.Collections.Generic;

namespace Boyum_Challenge.Model
{
   
    /// <summary>
    /// Class for storing details of a WebOrder.
    /// </summary>
    public class WebOrder
    {
        public string Customer { get; set; }
        public DateTime Date{ get; set; }
        public int Id{ get; set; }
        public List<WebOrderItem> Items{ get; set; }
        
        public WebOrder()
        {
        }
        /// <summary>
        /// Calculates Avg. Unit price taking one of each item in the order.
        /// I left in the solution if you want to take into consideration that there are more of on item.
        /// </summary>
        /// <returns></returns>
        public double AveragePrice()
        {
            double sum = 0;
            double count = 0;
            foreach (WebOrderItem item in Items)
            {
                count++;//(double) item.Quantity;
                sum += (double) item.Price; //(item.Price* item.Quantity);
            }

            return sum / count;
        }

        /// <summary>
        /// Calculates Sum of the price in the order.
        /// </summary>
        /// <returns></returns>
        public double TotalPrice()
        {
            double sum = 0;
            foreach (WebOrderItem item in Items)
            {
                sum+=(double) (item.Price* item.Quantity);
            }

            return sum;
        }

    }
}