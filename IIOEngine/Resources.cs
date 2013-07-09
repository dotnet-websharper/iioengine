using IntelliFactory.WebSharper;
using IntelliFactory.WebSharper.Core;
using System.Web.UI;

[assembly: Attributes.Require(typeof(IntelliFactory.WebSharper.IIOEngine.Resources.IIOEngine))]
[assembly: WebResource("iioEngine-1.2.2.min.js", "text/javascript")]