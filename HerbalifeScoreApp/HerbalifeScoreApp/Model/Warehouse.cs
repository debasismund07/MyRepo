using System;
using System.Linq;
using PagedList;

namespace HerbalifeScoreApp.Model
{
    public class Warehouse
    {
        public string WHCode { get; set; }
        public string CountryCode { get; set; }
        public string WHType { get; set; }
        public string City { get; set; }
        public Nullable<bool> Active { get; set; }
        public string CreateUser { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ChangeUser { get; set; }
        public Nullable<System.DateTime> ChangeDate { get; set; }
        string errorMessage = string.Empty;

        public int InsertWareHouse(Warehouse warehouse)
        {
            int result = 0;
            try
            {
                using (var aPACScore = new APACScoreEntities())
                {
                    aPACScore.HL_Web_Warehouse.Add(new HL_Web_Warehouse()
                    {
                        CountryCode = warehouse.CountryCode,
                        WHCode = warehouse.WHCode,
                        WHType = warehouse.WHType,
                        City = warehouse.City,
                        Active = warehouse.Active,
                    });

                    result = aPACScore.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw ex;
            }
            return result;
        }
        public IPagedList SelectWareHouses(int page, int noofRows, out int noOfRecords)
        {
            noOfRecords = 0;
            noofRows = noofRows == 0 ? 10 : noofRows;
            page = page == 0 ? 1 : page;
            IPagedList warehouses = null;
            try
            {
                using (var aPACScore = new APACScoreEntities())
                {
                    noOfRecords = aPACScore.HL_Web_Warehouse.ToList().Count;

                    warehouses = (from c in aPACScore.HL_Web_Warehouse
                                  join e in aPACScore.HL_Country
                                      on c.CountryCode equals e.CountryCode
                                  select new
                                  {
                                      WHCode = c.WHCode,
                                      WHType = c.WHType,
                                      CountryCode = c.CountryCode,
                                      CountryName = e.CountryName,
                                      City = c.City,
                                      Active = c.Active
                                  }).ToList().ToPagedList(page, noofRows);
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw ex;
            }
            return warehouses;
        }
        public int SelectWareHouse(string warehouseCode)
        {
            int result = 0;
            try
            {
                using (var aPACScoreEntities = new APACScoreEntities())
                {
                    var existingWarehouse = aPACScoreEntities.HL_Web_Warehouse.Where(s => s.WHCode == warehouseCode).FirstOrDefault<HL_Web_Warehouse>();

                    result = existingWarehouse != null ? 1 : 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw ex;
            }
            return result;
        }
        public IPagedList SearchWareHouse(string keywords, int page, int noofRows, out int noOfRecords)
        {
            noOfRecords = 0;
            noofRows = noofRows == 0 ? 10 : noofRows;
            page = page == 0 ? 1 : page;
            IPagedList warehouses = null;
            try
            {
                using (var aPACScore = new APACScoreEntities())
                {
                    noOfRecords = aPACScore.HL_Web_Warehouse.Where(x => x.WHCode.Contains(keywords)).ToList().Count;
                    warehouses = (from c in aPACScore.HL_Web_Warehouse
                                  join e in aPACScore.HL_Country
                                      on c.CountryCode equals e.CountryCode
                                  select new
                                  {
                                      WHCode = c.WHCode,
                                      WHType = c.WHType,
                                      CountryCode = c.CountryCode,
                                      CountryName = e.CountryName,
                                      City = c.City,
                                      Active = c.Active
                                  }).Where(x => x.WHCode.Contains(keywords)).ToList().ToPagedList(page, noofRows);
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                throw ex;
            }
            return warehouses;
        }
    }
}