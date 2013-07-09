namespace IIOEngine

open IntelliFactory.WebSharper

module Definition =
    open IntelliFactory.WebSharper.InterfaceGenerator
    open IIOEngine.Abstracts
//    module Res =
//        let IIOAPI = 
//            Resource "IIOAPI" "http://iioengine.com/js/iioEngine.min.js"
    
    //Shapes
    let Circle =
        let self = Type.New()
        Class "Circle"
        |=> self
        |=> Inherits Shape
        |+> Protocol [
            "radius" =@ T<float>
            "clone" => T<unit> ^-> self
            "setRadius" => T<float> ^-> self
            "contains" => Vec ^-> T<bool>
            "contains" => T<float> ^-> T<bool>
        ]
        |+> [
            Constructor <| Vec * T<float>
            Constructor <| T<float> * T<float> * T<float>
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
            "contains" => Vec ^-> T<bool>
            "contains" => T<float> * T<float> ^-> T<bool>
            "getTrueVertices" => T<unit> ^-> T<obj[]>
        ]
        |+> [
                Constructor <| T<obj[]>
                Constructor <| Vec * T<obj[]>
                Constructor <| T<float> * T<float> * T<obj[]>
        ]
    let Rect =
        let self = Type.New()
        Class "Rect"
        |=> self
        |=> Inherits Shape
        |+> Protocol [
            "clone" => T<unit> ^-> self
            "setSize" => Vec ^-> self
            "setSize" => T<float> * T<float> ^-> self
        ]
        |+> [
                Constructor <| Vec * T<float> * T<float>
                Constructor <| T<float> * T<float> * T<float> * T<float>
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
            "setSize" => Vec ^-> self
            "setSize" => T<float> * T<float> ^-> self
            "contains" => Vec ^-> T<bool>
            "contains" => T<float> * T<float> ^-> T<bool>
            "getTrueVertices" => T<unit> ^-> T<obj[]>
            "top" => T<unit> ^-> T<float>
            "right" => T<unit> ^-> T<float>
            "bottom" => T<unit> ^-> T<float>
            "left" => T<unit> ^-> T<float>
        ]
        |+> [
                Constructor <| Vec * T<float> * T<float>
                Constructor <| T<float> * T<float> * T<float> * T<float>
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
                Constructor <| Vec * T<float> * T<float>
                Constructor <| T<float> * T<float> * T<float> * T<float>
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
            "set" => self ^-> self
            "set" => Vec * Vec ^-> self
            "set" => T<float> * T<float> * T<float> * T<float> ^-> self
            "setEndPos" => Vec ^-> self
            "setEndPos" => T<float> * T<float> ^-> self
        ]
        |+> [
                Constructor <| Vec * Vec
                Constructor <| T<float> * T<float> * T<float> * T<float>
                Constructor <| T<float> * T<float> * Vec
                Constructor <| Vec * T<float> * T<float>
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
                Constructor <| T<obj[]>
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
            "getCellAt" => Vec ^-> Vec
            "getCellAt" => T<float> * T<float> ^-> Vec
            "getCellCenter" => Vec * T<bool> ^-> Vec
            "getCellCenter" => T<float> * T<float> * T<bool> ^-> Vec
        ]
        |+> [
                Constructor <| Vec * T<float> * T<float> * T<float> * T<float>
                Constructor <| T<float> * T<float> * T<float> * T<float> * T<float> * T<float>
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
                Constructor <| T<string> * Vec
                Constructor <| T<string> * T<float> * T<float>
        ]

    //AppManager
    let Canvas2DContext = Type.New()
    let AppManager =
        let self = Type.New()
        Class "AppManager"
        |=> self
        |+> Protocol [
            "canvas" =@ T<obj>
            "context" =@ Canvas2DContext
            "cnvs" =@ T<obj[]>
            "ctxs" =@ T<obj[]>
            "setFramerate" => T<float> * (T<obj> ^-> T<unit>) * T<float> ^-> self
            "setFramerate" => T<float> * Obj * Obj * (T<obj> ^-> T<unit>) ^-> self
            "pauseFramerate" => T<bool> ^-> self
            "pauseFramerate" => T<bool> * Obj * Obj ^-> self
            "cancelFramerate" => T<float> ^-> self
            "cancelFramerate" => Obj ^-> self
            "setAnimFPS" => T<float> * Obj * T<float> ^-> T<float>
            //Canvas Control Functions
            "draw" => T<float> ^-> self
            "addCanvas" => T<unit> ^-> T<float>
            "addCanvas" => T<string> ^-> T<float>
            "addCanvas" => T<float> ^-> T<float>
            "addCanvas" => T<float> * T<float> * T<float> ^-> T<float>
            "addCanvas" => T<float> * T<float> * T<float> * T<obj[]> ^-> T<float>
            "addCanvas" => T<float> * T<float> * T<float> * T<string> ^-> T<float>
            "addCanvas" => T<float> * T<float> * T<float> * T<string> * T<string> ^-> T<float>
            "addCanvas" => T<float> * T<float> * T<float> * T<string> * T<obj[]> ^-> T<float>
            "getEventPosition" =>  T<Dom.Event> * T<float> ^-> Vec
            "setBGColor" => T<string> * T<float> ^-> self
            "setBGPattern" => T<string> ^-> T<bool>
            "setBGPattern" => T<string> * T<float> ^-> T<bool>
            "setBGImage" => T<string> ^-> self
            "setBGImage" => T<string> * T<float> ^-> self
            //Object Control Functions
            "addObj" => Obj * T<float> ^-> Obj
            "rmvObj" => Obj * T<float> ^-> T<bool>
            "rmvAll" => T<float> ^-> self
            "addGroup" => T<string> * T<float> * T<float> ^-> T<float>
            "addToGroup" => T<string> * Obj * T<float> * T<float> ^-> Obj
            "rmvFromGroup" => Obj * T<string> * T<float> ^-> T<float>
            "getGroup" => T<string> * T<float> * T<float> * T<float> ^-> T<obj[]>
            "setCollisionCallback" => T<string> * (T<obj> ^-> T<unit>) * T<float> ^-> T<float>
            "setCollisionCallback" => T<string> * T<string> * (T<obj> ^-> T<unit>) * T<float> ^-> T<float>
        ]
        
    let Core =
        [
            //need the class inherit parent-child
            //"inherit" => ()
            //start functions
            "start" => (T<obj> ^-> T<unit>) ^-> AppManager
            "start" => (T<obj> ^-> T<unit>) * T<string> ^-> AppManager
            "start" => (T<obj> ^-> T<unit>) * T<float> * T<float> ^-> AppManager
            "start" => (T<obj> ^-> T<unit>) * T<string> * T<float> * T<float> ^-> AppManager
            //utility functions
            "getRandomNum" => T<float> * T<float> ^-> T<float>
            "getRandomInt" => T<int> * T<int> ^-> T<int>
            "isNumber" => T<obj> ^-> T<bool>
            "isBetween" => T<float> * T<float> * T<float> ^-> T<bool>
            "rotatePoint" => Vec * T<float> ^-> Vec
            "rotatePoint" => T<float> * T<float> * T<float> ^-> Vec
            "getCentroid" => T<obj[]> ^-> Vec
            "getSpecVertex" => T<obj[]> * (T<obj> ^-> T<unit>)  ^-> Vec
            "getVecsFromPointList" => T<obj[]> ^-> T<obj[]>
            "hasKeyCode" => T<string> * T<Dom.Event> ^-> T<bool>
            //intersection functions
            "lineConstains" => Vec * Vec * Vec ^-> T<bool>
            "intersects" => Shape * Shape ^-> T<bool>
            "lineXline" => Vec * Vec * Vec * Vec ^-> T<bool>
            "rectXrect" => SimpleRect * SimpleRect ^-> T<bool>
            "polyXpoly" => Poly * Poly ^-> T<bool>
            "circleXcircle" => Circle * Circle ^-> T<bool>
            "polyXcircle" => Poly * Circle ^-> T<bool>
        ]
        
    

    let Assembly =
        Assembly [
            Namespace "IIOEngine" [
                Vec
                Obj
                Shape
                Rect
                Circle
                Poly
                SimpleRect
                XShape
                Line
                MultiLine
                Grid
                Text
            ]
//            Namespace "IntelliFactory.WebSharper.IIOEngine.Resources" [
//                Res.IIOAPI
//            ]
        ]

module Main =
    open IntelliFactory.WebSharper.InterfaceGenerator

    do Compiler.Compile stdout Definition.Assembly
