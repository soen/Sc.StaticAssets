using System.IO;
using System.Web.Caching;
using Newtonsoft.Json;

namespace Sc.StaticAssets
{
	public class StaticAssetResolver
	{
		private readonly string _assetsJsonPath;
		private readonly Cache _cache;

		private const string CacheKey = "assetsJsonDictionary";

		public StaticAssetResolver(string assetsJsonPath, Cache cache)
		{
			_assetsJsonPath = assetsJsonPath;
			_cache = cache;
		}

		public string GetActualPath(string assetPath)
		{
			var assets = _cache.Get(CacheKey) as AssetCollection;

			if (assets == null)
			{
				assets = GetAssetsFromFile();
				_cache.Insert(CacheKey, assets, new CacheDependency(_assetsJsonPath));
			}

			return assets.ContainsKey(assetPath) ? assets[assetPath] : string.Empty;
		}

		private AssetCollection GetAssetsFromFile()
		{
			return JsonConvert.DeserializeObject<AssetCollection>(File.ReadAllText(_assetsJsonPath));
		}
	}
}