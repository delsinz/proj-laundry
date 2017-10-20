using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laundry_Platypus
{
    public class Garment
    {
        public string GarmentID { get; set; }
        public string Type_name { get; set; }
        public string Abbreviation { get; set; }
        public int Activate { get; set; }
        /**
        * This function is to initial the object
        * */
        public Garment(string garmentID, string type_name, string abbreviation, int activate)
        {
            GarmentID = garmentID;
            Type_name = type_name;
            Abbreviation = abbreviation;
            Activate = activate;
        }
    }
}