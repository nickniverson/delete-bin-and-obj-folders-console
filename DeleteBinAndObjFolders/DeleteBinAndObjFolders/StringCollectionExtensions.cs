using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace DeleteBinAndObjFolders
{
	public static class StringCollectionExtensions
	{
		public static List<string> ConvertToList(this StringCollection instance)
		{
			return instance
				.Cast<string>()
				.ToList();
		}
	}
}
