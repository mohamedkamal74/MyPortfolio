using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Owner:EntityBase
    {
        public string MyProperty { get; set; }
        public string JobTitle { get; set; }
        public string profile { get; set; }
        public Address Address { get; set; }
    }
}
