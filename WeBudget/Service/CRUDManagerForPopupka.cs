using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service
{
    public abstract class CRUDManagerForPokupka
    {
        public abstract ZdanieForPokupka findZdanieForPokupkaById(int? id);

        public abstract void Edit(ZdanieForPokupka zdanieForPokupka);

        public abstract void Create(ZdanieForPokupka zdanieForPokupka);
       
        public abstract void Delete(int id);

        public abstract List<ZdanieForPokupka> getList();

        public abstract void Dispose();
    }
}
