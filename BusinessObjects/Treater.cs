using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class Treater
    {
        public int id { get; set; }
        public string name { get; set; }
        public Candy favoriteCandy { get; set; }
        public Costume costume { get; set; }
    }
}
