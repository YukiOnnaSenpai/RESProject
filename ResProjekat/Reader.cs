using System;
using System.Collections;
using System.Dynamic;
using System.Xml.Linq;

public class Reader : DynamicObject, IEnumerable
{
        private dynamic _xml;
        //Dynamic XML reader

        public Reader(string fileName)
        {
            _xml = XDocument.Load(fileName);
        }

        public Reader(dynamic xml)
        {
            _xml = xml;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var xml = _xml.Element(binder.Name);
            if (xml != null)
            {
                result = new Reader(xml);
                return true;
            }
            result = null;
            return false;
            // return base.TryGetMember(binder, out result);
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var child in _xml.Elements())
            {
                yield return new Reader(child);
            }
        }

        public static implicit operator string(Reader xml)
        {
            return xml._xml.Value;
        }

        /*In main
         dynamic doc = new Reader("Name of doc");
         foreach(var thing in doc NameOfDoc)
         Console.WriteLine(employee.FirstName());
         */
 }
