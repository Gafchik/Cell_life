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
   public class Eat
    {
        public Random random;

        public Eat(Cell cell)
        {
            random = new Random();
            size = new Size(5, 5);
            color_leve = Color.Green;
            callory = 3;
            scatter =Convert.ToInt32(( cell.size.Width+cell.size.Height) *3.14);
           
            switch (random.Next(0, 3))
            {
                case 0:
                    this.location = new Point(cell.location.X + scatter, cell.location.Y);
                    break;
                case 1:
                    this.location = new Point(cell.location.X, cell.location.Y + scatter);
                    break;
                case 2:
                    this.location = new Point(cell.location.X - scatter, cell.location.Y);
                    break;
                case 3:
                    this.location = new Point(cell.location.X, cell.location.Y - scatter);
                    break;
                default:
                    break;
            }
        }

        public Point location { get; set; }
        public Size size { get; set; }
        public Color color_leve { get; set; }
        public int callory { get; set; }
        public int scatter { get; set; }

    }
}
