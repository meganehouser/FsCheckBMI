namespace TestFsCheckBMI

open NUnit.Framework
open FsCheck
open FsCheck.NUnit

[<TestFixture>]
///<summary>
/// from https://github.com/fsharp/FsCheck/blob/master/Docs/Documentation.md
///</summary>
type ``典型的なテスト``()=
    [<Test>]
    member this.``リストの逆順の逆順は元のリストに等しい`` () =
        let revRevIsOrig (xs:list<int>) = List.rev(List.rev xs) = xs
        fsCheck revRevIsOrig
