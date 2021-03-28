using Cell_life.Cell_Model.Cell_Base;
using Cell_life.Model.Eat_Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Model
{
   public static class Cells
    {
        public static List<Food> foods;
     
        public static  List<Cell> cells { get; set; }

        static Cells()
        {
            cells = new List<Cell>();
            foods = new List<Food>();
        }
    
    }
}
