using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class BuildKnowledgeBase
    {
        public List<Clause> MapKnowledgeBase()
        {
            Clause A = new Clause("A", new List<String> { "a", "~b", "~c" });
            Clause B = new Clause("B", new List<String> { "b", "~c" });
            Clause C = new Clause("C", new List<String> { "b", "~c", "~d" });
            Clause D = new Clause("D", new List<String> { "c" });
            Clause E = new Clause("E", new List<String> { "d" });

            return new List<Clause> {
                A, B, C, D, E
            };
        }

    }
}
