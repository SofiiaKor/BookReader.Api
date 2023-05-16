using System;
using Microsoft.Xrm.Sdk;
using System.Text.RegularExpressions;

namespace BookReader.Application.Plug_ins
{
	public class PreOperationFormatISBNCreateUpdate : IPlugin
	{
		public void Execute(IServiceProvider serviceProvider)
		{
			var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

			if (context == null || !context.InputParameters.ContainsKey("Target"))
				throw new InvalidPluginExecutionException("No target found");

			if (context.InputParameters["Target"] is not Entity entity || !entity.Attributes.Contains("ISBN"))
				return;

			var ISBNNumber = (string)entity["ISBN"];
			var formattedNumber = Regex.Replace(ISBNNumber, @"[^\d]", "");

			entity["ISBN"] = formattedNumber;
		}
	}
}
