module IIOEngine.Abstracts

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.InterfaceGenerator
    
//Abstracts
let Vec =
    let self = Type.New()
    Class "Vec"
    |=> self
    |+> Protocol [
        "x" =@ T<float>
        "y" =@ T<float>
        "clone" => T<unit> ^-> self
        "toString" => T<unit> ^-> T<string>
        "length" => T<unit> ^-> T<float>
        "normalize" => T<unit> ^-> T<unit>
        "set" => self ^-> self
        "set" => T<float> * T<float> ^-> self
        "add" => self ^-> self
        "add" => T<float> * T<float> ^-> self
        "sub" => self ^-> self
        "sub" => T<float> * T<float> ^-> self
        "mult" => T<float> ^-> T<float>
        "div" => T<float> ^-> T<float>
        "dot" => self ^-> T<float>
        "dot" => T<float> * T<float> ^-> self
        "distance" => self ^-> T<float>
        "distance" => T<float> * T<float> ^-> self
        "lerp" => self ^-> self
        "lerp" => T<float> * T<float> ^-> self
    ]
    //static functions
    |+> [
            Constructor <| self
            Constructor <| T<float> * T<float>
            "tostring" => self ^-> T<string>
            "tostring" => T<float> * T<float> ^-> T<string>
            "length" => self ^-> T<float>
            "length" => T<float> * T<float> ^-> T<float>
            "normalize" => self ^-> T<float>
            "normalize" => T<float> * T<float> ^-> T<float>
            "add" => self * self ^-> self
            "add" => self * T<float> * T<float> ^-> self
            "add" => T<float> * T<float> * self ^-> self
            "add" => T<float> * T<float> * T<float> * T<float> ^-> self
            "sub" => self * self ^-> self
            "sub" => self * T<float> * T<float> ^-> self 
            "sub" => T<float> * T<float> * self ^-> self
            "sub" => T<float> * T<float> * T<float> * T<float> ^-> self
            "mult" => self * T<float> ^-> self
            "mult" => T<float> * T<float> * T<float> ^-> self
            "div" => self * T<float> ^-> self
            "div" => T<float> * T<float> * T<float> ^-> self
            "dot" => self * self ^-> T<float>
            "dot" => self * T<float> * T<float> ^-> T<float>
            "dot" => T<float> * T<float> * self ^-> T<float>
            "dot" => T<float> * T<float> * T<float> * T<float> ^-> T<float>
            "distance" => self * self ^-> T<float>
            "distance" => self * T<float> * T<float> ^-> T<float>
            "distance" => T<float> * T<float> * self ^-> T<float>
            "distance" => T<float> * T<float> * T<float> * T<float> ^-> T<float>
            "lerp" => self * self * T<float> ^-> self
            "lerp" => self * T<float> * T<float> * T<float> ^-> self
            "lerp" => T<float> * T<float> * self * T<float> ^-> self
            "lerp" => T<float> * T<float> * T<float> * T<float> * T<float> ^-> self
    ]
let Obj =
    let self = Type.New()
    Class "Obj"
    |=> self
    |+> Protocol [
        "pos" =@ Vec
        "rotation" =@ T<float>
        "clone" => T<unit> ^-> self
        "setPos" => Vec ^-> self
        "setPos" => T<float> * T<float> ^-> self
        "translate" => Vec ^-> self
        "translate" => T<float> * T<float> ^-> self
        "rotate" => T<float> ^-> self
        "enableUpdates" => ((T<obj> ^-> T<unit>) * T<obj[]>) ^-> self
    ]
    |+> [
        Constructor <| Vec
        Constructor <| T<float> * T<float>
    ]
    //|+>ObjExtensions 
let Shape =
    Class "Shape"
    |=> Inherits Obj
    |+> Protocol [
        //nothing comes here
    ]
    