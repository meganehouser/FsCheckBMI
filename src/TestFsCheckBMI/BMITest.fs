namespace TestFsCheckBMI

open FsCheck
open FsCheck.NUnit
open NUnit.Framework
open FsCheckBMI

[<TestFixture>]
type ``BMI算出のテスト``()=
    [<Test>]
    member this.``BMI値は体重より小さい``() =
        fsCheck (fun (h:int) (w:int) -> 
            BMI.Compute(h, w) <= (float w)
            )
            //==> (h > 0))

//    [<Test>]
//    member this.``BMI値の正負は体重の正負と等しい``() =
//        fsCheck (fun (h:int) (w:int) -> (w > 0) = (BMI.Compute(h, w) > 0.0))
