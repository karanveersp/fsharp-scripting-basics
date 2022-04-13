# F# Scripting Basics

F# scripts are defined as `.fsx` files


```fs
// Strings.fsx

let toUpper (s: string) = s.ToUpper()
let toLower (s: string) = s.ToLower()
let replace (old: string) (newVal: string) (s: string) = s.Replace(old, newVal)

module StringBuilder =
    open System.Text
    let init() = new StringBuilder()
    let initWith(s: string) = new StringBuilder(s)
    let append (s: string) (sb: StringBuilder) = sb.Append(s)
```

```fs
// print-name.fsx

#load "Strings.fsx" // evaluates the given script
                    // defining the module containing
                    // symbols.
open Strings        // opens the module.

let name =
    "Devon"
    |> StringBuilder.initWith
    |> StringBuilder.append " Burriss"
    |> string
    |> toUpper

printfn "Name: %s" name
```

Execute the script with `dotnet fsi print-name.fsx`

--- 

## Load Nuget packages with `#r`

Also used to reference dotnet assemblies (`.dll`).

```fs
// json-conversions.fsx

#r "nuget: Newtonsoft.Json"
open Newtonsoft.Json

// anonymous record
let data =
    {| Name = "Don Syme"
       Occupation = "F# Creator" |}

let serialized = JsonConvert.SerializeObject(data)

printfn "Anonymous record serialized as json:\n%s" serialized

let deserialized =
    JsonConvert.DeserializeObject("{\"Name\":\"Don Syme\",\"Occupation\":\"F# Creator\"}")

printfn "Deserialized object:\n%O" deserialized
```

---

## Load remote & local packages with `#i`

```fs
#i "nuget: https://my-remote-package-source/index.json"
#i """nuget: C:\path\to\local\source"""
```

---

## CLI Args

```fs
// cli-args.fsx

let args = fsi.CommandLineArgs

for arg in args do
    printfn $"{arg}"
```

```shell
dotnet fsi cli-args.fsx 1 2 "three"
> cli-args.fsx
> 1
> 2
> three
```

---

## Relative paths in scripts

Absolute paths can be written with `@"..."` strings to ignore escape characters.

Use the built-in constants to refer to the running script's location.

```fs
__SOURCE_DIRECTORY__
__SOURCE_FILE__

let path = System.IO.Path.Combine(__SOURCE_DIRECTORY__, __SOURCE_FILE__)
```

---

## Adding a directory to library include path

Add a directory containing `.dll` or `.fsx` files to the _library include path_ to allow referencing the modules using their namespace/module names without the os path.

Directory structure:
```
project/
    lib/
        UtilFunctions.dll
        ScriptConstants.fsx
    src/
        App.fsx
```

```fs
// App.fsx
let pathToLib = 
    System.IO.Path.Combine(__SOURCE_DIRECTORY__, 
                           "..", "lib")
#I pathToLib  // gets added to search list
#r "UtilFunctions.dll"
#load "ScriptConstants.fsx"

// app logic...
```

--- 


## Notes

- The `open Script` declaration is required when a .fsx script is loaded with `#load`.
Constructs in an F# script are compiled into a top-level module
that is the name of the containing script file.

    If `script.fsx` is your script file, then the _implied module name_ will be `Script`, which is accessed with `open Script`.

    If there's a top-level module declaration in `script.fsx` then that is the module name to use when opening it.

- The first element of `fsi.CommandLineArgs` is the script name itself.

## References

- https://devonburriss.me/fsharp-scripting/
- https://brandewinder.com/2016/02/06/10-fsharp-scripting-tips/
- https://docs.microsoft.com/en-us/dotnet/fsharp/tools/fsharp-interactive/#scripting-with-f