using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.Extensions
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// The factor for converting degrees to radians
        /// </summary>
        private const double D2R = (Math.PI / 180D);



        public static double DegreesToRadians(this decimal radians)
        {
            return (Convert.ToDouble(radians) * D2R);
        }
    }
}
