using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entry
{
    public class Product
    {
        protected string m_id;
        protected string m_name;
        protected double m_price;

        public Product() {
            m_id = "0";
            m_name = "default";
            m_price = 0.0;
        }

        public Product(string id, string name, double price)
        {
            m_id = id;
            m_name = name;
            m_price = price;
        }

        public string Id { get => m_id; set => m_id = value; }
        public string Name { get => m_name; set => m_name = value; }
        public double Price { get => m_price; set => m_price = value; }
        public bool ValidData
        {
            get
            {
                if (Id == null) return false;
                if (Id.Trim().Equals("")) return false;
                if (Name == null) return false;
                if (Name.Trim().Equals("")) return false;
                if(Price<0) return false;
                return true;
            }
        }
        public string Info
        {
            get
            {
                return string.Format("{0}({1}, {2:#,0.00})", Name, Id, Price);
            }
        }
        public void Add(string id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public void Edit(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
