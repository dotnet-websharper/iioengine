#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("WebSharper.iioEngine")
        .VersionFrom("WebSharper")
        .WithFramework(fun fw -> fw.Net40)
        .References(fun r -> [r.Assembly "System.Web"])

let main =
    bt.WebSharper.Extension("Box2D_iioEngine")
        .SourcesFromProject()
        .Embed(["iioEngine-1.2.2.min.js"; "Box2dWeb-2.1.a.3.min.js"])

bt.Solution [
    main

    bt.NuGet.CreatePackage()
        .Description("WebSharper bindings to iio Engine (http://iioengine.com/) version 1.2.2")
        .ProjectUrl("http://github.com/intellifactory/websharper.iioengine")
        .Configure(fun c ->
            {
                c with
                    Authors = ["IntelliFactory"]
                    Id = "WebSharper.iioEngine"
//                    LicenseUrl = Some "http://github.com/intellifactory/websharper.iioengine/blob/master/LICENSE.md"
//                    RequiresLicenseAcceptance = true
                    Title = Some "WebSharper.iioEngine (1.2.2)"
            })
        .Add(main)

]
|> bt.Dispatch
