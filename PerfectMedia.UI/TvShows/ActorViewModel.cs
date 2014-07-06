﻿using PerfectMedia.UI.Images;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerfectMedia.UI.TvShows
{
    [ImplementPropertyChanged]
    public class ActorViewModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string ThumbUrl { get; set; }
        public ImageViewModel ThumbPath { get; private set; }

        public ActorViewModel(IFileSystemService fileSystemService)
        {
            ThumbPath = new ImageViewModel(fileSystemService);
        }
    }
}
