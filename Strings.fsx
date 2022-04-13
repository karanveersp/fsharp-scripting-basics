let toUpper (s: string) = s.ToUpper()
let toLower (s: string) = s.ToLower()
let replace (old: string) (newVal: string) (s: string) = s.Replace(old, newVal)

module StringBuilder =
    open System.Text
    let init() = new StringBuilder()
    let initWith(s: string) = new StringBuilder(s)
    let append (s: string) (sb: StringBuilder) = sb.Append(s)
