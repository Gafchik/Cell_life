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
       
        public void Create_genom(Color backColor, Point point)
        {
            lock (this)
            {
                Cells.cells.Add(new Cell(Cells.cells.Count + 1, backColor, point));
            }
        }     
        internal void Old()
        { 
            lock (this)
            {
                try                 
                {
                    //Cells.cells.ForEach(i => i.Get_Child());
                    Cells.cells.ForEach(i => i.Old()); 
                    Cells.cells.ForEach(i => i.Next_Move()); 
                } 
                catch (Exception) { } 
            }
        }
        internal void Mowe(Point point_zero_to_fild, Size size_field)
        {
            lock (this)
           {
                try
                {   
                    Cells.cells.ForEach(i => i.Move(point_zero_to_fild, size_field));
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
                        if (Cells.cells.Exists(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j))
                        {
                            var temp = Cells.cells.Find(q => q.location.X == mousePosition.X + i & q.location.Y == mousePosition.Y + j);
                            new Form_InfoCell(temp).Show();
                        }
                    }
                }
            }
        }    
        internal void Kill_All()
        {
           lock (this)
            {
                Cells.cells.Clear();
            }
        } 
    }
}
