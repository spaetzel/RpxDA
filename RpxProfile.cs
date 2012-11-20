using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace Spaetzel.RpxDA
{
    [Serializable]
    public class RpxProfile : ISerializable
    {
        public RpxProfile(XElement item)
        {

            Identifier = Utilities.GetElementValue(item.Element("identifier"));
          //  FormattedName Utilities.GetElementValue(item.Element("link"));
            Username = Utilities.GetElementValue(item.Element("preferredUsername"));
           DisplayName = Utilities.GetElementValue(item.Element("displayName"));
            Url = Utilities.GetElementValue(item.Element("url"));
            Gender = Utilities.GetElementValue(item.Element("gender"));
            Email = Utilities.GetElementValue(item.Element("email"));

        }

        public RpxProfile(SerializationInfo info, StreamingContext context)
        {
            Identifier = (string)info.GetValue("Identifier", typeof(string));
            FormattedName = (string)info.GetValue("FormattedName", typeof(string));
            Email = (string)info.GetValue("Email", typeof(string));
            Gender = (string)info.GetValue("Gender", typeof(string));
            Url = (string)info.GetValue("Url", typeof(string));
        }

        public string Identifier { get; set; }
        public string FormattedName { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Identifier", Identifier);
            info.AddValue("FormattedName", FormattedName);
            info.AddValue("Email", Email);
            info.AddValue("Gender", Gender);
            info.AddValue("Url", Url);
        }

        #endregion
    }
}
