﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AVP_CustomLauncher.Serializers
{
    class LithTechFormatSerializer
    {
        private Type type;

        public LithTechFormatSerializer(Type type)
        {
            this.type = type;
        }

        public T Deserialize<T>(FileStream fileStream) where T : new()
        {
            StreamReader streamReader = new StreamReader(fileStream);
            var deserializedObjects = new List<Data>();

            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (line.Contains(" "))
                {
                    var split = line.Split(new char[] { ' ' }, 2);
                    deserializedObjects.Add(new Data() { PropertyName = split[0].Trim(new char[] { '\"' }), Value = split[1].Trim(new char[] { '\"' }) });
                }
            }
            streamReader.Close();

            var target = new T();
            foreach (var property in deserializedObjects)
            {

                var propInfo = target.GetType().GetProperty(property.PropertyName);
                propInfo?.SetValue(target,
                    Convert.ChangeType(property.Value, propInfo.PropertyType), null);
            }
            return target;
        }

        public struct Data
        {
            public string PropertyName;
            public string Value;
        }

        internal void Serialize(StreamWriter fw, object customConfig)
        {
            var myType = customConfig.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (var prop in props)
            {
                var isTagged = prop.GetCustomAttribute<CustomFormatElement>();
                if (isTagged != null)
                {
                    var propValue = prop.GetValue(customConfig, null);
                    fw.WriteLine(prop.Name + ":" + propValue);
                }

            }
            fw.WriteLine();
            fw.Close();
        }
    }

    internal class LithTechConfigValue : Attribute
    {
    }

    internal class LithTechConfigAction : Attribute
    {
    }

    internal class LithTechConfigBinding : Attribute
    {
    }

    internal class LithTechConfigOther : Attribute
    {
    }
}