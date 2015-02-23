module B2D_CommonMath

open WebSharper.InterfaceGenerator

let b2Math22 = Type.New()
let Box2DSprite = T<obj>
let b2TimeStep = T<float>

let b2Vec2 =
    let self = Type.New()
    Class "Box2D.Common.Math.b2Vec2"
    |=> self
    |+> Instance [
        "x" =@ T<float>
        "y" =@ T<float>
        "Abs" => T<unit> ^-> T<unit>
        "Add" => self?v ^-> T<unit>
        "Copy" => T<unit> ^-> self
        "CrossFV" => T<float>?s ^-> T<unit>
        "CrossVF" => T<float>?s ^-> T<unit>
        "GetNegative" => T<unit> ^-> self
        "IsValid" => T<unit> ^-> T<bool>
        "Length" => T<unit> ^-> T<float>
        "LengthSquared" => T<unit> ^-> T<float>
        "MaxV" => self?b ^-> T<unit>
        "MinV" => self?b ^-> T<unit>
        "MulM" => b2Math22?A ^-> T<unit>
        "Multiply" => T<float>?a ^-> T<unit>
        "MulTM" => b2Math22?A ^-> T<unit>
        "NegativeSelf" => T<unit> ^-> T<unit>
        "Normalize" => T<unit> ^-> T<float>
        "Set" => T<float>?x * T<float>?y ^-> T<unit>
        "SetV" => self?v ^-> T<unit>
        "SetZero" => T<unit> ^-> T<unit>
        "Subtract" => self?v ^-> T<unit>
    ]
    |+> Static [
        Constructor <| T<float>?x * T<float>?y
        "Make" => T<float>?x * T<float>?y ^-> self
    ]

let b2Vec3 =
    let self = Type.New()
    Class "Box2D.Common.Math.b2Vec3"
    |=> self
    |+> Instance [
        "x" =@ T<float>
        "y" =@ T<float>
        "z" =@ T<float>
        "Add" => self?v ^-> T<unit>
        "Copy" => T<unit> ^-> self
        "GetNegative" => T<unit> ^-> self
        "Multiply" => T<float>?a ^-> T<unit>
        "NegativeSelf" => T<unit> ^-> T<unit>
        "Set" => T<float>?x * T<float>?y * T<float>?z ^-> T<unit>
        "SetV" => self?v ^-> T<unit>
        "SetZero" => T<unit> ^-> T<unit>
        "Subtract" => self?v ^-> T<unit>
    ]
    |+> Static [
        Constructor <| T<float>?x * T<float>?y * T<float>?z
    ]

let b2Math22Class =
    Class "Box2D.Common.Math.b2Math22"
    |=> b2Math22
    |+> Instance [
        "col1" =@ b2Vec2
        "col2" =@ b2Vec2
        "Abs" => T<unit> ^-> T<unit>
        "AddM" => b2Math22?m ^-> T<unit>
        "Copy" => T<unit> ^-> b2Math22
        "FromAngle" => T<float>?angle ^-> b2Math22
        "FromVV" => b2Vec2?c1 * b2Vec2?c2 ^-> b2Math22
        "GetAngle" => T<unit> ^-> T<float>
        "GetInverse" => b2Math22?out ^-> b2Math22
        "Set" => T<float>?angle ^-> T<unit>
        "SetIndentity" => T<unit> ^-> T<unit>
        "SetM" => b2Math22?m ^-> T<unit>
        "SetVV" => b2Vec2?c1 * b2Vec2?c2 ^-> T<unit>
        "SetZero" => T<unit> ^-> T<unit>
        "Solve" => b2Vec2?out * T<float>?bX * T<float>?bY ^-> b2Vec2
    ]

let b2Transform =
    let self = Type.New()
    Class "Box2D.Common.Math.b2Transform"
    |=> self
    |+> Instance [
        "position" =@ b2Vec2
        "R" =@ b2Math22
        "GetAngle" => T<unit> ^-> T<float>
        "Initialize" => b2Vec2?pos * b2Math22?r ^-> T<unit>
        "Set" => self?x ^-> T<unit>
        "SetIndentity" => T<unit> ^-> T<unit>
    ]
    |+> Static [
        Constructor <| b2Vec2?pos * b2Math22?r
    ]

let b2Math33 =
    let self = Type.New()
    Class "Box2D.Common.Math.b2Math33"
    |=> self
    |+> Instance [
        "col1" =@ b2Vec3
        "col2" =@ b2Vec3
        "col3" =@ b2Vec3
        "AddM" => self?m ^-> T<unit>
        "Copy" => T<unit> ^-> self
        "SetIndentify" => T<unit> ^-> T<unit>
        "SetM" => self?m ^-> T<unit>
        "SetVVV" => b2Vec3?c1 * b2Vec3?c2 * b2Vec3?c3 ^-> T<unit>
        "SetZero" => T<unit> ^-> T<unit>
        "Solve22" => b2Vec3?out * T<float>?bX * T<float>?bY ^-> b2Vec3
        "Solve33" => b2Vec3?out * T<float>?bX * T<float>?bY * T<float>?bZ ^-> b2Vec3

    ]
     |+> Static [
        Constructor <| b2Vec3?c1 * b2Vec3?c2 * b2Vec3?c3
     ]

let b2Sweep =
    let self = Type.New()
    Class "Box2D.Common.Math.b2Sweep"
    |=> self
    |+> Instance [
        "a" =@ T<float>
        "a0" =@ T<float>
        "c" =@ b2Vec2
        "c0" =@ b2Vec2
        "localCenter" =@ b2Vec2
        "t0" =@ T<float>
        "Advance" => T<float>?t ^-> T<unit>
        "Copy" => T<unit> ^-> self
        "GetTransform" => b2Transform?xf * T<float>?alpha ^-> T<unit>
        "Set" => self?other ^-> T<unit>
    ]
