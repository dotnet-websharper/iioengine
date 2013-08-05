namespace IntelliFactory.WebSharper.Box2D_iioEngine
{
    using IntelliFactory.WebSharper;
    using IntelliFactory.WebSharper.Core;

    public class Box2D : Core.Resources.BaseResource
    {
        public Box2D() : base("Box2dWeb-2.1.a.3.min.js") {
            
        }
    }

    [Attributes.Require(typeof(Box2D))]
    public class IIOEngine : Core.Resources.BaseResource
    {
        public IIOEngine() : base("iioEngine-1.2.2.min.js") { }
    }
}