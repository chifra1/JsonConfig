using System;
using System.Text;
using System.Reflection;
using Newtonsoft.Json;

namespace Utils
{
    public class JsonConfigHandler<T> where T : JsonConfig
    {

        private string _filename = "config.json";

        public JsonConfigHandler()
        {
        }
        public JsonConfigHandler(string filename) : base()
        {
            _filename = string.IsNullOrWhiteSpace(filename) ? _filename : filename.Trim();
        }
        public void WriteExample(T example)
        {
            File.WriteAllText(_filename+".example", JsonConvert.SerializeObject(example, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented }));
        }
        public void Write(T config)
        {
            File.WriteAllText(_filename, JsonConvert.SerializeObject(config, new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented }));
        }
        public JsonConfig? Load()
        {
            JsonConfig? _ret = null;
            //load configuration file
            try
            {
                _ret = JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText(_filename));                
            }
            catch (Exception ex)
            {
                File.WriteAllText(_filename + ".log", "Wrong config file\n\n" + ex.Message);
            }
            return _ret; 
        }
    }
    public class JsonConfig
    { 
    
    }
}