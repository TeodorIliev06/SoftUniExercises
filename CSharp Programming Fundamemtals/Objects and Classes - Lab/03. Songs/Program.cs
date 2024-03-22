using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());
            List<Song> playlist = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                string[] token = Console.ReadLine().Split('_');
                string type = token[0];
                string name = token[1];
                string time = token[2];
                playlist.Add(new Song(type, name, time));
            }

            string filter = Console.ReadLine();
            List<Song> filteredSong = playlist
                .Where(s => s.TypeList == filter)
                .ToList();

            if (filter == "all")
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.Name);
                }
                return;
            }

            Console.WriteLine(string.Join(Environment.NewLine, filteredSong
                .Select(song => song.Name)));
        }
    }

    public class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}