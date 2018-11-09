using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using WeBudget.Models;
using System.Xml.Serialization;

namespace WeBudget.Service
{
	public class ZdanieForPokupkaFileService
	{
		ConstructionCompanyContext db = new ConstructionCompanyContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/ZdanieForPokupka";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(ZdanieForPokupka));

        public void Create(ZdanieForPokupka zdanieForPokupka)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"ZdanieForPokupka\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("ZdanieForPokupka", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            zdanieForPokupka.Id = id;
            string newFilePath = currentPath + "/ZdanieForPokupka" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForPokupka);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public void Delete(int id) {
            File.Delete(currentPath + "/ZdanieForPokupka" + id + ".txt");
        }

        public void Edit(ZdanieForPokupka zdanieForPokupka) {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, zdanieForPokupka);
            File.WriteAllText(currentPath + "/ZdanieForPokupka" + zdanieForPokupka.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();

        }

        public ZdanieForPokupka findZdanieForPokupkaById(int? id)
        {
            ZdanieForPokupka zdanie;
            using (StreamReader stream = new StreamReader(currentPath + "/ZdanieForPokupka" + id + ".txt", true))
            {
                zdanie = (ZdanieForPokupka)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return zdanie;
        }

        public List<ZdanieForPokupka> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<ZdanieForPokupka> zdaniePokupkaList = new List<ZdanieForPokupka>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                ZdanieForPokupka zdanie = (ZdanieForPokupka)xsSubmit.Deserialize(stream);
                zdaniePokupkaList.Add(zdanie);
                stream.Close();
            }
            return zdaniePokupkaList;
        }
   
        public void Dispose() {
            db.Dispose();
        }


    }
}