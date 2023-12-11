﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Playerr
{
    public class Song
    {
        public string Title { get; set; }
        public string FilePath { get; set; }

        public Song(string title, string filePath)
        {
            Title = title;
            FilePath = filePath;
        }
    }
}