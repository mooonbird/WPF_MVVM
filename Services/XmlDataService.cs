using CrazyElephant.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrazyElephant.Client.Services
{
    internal class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishList = new List<Dish>();
            string xmlFileName = System.IO.Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument xDocument = XDocument.Load(xmlFileName);
            IEnumerable<XElement> dishes = xDocument.Descendants("Dish");
            foreach (var dish in dishes)
            {
                Dish dishTemp = new Dish()
                {
                    Name = dish.Element("Name")!.Value,
                    Category = dish.Element("Category")!.Value,
                    Comment = dish.Element("Comment")!.Value,
                    Score = Convert.ToDouble(dish.Element("Score")!.Value),
                };
                dishList.Add(dishTemp);
            }

            return dishList;
        }
    }
}
