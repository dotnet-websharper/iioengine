module IIO_Extensions

open IntelliFactory.WebSharper.Dom
open IntelliFactory.WebSharper.Html.Default
open IntelliFactory.WebSharper.InterfaceGenerator
open IIO_Abstracts
open IIO_Definition

let Canvas2DContext = Type.New()

//Graphics Engine!
let IioImg =
    Interface "IioImg"
    |+> [
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
        "addImage" => T<Element>?img ^-> T<unit>
        "addImage" => T<string>?src * !?(T<obj> ^-> T<unit>)?onloadCallback ^-> T<unit>
        "flipImage" => T<bool>?yes ^-> T<unit>
        "setImgOffset" => Vec?offset ^-> T<unit>
        "setImgOffset" => T<float>?offsetX * T<float>?offsetY ^-> T<unit>
        "setImgSize" => Vec?size ^-> T<unit>
        "setImgSize" => T<float>?width * T<float>?height ^-> T<unit>
        "setImgScale" => T<float>?scale ^-> T<unit>
        "setImgRotation" => T<float>?rotation ^-> T<unit>
        "addAnim" => T<obj[]>?imgs ^-> T<unit>
        "addAnim" => T<obj>?sprite * T<string>?tag ^-> T<unit>
        "addAnim" => T<obj[]>?imgSrcs * (T<obj> ^-> T<unit>)?onloadCallback ^-> T<unit>
        "setAnim" => T<string>?tag * T<float>?frame * T<obj>?ctx ^-> T<unit>
        "setAnim" => T<float>?key * T<float>?frame * T<obj>?ctx ^-> T<unit>
        "setAnim" => T<string>?tag * T<obj>?ctx ^-> T<unit>
        "setAnim" => T<float>?key * T<obj>?ctx ^-> T<unit>
        "setAnimKey" => T<float>?frame ^-> T<unit>
        "setAnimFrame" => T<float>?frame ^-> T<unit>
        "nextAnimFrame" => T<unit> ^-> T<unit>
        "playAnim" => T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "playAnim" => T<string>?tag * T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "playAnim" => T<float>?tag * T<float>?fps * AppManager?io * T<int>?canvasId ^-> T<unit>
        "stopAnim" => T<string>?tag * T<obj>?ctx ^-> T<unit>
        "stopAnim" => T<float>?tag * T<obj>?ctx ^-> T<unit>
    ]
//Obj Extensions
let ObjExtensions =
    Protocol [
        //primary functions
        "draw" => Canvas2DContext ^-> T<unit>
        //style functions
        "setAlpha" => T<float>?alpha ^-> T<unit>
        "setStrokeStyle" => (T<string> + T<obj>)?style * !?T<float>?width  ^-> T<unit>
        "setLineWidth" => T<float>?lineWidth ^-> T<unit>
        Generic - fun t -> "setFillStyle" => (T<string> + T<obj>)?style ^-> t
        "setShadow" => T<string>?color * Vec?offset * T<float>?blur ^-> T<unit>
        "setShadow" => T<string>?color * T<float>?offsetX * T<float>?offseY * T<float>?blur ^-> T<unit>
        "setShadowColor" => T<string>?color ^-> T<unit>
        "setShadowOffset" => Vec?offset ^-> T<unit>
        "setShadowOffset" => T<float>?offsetX * T<float>?offsetY ^-> T<unit>
        "setShadowBlur" => T<float>?blur ^-> T<unit>
        "drawReferenceLine" => T<bool>?turnOn ^-> T<unit>
        //effest functions
        "fade" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeIn" => T<float>?rate * T<float>?alpha ^-> T<unit>
        "fadeOut" => T<float>?rate * T<float>?alpha ^-> T<unit>
        //image functions               
        "createWithImage" => T<Element>?img ^-> T<unit>
        "createWithImage" => T<string>?src * (T<obj> ^-> T<unit>)?onloadCallback ^-> T<unit>          
        "setPolyDraw" => T<bool>?turnOn ^-> T<unit>
        //anim functions
        "createWithAnim" => T<obj[]>?imgs ^-> T<unit>
        "createWithAnim" => T<obj[]>?imgSrcs * (T<obj> ^-> T<unit>)?onloadCallback * T<float>?animFrame ^-> T<unit>
        "createWithAnim" => T<obj>?sprite * T<string>?tag * T<float>?animFrame ^-> T<unit>
        //misc
        "setRotationAxis" => T<float> * T<float> ^-> T<unit>
        "shrink" => T<float>?s ^-> T<float>
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
        "getSprite" => T<float>?start * T<float>?``end`` ^-> T<obj>
        "getSprite" => T<float>?row ^-> T<obj>
        "setSpriteRes" => Vec?res ^-> T<unit>
        "setSpriteRes" => T<float>?x * T<float>?y ^-> T<unit>
    ]
    |+> [
            Constructor <| T<obj>?src * T<float>?sprW * T<float>?spwrH ^-> T<unit>
            Constructor <| T<string>?src * T<float>?sprW * T<float>?sprH * (T<obj> ^-> T<unit>)?onloadCallback * T<obj>?callbackParam ^-> T<unit>
            Constructor <| T<string>?src * (T<obj> ^-> T<unit>)?onloadCallback * T<obj>?callbackParam ^-> T<unit>
    ]
let Sprite =
    let self = Type.New()
    Class "Sprite"
    |=> self
    |+> Protocol [
        "frames" =@ T<obj[]>
        "addFrame" => T<float>?x * T<float>?y * T<float>?w * T<float>?h ^-> T<unit>
    ]
    |+> [
            Constructor <| T<obj>?src
    ]
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
        "setVel" => Vec?v ^-> T<unit>
        "setVel" => T<float>?vX * T<float>?vY ^-> T<unit>
        "setAcc" => Vec?v ^-> T<unit>
        "setAcc" => T<float>?vX * T<float>?vY ^-> T<unit>
        "setTorque" => T<float>?t ^-> T<unit>
        "setBound" => T<string>?boundName * T<float>?boundCoordinate * !?(T<obj> ^-> T<unit>)?callback ^-> T<unit>
        "setBounds" => T<float>?top * T<float>?right * T<float>?bottom * T<float>?left * (T<obj> ^-> T<unit>)?callback ^-> T<unit>
    ]
