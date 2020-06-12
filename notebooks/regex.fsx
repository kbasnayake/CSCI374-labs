// +
namespace CSCI374
    
module RegularExpressions =
    
    open System.Text.RegularExpressions // Load regular expression namespace (library)

     let tester input test results =
        let rx = Regex(input, RegexOptions.Compiled ||| RegexOptions.Multiline)
        let ms = rx.Matches(test)
        //printfn "%A" ms
        let found = List.map (fun e -> seq{ for m in ms -> m.Value = e} |> Seq.fold (||) false ) results
        if found |> Seq.fold (&&) (ms.Count>0)
        then "OK"
        else "Wrong"

    let match01 input =
        tester input "The the quick brown Fox Fox jumps over the lazy dog dog." ["Fox"; "dog"]

    let match02 input =
        tester input "The the.quick brown Fox fox.jumps over.the lazy Dog dog." ["fox.ju"; "ver.th"; "the.qu"]

    let match03 input =
        tester input "The the quick brown Fox fox jumps over the lazy Dog dog." ["Fox"; "dog"; "The"; "jumps"]

    let match04 input =
        tester input "aab_cbABC aab__cbABC Aab__cbABc" ["bAB"]

    let match05 input =
        tester input "22x0. 1103, 20000 30sA. 31030" ["22x0."; "30sA."; "1103,"]

    let match06 input =
        tester input """The quick brown fox jumps over the lazy dog.
                        The quick brown fox jumps over the lazy dog. 
                        The quick brown fox jumps over the lazy dog 
                     """ ["dog."]

    let match07 input =
        tester input "The the quick brown fox fox jumps over the lazy dog dog." ["jumps"; "brown"]

    let match08 input =
        tester input "11A 123aA 1A 123AA 1hjAA" ["11A"; "123aA"; "123AA"]

    let match09 input =
        tester input "The quick quick brown fox jumps over the lazy dog dog." ["quick quick"]

    let match10 input =
        tester input "Mr.Dow Ms.Black Dr.Smith_sd Ds.Smith Mrs. White Mrs.White Er.Gray" ["Mr.Dow"; "Ms.Black"; "Dr.Smith"; "Mrs.White"; "Er.Gray"]
        
    let match11 input =
        tester input """
                        129-129-11310
                        129-129-1031
                        129-129-103
                        129-12-1031
                        12-129-1031
                    """ ["129-12-1031"]
                    
    let match12 input =
        tester input """
                        <i> This is a paragraph</i>
                        < b > This is a paragraph </b >
                        < p ></ p >
                        < z />
                        < p />
                        < a href="abc.com"> </ a>
                    """ ["<i>"; "</i>"; "< b >"; "</b >"; "< p >"; "</ p >"; "< p />"; "< a href=\"abc.com\">"; "</ a>"]

