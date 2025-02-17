using Newtonsoft.Json;

namespace Boardgames.Utilities
{
	public static class JsonHelper
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
		{
			//NullValueHandling = NullValueHandling.Ignore,
			//ContractResolver = new CamelCasePropertyNamesContractResolver(),
			Formatting = Formatting.Indented
		};
	}
}
