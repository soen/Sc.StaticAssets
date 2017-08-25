namespace Sc.StaticAssets
{
	public class Constants
	{
		public class StaticAssetRendererOutputFormats
		{			
			public const string ScriptOutputFormat = "<script src=\"{0}\"></script>";
			public const string StyleOutputFormat = "<link href=\"{0}\" rel=\"stylesheet\" />";
			public const string ErrorOutputFormat = "<script>console.error('[StaticAssetsResolver]: Could not find the style or script with the path: {0}. Please make sure that your static asset manifest contains a file with the given path.')</script>";
		}

		public class Errors
		{
			public static string AssetResolverIsNull =
				"The static asset resolver is not been properly initialized. Please verify that the pipeline processor 'Sc.Pipeline.InitializeStaticAssetsResolver' has been patched into Sitecore's default initialize pipeline";
		}
	}
}
