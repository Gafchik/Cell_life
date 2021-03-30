using Cell_life.Cell_Model.Cell_Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cell_life.Model.Eat_Model
{
   public class Food
    {

        public Food(Point point)
        {
            size = new Size(5, 5);
            color_leve = Color.Green;
            growth_HP = 10;
            regen_HP = 20;
            growth_damage = 1;
            location = point;
        }
        public int Step_to_Cell(Point point) => Convert.ToInt32(Math.Sqrt(
                Math.Pow(Convert.ToDouble(location.X - point.X), 2)
              + Math.Pow(Convert.ToDouble(location.Y - point.Y), 2)));
       
       
        public Point location { get; set; }
        public Size size { get; set; }
        public Color color_leve { get; set; }
        public int growth_HP { get; set; }
        public int growth_damage { get; set; }
        public int regen_HP{ get; set; }

    }
}
