#r "nuget: Serilog"
#r "nuget: Serilog.Sinks.Console"
#r "nuget: Serilog.Sinks.File"

open Serilog

let getTimestamp (dateOnly: bool) : string =
    if dateOnly then
        System.DateTime.Now.ToString("MMddyyyy")
    else
        System.DateTime.Now.ToString("MMddyyyy_HHmmss")


let getFileLogger (dirpath: string) (fileName: string) =
    let filepath =
        let name =
            if fileName.Contains(".") then
                fileName // if extension included, then no addition of timestamp.
            else
                sprintf "%s_%s.log" fileName (getTimestamp false)

        System.IO.Path.Combine(dirpath, name)

    (new LoggerConfiguration())
        .MinimumLevel.Debug()
        .WriteTo.File(filepath)
        .WriteTo.Console()
        .CreateLogger()

let getConsoleLogger () =
    (new LoggerConfiguration())
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger()

let getNullLogger () =
    (new LoggerConfiguration()).CreateLogger()
