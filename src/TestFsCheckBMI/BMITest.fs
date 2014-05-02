namespace TestFsCheckBMI

open FsCheck
open FsCheck.NUnit
open NUnit.Framework
open FsCheckBMI

[<TestFixture>]
type ``BMI算出のテスト``()=
    [<Test>]
    member this.``BMI値の正負は体重の正負と等しい``() =
        BMI.Compute(0, 10) |> ignore
        fsCheck (fun (h:int) (w:int) -> (w > 0) = (BMI.Compute(h, w) > 0.0))
