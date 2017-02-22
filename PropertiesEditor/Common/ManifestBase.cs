﻿namespace PropertiesEditor.Common
{
    using System;
    using System.IO;
    using System.Xml;

    public abstract class ManifestBase
    {
        protected XmlDocument _doc;
        private XmlNode _versionNode;

        public Version Version
        {
            get { return new Version(_versionNode.Value); }
            set { _versionNode.Value = value.ToString(); }
        }

        public void Load(string path)
        {
            _doc = new XmlDocument();
            _doc.Load(new FileStream(path, FileMode.Open));
            _versionNode = GetVersion();
        }

        protected abstract XmlNode GetVersion();

        public void Save(string path)
        {
            _doc.Save(new FileStream(path, FileMode.Create));
        }
    }
}
