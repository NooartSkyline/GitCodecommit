using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Data.SqlServerCe;

namespace DoHome.HandHeld.Client
{
    public class SqlHelper
    {
        public static string GetSql(int queryID)
        {
            Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream("DoHome.HandHeld.Client.Sql.xml");

            XmlDocument doc = new XmlDocument();

            doc.Load(stream);

            XmlNode node = doc.SelectSingleNode(string.Format("/sql/query[@id={0}]", queryID));

            return node != null ? node.InnerText : null;

        }

        public static string SqlCeConnectionString
        {
            get
            {
                return "Data Source =" + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\HandHeldDB.sdf;Password =p@ssw0rd";
            }
        }

        //public static void ExecuteNonQuery(int queryID,SqlCeParameter parametor)
        //{
        //    using (SqlCeConnection con = new SqlCeConnection(SqlCeConnectionString))
        //    {
        //        con.Open();

        //        using (SqlCeCommand com = new SqlCeCommand(SqlHelper.GetSql(2), con))
        //        {
        //            foreach (var item in locations)
        //            {
        //                com.Parameters.AddWithValue("@LocationCode", item.Code);
        //                //com.Parameters.AddWithValue("@LocationName", item.Name);
        //                com.ExecuteNonQuery();
        //                com.Parameters.Clear();
        //            }
        //        }
        //    }
        //}

    }
}
