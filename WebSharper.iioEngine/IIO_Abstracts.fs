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
module IIO_Abstracts

open WebSharper.InterfaceGenerator
open WebSharper.JavaScript.Dom

//Abstracts
let Vec =
    let self = Type.New()
    Class "iio.Vec"
    |=> self
    |+> Instance [
        "x" =@ T<float>
        "y" =@ T<float>
        "clone" => T<unit> ^-> self
        "toString" => T<unit> ^-> T<string>
        "length" => T<unit> ^-> T<float>
        "normalize" => T<unit> ^-> T<unit>
        "set" => self?v ^-> self
        "set" => T<float>?x * T<float>?y ^-> self
        "add" => self?v ^-> self
        "add" => T<float>?x * T<float>?y ^-> self
        "sub" => self?v ^-> self
        "sub" => T<float>?x * T<float>?y ^-> self
        "mult" => T<float>?number ^-> T<float>
        "div" => T<float>?divisor ^-> T<float>
        "dot" => self?v ^-> T<float>
        "dot" => T<float>?x * T<float>?y ^-> self
        "distance" => self?v ^-> T<float>
        "distance" => T<float>?x * T<float>?y ^-> self
        "lerp" => self?v * T<float>?weight ^-> self
        "lerp" => T<float>?x * T<float>?y * T<float>?weight ^-> self
    ]
    //static functions
    |+> Static [
            Constructor <| self?v
            Constructor <| T<float>?x * T<float>?y
            "tostring" => self?v ^-> T<string>
            "tostring" => T<float>?x * T<float>?y ^-> T<string>
            "length" => self?v ^-> T<float>
            "length" => T<float>?x * T<float>?y ^-> T<float>
            "normalize" => self?v ^-> T<float>
            "normalize" => T<float>?x * T<float>?y ^-> T<float>
            "add" => self?v1 * self?v2 ^-> self
            "add" => self?v1 * T<float>?x2 * T<float>?y2 ^-> self
            "add" => T<float>?x1 * T<float>?y1 * self?v2 ^-> self
            "add" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> self
            "sub" => self?v1 * self?v2 ^-> self
            "sub" => self?v1 * T<float>?x2 * T<float>?y2 ^-> self 
            "sub" => T<float>?x1 * T<float>?y1 * self?v2 ^-> self
            "sub" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> self
            "mult" => self?v1 * T<float>?factor ^-> self
            "mult" => T<float>?x1 * T<float>?y1 * T<float>?factor ^-> self
            "div" => self?v1 * T<float>?divisor ^-> self
            "div" => T<float>?x1 * T<float>?y1 * T<float>?divisor ^-> self
            "dot" => self?v1 * self?v2 ^-> T<float>
            "dot" => self?v1 * T<float>?x2 * T<float>?y2 ^-> T<float>
            "dot" => T<float>?x1 * T<float>?y1 * self?v2 ^-> T<float>
            "dot" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> T<float>
            "distance" => self?v1 * self?v2 ^-> T<float>
            "distance" => self?v1 * T<float>?x2 * T<float>?y2 ^-> T<float>
            "distance" => T<float>?x1 * T<float>?y1 * self?v2 ^-> T<float>
            "distance" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> T<float>
            "lerp" => self?v1 * self?v2 * T<int>?weight ^-> self
            "lerp" => self?v1 * T<float>?x2 * T<float>?y2 * T<int>?weight ^-> self
            "lerp" => T<float>?x1 * T<float>?y1 * self?v2 * T<int>?weight ^-> self
            "lerp" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 * T<int>?weight ^-> self

    ]
let Obj =
    let self = Type.New()
    Class "iio.Obj"
    |=> self
    |+> Instance [
        "pos" =@ Vec
        "rotation" =@ T<float>
        "clone" => T<unit> ^-> self
        "setPos" => Vec?pos ^-> self
        "setPos" => T<float>?x * T<float>?y ^-> self
        "translate" => Vec?v ^-> self
        "translate" => T<float>?x * T<float>?y ^-> self
        "rotate" => T<float>?radians ^-> self
        "enableUpdates" => ((T<obj> ^-> T<unit>)?callback * T<obj[]>?callbackParams) ^-> self
        "addEventListener" => T<Event>?evt * (T<obj> ^-> T<unit>)?fn * T<obj>?capt ^-> T<bool>
    ]
    |+> Static [
        Constructor <| Vec?position
        Constructor <| T<float>?x * T<float>?y
    ]
    //|+>ObjExtensions 
let Shape =
    Class "Shape"
    |=> Inherits Obj
