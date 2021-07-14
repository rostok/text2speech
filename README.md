# text2speech
a simple command line tool converting text to speech using microsoft build-in speech synthesizer

# building
use standard `dotnet build`
alternatively, if you really like small exes, run `custom-single-exe-build.bat`. you may however edit filepaths to System.Speech.dll

# usage
this help should explain everything
```
text2speech [options] [text]                                                   
options:                                                                     
 -h --help -?    : show this help                                            
 -l              : list installed voices                                     
 -v name         : choose alternative voice by partial name match            
```
providing no text in command line will read line after line from standard input. use ^Z or ^C to end this.

if you will redirect text from files remember to match file code-page with console with `chcp` command.