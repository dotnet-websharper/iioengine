namespace IIOEngine

module Something =

    open IntelliFactory.WebSharper
    open IntelliFactory.WebSharper.InterfaceGenerator
    open IIOEngine.Abstracts
    open IIOEngine.Definition
    open IIOEngine.Extensions

    let Assembly =
        Assembly [
            Namespace "IIOEngine" [
                Vec
                Obj |+> ObjExtensions 
                Shape |+> ShapeExtensions
                Circle   
                Poly 
                Rect 
                SimpleRect 
                XShape 
                Line 
                MultiLine  
                Grid
                Text 
            ]
       ]

module Main =
    open IntelliFactory.WebSharper.InterfaceGenerator

    do Compiler.Compile stdout Something.Assembly
