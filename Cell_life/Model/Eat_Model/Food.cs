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
        public Random random;

        public Food(Point point)
        {
            random = new Random();
            size = new Size(5, 5);
            color_leve = Color.Green;
            callory = 3;
            scatter = 0;
            location = point;
        }              
        public Point location { get; set; }
        public Size size { get; set; }
        public Color color_leve { get; set; }
        public int callory { get; set; }
        public int scatter { get; set; }

    }
}
