using System;
using System.Collections.Generic;
using System.IO;
using Boyum_Challenge.Model;

namespace Boyum_Test.Model
{
    public class WebOrderXmlDeserializer
    {
        /// <summary>
        /// Deserializes an XML File that contains one WebOrder object.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>WebOrder</returns>
        public WebOrder ProcessFile(string filename) 
        {
            try
            {
                // Opening File to read.
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(fs);
            
            // Declaring local variables.
            WebOrder order=new WebOrder();
            order.Items= new List<WebOrderItem>();
            string line;
            
            // Reading WebOrder details
            reader.ReadLine();// flushing first line
            line = reader.ReadLine();
            order.Id = Int32.Parse(ReadXmlAttribute(line,1)[0]);
            line = reader.ReadLine();
            order.Customer = ReadXmlElement(line);
            line = reader.ReadLine();
            string tempDate= ReadXmlElement(line);
            order.Date = new DateTime(
                Int32.Parse(tempDate.Substring(0,4)),
                Int32.Parse(tempDate.Substring(4,2)),
                Int32.Parse(tempDate.Substring(6,2)) 
                );
            // Dropping one line than preloading for the loop.
            reader.ReadLine();
            line = reader.ReadLine();
            
            // Loop until no more items left.
            while (!line.Contains("</Items>")) 
            {
                // Reading file through item
                string[] tempAttribute = ReadXmlAttribute(line, 2);
                line = reader.ReadLine();
                int tepmQ = Int32.Parse(ReadXmlElement(line));
                line = reader.ReadLine();
                decimal tempP = Decimal.Parse(ReadXmlElement(line).Replace('.',','));
                
                // Dropping carriage and reading forward to next item. 
                reader.ReadLine();
                line = reader.ReadLine();
                
                // Composing Item to add.
                WebOrderItem Item = new WebOrderItem();
                Item.Id = tempAttribute[0];
                Item.Description = tempAttribute[1];
                Item.Quantity = tepmQ;
                Item.Price = tempP;
                
                // Adding Item to order
                order.Items.Add(Item);
            }
            //Closing up so nothing left open.
            reader.Close();
            fs.Close();
            
            return order;
            }
            catch (Exception e)
            {
                throw new FileLoadException(e.Message);
            }
        }

        private string ReadXmlElement(string line)
        {
            string attributeContent="";
            bool read = false;
            for (int i = 0; i<=line.Length; i++)
            {
                if (line.Substring(i, 2).Equals("</"))
                {
                    break;
                }
                if (read)
                {
                    attributeContent = attributeContent + line.Substring(i,1);
                }
                if (line.Substring(i, 1).Equals(">"))
                {
                    read = true;
                }
            }

            return attributeContent;

        }

        private string[] ReadXmlAttribute(string line,int expectedNumOfAttribute)
        {
            string[] result= new string[expectedNumOfAttribute];

            string[] temp = line.Split('"');
            int j = 0;
            for (int i = 0;i<temp.Length;i++)
            {
                if (i%2!=0)
                {
                    result[j] = temp[i];
                    j++;
                }
            }


            return result;
        }
    }
}