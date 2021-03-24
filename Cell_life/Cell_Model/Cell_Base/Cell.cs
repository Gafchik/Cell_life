using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_life.Cell_Model.Cell_Base
{
    class Cell : I_Cell
    {
        public int id { get; set; }
        readonly int time_life;
        readonly int time_to_death;
        public int count_genom { get; set; }
        public List<int> id_childs { get; set; }
        readonly Color color;


        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Get_Generation()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Old()
        {
            throw new NotImplementedException();
        }
    }
}
