using BruPark.Jobs.OpenDataImporter.Templates;
using BruPark.OpenData.Models;
using BruPark.Persistence.DataLayer;
using BruPark.Persistence.Entities;
using BruPark.Tools.RestClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace BruPark.Jobs.OpenDataImporter
{
    class OpenDataImporter : IDisposable
    {
        public const string URL_DISABLED = "http://opendata.brussel.be/explore/dataset/parking-spaces-for-disabled/download/?format=json&timezone=Europe/Brussels";

        public const string URL_PUBLIC = "http://opendata.brussel.be/explore/dataset/public-parkings/download/?format=json&timezone=Europe/Brussels";

        private BruParkContext db = new BruParkContext();



        public void Dispose()
        {
            db.Dispose();
            db = null;
        }

        private static object GetField(IDictionary<string, object> map, string key, object defaultValue)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            }
            else
            {
                return defaultValue;
            }
        }

        public void Import()
        {
            try
            {
                ImportParkingsPublic();
                ImportParkingsDisabled();
            }
            catch (DbEntityValidationException e)
            {
                foreach (DbEntityValidationResult result in e.EntityValidationErrors)
                {
                    Debug.WriteLine("entry:  " + result.Entry);

                    foreach (DbValidationError error in result.ValidationErrors)
                    {
                        Debug.WriteLine(error.PropertyName + ":  " + error.ErrorMessage);
                    }
                }
            }
            catch (DbUpdateException e)
            {
                Exception ex = e;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                Debug.WriteLine("ERROR:  " + ex.Message);
            }
        }

        private AddressPO ImportAddress(string street)
        {
            AddressPO address = new AddressPO();

            address.Street = street;

            address = db.Addresses.Add(address);

            db.SaveChanges();

            return address;
        }

        private CompanyPO ImportCompany(string name)
        {
            CompanyPO company = (from c in db.Companies where c.Name == name select c).SingleOrDefault();

            if (company == null)
            {
                company = new CompanyPO();

                company.Name = name;

                company = db.Companies.Add(company);

                db.SaveChanges();
            }

            return company;
        }

        private LocationPO ImportLocation(decimal[] coordinates)
        {
            LocationPO location = new LocationPO();

            location.Latitude = coordinates[0];
            location.Longitude = coordinates[1];

            location = db.Locations.Add(location);

            db.SaveChanges();

            return location;
        }

        private int ImportParking(ParkingTemplate template)
        {
            ParkingPO parking = (from p in db.Parkings where p.RecordId == template.RecordId select p).SingleOrDefault();
            
            if (parking == null)
            {
                //  Create

                parking = new ParkingPO();

                parking.AddressDutch = ImportAddress(template.AddressNL);
                parking.AddressFrench = ImportAddress(template.AddressFR);

                if (template.Company != null)
                {
                    parking.Company = ImportCompany(template.Company);
                }

                parking.Disabled = template.Disabled;
                parking.Location = ImportLocation(template.Location);
                parking.RecordId = template.RecordId;
                parking.Spaces = template.Spaces;

                parking = db.Parkings.Add(parking);

                Debug.WriteLine("Added parking # " + parking.Id + " (" + parking.RecordId + ")");
            }
            else
            {
                //  Update

                db.Addresses.Attach(parking.AddressDutch).Street = template.AddressNL;
                db.Addresses.Attach(parking.AddressFrench).Street = template.AddressFR;

                if (template.Company != null)
                {
                    if ((parking.Company == null) || !template.Company.Equals(parking.Company.Name))
                    {
                        parking.Company = ImportCompany(template.Company);
                    }
                }

                parking.Disabled = template.Disabled;
                parking.RecordId = template.RecordId;
                parking.Spaces = template.Spaces;

                Debug.WriteLine("Update parking # {0} ({1})", parking.Id, parking.RecordId);
            }

            db.SaveChanges();

            return parking.Id;
        }

        private void ImportParkingsDisabled()
        {
            Response<IList<Record>> response = RestClient.Get<IList<Record>>(URL_DISABLED);

            if (response.Failure)
            {
                Debug.WriteLine("ERROR:  " + response.Error);
                return;
            }

            IList<Record> records = response.Body;

            ParkingTemplate template = new ParkingTemplate();

            template.Disabled = true;

            foreach (Record record in records)
            {
                if (!String.IsNullOrWhiteSpace(record.RecordId) && (record.Geometry != null))
                {
                    IDictionary<string, object> fields = record.Fields;

                    template.AddressFR = Convert.ToString(GetField(fields, "adresse", "???"));
                    template.AddressNL = Convert.ToString(GetField(fields, "adres", "???"));
                    template.Company = null;
                    template.Location = record.Geometry.Coordinates.Reverse().ToArray();
                    template.RecordId = record.RecordId;
                    template.Spaces = Convert.ToInt32(GetField(fields, "nombre_d_emplacements", -1));

                    ImportParking(template);
                }
            }
        }

        private void ImportParkingsPublic()
        {
            Response<IList<Record>> response = RestClient.Get<IList<Record>>(URL_PUBLIC);

            if (response.Failure)
            {
                Debug.WriteLine("ERROR:  " + response.Error);
                return;
            }

            IList<Record> records = response.Body;

            ParkingTemplate template = new ParkingTemplate();

            template.Disabled = false;

            foreach (Record record in records)
            {
                if (!String.IsNullOrWhiteSpace(record.RecordId))
                {
                    IDictionary<string, object> fields = record.Fields;
                    
                    template.AddressFR = Convert.ToString(GetField(fields, "parking_adresse", "???"));
                    template.AddressNL = Convert.ToString(GetField(fields, "parking_adresse", "???"));
                    template.Company = Convert.ToString(GetField(fields, "societe_gestionnaire", "???"));
                    template.Location = record.Geometry.Coordinates.Reverse().ToArray();
                    template.RecordId = record.RecordId;
                    template.Spaces = Convert.ToInt32(GetField(fields, "nombre_de_places", -1));

                    ImportParking(template);
                }
            }
        }
    }
}
