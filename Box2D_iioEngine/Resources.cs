using IntelliFactory.WebSharper;
using IntelliFactory.WebSharper.Core;
using System.Web.UI;

[assembly: Attributes.Require(typeof(IntelliFactory.WebSharper.Box2D_iioEngine.Box2D))]
[assembly: WebResource("Box2dWeb-2.1.a.3.min.js", "text/javascript")]
[assembly: Attributes.Require(typeof(IntelliFactory.WebSharper.Box2D_iioEngine.IIOEngine))]
[assembly: WebResource("iioEngine-1.2.2.min.js", "text/javascript")]
