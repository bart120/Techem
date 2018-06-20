using System;
using System.Collections.Generic;
using System.Text;

namespace Techem.Models
{
    public class Weather
    {
        public Weather()
        {
            this.Sun = new Sun();
        }

        public string City { get; set; }

        public double Temperature { get; set; }

        public string Icon { get; set; }

        public Sun Sun { get; set; }

    }

    public class Sun
    {
        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }
    }
}
