using System;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;

using System.Reflection;
[assembly: AssemblyTitle("text2speech")]
[assembly: AssemblyDescription("says the text")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("rostok - https://github.com/rostok/")]
[assembly: AssemblyProduct("text2speech")]
[assembly: AssemblyCopyright("Copyright © 2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

class text2speech
{
    static public SpeechSynthesizer synth;

    static void Help()
    {
        Console.WriteLine("text2speech [options] [text]");
        Console.WriteLine("options:");
        Console.WriteLine(" -h --help -?    : show this help");
        Console.WriteLine(" -l              : list installed voices");
        Console.WriteLine(" -v name         : choose alternative voice by partial name match");
    }

    static void Voices(string chosenVoice="")
    {
        if (chosenVoice=="") Console.WriteLine("Installed voices:");
        foreach (InstalledVoice voice in synth.GetInstalledVoices())
        {
            VoiceInfo info = voice.VoiceInfo;
            string AudioFormats = "";
            foreach (SpeechAudioFormatInfo fmt in info.SupportedAudioFormats) AudioFormats += $"{fmt.EncodingFormat.ToString()}\n";
            if (chosenVoice=="") {
                Console.WriteLine(" Name:          " + info.Name);
                Console.WriteLine(" Culture:       " + info.Culture?.ToString());
                Console.WriteLine(" Age:           " + info.Age.ToString());
                Console.WriteLine(" Gender:        " + info.Gender.ToString());
                Console.WriteLine(" Description:   " + info.Description);
                Console.WriteLine(" ID:            " + info.Id);
                Console.WriteLine(" Enabled:       " + voice.Enabled.ToString());
                Console.WriteLine(" Audio formats: " + (info.SupportedAudioFormats.Count != 0 ? AudioFormats : "No supported audio formats found"));
            }
            // string AdditionalInfo = "";
            // foreach (string key in info.AdditionalInfo.Keys)
            // {
            //     AdditionalInfo += $"  {key}: {info.AdditionalInfo[key]}\n";
            // }
            // Console.WriteLine(" Additional Info - " + AdditionalInfo);

            if (chosenVoice!="" && info.Name.ToLower().Contains(chosenVoice.ToLower())) {
                synth.SelectVoice(info.Name);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        if (args.ToList().FirstOrDefault()=="-h"||args.ToList().FirstOrDefault()=="--help"||args.ToList().FirstOrDefault()=="-?"||args.ToList().FirstOrDefault()=="/?") {
            Help();
            Environment.Exit(0);
        }

        synth = new SpeechSynthesizer();
        if (args.Length>0)
        if (args.ToList().FirstOrDefault()=="-l") {
            Voices();
            Environment.Exit(0);
        }

        if (args.ToList().FirstOrDefault()=="-v") {
            Voices(args.ToList().Skip(1).First());
            args = args.ToList().Skip(2).ToArray();
        }

        synth.SetOutputToDefaultAudioDevice();

        string text = string.Join(" ", args).Trim();
        if (text!="") {
            synth.Speak(text);
        }
        else {
            while ( (text = Console.ReadLine()) != null ) {
                synth.Speak(text);
            }
        }
    }
}
