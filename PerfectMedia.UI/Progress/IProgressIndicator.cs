﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectMedia.UI.Progress
{
    public interface IProgressIndicator
    {
        void Show(IProgressManagerViewModel progressManagerViewModel);
    }
}