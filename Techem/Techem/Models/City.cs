using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Techem.Models
{
    public class City
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
