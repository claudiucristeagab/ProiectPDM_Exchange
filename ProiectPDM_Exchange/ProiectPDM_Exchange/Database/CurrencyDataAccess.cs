using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectPDM_Exchange.Database
{
    public class CurrencyDataAccess
    {
        private SQLiteConnection db;

        public CurrencyDataAccess()
        {
            db = new SQLiteConnection(DbStrings.DbPath);
            CreateCurrencyTable();
        }

        #region Get
        public List<Currency> GetAllCurrencies()
        {
            return db.Table<Currency>().ToList();
        }

        public Currency GetCityById(int id)
        {
            return db.Get<Currency>(id);
        }
        #endregion

        #region Insert
        public void InsertCurrency(Currency currency)
        {
            db.Insert(currency);
        }
        #endregion

        #region Delete
        public void DeleteCurrencyById(int id)
        {
            db.Delete<Currency>(id);
        }

        public void DeleteAllCurrencies()
        {
            db.DeleteAll<Currency>();
        }
        #endregion

        #region Create Table
        public void CreateCurrencyTable()
        {
            db.CreateTable<Currency>();
        }
        #endregion
    }
}
