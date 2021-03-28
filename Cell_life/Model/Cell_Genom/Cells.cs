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
   public class Cells
    {
        public static List<Food> foods;
        public static int time_life_genom { get; set; }
        public Color color { get; set; }
        public  int id_genom { get; set; }
        public static  List<Cell> cells { get; set; }

        static Cells()
        {
            cells = new List<Cell>();
            foods = new List<Food>();
        }
        public Cells(int id_genom ,Color color,Point point)
        {
            time_life_genom = 0;
            this.color = color;
            this.id_genom = id_genom;           
        }

      

        public void Old()
        {
            try { cells.ForEach(i => i.Old()); }
            catch (Exception) { }
        }
      

        internal void Live() => time_life_genom++;



        public bool Is_Die() => cells.Count == 0 ? true : false;

        internal void Serch_Food() => cells.ForEach(i => i.Search_Eat());

    }
}
