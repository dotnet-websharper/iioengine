module B2D_Collisions

open WebSharper.InterfaceGenerator
open WebSharper.JavaScript.Dom
open IIO_Abstracts
open IIO_Definition
open IIO_Extensions

open B2D_CommonMath

let Features = Type.New()
let b2Shape = Type.New()
let Canvas2DContext = T<obj>

let b2RayCastInput =
    Class "Box2D.Collision.b2RayCastInput"
    |+> Instance [
        "maxFraction" =@ T<float>
        "p1" =@ b2Vec2
        "p2" =@ b2Vec2
    ]
    |+> Static [
        Constructor <| b2Vec2?p1 * b2Vec2?p2 * T<float>?maxFraction
    ]

let b2RayCastOutput =
    Class "Box2D.Collision.b2RayCastOutput"
    |+> Instance [
        "fraction" =@ T<float>
        "normal" =@ b2Vec2
    ]

let Vector =
    Class "Vector"
    |+> Instance [
        "x" =@ T<float>
        "y" =@ T<float>
    ]

let b2AABB =
    let self = Type.New()
    Class "Box2D.Collision.b2AABB"
    |+> Instance [
        "lowerBound" =@ b2Vec2
        "upperBound" =@ b2Vec2
        "Combine" => self?aabb1 * self?aabb2 ^-> self
        "Contains" => self?aabb ^-> T<bool>
        "GetCenter" => T<unit> ^-> b2Vec2
        "GetExtents" => T<unit> ^-> b2Vec2
        "IsValid" => T<unit> ^-> T<bool>
        "RayCast" => b2RayCastOutput?output * b2RayCastInput?input ^-> T<bool>
        "TestOverlap" => self?other ^-> T<bool>
    ]
    |+> Static [
        Constructor <| T<unit>
    ]

let b2ContactID =
    let self = Type.New()
    Class "Box2D.Collision.b2ContactID"
    |+> Instance [
        "features" =@ Features
        "key" =@ T<int>
        "Copy" => T<unit> ^-> self
        "Set" => self?id ^-> T<unit>
    ]

let b2ContactPoint =
    let self = Type.New()
    Class "Box2D.Collision.b2ContactPoint"
    |+> Instance [
        "friction" =@ T<float>
        "id" =@ b2ContactID
        "normal" =@ b2Vec2
        "position" =@ b2Vec2
        "resitution" =@ T<float>
        "separation" =@ T<float>
        "shape1" =@ b2Shape
        "shape2" =@ b2Shape
        "velocity" =@ b2Vec2
    ]

let b2DistanceInput =
    let self = Type.New()
    Class "Box2D.Collision.b2DistanceInput"
    |+> Instance [
        "proxyA" =@ self
        "proxyB" =@ self
        "transformA" =@ b2Transform
        "transformB" =@ b2Transform
        "useRadii" =@ T<bool>
    ]

let b2DistanceOutput =
    Class "Box2D.Collision.b2DistanceOutput"
    |+> Instance [
        "distance" =@ T<float>
        "iterations" =@ T<int>
        "pointA" =@ b2Vec2
        "pointB" =@ b2Vec2
    ]

let b2DistanceProxy =
    Class "Box2D.Collision.b2DistanceProxy"
    |+> Instance [
        "m_count" =@ T<int>
        "m_radius" =@ T<float>
        "m_vertices" =@ Vector
    ]
    
let IBroadPhase =
    Interface "Box2D.Collision.IBroadPhase"
    |+> [
        Generic - fun t -> "CreateProxy" => b2AABB?aabb * t?userData ^-> t
        Generic - fun t -> "DestroyProxy" => t?proxy ^-> T<unit>
        Generic - fun t -> "GetFatAABB" => t?proxy ^-> b2AABB
        "GetProxyCount" => T<unit> ^-> T<int>
        Generic - fun t -> "GetUserData" => t?proxy ^-> t
        Generic - fun t -> "MoveProxy" => t?proxy * b2AABB?aabb * b2Vec2?displacement ^-> T<unit>
        "Query" => (T<unit> ^-> T<unit>)?callback * b2AABB?aabb ^-> T<unit>
        "RayCast" => (T<unit> ^-> T<unit>)?callback * b2RayCastInput?input ^-> T<unit>
        "Rebalance" => T<int>?iterations ^-> T<unit>
        Generic - fun t -> "TestOverlap" => t?proxyA * t?proxyB ^-> T<bool>
        "UpdatePairs" => (T<unit> ^-> T<unit>)?callback ^-> T<unit>
        "Validate" => T<unit> ^-> T<unit>
    ]

let b2DynamicTreeBroadPhase =
    let self = Type.New()
    Class "Box2D.Collision.b2DynamicTreeBroadPhase"
    |=> Implements [ IBroadPhase ]

let b2Manifold =
    let self = Type.New()
    Class "Box2D.Collision.b2Manifold"
    |+> Instance [
        "m_localPlaneNormal" =@ b2Vec2
        "m_localPoint" =@ b2Vec2
        "m_pointCount" =@ T<int>
        "m_point" =@ Vector
        "m_type" =@ T<int>
        "Copy" => T<unit> ^-> self
        "Reset"=> T<unit> ^-> T<unit>
        "Set" => self?m ^-> T<unit>
    ]
    |+> Static [
        "e_circles" =! T<int>
        "e_faceA" =! T<int>
        "e_faceB" =! T<int>
    ]

let b2ManifoldPoint =
    let self = Type.New()
    Class "Box2D.Collision.b2ManifoldPoint"
    |+> Instance [
        "m_id" =@ b2ContactID
        "m_localPoint" =@ b2Vec2
        "m_normalImpulse" =@ T<float>
        "m_tangentImpulse" =@ T<float>
        "Reset"=> T<unit> ^-> T<unit>
        "Set" => self?m ^-> T<unit>
    ]

let b2OBB =
    Class "Box2D.Collision.b2OBB"
    |+> Instance [
        "center" =@ b2Vec2
        "extents" =@ b2Vec2
        "R" =@ b2Math22
    ]

let b2Segment =
    let self = Type.New()
    Class "b2Segment"
    |+> Instance [
        "p1" =@ b2Vec2
        "p2" =@ b2Vec2
        "Extend" => b2AABB?aabb ^-> T<unit>
        "ExtendBackward" => b2AABB?aabb ^-> T<unit>
        "ExtendForward" => b2AABB?aabb ^-> T<unit>
        "TestSegment" => T<float[]>?lambda * b2Vec2?normal * self?segment * T<float>?maxLambda ^-> T<bool>
    ]

let b2SimplexCache =
    Class "Box2D.Collision.b2SimplexCache"
    |+> Instance [
        "count" =@ T<int>
        "indexA" =@ Vector
        "indexB" =@ Vector
        "metric" =@ T<float>
    ]

let b2TOIInput =
    Class "Box2D.Collision.b2TOIInput"
    |+> Instance [
        "proxyA" =@ b2DistanceProxy
        "sweepA" =@ b2Sweep
        "sweepB" =@ b2Sweep
        "tolerance" =@ T<float>
    ]

let b2WorldManifold =
    Class "Box2D.Collision.b2WorldManifold"
    |+> Instance [
        "m_normal" =@ b2Vec2
        "m_points" =@ Vector
        "Initialize" =@ b2Manifold?manifold * b2Transform?xfA * T<float>?radiusA * b2Transform?xfB * T<float>?radiusB ^-> T<unit>
    ]

let FeaturesClass =
    Class "Box2D.Collision.Features"
    |+> Instance [
        "flip" =@ T<int>
        "incidentEdge" =@ T<int>
        "incidentVertex" =@ T<int>
        "referenceEdge" =@ T<int>
    ]

let b2EdgeChainDef =
    Class "b2EdgeChainDef"
    |+> Instance [
        "isALoop" =@ T<bool>
        "vertexCount" =@ T<int>
        "vertices" =@ T<float>
    ]

let b2MassData =
    Class "Box2D.Collision.Shapes.b2MassData"
    |+> Instance [
        "center" =@ b2Vec2
        "I" =@ T<float>
        "mass" =@ T<float>  
    ]

let b2ShapeClass =
    Class "Box2D.Collision.Shapes.b2Shape"
    |=> b2Shape
    |+> Instance [
        "ComputeAABB" => b2AABB?aabb * b2Transform?xf ^-> T<unit>
        "ComputeMass" => b2MassData?massData * T<float>?density ^-> T<unit>
        "ComputeSubmergedArea" => b2Vec2?normal * T<float>?number ^-> T<unit>
        "Copy" => T<unit> ^-> b2Shape
        "GetType" => T<unit> ^-> T<int>
        "RayCast" => b2RayCastOutput?output * b2RayCastInput?input * b2Transform?transform ^-> T<bool>
        "Set" => b2Shape?other ^-> T<unit>
        "TestOverlap" => b2Shape?shape1 * b2Transform?transform1 * b2Shape?shape2 * b2Transform?transform2 ^-> T<bool>
        "TestPoint" => b2Transform?xf * b2Vec2?p ^-> T<bool>
        //interface stuff
        "prepGraphics" => T<float>?scale ^-> T<unit>
        "draw" => Canvas2DContext ^-> T<unit>
        "setAlpha" => T<float>?alpha ^-> T<unit>
        "setStrokeStyle" => (T<string> + T<obj>)?style * !?T<float>?width  ^-> T<unit>
        "setLineWidth" => T<float>?lineWidth ^-> T<unit>
        "setFillStyle" => (T<string> + T<obj>)?style ^-> T<unit>
        "setShadow" => T<string>?color * Vec?offset * T<float>?blur ^-> T<unit>
        "setShadow" => T<string>?color * T<float>?offsetX * T<float>?offseY * T<float>?blur ^-> T<unit>
        "setShadowColor" => T<string>?color ^-> T<unit>
        "setShadowOffset" => Vec?offset ^-> T<unit>
        "setShadowOffset" => T<float>?offsetX * T<float>?offsetY ^-> T<unit>
        "setShadowBlur" => T<float>?blur ^-> T<unit>
        "fade" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeIn" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeOut" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "addImage" => T<Element>?img ^-> T<unit>
        "addImage" => T<string>?src * !?(T<obj> ^-> T<unit>)?onloadCallback ^-> T<unit>
        "addAnim" => T<obj[]>?imgs ^-> T<unit>
        "addAnim" => T<obj>?sprite * T<string>?tag ^-> T<unit>
        "addAnim" => T<obj[]>?imgSrcs * (T<obj> ^-> T<unit>)?onloadCallback ^-> T<unit>
        "flipImage" => T<bool>?yes ^-> T<unit>
        "setImgOffset" => Vec?offset ^-> T<unit>
        "setImgOffset" => T<float>?offsetX * T<float>?offsetY ^-> T<unit>
        "setImgSize" => Vec?size ^-> T<unit>
        "setImgSize" => T<float>?width * T<float>?height ^-> T<unit>
        "setImgScale" => T<float>?scale ^-> T<unit>
        "setImgRotation" => T<float>?rotation ^-> T<unit>
        "setAnimKey" => T<float>?frame ^-> T<unit>
        "setAnimFrame" => T<float>?frame ^-> T<unit>
        "nextAnimFrame" => T<unit> ^-> T<unit>
        "playAnim" => T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "playAnim" => T<string>?tag * T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "playAnim" => T<float>?tag * T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "stopAnim" => T<string>?tag * T<obj>?ctx ^-> T<unit>
        "stopAnim" => T<float>?tag * T<obj>?ctx ^-> T<unit>
    ]
    |+> Static [
        "e_hitCollide" =@ T<int>
        "e_missCollide" =@ T<int>
        "e_startsInsideCollide" =@ T<int>
    ]

let b2CircleShape =
    Class "Box2D.Collision.Shapes.b2CircleShape"
    |=> Inherits b2ShapeClass
    |+> Instance [
        "ComputeAABB" => b2AABB?aabb * b2Transform?transform ^-> T<unit>
        "ComputeMass" => b2MassData?massData * T<float>?density ^-> T<unit>
        "ComputeSubmergedArea" => b2Vec2?normal * T<float>?offset * b2Transform?xf * b2Vec2?c ^-> T<float>
        "Copy" => T<unit> ^-> b2Shape
        "GetLocalPosition" => T<unit> ^-> b2Vec2
        "GetRadius" => T<unit> ^-> T<float>
        "RayCast" => b2RayCastOutput?output * b2RayCastInput?input * b2Transform?transform ^-> T<bool>
        "Set" => b2Shape?other ^-> T<unit>
        "SetLocalPosition" => b2Vec2?position ^-> T<unit>
        "SetRadius" => T<float>?radius ^-> T<unit>
        "TestPoint" => b2Transform?transform * b2Vec2?p ^-> T<bool>
        //interface stuff
        "drawReferenceLine" => T<bool>?turnOn ^-> T<unit>
        "setPolyDraw" => T<bool>?turnOn ^-> T<unit>
    ]
    |+> Static [
        Constructor <| T<float>?radius
    ]

let b2PolygonShape =
    let self = Type.New()
    Class "Box2D.Collision.Shapes.b2PolygonShape"
    |=> self
    |=> Inherits b2ShapeClass
    |+> Instance [
        "ComputeAABB" => b2AABB?aabb * b2Transform?xf ^-> T<unit>
        "ComputeMass" => b2MassData?massData * T<float>?density ^-> T<unit>
        "ComputeSubmergedArea" => b2Vec2?normal * T<float>?offset * b2Transform?xf * b2Vec2?c ^-> T<float>
        "Copy" => T<unit> ^-> b2Shape
        "GetNormals" => T<unit> ^-> Vector
        "GetSupport" => b2Vec2?d ^-> T<int>
        "GetSupportVertex" => b2Vec2?d ^-> b2Vec2
        "GetType" => T<unit> ^-> T<int>
        "GetTypeCount" => T<unit> ^-> T<int>
        "GetVertexCount" => T<unit> ^-> T<int>
        "GetVertices" => T<unit> ^-> Vector
        "RayCast" => b2RayCastOutput?output * b2RayCastInput?input * b2Transform?transform ^-> T<bool>
        "Set" => b2Shape?other ^-> T<unit>
        "SetAsArray" => T<float[]>?vertices * T<float>?vertexCount ^-> T<unit>
        "SetAsBox" => T<float>?hx * T<float>?hy ^-> T<unit>
        "SetAsEdge" => b2Vec2?v1 * b2Vec2?v2 ^-> T<unit>
        "SetAsOrientedBox" => T<float>?hx * T<float>?hy * b2Vec2?center ^-> T<unit>
        "TestPoint" => b2Transform?xf * b2Vec2?p ^-> T<bool>
    ]
    |+> Static [
        Constructor <| T<unit>
        "AsArray" => T<obj[]>?vertices * T<int>?vertexCount ^-> self
        "AsBox" => T<float>?hx * T<float>?hy ^-> self
        "AsEdge" => b2Vec2?v1 * b2Vec2?v2 ^-> self
        "AsOrientedBox" => T<float>?hx * T<float>?hy * b2Vec2?center * T<float>?angle ^-> self
        "AsVector" => Vector?vertices * T<float>?vertexCount ^-> self
        "ComputeCentroid" => b2AABB?aabb * b2Transform?xf ^-> b2Vec2
    ]
