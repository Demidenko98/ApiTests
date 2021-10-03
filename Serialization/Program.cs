using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Serialization
{


    class Program
    {
        static void Main(string[] args)
        {

            //Person person = new Person { Name = "Tom", Age = 35 };
            //person.names = new string[] { "Vasya", "Petya", "Kolya" };

            //string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            //Console.WriteLine(json);
            //Person deserializedPerson = JsonConvert.DeserializeObject<Person>(json);

            string json = @"{'data':[
         {'from' : { 'name' : 'xxx', 'age': '12' }, 'message' : 'yyy' },
         { 'from' : { 'name' : 'yyy', 'age': '15' }, 'message' : 'sdfsd' },
         { 'from' : { 'name' : 'zzz', 'age': '17' }, 'message' : 'sdfsdf' }
     ]
 }";

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
            for (int i = 0; i < myDeserializedClass.data.Count; i++)
            {
                Console.WriteLine(myDeserializedClass.data[i].From.Name);
            }
               
            Console.ReadLine();
        }

        public static void XmlToJson()
        {

            string xml = @"<?xml version='1.0' standalone='no'?>
                                <root>
                                  <person id='1'>
                                    <name>Alan</name>
                                    <url>http://www.google.com</url>
                                  </person>
                                  <person id='2'>
                                    <name>Louis</name>
                                    <url>http://www.yahoo.com</url>
                                  </person>
                                </root>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            string jsonText = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);

            Console.WriteLine(jsonText);
        }


        public static void JsonToXml()
        {
            string json = @"{
              '?xml': {
                '@version': '1.0',
                '@standalone': 'no'
              },
              'root': {
                'person': [
                  {
                    '@id': '1',
                    'name': 'Alan',
                    'url': 'http://www.google.com'
                  },
                  {
                    '@id': '2',
                    'name': 'Louis',
                    'url': 'http://www.yahoo.com'
                  }
                ]
              }
            }";

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(json);
            Console.WriteLine(doc);
        }
    }

    
    public class From
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }

    public class Data
    {
        public From From { get; set; }
        public string Message { get; set; }
    }

    public class Root
    {
        public List<Data> data { get; set; }
    }


    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string[] names = new string[3]; 
    }




}

      

