using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SearchProblem
    {
        public StreetCorner root { get; set; }
        public StreetCorner goal { get; set; }

        public SearchProblem(StreetCorner root, StreetCorner goal)
        {
            this.root = root;
            this.goal = goal;
        }

        public StreetCorner getRoot()
        {
            return root;
        }

        public StreetCorner getGoal()
        {
            return goal;
        }
    }
}
