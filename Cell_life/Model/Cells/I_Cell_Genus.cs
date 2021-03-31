using Cell_life.Cell_Model.Cell_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Model
{
    interface I_Cell_Genus
    {
        void Add_Child(Cell cell);
        bool Is_Die();
        void Live();
    }
}
