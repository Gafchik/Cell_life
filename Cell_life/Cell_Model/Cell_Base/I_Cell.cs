﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Model.Cell_Base
{
    interface I_Cell
    {
        void Move();
        void Old();
        void Get_Generation();
        void Die();
        void Eat();
    }
}
