let printSourceLocation () =
    printfn "Line: %s" __LINE__
    printfn "Source Directory: %s" __SOURCE_DIRECTORY__
    printfn "Source File: %s" __SOURCE_FILE__
    printfn "Source Path: %s" (sprintf "%s\\%s" __SOURCE_DIRECTORY__ __SOURCE_FILE__)

printSourceLocation ()
