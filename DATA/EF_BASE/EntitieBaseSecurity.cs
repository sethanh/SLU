﻿using DATA.EF_BASE;
using System;
using System.ComponentModel.DataAnnotations;

namespace DATA.EF_BASE
{
    public class EntitieBaseSecurity : EntitiesBase
    {
        public string SecurityStamp { get; set; } = DateTime.Now.ToString();

    }
}
