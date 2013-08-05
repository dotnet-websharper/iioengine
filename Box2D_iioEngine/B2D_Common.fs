module B2D_Common

open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.Html5

open IIO_Abstracts
open IIO_Definition
open IIO_Extensions

open B2D_CommonMath
open B2D_Collisions

let b2Color =
    Class "Box2D.Common.b2Color"
    |+> Protocol [
        "b" =! T<int>
        "color" =? T<uint32>
        "g" =! T<int>
        "r" =! T<int>
        Generic - fun t -> "Set" => T<int>?rr * T<int>?gg * T<int>?bb ^-> t
    ]
    |+> [
        Constructor <| T<int>?rr * T<int>?gg * T<int>?bb
    ]

let b2Settings =
    Class "Box2D.Common.b2Settings"
    |+> Protocol [
        "b2Assert" => T<bool>?a ^-> T<unit>
        "b2MixFriction" => T<float>?friction1 * T<float>?friction2 ^-> T<float>
        "b2MixResitution" => T<float>?resistution1 * T<float>?resistution2 ^-> T<float>
    ]
    |+> [
        "b2_aabbExtension" =@ T<float>
        "b2_aabbMultiplier" =@ T<float>
        "b2_angularSleepTolerance" =@ T<float>
        "b2_angularSlop" =@ T<float>
        "b2_contactBaumgarte" =@ T<float>
        "b2_linearSleepTolerance" =@ T<float>
        "b2_linearSlop" =@ T<float>
        "b2_maxAngularCorrection" =@ T<float>
        "b2_maxLinearCorrection" =@ T<float>
        "b2_maxManifoldPoints" =@ T<float>
        "b2_maxRotation" =@ T<float>
        "b2_maxRotationSquared" =@ T<float>
        "b2_maxTOIContactsPerIsland" =@ T<float>
        "b2_maxTOIJointsPerIsland" =@ T<float>
        "b2_maxTranslation" =@ T<float>
        "b2_maxTranslationSquared" =@ T<float>
        "b2_pi" =@ T<float>
        "b2_polygonRadius" =@ T<float>
        "b2_timeToSleep" =@ T<float>
        "b2_toiSlop" =@ T<float>
        "b2_velocityThreshold" =@ T<float>
        "USHRT_MAX" =@ T<int>
        "VERSION" =@ T<string>
    ]
