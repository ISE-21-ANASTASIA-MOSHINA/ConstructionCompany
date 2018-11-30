using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using WeBudget.Models;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace WeBudget.Service
{
	public class ZdanieForArendaFileService : CRUDManagerForArenda
	{
        ConstructionCompanyContext db = new ConstructionCompanyContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/ZdanieForArenda";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(ZdanieForArenda));


        public override void Create(ZdanieForArenda zdanieForArenda)
        {

            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"ZdanieForArenda\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("ZdanieForArenda", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            zdanieForArenda.Id = id;
            string newFilePath = currentPath + "/ZdanieForArenda" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForArenda);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();

        }

        public override void Delete(int id)
        {
            File.Delete(currentPath + "/ZdanieForArenda" + id + ".txt");
        }

        public override void Edit(ZdanieForArenda zdanieForArenda)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForArenda);
            File.WriteAllText(currentPath + "/ZddanieForArenda" + zdanieForArenda.Id + ".txt", txtWriter.ToString());
        }

        public override ZdanieForArenda findZdanieForArendaById(int? id)
        {
            ZdanieForArenda zdanie;
            using (StreamReader stream = new StreamReader(currentPath + "/ZdanieForArenda" + id + ".txt", true))
            {
                zdanie = (ZdanieForArenda)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return zdanie;
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

    }
}
