using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class SearchHelper
    {
        public StreetCorner getNodeFromOpenList(StreetCorner target, SimplePriorityQueue<StreetCorner> queue)
        {
            StreetCorner node = null;

            foreach (var n in queue)
            {
                if (n.name == target.name)
                {
                    node = n;
                    break;
                }
            }
            return node;
        }

        public StreetCorner getNodeFromClosedList(StreetCorner target, List<StreetCorner> list)
        {
            StreetCorner node = null;

            foreach (var n in list)
            {
                if (n.name == target.name)
                {
                    node = n;
                    break;
                }
            }
            return node;
        }
    }
}
