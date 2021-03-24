using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Model.Game_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Control
{
    class Cell_Conrol
    {
        public void Create_genom(Color backColor, Point point) => Cell_Genoms.genus.Add(new Cell_Genome(Cell_Genoms.genus.Count+1,backColor, point));

        public void Kill_My(Cell cell) { lock (this) { Cell_Genoms.genus.ForEach(i => i.cells_genom.Remove(cell)); } }
        public void Info_cell()
        {

        }

        internal void Old() { lock (this) { Cell_Genoms.genus.ForEach(i => i.Old()); cleaning();  } }

        internal void Mowe() { lock (this) { Cell_Genoms.genus.ForEach(i => i.Mowe()); } }
        internal void Get_child() { lock (this) { Cell_Genoms.genus.ForEach(i => i.Get_Child()); } }


        void cleaning() { lock (this) { Cell_Genoms.genus.RemoveAll(i => i.cells_genom.Count == 0); } }
    }
}
