using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBudget.Models;

namespace WeBudget.Service
{
    public abstract class CRUDManagerForArenda
    {
        public abstract ZdanieForArenda findZdanieForArendaById(int? id);

        public abstract void Edit(ZdanieForArenda zdanieForArenda);

        public abstract void Create(ZdanieForArenda zdanieForArenda);

        public abstract void Delete(int id);
    }
}
