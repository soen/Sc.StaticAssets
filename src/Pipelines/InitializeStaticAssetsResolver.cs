using System.Web;
using Sitecore.Pipelines;

namespace Sc.StaticAssets.Pipelines
{
	public class InitializeStaticAssetsResolver
	{
		private readonly string _assetPath;

		public InitializeStaticAssetsResolver(string assetPath)
		{
			_assetPath = assetPath;
		}

		public void Process(PipelineArgs args)
		{
			var resolver = new StaticAssetResolver(HttpContext.Current.Server.MapPath(_assetPath), HttpContext.Current.Cache);
			StaticAssetsRenderer.Initialize(resolver);
		}
	}
}