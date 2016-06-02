#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.iioEngine")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)
        .References(fun r -> [r.Assembly "System.Web"])

let main =
    bt.Zafir.Extension("WebSharper.iioEngine")
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
                    Id = "Zafir.iioEngine"
//                    LicenseUrl = Some "http://github.com/intellifactory/websharper.iioengine/blob/master/LICENSE.md"
//                    RequiresLicenseAcceptance = true
                    Title = Some "Zafir.iioEngine (1.2.2)"
            })
        .Add(main)

]
|> bt.Dispatch
