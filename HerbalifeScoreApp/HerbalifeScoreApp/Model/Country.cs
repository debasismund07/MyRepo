using System;
using System.Collections.Generic;
using System.Linq;

namespace HerbalifeScoreApp.Model
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }

        public List<HL_Country> SelectCountries()
        {
            string errorMessage = string.Empty;
            List<HL_Country> countries = null;
            try
            {
                using (var aPACScore = new APACScoreEntities())
                {
                    countries = aPACScore.HL_Country.ToList();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw ex;
            }
            return countries;
        }
    }
}