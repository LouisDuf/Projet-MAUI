using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.ViewModel
{
    public class ViewModelMenuItem
    {
        public string Name { get; set; }
        public string Icone { get; set; }
        public long? Number { get; set; }
        public string Route { get; set; }
        public bool IsLastItem { get; set; }

        public ViewModelMenuItem(
            string name,
            string icone,
            long? number,
            string route,
            bool isLastItem = false
        )
        {
            Name = name;
            Icone = icone;
            Number = number;
            Route = route;
            IsLastItem = isLastItem;
        }
    }
}
