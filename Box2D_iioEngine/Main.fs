namespace Box2D_iioEngine

module Something =

    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.InterfaceGenerator
    
    open B2D_CommonMath
    open B2D_Collisions
    open B2D_Common
    open B2D_Dynamics

    open IIO_Abstracts
    open IIO_Definition
    open IIO_Extensions


    let Assembly =
        Assembly [
            Namespace "IntelliFactory.WebSharper.IIOEngine" [
                b2AABB
                b2ContactID
                b2ContactPoint
                b2DistanceInput
                b2DistanceOutput
                b2DynamicTreeBroadPhase
                b2Manifold
                b2ManifoldPoint
                b2OBB
                b2RayCastInput
                b2RayCastOutput
                b2Segment
                b2SimplexCache
                b2TOIInput
                b2WorldManifold
                FeaturesClass
                IBroadPhase
                b2ShapeClass
                b2CircleShape
                b2EdgeChainDef
                b2MassData
                b2PolygonShape
                b2Color
                b2Settings
                b2Math22Class
                b2Math33
                b2Sweep
                b2Transform
                b2Vec2
                b2Vec3
                b2BodyClass
                b2BodyDefClass
                b2ContactFilter
                b2ContactImpulse
                b2ContactListener
                b2DebugDraw
                b2DestructionListener
                b2FilterDataClass
                b2FixtureClass
                b2FixtureDefClass
                b2WorldClass
                b2Contact
                b2ContactEdge
                b2ContactResult
                b2BuoyancyController
                b2ConstantAccelController
                b2ConstantForceController
                b2ControllerClass
                b2ControllerEdgeClass
                b2GravityController
                b2TensorDampingController
                b2DistanceJoint
                b2DistanceJointDef
                b2FrictionJoint
                b2FrictionJointDef
                b2GearJoint
                b2GearJointDef
                b2JointClass
                b2JointDefClass
                b2JointEdgeClass
                b2LineJoint
                b2LineJointDef
                b2MouseJoint
                b2MouseJointDef
                b2PrismaticJoint
                b2PrismaticJointDef
                b2PulleyJoint
                b2PulleyJointDef
                b2RevoluteJoint
                b2RevoluteJointDef
                b2WeldJoint
                b2WeldJointDef
                Vec
                Obj |+> ObjExtensions 
                Shape |+> ShapeExtensions |+> Kinematics
                Circle   
                Poly 
                Rect 
                SimpleRect 
                XShape 
                Line 
                MultiLine  
                Grid
                Text
                AppManager
                fxFade
                ObjExtClass
                SpriteMap
                Sprite
                KinematicsBound
                KinematicsBounds
                IioImg
                Iio
            ]
        ]

module Main =
    open IntelliFactory.WebSharper.InterfaceGenerator

    do Compiler.Compile stdout Something.Assembly
