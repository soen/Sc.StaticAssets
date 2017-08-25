using System.Diagnostics;
using System.Web;

namespace Sc.StaticAssets
{
	public class StaticAssetsRenderer
	{
		private static StaticAssetResolver _assetResolver;

		public static void Initialize(StaticAssetResolver staticAssetResolver)
		{
			if (_assetResolver == null)
				_assetResolver = staticAssetResolver;
		}

		public static HtmlString RenderScript(string path)
		{
			return RenderOutput(path, Constants.StaticAssetRendererOutputFormats.ScriptOutputFormat);
		}

		public static HtmlString RenderStyle(string path)
		{
			return RenderOutput(path, Constants.StaticAssetRendererOutputFormats.StyleOutputFormat);
		}

		private static HtmlString RenderOutput(string path, string outputFormat)
		{
			Debug.Assert(_assetResolver != null, Constants.Errors.AssetResolverIsNull);
			
			var actualPath = _assetResolver.GetActualPath(path);

			if (string.IsNullOrEmpty(actualPath))
				return new HtmlString(string.Format(Constants.StaticAssetRendererOutputFormats.ErrorOutputFormat, path));

			return new HtmlString(string.Format(outputFormat, actualPath));
		}
	}
}