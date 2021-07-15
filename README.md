# text2speech
a simple command line tool converting text to speech using microsoft built-in speech synthesizer

# building
use standard `dotnet build`
alternatively, if you really like small exes, run `custom-single-exe-build.bat`. you may however have to find and edit filepaths to System.Speech.dll

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

if you want to redirect text from files, remember to match the file's code-page with the console using `chcp` command.