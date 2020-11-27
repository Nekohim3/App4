using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using Newtonsoft.Json;

namespace App4
{

    public class Offer
    {
        public string Id   { get; set; }
        public string Data { get; set; }

        public Offer(string id, XmlNode data)
        {
            Id   = id;
            Data = JsonConvert.SerializeXmlNode(data, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
