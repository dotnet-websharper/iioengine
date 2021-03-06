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
module IIO_Definition

open WebSharper.InterfaceGenerator

open WebSharper
open WebSharper.JavaScript.Dom

open IIO_Abstracts

//Shapes
let Circle =
    let self = Type.New()
    Class "iio.Circle"
    |=> self
    |=> Inherits Shape
    |+> Instance [
        "radius" =@ T<float>
        "clone" => T<unit> ^-> self
        "setRadius" => T<float>?radius ^-> self
        "contains" => Vec?point ^-> T<bool>
        "contains" => T<float>?x * T<float>?y ^-> T<bool>
    ]
    |+> Static [
        Constructor <| Vec?position * T<float>?radius
        Constructor <| T<float>?x * T<float>?y * T<float>?radius
    ]
let Poly =
    let self = Type.New()
    Class "iio.Poly"
    |=> self
    |=> Inherits Shape
    |+> Instance [
        "vertices" =@ T<obj[]>
        "width" =@ T<float>
        "height" =@ T<float>
        "originToLeft" =@ T<float>
        "originToTop" =@ T<float>
        "clone" => T<unit> ^-> self
        "contains" => Vec?point ^-> T<bool>
        "contains" => T<float>?x * T<float>?y ^-> T<bool>
        "getTrueVertices" => T<unit> ^-> T<obj[]>
    ]
    |+> Static [
            Constructor <| T<obj[]>?vertices
            Constructor <| Vec?position * T<obj[]>?vertices
            Constructor <| T<float>?x * T<float>?y * T<obj[]>?vertices
    ]
let Rect =
    let self = Type.New()
    Class "iio.Rect"
    |=> self
    |=> Inherits Shape
    |+> Instance [
        "clone" => T<unit> ^-> self
        "setSize" => Vec?size ^-> self
        "setSize" => T<float>?w * T<float>?h ^-> self
    ]
    |+> Static [
            Constructor <| Vec?position * T<float>?width * T<float>?height
            Constructor <| T<float>?x * T<float>?y * T<float>?width * T<float>?height
    ]
let SimpleRect =
    let self = Type.New()
    Class "iio.SimpleRect"
    |=> self
    |=> Inherits Shape
    |+> Instance [
        "width" =@ T<float>
        "height" =@ T<float>
        "clone" => T<unit> ^-> self
        "setSize" => Vec?size ^-> self
        "setSize" => T<float>?w * T<float>?h ^-> self
        "contains" => Vec?point ^-> T<bool>
        "contains" => T<float>?x * T<float>?y ^-> T<bool>
        "getTrueVertices" => T<unit> ^-> T<obj[]>
        "top" => T<unit> ^-> T<float>
        "right" => T<unit> ^-> T<float>
        "bottom" => T<unit> ^-> T<float>
        "left" => T<unit> ^-> T<float>
    ]
    |+> Static [
            Constructor <| Vec?position * !?T<float>?width * !?T<float>?height
            Constructor <| T<float>?x * T<float>?y * !?T<float>?width * !?T<float>?height
    ]
let XShape =
    let self = Type.New()
    Class "iio.XShape"
    |=> self
    |=> Inherits Shape
    |+> Instance [
        "clone" => T<unit> ^-> self
    ]
    |+> Static [
            Constructor <| Vec?position * T<float>?width * !?T<float>?height
            Constructor <| T<float>?x * T<float>?y * T<float>?width * !?T<float>?height
    ]


//Constructs
let Line =
    let self = Type.New()
    Class "iio.Line"
    |=> self
    |=> Inherits Obj
    |+> Instance [
        "endPos" =@ Vec
        "clone" => T<unit> ^-> self
        "set" => self?line ^-> self
        "set" => Vec?v1 * Vec?v2 ^-> self
        "set" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> self
        "setEndPos" => Vec?point ^-> self
        "setEndPos" => T<float>?x * T<float>?y ^-> self
    ]
    |+> Static [
            Constructor <| Vec?v1 * Vec?v2
            Constructor <| T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2
            Constructor <| T<float>?x1 * T<float>?y1 * Vec?v2
            Constructor <| Vec?v1 * T<float>?x2 * T<float>?y2
    ]
let MultiLine =
    let self = Type.New()
    Class "iio.MultiLine"
    |=> self
    |=> Inherits Obj
    |+> Instance [
        "vertices" =@ T<obj[]>
        "clone" => T<unit> ^-> self
    ]
    |+> Static [
            Constructor <| T<obj[]>?vertices
    ]
let Grid =
    let self = Type.New()
    Class "iio.Grid"
    |=> self
    |=> Inherits Obj
    |+> Instance [
        "cells" =@ Vec
        "R" =@ T<float>
        "C" =@ T<float>
        "res" =@ T<float>
        "clone" => T<unit> ^-> self
        "resetCells" => T<unit> ^-> self
        "getCellAt" => Vec?v ^-> Vec
        "getCellAt" => T<float>?x * T<float>?y ^-> Vec
        "getCellCenter" => Vec?v * T<bool>?pixelPos ^-> Vec
        "getCellCenter" => T<float>?x * T<float>?y * T<bool>?pixelPos ^-> Vec
    ]
    |+> Static [
            Constructor <| Vec?pos * T<float>?columns * T<float>?rows * T<float>?xRes * T<float>?yRes
            Constructor <| T<float>?x1 * T<float>?y1 * T<float>?columns * T<float>?rows * T<float>?xRes * T<float>?yRes
    ]
let Text =
    let self = Type.New()
    Class "iio.Text"
    |=> self
    |=> Inherits Obj
    |+> Instance [
        "text" =@ T<string> |> WithSourceName "Value"
        "font" =@ T<string>
        "textAlign" =@ T<string>
        "clone" => T<unit> ^-> self
        "setText" => T<string>?text ^-> self
        "setFont" => T<string>?text ^-> self
        "setTextAlign" => T<string>?text ^-> self
    ]
    |+> Static [
            Constructor <| T<string>?text * Vec?pos
            Constructor <| T<string>?text * T<float>?x * T<float>?y
    ]


//AppManager
let Canvas2DContext = Type.New()
let b2World = Type.New()
let AppManager =
    let self = Type.New()
    Class "AppManager"
    |=> self
    |+> Instance [
        "canvas" =@ T<JavaScript.CanvasElement>
        "context" =@ Canvas2DContext
        "cnvs" =@ T<obj[]>
        "ctxs" =@ T<obj[]>
        "setFramerate" => T<int>?fps * (T<obj> ^-> T<unit>)?callback * !?T<float>?c ^-> self
        "setFramerate" => T<int>?fps * Obj?obj * T<obj>?ctx * (T<obj> ^-> T<unit>)?callback ^-> self
        "pauseFramerate" => T<bool>?pause ^-> self
        "pauseFramerate" => T<bool>?pause * Obj?obj ^-> self
        "cancelFramerate" => T<int>?canvasIndex ^-> self
        "cancelFramerate" => Obj?obj ^-> self
        "setAnimFPS" => T<float>?fps * Obj?obj * !?T<float>?canvasId ^-> T<float>
        //Canvas Control Functions
        "draw" => T<float>?c ^-> self
        "addB2World" => b2World?world * !?T<int>?c ^-> b2World
        "addCanvas" => T<unit> ^-> T<float>
        "addCanvas" => T<string>?canvasId ^-> T<float>
        "addCanvas" => T<int>?zIndex ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<obj[]>?cssClasses ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId * T<string>?cssClass ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId * T<obj[]>?cssClasses ^-> T<float>
        "getEventPosition" => T<Event>?event * !?T<int>?c ^-> Vec
        "setBGColor" => T<string>?color * !?T<int>?c ^-> self
        "setBGPattern" => T<string>?imagePath ^-> T<bool>
        "setBGPattern" => T<string>?imagePath * T<float>?c ^-> T<bool>
        "setBGImage" => T<string>?imagePath ^-> self
        "setBGImage" => T<Element>?img ^-> self
        "setBGImage" => T<string>?imagePath * T<float>?c ^-> self
        //Object Control Functions
        Generic - fun t -> "addObj" => t?obj * !?T<int>?c ^-> t
        "rmvObj" => Obj?obj * !?T<int>?c ^-> T<bool>
        "rmvAll" => !?T<int>?c ^-> T<unit>
        "addGroup" => T<string>?tag * !?T<int>?zIndex * !?T<float>?c ^-> T<float>
        "addToGroup" => T<string>?tag * Obj?obj * !?T<int>?zIndex * !?T<float>?c ^-> Obj
        "rmvFromGroup" => Obj?obj * T<string>?tag * !?T<float>?c ^-> T<float>
        "getGroup" => T<string>?tag * T<int>?canvasId * T<float>?from * T<float>?``to`` ^-> T<obj[]>
        "setCollisionCallback" => T<string>?tag * ((T<obj> * T<obj>) ^-> T<unit>) * !?T<int>?c ^-> T<float>
        "setCollisionCallback" => T<string>?tag1 * T<string>?tag2 * ((Obj * Obj) ^-> T<unit>)?callback * !?T<int> ^-> T<float>
    ]
        
let Iio =
    Class "iio"
    |+> Static [
        //need the class inherit parent-child
        //"inherit" => ()
        //start functions
        "start" => (AppManager ^-> T<unit>)?app ^-> AppManager
        "start" => (AppManager ^-> T<unit>)?app * T<string>?canvasId ^-> AppManager
        "start" => (AppManager ^-> T<unit>)?app * T<float>?width * T<float>?height ^-> AppManager
        "start" => (AppManager ^-> T<unit>)?app * T<string>?elementId * T<float>?width * T<float>?height ^-> AppManager
        //utility functions
        "getRandomNum" => T<float>?min * T<float>?max ^-> T<float>
        "getRandomInt" => T<int>?min * T<int>?max ^-> T<int>
        "isNumber" => T<obj> ^-> T<bool>
        "isBetween" => T<float>?value * T<float>?bound1 * T<float>?bound2 ^-> T<bool>
        "rotatePoint" => Vec?point * T<float>?angle ^-> Vec
        "rotatePoint" => T<float>?x * T<float>?y * T<float>?angle ^-> Vec
        "getCentroid" => T<obj[]>?vectors ^-> Vec
        "getSpecVertex" => T<obj[]>?vectors * (T<obj> ^-> T<unit>)?comparator  ^-> Vec
        "getVecsFromPointList" => T<obj[]>?points ^-> T<obj[]>
        "hasKeyCode" => T<string>?key * T<Event>?event ^-> T<bool>
        //intersection functions
        "lineConstains" => Vec?lineStart * Vec?lineEnd * Vec?point ^-> T<bool>
        "intersects" => Shape?shap1 * Shape?shape2 ^-> T<bool>
        "lineXline" => Vec?l1Start * Vec?l1End * Vec?l2Start * Vec?l2End ^-> T<bool>
        "rectXrect" => SimpleRect?rect1 * SimpleRect?rect2 ^-> T<bool>
        "polyXpoly" => Poly?poly1 * Poly?poly2 ^-> T<bool>
        "circleXcircle" => Circle?circle1 * Circle?circle2 ^-> T<bool>
        "polyXcircle" => Poly?poly * Circle?circle ^-> T<bool>
        "addEvent" => T<JavaScript.CanvasElement>?obj * T<string>?evt * (T<obj> ^-> T<unit>)?fn * !?T<obj>?capt ^-> T<bool>
    ] 
