﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace CPVPAAppDes
{
    public interface IConfig
    {
        string DirectorioDB { get;  }
        ISQLitePlatform Plataforma { get;  }

    }
}
