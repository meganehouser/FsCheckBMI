﻿module FsCheck.NUnit

open FsCheck
open NUnit.Framework

let private nUnitRunner =
    { new IRunner with
        member x.OnStartFixture t = ()
        member x.OnArguments(ntest, args, every) = ()
        member x.OnShrink(args, everyShrink) = ()
        member x.OnFinished(name, result) = 
            match result with 
            | TestResult.True data -> printfn "%s" (Runner.onFinishedToString name result)
            | _ -> Assert.Fail(Runner.onFinishedToString name result) }
   
let private nUnitConfig = 
    { Config.Default 
        with Runner = nUnitRunner; EndSize = 999}

let fsCheck testable =
    //FsCheck.Check.Verbose testable
    FsCheck.Check.One ("", nUnitConfig, testable)
