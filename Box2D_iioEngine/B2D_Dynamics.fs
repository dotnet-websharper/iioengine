module B2D_Dynamics

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.Html5

open IIO_Abstracts
open IIO_Definition
open IIO_Extensions

open B2D_CommonMath
open B2D_Collisions
open B2D_Common

let b2Fixture = Type.New()
let b2Body = Type.New()
let b2World =  Type.New()
let b2BodyDef = Type.New()
let b2FilterData = Type.New()
let b2Controller = Type.New()
let b2ControllerEdge = Type.New()
let b2Friction = Type.New()
let b2Joint = Type.New()
let b2JointDef = Type.New()
let b2JointEdge = Type.New()
let b2FixtureDef = Type.New()

let b2Contact =
    let self = Type.New()
    Class "Box2D.Dynamics.Contacts.b2Contact"
    |=> self
    |+> Protocol [
        "FlagForLitering" => T<unit> ^-> T<unit>
        "GetFixtureA" => T<unit> ^-> b2Fixture
        "GetFixtureB" => T<unit> ^-> b2Fixture
        "GetManifold" => T<unit> ^-> b2Manifold
        "GetNext" => T<unit> ^-> self
        "GetWorldManifold" => b2WorldManifold?worldManifold ^-> T<unit>
        "IsContinuous" => T<unit> ^-> T<bool>
        "IsEnabled" => T<unit> ^-> T<bool>
        "IsSensor" => T<unit> ^-> T<bool>
        "IsTouching" => T<unit> ^-> T<bool>
        "SetEnabled" => T<bool>?flag ^-> T<unit>
        "SetSensor" => T<bool>?sensor ^-> T<unit>
    ]

let b2ContactEdge =
    let self = Type.New()
    Class "Box2D.Dynamics.Contacts.b2ContactEdge"
    |=> self
    |+> Protocol [
        "contact" =@ b2Contact
        "next" =@ self
        "other" =@ b2Body
        "prev" =@ self
    ]

let b2ContactResult =
    Class "Box2D.Dynamics.Contacts.b2ContactResult"
    |+> Protocol [
        "id" =@ b2ContactID
        "normal" =@ b2Vec2
        "normalImpulse" =@ T<float>
        "position" =@ b2Vec2
        "shape1" =@ b2Shape
        "shape2" =@ b2Shape
        "tangentImpulse" =@ T<float>
    ]


let b2BodyClass =
    Class "Box2D.Dynamics.b2Body"
    |=> b2Body
    |+> Protocol [
        "ApplyForce" => b2Vec2?force * b2Vec2?point ^-> T<unit>
        "ApplyImpulse" => b2Vec2?impulse * b2Vec2?point ^-> T<unit>
        "ApplyTorque" => T<float>?torque ^-> T<unit>
        "CreateFixture" => b2FixtureDef?def ^-> b2Fixture
        "CreateFixture2" => b2Shape?shape * T<float>?density ^-> b2Fixture
        "DestroyFixture" => b2Fixture?fixture ^-> T<unit>
        "GetAngle" => T<unit> ^-> T<float>
        "GetAngularDamping" => T<unit> ^-> T<float>
        "GetAngularVelocity" => T<unit> ^-> T<float>
        "GetContactList" => T<unit> ^-> b2ContactEdge
        "GetControllerList" => T<unit> ^-> b2ControllerEdge
        "GetDefinition" => T<unit> ^-> b2BodyDef
        "GetFixtureList" => T<unit> ^-> b2Fixture
        "GetInertia" => T<unit> ^-> T<float>
        "GetJointList" => T<unit> ^-> b2JointEdge
        "GetLinearDamping" => T<unit> ^-> T<float>
        "GetLinearVelocity" => T<unit> ^-> b2Vec2
        "GetLinearVelocityFromLocalPoint" => b2Vec2?localPoint ^-> b2Vec2
        "GetLinearVelocityFromWorldPoint" => b2Vec2?worldPoint ^-> b2Vec2
        "GetLocalCenter" => T<unit> ^-> b2Vec2
        "GetLocalPoint" => b2Vec2?worldPoint ^-> b2Vec2
        "GetLocalVector" => b2Vec2?worldVector ^-> b2Vec2
        "GetMass" => T<unit> ^-> T<float>
        "GetMassData" => b2MassData?data ^-> T<unit>
        "GetNext" => T<unit> ^-> b2Body
        "GetPosition" => T<unit> ^-> b2Vec2
        "GetTransform" => T<unit> ^-> b2Transform
        "GetType" => T<unit> ^-> T<int>
        Generic - fun t -> "GetUserData" => T<unit> ^-> t
        "GetWorld" => T<unit> ^-> b2World
        "GetWorldCenter" => T<unit> ^-> b2Vec2
        "GetWorldPoint" => b2Vec2?localPoint ^-> b2Vec2
        "GetWorldVector" => b2Vec2?localVector ^-> b2Vec2
        "IsActive" => T<unit> ^-> T<bool>
        "IsAwake" => T<unit> ^-> T<bool>
        "IsBullet" => T<unit> ^-> T<bool>
        "IsFixedRotation" => T<unit> ^-> T<bool>
        "IsSleepingAllowed" => T<unit> ^-> T<bool>
        "Merge" => b2Body?other ^-> T<unit>
        "ResetMassData" => T<unit> ^-> T<unit>
        "SetActive" => T<bool>?flag ^-> T<unit>
        "SetAngle" => T<float>?flag ^-> T<unit>
        "SetAngularDamping" => T<float>?angularDamping ^-> T<unit>
        "SetAngularVelocity" => T<float>?omega ^-> T<unit>
        "SetAwake" => T<bool>?flag ^-> T<unit>
        "SetBullet" => T<bool>?flag ^-> T<unit>
        "SetFixedRotation" => T<bool>?flag ^-> T<unit>
        "SetLinearVelocity" => b2Vec2?v ^-> T<unit>
        "SetMassData" => b2MassData?massData ^-> T<unit>
        "SetPosition" => b2Vec2?position ^-> T<unit>
        "SetPositionAndAngle" => b2Vec2?position * T<float>?angle ^-> T<unit>
        "SetSleepingAllowed" => T<bool>?flag ^-> T<unit>
        "SetTransform" => b2Transform?xf ^-> T<unit>
        "SetType" => T<int>?``type`` ^-> T<unit>
        Generic - fun t -> "SetUserData" => t?data ^-> T<unit>
        Generic - fun t -> "Split" => (T<unit> * t)?callback ^-> b2Body
    ]
    |+> [
        Constructor <| T<unit>
        "b2_dynamicBody" =@ T<int>
        "b2_kincematicBody" =@ T<int>
        "b2_staticBody" =@ T<int>
    ]

let b2FixtureClass =
    Class "Box2D.Dynamics.b2Fixture"
    |=> b2Fixture
    |+> Protocol [
        "GetAABB" => T<unit> ^-> b2AABB
        "GetBody" => T<unit> ^-> b2Body
        "GetDensity" => T<unit> ^-> T<float>
        "GetFilterData" => T<unit> ^-> b2FilterData
        "GetFriction" => T<unit> ^-> T<float>
        Generic - fun t -> "GetMassData" => t?massData ^-> t
        "GetNext" => T<unit> ^-> b2Fixture
        "GetRestitution"  => T<unit> ^-> T<float>
        "GetShape" => T<unit> ^-> b2Shape
        "GetType" => T<unit> ^-> T<int>
        Generic - fun t -> "GetUserData" => T<unit> ^-> t
        "IsSensor" => T<unit> ^-> T<bool>
        "RayCast" => b2RayCastOutput?output * b2RayCastInput?input ^-> T<bool>
        "SetDensity" => T<float>?density ^-> T<unit>
        "SetFilterData" => b2FilterData?filter ^-> T<unit>
        "SetFriction" => b2Friction?friction ^-> T<unit>
        "SetRestitution" => T<float>?restitution ^-> T<unit>
        "SetSensor" => T<bool>?sensor ^-> T<unit>
        Generic - fun t -> "SetUserData" => t?data ^-> T<unit>
        "TestPoint" => b2Vec2?p ^-> T<bool>
    ]
    |+> [
        Constructor <| T<unit>
    ]

let b2FixtureDefClass =
    Class "Box2D.Dynamics.b2FixtureDef"
    |=> b2FixtureDef
    |+> Protocol [
        "density" =@ T<float>
        "filter" =@ b2FilterData
        "friction" =@ T<float>
        "isSensor" =@ T<bool>
        "restitution" =@ T<float>
        "shape" =@ b2Shape
        "userData" =@ T<obj>
    ]
    |+> [
        Constructor <| T<unit>
    ]

let b2BodyDefClass =
    Class "Box2D.Dynamics.b2BodyDef"
    |=> b2BodyDef
    |+> Protocol [
        "active" =@ T<bool>
        "allowSleep" =@ T<bool>
        "angle" =@ T<float>
        "angularDamping" =@ T<float>
        "angularVelocity" =@ T<float>
        "awake" =@ T<bool>
        "bullet" =@ T<bool>
        "fixedRotation" =@ T<bool>
        "inertiaScale" =@ T<float>
        "linearDamping" =@ T<float>
        "linearVelocity" =@ b2Vec2
        "position" =@ b2Vec2
        "type" =@ T<int>
        "userData" =@ T<obj>
    ]
    |+> [
        Constructor <| T<unit>
    ]

let b2ContactFilter =
    Class "Box2D.Dynamics.b2ContactFilter"
    |+> Protocol [
        Generic - fun t -> "RayCollide" => t?userData * b2Fixture?fixture ^-> T<bool>
        "ShouldCollide" => b2Fixture?fixtureA * b2Fixture?fixtureB ^-> T<bool>
    ]

let b2ContactImpulse =
    Class "Box2D.Dynamics.b2ContactImpulse"
    |+> Protocol [
        "normalImpulses" =@ Vector
        "tangentImpulses" =@ Vector
    ]

let b2ContactListener =
    Class "Box2D.Dynamics.b2ContactListener"
    |+> Protocol [
        "BeginContact" => b2Contact?contact ^-> T<unit>
        "EndContact" => b2Contact?contact ^-> T<unit>
        "PostSolve" => b2Contact?contact * b2ContactImpulse?impulse ^-> T<unit>
        "ProSolve" => b2Contact?contact * b2Manifold?oldManifold ^-> T<unit>
    ]

let b2DebugDraw =
    let self = Type.New()
    Class "Box2D.Dynamics.b2DebugDraw"
    |=> self
    |+> Protocol [
        "AppendFlags" => T<int>?flags ^-> T<unit>
        "ClearFlags" => T<int>?flags ^-> T<unit>
        "DrawCircle" => b2Vec2?center * T<float>?radius * b2Color?color ^-> T<unit>
        "DrawPolygon" => T<float[]>?vertices * T<int>?vertexCount * b2Color?color ^-> T<unit>
        "DrawSegment" => b2Vec2?p1 * b2Vec2?p2 * b2Color?color ^-> T<unit>
        "DrawSolidCircle" => b2Vec2?center * T<float>?radius * b2Vec2?axis * b2Color?color ^-> T<unit>
        "DrawSolidPolygon" => Vector?vertices * T<int>?vertexCount * b2Color?color ^-> T<unit>
        "DrawTransform" => b2Transform?xf ^-> T<unit>
        "GetAlpha" => T<unit> ^-> T<float>
        "GetDrawScale" => T<unit> ^-> T<float>
        "GetFillAlpha" => T<unit> ^-> T<float>
        "GetFlags" => T<unit> ^-> T<int>
        "GetLineThickness" => T<unit> ^-> T<float>
        "GetSprite" => T<unit> ^-> Box2DSprite
        "GetXFormScale" => T<unit> ^-> T<float>
        "SetAlpha" => T<float>?alpha ^-> T<unit>
        "SetDrawScale" => T<float>?drawScale ^-> T<unit>
        "SetFillAlpha" => T<float>?alpha ^-> T<unit>
        "SetFlags" => T<int>?flags ^-> T<unit>
        "SetLineThickness" => T<float>?lineThickness ^-> T<unit>
        "SetSprite" => Box2DSprite?sprite ^-> T<unit>
        "SetXFormScale" => T<float>?xformScale ^-> T<unit>
    ]
    |+> [
        Constructor <| T<unit>                    
        "e_aabbBit" =@ T<int>
        "e_centerOfMassBit" =@ T<int>
        "e_controllerBit" =@ T<int>
        "e_jointBit" =@ T<int>
        "e_pairBit" =@ T<int>
        "e_shapeBit" =@ T<int>
    ]

let b2DestructionListener =
    Class "Box2D.Dynamics.b2DestructionListener"
    |+> Protocol [
        "SayGoodbyeFixture" => b2Fixture?fixture ^-> T<unit>
        "SayGoodbyeJoint" => b2Joint?joint ^-> T<unit>
    ]

let b2FilterDataClass =
    Class "Box2D.Dynamics.b2FilterData"
    |=> b2FilterData
    |+> Protocol [
        "Copy" => T<unit> ^-> b2FilterData
    ]
    |+> [
        "categoryBits" =@ T<int>
        "groupIndex" =@ T<int>
        "maskBits" =@ T<int>
    ]


let b2WorldClass =
    Class "Box2D.Dynamics.b2World"
    |=> b2World
    |+> Protocol [
        "AddController" => b2Controller?c ^-> b2Controller
        "ClearForces" => T<unit> ^-> T<unit>
        "CreateBody" => b2BodyDef?def ^-> b2Body
        "CreateController" => b2Controller?controller ^-> b2Controller
        "CreateJoint" => b2JointDef?def ^-> b2Joint
        "DestroyBody" => b2Body?b ^-> T<unit>
        "DestroyController" => b2Controller?controller ^-> T<unit>
        "DestroyJoint" => b2Joint?j ^-> T<unit>
        "DrawDebugData" => T<unit> ^-> T<unit>
        "GetBodyCount" => T<unit> ^-> T<int>
        "GetBodyList" => T<unit> ^-> b2Body
        "GetContactCount" => T<unit> ^-> T<int>
        "GetContactList" => T<unit> ^-> b2Contact
        "GetGravity" => T<unit> ^-> b2Vec2
        "GetGroundBody" => T<unit> ^-> b2Body
        "GetJointCount" => T<unit> ^-> T<int>
        "GetJointList" => T<unit> ^-> b2Joint
        "GetProxyCount" => T<unit> ^-> T<int>
        "IsLocked" => T<unit> ^-> T<bool>
        "QueryAABB" => (b2Fixture ^-> T<bool>)?callback * b2AABB?aabb ^-> T<unit>
        "QueryPoint" => (b2Fixture ^-> T<unit>)?callback * b2Vec2?p ^-> T<unit>
        "QueryShape" => (b2Fixture ^-> T<unit>)?callback * b2Shape?shape * b2Transform?transform ^-> T<unit>
        "RayCast" => (b2Fixture ^-> T<unit>)?callback * b2Vec2?point1 * b2Vec2?point2 ^-> T<unit>
        "RayCastAll" => b2Vec2?point1 * b2Vec2?point2 ^-> Vector
        "RayCastOne" => b2Vec2?point1 * b2Vec2?point2 ^-> b2Fixture
        "RemoveController" => b2Controller?c ^-> T<unit>
        "SetBroadPhase" => IBroadPhase?broadPhase ^-> T<unit>
        "SetContactFilter" => b2ContactFilter?filter ^-> T<unit>
        "SetContactListener" => b2ContactListener?listener ^-> T<unit>
        "SetcontinousPhysics" => T<bool>?flag ^-> T<unit>
        "SetDebugDraw" => b2DebugDraw?debugDraw ^-> T<unit>
        "SetDestructionListener" => b2DestructionListener?listener ^-> T<unit>
        "SetGravity" => b2Vec2?gravity ^-> T<unit>
        "SetWarmStarting" => T<bool>?flag ^-> T<unit>
        "Step" => T<float>?dt * T<int>?velocityIterations * T<int>?positionsIterations ^-> T<unit>
        "Validate"=> T<unit> ^-> T<unit>
    ]
    |+> [
        Constructor <| b2Vec2?gravity * T<bool>?doSleep
        "e_locked" =@ T<int>
        "e_newFixture" =@ T<int>
    ]

//JOINT CLASSES
let b2JointClass =
    Class "Box2D.Dynamics.Joints.b2Joint"
    |=> b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetBodyA" => T<unit> ^-> b2Vec2
        "GetBodyB" => T<unit> ^-> b2Vec2
        "GetNext" => T<unit> ^-> b2Joint
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "GetType" => T<unit> ^-> T<int>
        Generic - fun t -> "GetUserData" => T<unit> ^-> t
        "IsActive" => T<unit> ^-> T<bool>
        Generic - fun t -> "SetUserData" => t?data ^-> T<unit>
        //interface stuff
        "prepGraphics" => T<float>?scale ^-> T<unit>  
        "draw" => Canvas2DContext ^-> T<unit>
        "setAlpha" => T<float>?alpha ^-> T<unit>
        "setStrokeStyle" => (T<string> + T<obj>)?style * !?T<float>?width  ^-> T<unit>
        "setLineWidth" => T<float>?lineWidth ^-> T<unit>
        "setShadow" => T<string>?color * Vec?offset * T<float>?blur ^-> T<unit>
        "setShadow" => T<string>?color * T<float>?offsetX * T<float>?offseY * T<float>?blur ^-> T<unit>
        "setShadowColor" => T<string>?color ^-> T<unit>
        "setShadowOffset" => Vec?offset ^-> T<unit>
        "setShadowOffset" => T<float>?offsetX * T<float>?offsetY ^-> T<unit>
        "fade" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeIn" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeOut" => T<float>?rate * T<float>?alpha ^-> T<unit>
    ]

let b2JointDefClass =
    Class "Box2D.Dynamics.Joints.b2JointDef"
    |+> Protocol [
        "bodyA" =@ b2Body
        "bodyB" =@ b2Body
        "collideConnected" =@ T<bool>
        "type" =@ T<int>
        "userData" =@ T<obj>
    ]
    |+> [
        Constructor <| T<unit>
    ]

let b2DistanceJoint =
    Class "Box2D.Dynamics.Joints.b2DistanceJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetDampingRatio" => T<unit> ^-> T<float>
        "GetFrequency" => T<unit> ^-> T<float>
        "GetLength" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "SetDampingRatio" => T<float>?ratio ^-> T<unit>
        "SetFrequency" => T<float>?hz ^-> T<unit>
        "SetLength" => T<float>?length ^-> T<unit>
    ]

let b2DistanceJointDef =
    Class "Box2D.Dynamics.Joints.b2DistanceJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "DampingRatio" =@ T<float>
        "frequencyHZ" =@ T<float>
        "length" =@ T<float>
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "Initialize" =@ b2Body?bA * b2Body?bB * b2Vec2?anchorA * b2Vec2?anchorB ^-> T<unit>
    ]

let b2FrictionJoint =
    Class "Box2D.Dynamics.Joints.b2FrictionJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "m_angularMass" =@ T<float>
        "m_linearMass" =@ b2Math22
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetMaxForce" => T<unit> ^-> T<float>
        "GetMaxTorque" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "SetMaxForce" => T<float>?force ^-> T<unit>
        "SetMaxTorque" => T<float>?torque ^-> T<unit>
    ]

let b2FrictionJointDef =
    Class "Box2D.Dynamics.Joints.b2FrictionJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "maxForce" =@ T<float>
        "maxTorque" =@ T<float>
        "Initialize" => b2Body?bA * b2Body?bB * b2Vec2?anchor ^-> T<unit>
    ]

let b2GearJoint =
    Class "Box2D.Dynamics.Joints.b2GearJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetRatio" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "SetRatio" => T<float>?ratio ^-> T<unit>
    ]

let b2GearJointDef =
    Class "Box2D.Dynamics.Joints.b2GearJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "joint1" =@ b2Joint
        "joint2" =@ b2Joint
        "ratio" =@ T<float>
    ]

let b2JointEdgeClass =
    Class "Box2D.Dynamics.Joints.b2JointEdge"
    |=> b2JointEdge
    |+> Protocol [
        "joint" =@ b2Joint
        "next" =@ b2JointEdge
        "other" =@ b2Body
        "prev" =@ b2JointEdge
    ]

let b2LineJoint =
    Class "Box2D.Dynamics.Joints.b2LineJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "EnableLimit" => T<bool>?flag ^-> T<unit>
        "EnableMotor" => T<bool>?flag ^-> T<unit>
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetJointSpeed" => T<unit> ^-> T<float>
        "GetJointTranslation" => T<unit> ^-> T<float>
        "GetLowerLimit" => T<unit> ^-> T<float>
        "GetMaxmotorForce" => T<unit> ^-> T<float>
        "GetMotorForce" => T<unit> ^-> T<float>
        "GetMotorSpeed" => T<unit> ^-> T<float>
        "GetReactionFoce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "GetUpperLimit" => T<unit> ^-> T<float>
        "IsLimitEnabled" => T<unit> ^-> T<bool>
        "IsMotorEnabled" => T<unit> ^-> T<bool>
        "SetLimits" => T<float>?lower * T<float>?upper ^-> T<unit>
        "SetMaxMotorForce" => T<float>?force ^-> T<unit>
        "SetMotorSpeed" => T<float>?speed ^-> T<unit>
    ]

let b2LineJointDef =
    Class "Box2D.Dynamics.Joints.b2LineJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "enableLimit" =@ T<bool>
        "enableMotor" =@ T<bool>
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "localAxisA" =@ b2Vec2
        "lowerTranslation" =@ T<float>
        "maxMotorForce" =@ T<float>
        "motorSpeed" =@ T<float>
        "upperTranslation" =@ T<float>
        "Initialize" => b2Body?bA * b2Body?bB * b2Vec2?anchor * b2Vec2?axis ^-> T<unit>
    ]

let b2MouseJoint =
    Class "Box2D.Dynamics.Joints.b2MouseJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetDampingRatio" => T<unit> ^-> T<float>
        "GetFrequency" => T<unit> ^-> T<float>
        "GetMaxForce" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> b2Vec2
        "GetTarget" => T<unit> ^-> b2Vec2
        "SetDampingRatio" => T<float>?ratio ^-> T<unit>
        "SetFrequency" => T<float>?hz ^-> T<unit>
        "SetMaxForce" => T<float>?maxForce ^-> T<unit>
        "SetTarget" => b2Vec2?target ^-> T<unit>
    ]
    |+> [
        Constructor <| T<unit>
    ]

let b2MouseJointDef =
    Class "Box2D.Dynamics.Joints.b2MouseJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "dampingRatio" =@ T<float>
        "frequencyHz" =@ T<float>
        "maxForce" =@ T<float>
        "target" =@ b2Vec2
    ]
    |+> [
        Constructor <| T<unit>
    ]


let b2PrismaticJoint =
    Class "Box2D.Dynamics.Joints.b2PrismaticJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "EnableLimit" => T<bool>?flag ^-> T<unit>
        "EnableMotor" => T<bool>?flag ^-> T<unit>
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetJointSpeed" => T<unit> ^-> T<float>
        "GetJointTranslation" => T<unit> ^-> T<float>
        "GetLowerLimit" => T<unit> ^-> T<float>
        "GetMotorForce" => T<unit> ^-> T<float>
        "GetMotorSpeed" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "GetUpperLimit" => T<unit> ^-> T<float>
        "IsLimitEnabled" => T<unit> ^-> T<bool>
        "IsMotorEnabled" => T<unit> ^-> T<bool>
        "SetLimits" => T<float>?lower * T<float>?upper ^-> T<unit>
        "SetMaxMotorForce" => T<float>?force ^-> T<unit>
        "SetMotorSpeed" => T<float>?speed ^-> T<unit>
    ]

let b2PrismaticJointDef =
    Class "Box2D.Dynamics.Joints.b2PrismaticJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "enableLimit" =@ T<bool>
        "enableMotor"=@ T<bool>
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "localAxisA" =@ b2Vec2
        "lowerTranslation" =@ T<float>
        "maxMotorForce" =@ T<float>
        "motorSpeed" =@ T<float>
        "referenceAngle" =@ T<float>
        "upperTranslation" =@ T<float>
        "Initialize" => b2Body?bA * b2Body?bB * b2Vec2?anchor * b2Vec2?axis ^-> T<unit>
    ]

let b2PulleyJoint =
    Class "Box2D.Dynamics.Joints.b2PulleyJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetGroundAnchorA" => T<unit> ^-> b2Vec2
        "GetGroundAnchorB" => T<unit> ^-> b2Vec2
        "GetLength1" => T<unit> ^-> T<float>
        "GetLength2" => T<unit> ^-> T<float>
        "GetRatio" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
    ]

let b2PulleyJointDef =
    Class "Box2D.Dynamics.Joints.b2PulleyJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "groundAnchorA" =@ b2Vec2
        "groundAnchorB" =@ b2Vec2
        "lengthA" =@ T<float>
        "lengthB" =@ T<float>
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "maxLengthA" =@ T<float>
        "maxLengthB" =@ T<float>
        "ratio" =@ T<float>
        "Initialize" => b2Body?bA * b2Body?bB * b2Vec2?gaA * b2Vec2?gaB * b2Vec2?anchorA * b2Vec2?anchorB * T<float>?r ^-> T<unit>
    ]

let b2RevoluteJoint =
    Class "Box2D.Dynamics.Joints.b2RevoluteJoint"
    |=> Inherits b2Joint
    |+> Protocol [
        "EnableLimit" => T<bool>?flag ^-> T<unit>
        "EnableMotor" => T<bool>?flag ^-> T<unit>
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetJointAngle" => T<unit> ^-> T<float>
        "GetJointSpeed" => T<unit> ^-> T<float>
        "GetLowerLimit" => T<unit> ^-> T<float>
        "GetMotorSpeed" => T<unit> ^-> T<float>
        "GetMotorTorque" => T<unit> ^-> T<float>
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
        "GetUpperLimit" => T<unit> ^-> T<float>
        "IsLimitEnabled" => T<unit> ^-> T<bool>
        "IsMotorEnabled" => T<unit> ^-> T<bool>
        "SetLimits" => T<float>?lower * T<float>?upper ^-> T<unit>
        "SetMaxMotorTorque" => T<float>?torque ^-> T<unit>
        "SetMotorSpeed" => T<float>?speed ^-> T<unit>
    ]

let b2RevoluteJointDef =
    Class "Box2D.Dynamics.Joints.b2RevoluteJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "enableLimit" =@ T<bool>
        "enableMotor" =@ T<bool>
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "lowerAngle" =@ T<float>
        "maxMotorTorque" =@ T<float>
        "motorSpeed" =@ T<float>
        "referenceAngle" =@ T<float>
        "upperAngle" =@ T<float>
        "Initialize" =@ b2Body?bA * b2Body?bB * b2Vec2?anchor ^-> T<unit>
    ]

let b2WeldJoint =
    Class "Box2D.Dynamics.Joints.b2RevoulteJointDef"
    |=> Inherits b2Joint
    |+> Protocol [
        "GetAnchorA" => T<unit> ^-> b2Vec2
        "GetAnchorB" => T<unit> ^-> b2Vec2
        "GetReactionForce" => T<float>?inv_dt ^-> b2Vec2
        "GetReactionTorque" => T<float>?inv_dt ^-> T<float>
    ]

let b2WeldJointDef =
    Class "Box2D.Dynamics.Joints.b2WeldJointDef"
    |=> Inherits b2JointDefClass
    |+> Protocol [
        "localAnchorA" =@ b2Vec2
        "localAnchorB" =@ b2Vec2
        "referenceAngle" =@ T<float>
        "Initialize" => b2Body?bA * b2Body?bB * b2Vec2?anchor ^-> T<unit>
    ]

let b2ControllerClass =
    Class "Box2D.Dynamics.Controllers.b2Controller"
    |=> b2Controller
    |+> Protocol [
        "m_bodyCount" =@ T<int>
        "m_bodyList" =@ b2ControllerEdge
        "AddBody" => b2Body?body ^-> T<unit>
        "Clear" => T<unit> ^-> T<unit>
        "Draw" => b2DebugDraw?debugDraw ^-> T<unit>
        "GetBodyList" => T<unit> ^-> b2ControllerEdge
        "GetNext" => T<unit> ^-> b2Controller
        "GetWorld" => T<unit> ^-> b2World
        "RemoveBody" => b2Body?body ^-> T<unit>
        "Step" => b2TimeStep?step ^-> T<unit>
    ]

let b2BuoyancyController =
    Class "Box2D.Dynamics.Controllers.b2BuoyancyController"
    |=> Inherits b2Controller
    |+> Protocol [
        "angularDrag" =@ T<float>
        "density" =@ T<float>
        "gravity" =@ b2Vec2
        "linearDrag" =@ T<float>
        "normal" =@ b2Vec2
        "offset" =@ T<float>
        "useDensity" =@ T<bool>
        "useWorldGravity" =@ T<bool>
        "velocity" =@ b2Vec2
        "Draw" => b2DebugDraw?debugDraw ^-> T<unit>
        "Step" => b2TimeStep?step ^-> T<unit>
    ]
    |+> [
        Constructor <| T<unit> 
    ]

let b2ConstantAccelController =
    Class "Box2D.Dynamics.Controllers.b2ConstantAccelController"
    |=> Inherits b2Controller
    |+> Protocol [
        "A" =@ b2Vec2
        "Step" =@ b2TimeStep?step ^-> T<unit> 
    ]

let b2ConstantForceController =
    Class "Box2D.Dynamics.Controllers.b2ConstantForceController"
    |=> Inherits b2Controller
    |+> Protocol [
        "F" =@ b2Vec2
        "Step" => b2TimeStep?step ^-> T<unit>
    ]

let b2ControllerEdgeClass =
    Class "Box2D.Dynamics.Controllers.b2ControllerEdge"
    |=> b2ControllerEdge
    |+> Protocol [
        "body" =@ b2Body
        "controller" =@ b2Controller
        "nextBody" =@ b2ControllerEdge
        "nextController" =@ b2ControllerEdge
        "prevBody" =@ b2ControllerEdge
        "prevController" =@ b2ControllerEdge
    ]

let b2GravityController =
    Class "Box2D.Dynamics.Controllers.b2GravityController"
    |=> Inherits b2Controller
    |+> Protocol [
        "G" =@ T<float>
        "invSqr" =@ T<bool>
        "Step" => b2TimeStep?step ^-> T<unit>
    ]

let b2TensorDampingController =
    Class "Box2D.Dynamics.Controllers.b2TensorDampingController"
    |=> Inherits b2Controller
    |+> Protocol [
        "maxTimestep" =@ T<int>
        "T" =@ b2Math22
        "SetAxisAligned" => T<float>?xDamping * T<float>?yDamping ^-> T<unit>
        "Step" => b2TimeStep?step ^-> T<unit>
    ]
