using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Entry
{
    public class Customer
    {
        private string _id;
        private string _name;
        private string _email;
        private string _phone;
        private string _address;
        private string _city;

        public Customer(string id, string name, string email, string phone, string address, string city)
        {
            _id = id;
            _name = name;
            _email = email;
            _phone = phone;
            _address = address;
            _city = city;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public string City { get => _city; set => _city = value; }
    }
}
