using Cell_life.Cell_Model.Cell_Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Model
{
   public class Cell_Genome
    {
        public int time_life_genom { get; set; }
        public Color color { get; set; }
        public  int id_genom { get; set; }
        public   List<Cell> cells_genom { get; set; }

        public Cell_Genome(int id_genom ,Color color,Point point)
        {
            time_life_genom = 0;
            this.color = color;
            this.id_genom = id_genom;
            cells_genom = new List<Cell>();
            cells_genom.Add(new Cell(cells_genom.Count+1, id_genom, color, point));
        }

        internal void Mowe()
        {
            try { cells_genom.ForEach(i => i.Move()); }
            catch (Exception) { }
        }

        public void Old()
        {
            try { cells_genom.ForEach(i => i.Old()); }
            catch (Exception) { }
        }
        public void Get_Child()
        {
            try
            {
                foreach (Cell item in cells_genom)
                {
                    for (int i = 0; i < item.Get_Cout_Generation(); i++)
                    {
                        cells_genom.Add(new Cell(cells_genom.Count + 1, id_genom, item.color_leve, new Point(item.location.X + 1, item.location.Y + 1)));
                        item.id_childs.Add(cells_genom.Count);
                    }
                }
            }
            catch (Exception) { }
        }

      
        public bool Is_Die() => cells_genom.Count == 0 ? true : false;
       
    }
}
