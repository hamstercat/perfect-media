﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Sources
{
    public interface ISourceProvider
    {
        ISourceManagerViewModel Sources { get; }
    }
}