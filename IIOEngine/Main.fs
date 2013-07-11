namespace IIOEngine

module Something =

    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.InterfaceGenerator
    open IIOEngine.Abstracts
    open IIOEngine.Definition
    open IIOEngine.Extensions

    let Assembly =
        Assembly [
            Namespace "IntelliFactory.WebSharper.IIOEngine" [
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
                Iio
            ]
       ]

module Main =
    open IntelliFactory.WebSharper.InterfaceGenerator

    do Compiler.Compile stdout Something.Assembly
