# libargument
Simple library for parsing command line arguments in .NET.

## Progress
Finished creating first two bullet points on Plans.  
Going to implement the Help-provider in near future.

## Plans
* execute different methods based on selected switches (behave like PowerShell script) (implemented)
* match first action (implemented)
* ~~Autocomplete~~ (this requires a custom written command prompt. Won't do that)
* providing help (work in progress)
* Documentation (work in progress)
* Samples (work in progress)

## Thoughts
```
-- SampleProject --
/switch1
/switch2 /required=value </optional=value, "Default">
/switch3 /list=value1 /list=value2 /list=value3
/switch4
 /parameter="value with whitespace"
 /parameter=value\ with\ escaped\ whitespace
 /parameter="value with escaped \"double quotes\""
```

Escape-sequences  
`\ , \"`

## Types to be implemented
* ~~Switch~~ (done)
* ~~Value~~ done
* ~~Enumeration~~ not implemented
* ~~List~~ done

## Auto-Help
Basic structure of /help-switch:
```
{Application header}
--- skipped with /noheader-switch
Help powered by libargument {Version}.
© 2014 by AliveDevil
https://github.com/alivedevil/libargument
Skip with /noheader
---

{Application description}
Usage
    </requiredSwitch> </requiredValue=type> [/optionalList=list,"DefaultValue"]
    </requiredSwitch> [/optionalValue=type,"DefaultValue"]

Parameters  
requiredSwitch
    Short description of "requiredSwitch"

requiredValue
    Short description of "requiredValue"

optionalList
    Short description of "optionalList"

optionalValue
    Short description of "optionalValue"

Examples
{User provided examples}
```

Structure for "/switch /help"
```
{Application header} - {switchname}
--- skipped with /noheader-switch
Help powered by libargument {Version}.
© 2014 by AliveDevil
https://github.com/alivedevil/libargument
Skip with /noheader
---

{Application description}
{Switch description}
Usage
    </switch> more parameters

Parameters  
switch
    Long description of "switch"

Long Descriptions per parameter

Example
{User provided examples}
```

## Localization
I am able to translate this library to English and German. If you are able to speak any other major language feel free to translate the library.

## License
This project is licensed under GPLv2 (see LICENSE for more information).

If you have suggestions to anything (not) mentioned here feel free to create an issue for it.
