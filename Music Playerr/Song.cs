using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playerr
{
    public class Song
    {
        public string FilePath { get; set; }
        public string Title { get; set; }

        //public Song(string title, string filePath)
        //{
        //    Title = title;
        //    FilePath = filePath;
        //}

        public Song(string filePath, string title)
        {
            Title = title;
            FilePath = filePath;
        }
    }

   
}
