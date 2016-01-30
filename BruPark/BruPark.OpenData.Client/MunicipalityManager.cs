using BruPark.OpenData.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BruPark.OpenData.Client
{
    public class MunicipalityManager
    {
        private IList<Municipality> municipalities;
        


        public MunicipalityManager()
        {
            municipalities = LoadMunicipalities();
        }
        

        
        public IList<Municipality> GetMunicipalitiesByName()
        {
            return municipalities.OrderBy(m => m.Name).ToList();
        }

        public IList<Municipality> GetMunicipalitiesByPostalCode()
        {
            return municipalities.OrderBy(m => m.PostalCode).ToList();
        }

        private static IList<Municipality> LoadMunicipalities()
        {
            IList<Municipality> results = new List<Municipality>();

            string csv = Properties.Resources.gemeentecodes;

            using (StringReader reader = new StringReader(csv))
            {
                for (string line; ((line = reader.ReadLine()) != null);)
                {
                    string[] tokens = line.Split(new char[] { ';' }, 4);

                    Municipality municipality = new Municipality();
                    municipality.Name = tokens[2];
                    municipality.PostalCode = Convert.ToInt32(tokens[1]);

                    results.Add(municipality);
                }
            }

            return results;
        }
        
    }
}
