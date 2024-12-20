using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XmlDataMgr
{
    private XmlDataMgr instance = new XmlDataMgr();

    public XmlDataMgr Instance => instance;

    private XmlDataMgr() { }

    public void SaveData(object data , string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";

        using(StreamWriter writer = new StreamWriter(path)) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
            xmlSerializer.Serialize(writer, data);
        }
    }

    public object LoadData(Type type, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".xml";
        if(!File.Exists(path))
        {
            path = Application.streamingAssetsPath + "/" + fileName + ".xml";
            if(!File.Exists (path))
            {
                return Activator.CreateInstance(type);
            }
        }
        using(StreamReader reader = new StreamReader(path))
        {
            XmlSerializer xmlSerializer = new XmlSerializer (type);
            return xmlSerializer.Deserialize(reader);
        }
    }
}
