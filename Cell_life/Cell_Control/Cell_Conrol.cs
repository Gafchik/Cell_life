using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Cell_View;
using Cell_life.Model.Eat_Model;
using Cell_life.Model.Game_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_life.Cell_Control
{
    class Cell_Conrol
    {
        public void Create_genom(Color backColor, Point point) => Game_elements.genus.Add(new Cell_Genome(Game_elements.genus.Count+1,backColor, point));

        public void Kill_My(Cell cell)
        {
            lock (this)
            {
                for (int i = 0; i < 3; i++)
                { Game_elements.eats.Add(new Eat(cell)); }

                
                Game_elements.genus.ForEach(i => i.cells_genom.Remove(cell));
            }
        }
       

        internal void Old() { lock (this) { Game_elements.genus.ForEach(i => i.Old()); cleaning(); Game_elements.genus.ForEach(i => i.Live()); } }

        internal void Mowe(Point point_zero_to_fild, Size size_field) { lock (this) { Game_elements.genus.ForEach(i => i.Mowe(point_zero_to_fild, size_field)); } }
        internal void Get_child() { lock (this) { Game_elements.genus.ForEach(i => i.Get_Child()); } }


        void cleaning() { lock (this) { Game_elements.genus.RemoveAll(i => i.cells_genom.Count == 0); } }

        internal void Get_Cell_Info(Point mousePosition)
        {
            int radius = 10;
            lock (this) 
            {
                foreach (var coll in Game_elements.genus)
                {

                    for (int i = radius - (radius * 2); i <= (radius * 2) + 1; i++)
                    {
                        for (int j = radius - (radius * 2); j <= (radius * 2) + 1; j++)
                        {
                            if (coll.cells_genom.Exists(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j))
                            {
                                var temp = coll.cells_genom.Find(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j);
                                new Form_InfoCell(coll,temp).Show();
                            }
                        }
                    }                  
                }
             
            } 
        }

        internal void Kill_All() => Game_elements.genus.Clear();

    }
}
