using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrxUITest.src.utils
{
	public static class ObjectClone
	{
		public static T Clone<T>(this T source)
		{
			if (source is null)
			{
				return default;
			}

			var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
			var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source, serializeSettings), deserializeSettings);
		}
	}
}