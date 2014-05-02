namespace TestFsCheckBMI

open FsCheck
open FsCheck.NUnit
open NUnit.Framework
open FsCheckBMI

[<TestFixture>]
type ``検証機能のexample-based test``() = 
    [<Test>]
    member this.``数字以外の文字列はfalseを返す`` () =
        let validator = new Validator()
        Assert.That(validator.IsValid("ABC"), Is.False)
        Assert.That(validator.IsValid("1A2"), Is.False)

    [<Test>]
    member this.``数字4桁以上はfalseを返す`` () =
        let validator = new Validator()
        Assert.That(validator.IsValid("1000"), Is.False)
        Assert.That(validator.IsValid("10000"), Is.False)

    [<Test>]
    member this.``数字3桁以下はtrueを返す`` () =
        let validator = new Validator()
        Assert.That(validator.IsValid("9"), Is.True)
        Assert.That(validator.IsValid("99"), Is.True)
        Assert.That(validator.IsValid("999"), Is.True)


[<TestFixture>]
type ``検証機能のproperty-based test``() =
    [<Test>]
    member this.``数字3桁以下の場合はtrueを返す`` () =
        let validator = new Validator()
        fsCheck (fun (i:int32) -> validator.IsValid(i.ToString())
                                  ==> (i <= 999))
                                 
    [<Test>]
    member this.``数字4桁以上の場合はfalseを返す``() =
        let validator = new Validator()
        let gen = Gen.choose(1000, 999999) |> Arb.fromGen
        fsCheck (fun _ -> Prop.forAll gen (fun (i:int) -> (validator.IsValid(i.ToString()) = false)))
                                            
    [<Test>]
    member this.``数字以外の文字列を含む場合はfalseを返す`` () =
        let validator = new Validator()
        let numbers = [0 .. 9] |> List.map(fun i -> i.ToString())
        let isNumber (c:char) = List.exists(fun no -> no = (string c)) numbers
        fsCheck (fun s -> validator.IsValid(s) = false
                          ==> (s.Length = 0 || not (String.forall(fun c -> isNumber c) s)))

