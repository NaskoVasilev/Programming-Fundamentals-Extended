using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            string namePattern = @"(\[\w[\w\s-]+\w\])";
            string lyricPattern= "(\"[\\w\\s]+\")";
            string lengthPattern = @"(\d+:\d{2}m|\d+s)";
            List<string> songs = new List<string>();
            string name = null;
            string lyric = null;
            string length = null;
            bool nameIsReady = false;
            bool lyricIsReady = false;
            bool lengthIsReady = false;
            string command = Console.ReadLine();
            while(command!= "Rock on!")
            {
                if(Regex.IsMatch(command,namePattern))
                {
                    nameIsReady = true;
                    name = Regex.Match(command, namePattern).Value;
                    name = name.Substring(1, name.Length - 2);
                }
                if (Regex.IsMatch(command, lyricPattern))
                {
                    lyricIsReady = true;
                    lyric = Regex.Match(command,lyricPattern ).Value;
                    lyric = lyric.Substring(1, lyric.Length - 2);
                }
                if (Regex.IsMatch(command, lengthPattern))
                {
                    lengthIsReady = true;
                    length = Regex.Match(command, lengthPattern).Value;
                    length = length.Substring(0, length.Length - 1);
                    if(!length.Contains(":"))
                    {
                        int time = int.Parse(length);
                        int min = time / 60;
                        int secs = time % 60;
                        length = $"{min:d2}:{secs:d2}";
                    }
                }
                if(lyricIsReady==true && nameIsReady==true && lengthIsReady==true)
                {
                    string song = $"{name} -> {length} => {lyric}";
                    songs.Add(song);
                    lyricIsReady = false;
                    nameIsReady = false;
                    lengthIsReady = false;
                }
                if(songs.Count>=4)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            foreach(var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
