module IIOEngine.Extensions

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.InterfaceGenerator
open IIOEngine.Abstracts
open IIOEngine.Definition

let Canvas2DContext = Type.New()

//Graphics Engine!
let Img =
    Class "Img"
    |+> Protocol [
        //image propterties
        "pos" =@ Vec
        "size" =@ Vec
        "scale" =@ T<float>
        "rotation" =@ T<float>
    ]
//Shape Extensions
let ShapeExtensions =
    Protocol [
        "clearSelf" => Canvas2DContext ^-> T<unit>   
        "setFillStyle" => T<float> + T<float> + T<float> ^-> T<unit>
        "addImage" => T<obj> ^-> T<unit>
        "addImage" => T<string> * (T<obj> ^-> T<unit>) ^-> T<unit>
        "flipImage" => T<bool> ^-> T<unit>
        "setImgOffset" => Vec ^-> T<unit>
        "setImgOffset" => T<float> * T<float> ^-> T<unit>
        "setImgSize" => Vec ^-> T<unit>
        "setImgSize" => T<float>* T<float> ^-> T<unit>
        "setImgScale" => T<float> ^-> T<unit>
        "setImgRotation" => T<float> ^-> T<unit>
        "addAnim" => T<obj[]> ^-> T<unit>
        "addAnim" => T<obj> * T<string> ^-> T<unit>
        "addAnim" => T<obj[]> * (T<obj> ^-> T<unit>) ^-> T<unit>
        "setAnim" => T<string> * T<float> * T<obj> ^-> T<unit>
        "setAnim" => T<float> * T<float> * T<obj> ^-> T<unit>
        "setAnim" => T<string> * T<obj> ^-> T<unit>
        "setAnim" => T<float> * T<obj> ^-> T<unit>
        "setAnimKey" => T<float> ^-> T<unit>
        "setAnimFrame" => T<float> ^-> T<unit>
        "nextAnimFrame" => T<unit> ^-> T<unit>
        "playAnim" => T<float> * AppManager * T<float> ^-> T<unit>
        "playAnim" => T<string> * T<float> * AppManager * T<float> ^-> T<unit>
        "playAnim" => T<float> * T<float> * AppManager * T<float> ^-> T<unit>
        "stopAnim" => T<string> * T<obj> ^-> T<unit>
        "stopAnim" => T<float> * T<obj> ^-> T<unit>
    ]
//Obj Extensions
let ObjExtensions =
    Protocol [
        //primary functions
        "draw" => Canvas2DContext ^-> T<unit>
        //style functions
        "setAlpha" => T<float> ^-> T<unit>
        "setStrokeStyle" => T<float> + T<float> + T<float> ^-> T<unit>
        "setLineWidth" => T<float> ^-> T<unit>
        "setFillStyle" => T<float> + T<float> + T<float> ^-> T<unit>
        "setShadow" => T<string> * Vec * T<float> ^-> T<unit>
        "setShadow" => T<string> * T<float> * T<float> * T<float> ^-> T<unit>
        "setShadowColor" => T<string> ^-> T<unit>
        "setShadowOffset" => Vec ^-> T<unit>
        "setShadowOffset" => T<float> * T<float> ^-> T<unit>
        "setShadowBlur" => T<float> ^-> T<unit>
        "drawReferenceLine" => T<bool> ^-> T<unit>
        //effest functions
        "fade" => T<float> * T<float> ^-> T<unit>
        "fadeIn" => T<float> * T<float>
        "fadeOut" => T<float> * T<float>
        //image functions               
        "createWithImage" => T<obj> ^-> T<unit>
        "createWithImage" => T<string> * (T<obj> ^-> T<unit>) ^-> T<unit>          
        "setPolyDraw" => T<bool> ^-> T<unit>
        //anim functions
        "createWithAnim" => T<obj[]> ^-> T<unit>
        "createWithAnim" => T<obj[]> * (T<obj> ^-> T<unit>) * T<float> ^-> T<unit>
        "createWithAnim" => T<obj> * T<string> * T<float> ^-> T<unit>
        
    ]
let fxFade =
    Class "fxFade"
    |+> Protocol [
        //effects properties
        "rate" =@ T<float>
        "alpha" =@ T<float>
    ]
let ObjExtClass =
    Class "ObjExtClass"
    |+> Protocol [
        //style properties
        "alpha" =@ T<float>
        "strokeStyle" =@ T<float> + T<float> + T<float>
        "lineWidth" =@ T<float>
        "fillStyle" =@ T<float> + T<float> + T<float>
        "shadowColor" =@ T<string>
        "shadowBlur" =@ T<float>
        "shadowOffset" =@ Vec
        "refLine" =@ Obj
        //anim properties
        "anims" =@ T<obj[]>
        "animKey" =@ T<float>
        "animFrame" =@ T<float>
    ]
let SpriteMap =
    let self = Type.New()
    Class "SpriteMap"
    |=> self
    |+> Protocol [
        "getSprite" => T<float> * T<float> ^-> T<obj>
        "getSprite" => T<float> ^-> T<obj>
        "setSpriteRes" => Vec ^-> T<unit>
        "setSpriteRes" => T<float> * T<float> ^-> T<unit>
    ]
    |+> [
            Constructor <| T<obj> * T<float> * T<float>
            Constructor <| T<string> * T<float> * T<float> * (T<obj> ^-> T<unit>) * T<obj>
            Constructor <| T<string> * (T<obj> ^-> T<unit>) * T<obj>
    ]
let Sprite =
    let self = Type.New()
    Class "Sprite"
    |=> self
    |+> Protocol [
        "frames" =@ T<obj[]>
        "addFrame   " => T<float> * T<float> * T<float> * T<float> ^-> T<unit>
    ]
    |+> [
            Constructor <| T<obj>
    ]
//grapichs engine end
//kinematics start

let KinematicsBound =
    Class "KinematicsBound"
    |+> Protocol [
        "val" =@ T<float>  
        "callback" =@ T<obj> ^-> T<unit>
    ]
let KinematicsBounds =
    Class "KinematicsBounds"
    |+> Protocol [
        "top" =@ KinematicsBound
        "right" =@ KinematicsBound 
        "left" =@ KinematicsBound 
        "bottom" =@ KinematicsBound
        "callback" =@ T<obj> ^-> T<unit>
    ]
let Kinematics =
    Protocol [
        //functions
        "vel" =@ Vec
        "acc" =@ Vec
        "torque" =@ T<float>
        "bounds" =@ KinematicsBounds
        "enableKinematics" => T<unit> ^-> T<unit>
        "update" => T<unit> ^-> T<unit>
        "setVel" => Vec ^-> T<unit>
        "setVel" => T<float> * T<float> ^-> T<unit>
        "setAcc" => Vec ^-> T<unit>
        "setAcc" => T<float> * T<float> ^-> T<unit>
        "setTorque" => T<float> ^-> T<unit>
        "setBound" => T<string> * T<float> * (T<obj> ^-> T<unit>) ^-> T<unit>
        "setBounds" => T<float> * T<float> * T<float> * T<float> * (T<obj> ^-> T<unit>) ^-> T<unit>
    ]
