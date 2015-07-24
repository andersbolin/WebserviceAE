using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Xml;

namespace AgeevidencerTest
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://www.ageevidencer.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Returns string if connection established")]
        public string HelloWorld()
        {
            return "Connection established";
        }

       

        [WebMethod(Description = "Returns string")]
        public string getUserName()
        {
            //var json = "";
            DAL dal = new DAL();
            //dynamic result = dal.getFirstName();
            //JavaScriptSerializer  jss = new JavaScriptSerializer();
            //var jsonString = JsonConvert.SerializeObject(result);
            //json = jss.Serialize(result);
            string xml = dal.getFirstName();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);

            return json;
        }

        [WebMethod]
        public string testXML()
        {
            string xml = "<Test><Name>Test class</Name><X>100</X><Y>200</Y></Test>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
            return json;
        }

    }
}
