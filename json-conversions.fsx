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
