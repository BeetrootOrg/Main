﻿using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IArmorService
    {
        List<Armor> GetAll();
    }
}
