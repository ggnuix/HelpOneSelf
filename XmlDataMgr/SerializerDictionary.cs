using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml;
using UnityEngine;

public class SerializerDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        XmlSerializer intSerializer = new XmlSerializer(typeof(int));
        XmlSerializer stringSerializer = new XmlSerializer(typeof(string));
        reader.Read();
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            TKey key = (TKey)intSerializer.Deserialize(reader);
            TValue value = (TValue)stringSerializer.Deserialize(reader);
            this.Add(key, value);
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer intSerializer = new XmlSerializer(typeof(int));
        XmlSerializer stringSerializer = new XmlSerializer(typeof(string));

        foreach (var item in this)
        {
            intSerializer.Serialize(writer, item.Key);
            stringSerializer.Serialize(writer, item.Value);
        }
    }
}