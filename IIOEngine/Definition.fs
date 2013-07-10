module IIOEngine.Definition

open IntelliFactory.WebSharper.InterfaceGenerator

open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Html5
open IntelliFactory.WebSharper.Dom

open IIOEngine.Abstracts

//Shapes
let Circle =
    let self = Type.New()
    Class "Circle"
    |=> self
    |=> Inherits Shape
    |+> Protocol [
        "radius" =@ T<float>
        "clone" => T<unit> ^-> self
        "setRadius" => T<float>?radius ^-> self
        "contains" => Vec?point ^-> T<bool>
        "contains" => T<float>?x * T<float>?y ^-> T<bool>
    ]
    |+> [
        Constructor <| Vec?position * T<float>?radius
        Constructor <| T<float>?x * T<float>?y * T<float>?radius
    ]
let Poly =
    let self = Type.New()
    Class "Poly"
    |=> self
    |=> Inherits Shape
    |+> Protocol [
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
    |+> [
            Constructor <| T<obj[]>?vertices
            Constructor <| Vec?position * T<obj[]>?vertices
            Constructor <| T<float>?x * T<float>?y * T<obj[]>?vertices
    ]
let Rect =
    let self = Type.New()
    Class "Rect"
    |=> self
    |=> Inherits Shape
    |+> Protocol [
        "clone" => T<unit> ^-> self
        "setSize" => Vec?size ^-> self
        "setSize" => T<float>?w * T<float>?h ^-> self
    ]
    |+> [
            Constructor <| Vec?position * T<float>?width * T<float>?height
            Constructor <| T<float>?x * T<float>?y * T<float>?width * T<float>?height
    ]
let SimpleRect =
    let self = Type.New()
    Class "SimpleRect"
    |=> self
    |=> Inherits Shape
    |+> Protocol [
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
    |+> [
            Constructor <| Vec?position * !?T<float>?width * !?T<float>?height
            Constructor <| T<float>?x * T<float>?y * !?T<float>?width * !?T<float>?height
    ]
let XShape =
    let self = Type.New()
    Class "XShape"
    |=> self
    |=> Inherits Shape
    |+> Protocol [
        "clone" => T<unit> ^-> self
    ]
    |+> [
            Constructor <| Vec?position * T<float>?width * !?T<float>?height
            Constructor <| T<float>?x * T<float>?y * T<float>?width * !?T<float>?height
    ]


//Constructs
let Line =
    let self = Type.New()
    Class "Line"
    |=> self
    |=> Inherits Obj
    |+> Protocol [
        "endPos" =@ Vec
        "clone" => T<unit> ^-> self
        "set" => self?line ^-> self
        "set" => Vec?v1 * Vec?v2 ^-> self
        "set" => T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2 ^-> self
        "setEndPos" => Vec?point ^-> self
        "setEndPos" => T<float>?x * T<float>?y ^-> self
    ]
    |+> [
            Constructor <| Vec?v1 * Vec?v2
            Constructor <| T<float>?x1 * T<float>?y1 * T<float>?x2 * T<float>?y2
            Constructor <| T<float>?x1 * T<float>?y1 * Vec?v2
            Constructor <| Vec?v1 * T<float>?x2 * T<float>?y2
    ]
let MultiLine =
    let self = Type.New()
    Class "MultiLine"
    |=> self
    |=> Inherits Obj
    |+> Protocol [
        "vertices" =@ T<obj[]>
        "clone" => T<unit> ^-> self
    ]
    |+> [
            Constructor <| T<obj[]>?vertices
    ]
let Grid =
    let self = Type.New()
    Class "Grid"
    |=> self
    |=> Inherits Obj
    |+> Protocol [
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
    |+> [
            Constructor <| Vec?pos * T<float>?columns * T<float>?rows * T<float>?xRes * T<float>?yRes
            Constructor <| T<float>?x1 * T<float>?y1 * T<float>?columns * T<float>?rows * T<float>?xRes * T<float>?yRes
    ]
let Text =
    let self = Type.New()
    Class "Text"
    |=> self
    |=> Inherits Obj
    |+> Protocol [
        "text" =@ T<string> |> WithSourceName "Value"
        "font" =@ T<string>
        "textAlign" =@ T<string>
        "clone" => T<unit> ^-> self
        "setText" => T<string> ^-> self
        "setFont" => T<string> ^-> self
        "setTextAlign" => T<string> ^-> self
    ]
    |+> [
            Constructor <| T<string>?text * Vec?pos
            Constructor <| T<string>?text * T<float>?x * T<float>?y
    ]


//AppManager
let Canvas2DContext = Type.New()
let AppManager =
    let self = Type.New()
    Class "AppManager"
    |=> self
    |+> Protocol [
        "canvas" =@ T<IntelliFactory.WebSharper.Html5.CanvasElement>
        "context" =@ Canvas2DContext
        "cnvs" =@ T<obj[]>
        "ctxs" =@ T<obj[]>
        "setFramerate" => T<float>?fps * (T<obj> ^-> T<unit>)?callback * !?T<float>?c ^-> self
        "setFramerate" => T<float>?fps * Obj?obj * T<obj>?ctx * (T<obj> ^-> T<unit>)?callback ^-> self
        "pauseFramerate" => T<bool>?pause ^-> self
        "pauseFramerate" => T<bool>?pause * Obj?obj ^-> self
        "cancelFramerate" => T<int>?canvasIndex ^-> self
        "cancelFramerate" => Obj?obj ^-> self
        "setAnimFPS" => T<float>?fps * Obj?obj * !?T<float>?canvasId ^-> T<float>
        //Canvas Control Functions
        "draw" => T<float>?c ^-> self
        "addCanvas" => T<unit> ^-> T<float>
        "addCanvas" => T<string>?canvasId ^-> T<float>
        "addCanvas" => T<int>?zIndex ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<obj[]>?cssClasses ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId * T<string>?cssClass ^-> T<float>
        "addCanvas" => T<int>?zIndex * T<float>?w * T<float>?h * T<string>?attachElementId * T<obj[]>?cssClasses ^-> T<float>
        "getPosition" => T<Event>?event * !?T<float>?c ^-> Vec
        "setBGColor" => T<string>?color * !?T<float>?c ^-> self
        "setBGPattern" => T<string>?imagePath ^-> T<bool>
        "setBGPattern" => T<string>?imagePath * T<float>?c ^-> T<bool>
        "setBGImage" => T<string>?imagePath ^-> self
        "setBGImage" => T<string>?imagePath * T<float>?c ^-> self
        //Object Control Functions
        "addObj" => Obj?obj * T<float>?c ^-> Obj
        "rmvObj" => Obj?obj * T<float>?c ^-> T<bool>
        "rmvAll" => !?T<int>?c ^-> self
        "addGroup" => T<string>?tag * T<int>?zIndex * !?T<float>?c ^-> T<float>
        "addToGroup" => T<string>?tag * Obj?obj * !?T<int>?zIndex * !?T<float>?c ^-> Obj
        "rmvFromGroup" => Obj?obj * T<string>?tag * !?T<float>?c ^-> T<float>
        "getGroup" => T<string>?tag * T<int>?canvasId * T<float>?from * T<float>?``to`` ^-> T<obj[]>
        "setCollisionCallback" => T<string>?tag * (T<obj> ^-> T<unit>)?callback * !?T<float>?c ^-> T<float>
        "setCollisionCallback" => T<string>?tag1 * T<string>?tag2 * (T<obj> ^-> T<unit>)?callback * !?T<float>?c ^-> T<float>
    ]
        
let Iio =
    Class "Iio"
    |+> [
        //need the class inherit parent-child
        //"inherit" => ()
        //start functions
        "start" => (T<obj> ^-> T<unit>)?app ^-> AppManager
        "start" => (T<obj> ^-> T<unit>)?app * T<string>?canvasId ^-> AppManager
        "start" => (T<obj> ^-> T<unit>)?app * T<float>?width * T<float>?height ^-> AppManager
        "start" => (T<obj> ^-> T<unit>)?app * T<string>?elementId * T<float>?width * T<float>?height ^-> AppManager
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
    ]