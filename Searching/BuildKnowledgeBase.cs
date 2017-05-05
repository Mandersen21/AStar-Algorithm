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
            Clause A = new Clause("A", new List<String> { "a", "v", "~b" });
            Clause B = new Clause("B", new List<String> { "b" });
            Clause C = new Clause("C", new List<String> { "c" });

            return new List<Clause> {
                A,
                B,
                C,
            };
        }

    }
}
