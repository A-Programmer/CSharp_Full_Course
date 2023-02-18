using System.Xml;

namespace System;

public static class DateTimeExtensions
{
    public static string ToXmlDateTime(this DateTime dateTime, XmlDateTimeSerializationMode mode = XmlDateTimeSerializationMode.Utc)
    {
        return XmlConvert.ToString(dateTime, mode);
    }
}
