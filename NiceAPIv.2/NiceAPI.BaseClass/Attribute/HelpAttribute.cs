﻿namespace NiceAPI.BaseClass
{
    public class HelpAttribute : System.Attribute
    {
        string url;
        string topic;

        public HelpAttribute(string url)
        {
            this.url = url;
        }

        public string Url
        {
            get { return url; }
        }

        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
    }
}
