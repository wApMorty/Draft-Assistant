﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draft_Assistant
{
    class Team : List<Champion>
    {
        public int Length { get; internal set; }
    }
}
