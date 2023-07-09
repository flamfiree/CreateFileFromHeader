using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Structure
    {
        public string Name { get; set; }
        public List<Line> Lines { get; set; }
        public string Description { get; set; }
        public Structure()
        {
            Lines = new List<Line>(); // Добавлено создание экземпляра списка Lines
        }
    }
}
