using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class ZdanieForFilePokupkaService
	{
		ConstructionCompanyContext db = new ConstructionCompanyContext();

        public void Delete(int id) {
            ZdanieForPokupka b = db.ZdanieForPokupkas.Find(id);
            if (b != null)
            {
                db.ZdanieForPokupkas.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(ZdanieForPokupka zdanieForPokupka) {
            db.Entry(zdanieForPokupka).State = EntityState.Modified;
            db.SaveChanges();
        }
            
        public void Create(ZdanieForPokupka zdanieForPokupka) {
            db.ZdanieForPokupkas.Add(zdanieForPokupka);
            db.SaveChanges();
        }

        public ZdanieForPokupka findZdanieForPokupkaById(int? id)
        {
            ZdanieForPokupka zdanieForPokupka = db.ZdanieForPokupkas.Find(id);
            return zdanieForPokupka;
        }

        public List<ZdanieForPokupka> getList()
        {
            return db.ZdanieForPokupkas.ToList();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}