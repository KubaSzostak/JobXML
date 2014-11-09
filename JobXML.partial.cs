using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JobXML
{
    public partial class JOBFile
    {

        [XmlAttributeAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsiSchemaLocation = "http://www.trimble.com/schema/JobXML/5_3 http://www.trimble.com/schema/JobXML/5_3/JobXMLSchema-5.3.xsd";

        public JOBFile()
        {            
            versionField = 5.3;
            productField = "JobXML.cs";
            productVersionField = "1.0";
            timeStampField = DateTime.Now;
        }
    }
}
