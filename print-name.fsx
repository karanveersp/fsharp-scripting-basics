#load "Strings.fsx" // evaluates the given script
open Strings // open NameOfFileWithoutExtension to import file

let name =
    "Devon"
    |> StringBuilder.initWith
    |> StringBuilder.append " Burriss"
    |> string
    |> toUpper

printfn "Name: %s" name
