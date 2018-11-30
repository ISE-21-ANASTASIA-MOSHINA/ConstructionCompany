using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class ZdanieForArendaService : CRUDManagerForArenda
    {
        ConstructionCompanyContext db = new ConstructionCompanyContext();
        public override void Delete(int id)
        {
            ZdanieForArenda b = db.ZdanieForArendas.Find(id);
            if (b != null)
            {
                db.ZdanieForArendas.Remove(b);
                db.SaveChanges();
            }
        }

        public override void Edit(ZdanieForArenda zdanieForArenda)
        {
            db.Entry(zdanieForArenda).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Create(ZdanieForArenda zdanieForArenda)
        {
            db.ZdanieForArendas.Add(zdanieForArenda);
            db.SaveChanges();
        }

        public override ZdanieForArenda findZdanieForArendaById(int? id)
        {
            ZdanieForArenda zdanieForArenda = db.ZdanieForArendas.Find(id);
            return zdanieForArenda;
        }

       public List<ZdanieForArenda> getList()
       {
            return db.ZdanieForArendas.ToList();
 
       }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}