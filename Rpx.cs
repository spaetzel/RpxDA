using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
namespace Spaetzel.RpxDA
{
public static class Rpx
{
    


    public static RpxProfile OpenidResponse(string token, bool extended) {
        Dictionary<string,string> query = new Dictionary<string,string>();
        query.Add("token", token);
        if (extended)
        {
            query.Add("extended", "true");
        }
                
        var doc = ApiCall("auth_info", query);

        return (from p in doc.Descendants("profile")
                select new RpxProfile(p)).First();
    }

    //public static ArrayList Mappings(string primaryKey) {
    //    Dictionary<string,string> query = new Dictionary<string,string>();
    //    query.Add("primaryKey", primaryKey);
    //    XmlElement rsp = ApiCall("mappings", query);
    //    XmlElement oids = (XmlElement)rsp.FirstChild;

    //    ArrayList result = new ArrayList();

    //    for (int i = 0; i < oids.ChildNodes.Count; i++) {
    //        result.Add(oids.ChildNodes[i].InnerText);
    //    }

    //    return result;
    //}

    public static void Map(string identifier, string primaryKey) {
        Dictionary<string,string> query = new Dictionary<string,string>();
        query.Add("identifier", identifier);
        query.Add("primaryKey", primaryKey);
        ApiCall("map", query);
    }

    public static void Unmap(string identifier, string primaryKey) {
        Dictionary<string,string> query = new Dictionary<string,string>();
        query.Add("identifier", identifier);
        query.Add("primaryKey", primaryKey);
        ApiCall("unmap", query);
    }

    private static XDocument ApiCall(string methodName, Dictionary<string,string> partialQuery) {
        Dictionary<string,string> query = new Dictionary<string,string>(partialQuery);
        query.Add("format", "xml");
        query.Add("apiKey", Config.ApiKey);

        StringBuilder sb = new StringBuilder();
        foreach (KeyValuePair<string, string> e in query) {
            if (sb.Length > 0) {
                sb.Append('&');
            }

            sb.Append(System.Web.HttpUtility.UrlEncode(e.Key, Encoding.UTF8));
            sb.Append('=');
            sb.Append(HttpUtility.UrlEncode(e.Value, Encoding.UTF8));
        }
        string data = sb.ToString();

        Uri url = new Uri(Config.BaseUrl + "/api/v2/" + methodName);

        String response = UtilityLibrary.Utilities.HttpPost(url.ToString(), data);

        XDocument doc = XDocument.Parse(response);

        return doc;
    }

    //public static static void Main(string[] args) {
    //    Rpx r = new Rpx(args[0], args[1]);

    //    if (args[2].Equals("mappings")) {
    //        Console.WriteLine("Mappings for " + args[3] + ":");
    //        foreach(string s in r.Mappings(args[3])) {
    //            Console.WriteLine(s);
    //        }
    //    }

    //    if (args[2].Equals("map")) {
    //        Console.WriteLine(args[3] + " mapped to " + args[4]);
    //        r.Map(args[3], args[4]);
    //    }

    //    if (args[2].Equals("unmap")) {
    //        Console.WriteLine(args[3] + " unmapped from " + args[4]);
    //        r.Unmap(args[3], args[4]);
    //    }

    }
}
