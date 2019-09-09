using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizontalList
{
    public class Card
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public Card()
        {

        }
        public Card(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
