using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using WeBudget.Models;
using System.Xml.Serialization;

namespace WeBudget.Service
{
	public class ZdanieForArendaFileService
	{
        ConstructionCompanyContext db = new ConstructionCompanyContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/ZdanieForArenda";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(ZdanieForArenda));


        public void Create(ZdanieForArenda zdanieForArenda)
        {
           
            int fCount = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly).Length;
            int id = fCount + 1;
            zdanieForArenda.Id = id;
            string newFilePath = currentPath + "/ZdanieForArenda" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForArenda);
            File.WriteAllText(newFilePath, txtWriter.ToString());
           










        }

        public void Delete(int id)
        {
            File.Delete(currentPath + "/ZdanieForArenda" + id + ".txt");
        }

        public void Edit(ZdanieForArenda zdanieForArenda)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForArenda);
            File.WriteAllText(currentPath + "/ZddanieForArenda" + zdanieForArenda.Id + ".txt", txtWriter.ToString());
        }

        public ZdanieForArenda findZdanieForArendaById(int? id)
        {
            StreamReader stream = new StreamReader(currentPath + "/ZdanieForArenda" + id + ".txt", true);
            return (ZdanieForArenda)xsSubmit.Deserialize(stream);
        }

        public List<ZdanieForArenda> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<ZdanieForArenda> zdanieArendaList = new List<ZdanieForArenda>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                ZdanieForArenda zdanie = (ZdanieForArenda)xsSubmit.Deserialize(stream);
                zdanieArendaList.Add(zdanie);
                stream.Close();
            }
            return zdanieArendaList;
        }


        public void Dispose()
        {
            db.Dispose();
        }

    }
}
