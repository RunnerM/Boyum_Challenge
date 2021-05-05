using System;
using System.Xml.Serialization;

namespace Boyum_Challenge.Model
{
    /// <summary>
    /// Class for storing Data of an Item in WebOrder.
    /// </summary>
    public class WebOrderItem
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public decimal Price{ get; set; }
        public decimal Quantity{ get; set; }

        public WebOrderItem()
        {
        }
    }
}