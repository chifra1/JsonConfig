using System;
using Utils;

namespace UtilsExamples 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JsonConfigHandler example: see settings.cfg.example");

            JsonConfigHandler<JsonConfigExample> handler = new JsonConfigHandler<JsonConfigExample>("settings.cfg");
            
            //to get an example of json config file
            JsonConfigExample example = new JsonConfigExample() { Mailfrom = "ddd@example.org", Mailto = "aaa@example.org,bbb@example.org", ServerSmtp = "mail.example.org", Port = 555 };
            handler.WriteExample(example);

            //load a json configuration file
            JsonConfigExample? myconfig= handler.Load();
            if (myconfig != null)
            { 
                if(myconfig.Mailfrom != null)   Console.WriteLine("Mailfrom=" + myconfig.Mailfrom);
            }
        }
    }
    /// <summary>
    /// Example of Poco class to manage configuration settings
    /// </summary>
    public class JsonConfigExample : JsonConfig
    {
        public string? Mailfrom { get; set; }
        public string? Mailto { get; set; }
        public string? ServerSmtp { get; set; }
        public int Port { get; set; }
    }
}