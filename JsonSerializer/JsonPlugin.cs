using Painter.Models;

namespace JsonSerializer
{
	public class JsonPlugin : IPluginFile
	{
		public string Name => "Json";
		public bool Enabled { get; set; }

		public MTab Deserialize(string str)
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<MTab>(str);
		}

		public string Serialize(MTab mTab)
		{
			return Newtonsoft.Json.JsonConvert.SerializeObject(mTab);
		}
	}
}
