namespace TestFsCheckBMI

open NUnit.Framework
open FsCheck

[<TestFixture>]
/// <summary>
/// http://fsharpforfunandprofit.com/posts/low-risk-ways-to-use-fsharp-at-work-3/
/// </summary>
type ``テストデータ作成例`` ()=
    [<Test>]
    member this.``メールアドレスを作成する``() =
        let userGen = Gen.elements ["a"; "b"; "c"; "d"; "e"; "f"]
        let domainGen = Gen.elements ["gmail.com"; "example.com"; "outlook.com"]
        let makeEmail u d = sprintf "%s@%s" u d

        Gen.map2 makeEmail userGen domainGen
        |> Gen.sample 0 5 |> List.iter(fun data -> printfn "%s" data)

    [<Test>]
    member this.``郵便番号を作成する``() =
        let n1Gen = Gen.choose(0, 999)
        let n2Gen = Gen.choose(0, 9999)
        let makePostalNo n1 n2 = sprintf "%03i-%04i" n1 n2

        Gen.map2 makePostalNo n1Gen n2Gen
        |> Gen.sample 0 5 |> List.iter(fun data -> printfn "%s" data)
