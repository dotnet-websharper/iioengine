// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
module B2D_Common

open WebSharper.InterfaceGenerator

open IIO_Abstracts
open IIO_Definition
open IIO_Extensions

open B2D_CommonMath
open B2D_Collisions

let b2Color =
    Class "Box2D.Common.b2Color"
    |+> Instance [
        "b" =! T<int>
        "color" =? T<uint32>
        "g" =! T<int>
        "r" =! T<int>
        Generic - fun t -> "Set" => T<int>?rr * T<int>?gg * T<int>?bb ^-> t
    ]
    |+> Static [
        Constructor <| T<int>?rr * T<int>?gg * T<int>?bb
    ]

let b2Settings =
    Class "Box2D.Common.b2Settings"
    |+> Instance [
        "b2Assert" => T<bool>?a ^-> T<unit>
        "b2MixFriction" => T<float>?friction1 * T<float>?friction2 ^-> T<float>
        "b2MixResitution" => T<float>?resistution1 * T<float>?resistution2 ^-> T<float>
    ]
    |+> Static [
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
