using Cell_life.Cell_Model;
using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Cell_View;
using Cell_life.Model.Eat_Model;
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
        public void Create_genom(Color backColor, Point point) => Cell_Genome.cells_genom.Add(new Cell(Cell_Genome.cells_genom.Count + 1,  backColor, point));
        public void Kill_Cell(Cell cell)
        {
            Cell_Genome.foods.Add(new Food(new Point(cell.location.X - 10, cell.location.Y + 10)));      
            Cell_Genome.cells_genom.Remove(cell);
        }
        internal void Old() { lock (this) { try { Cell_Genome.cells_genom.ForEach(i => i.Old()); } catch (Exception) { } } }
        internal  void Mowe(Point point_zero_to_fild, Size size_field)
        { 
            lock (this)
            {
                try { Cell_Genome.cells_genom.ForEach(i => i.Move(point_zero_to_fild, size_field)); }
                catch (Exception) { }
            } 
        }
        internal void Get_child()
        {
            lock (this)
            {
                try
                {
                    foreach (Cell item in Cell_Genome.cells_genom)
                    {
                        for (int i = 0; i < item.Get_Cout_Generation(); i++)
                        {
                            Cell_Genome.cells_genom.Add(new Cell(Cell_Genome.cells_genom.Count + 1, item.color_leve, new Point(item.location.X + 1, item.location.Y + 1)));
                            item.id_childs.Add(Cell_Genome.cells_genom.Count);
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        internal void Get_Cell_Info(Point mousePosition)
        {
            int radius = 10;
            lock (this)
            {
                for (int i = radius - (radius * 2); i <= (radius * 2) + 1; i++)
                {
                    for (int j = radius - (radius * 2); j <= (radius * 2) + 1; j++)
                    {
                        if (Cell_Genome.cells_genom.Exists(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j))
                        {
                            var temp = Cell_Genome.cells_genom.Find(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j);
                            new Form_InfoCell(temp).Show();
                        }
                    }
                }
            }
        }

        internal void Serch_Food() => Cell_Genome.cells_genom.ForEach(i => i.Search_Eat());



        internal void Eat(Food food) => Cell_Genome.foods.Remove(food);     
        internal void Kill_All() => Cell_Genome.cells_genom.Clear();
    }
}
