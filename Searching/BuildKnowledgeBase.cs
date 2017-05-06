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
            Clause A = new Clause("A");
            Clause B = new Clause("B");
            Clause C = new Clause("C");
            Clause D = new Clause("D");
            Clause E = new Clause("E");

            A.clauseLiterals = new List<Literal>
            {
                new Literal("a"),
                new Literal("~b"),
                new Literal("~c")
            };

            B.clauseLiterals = new List<Literal>
            {
                new Literal("b"),
                new Literal("~b"),
            };

            C.clauseLiterals = new List<Literal>
            {
                new Literal("b"),
                new Literal("~c"),
                new Literal("~d")
            };

            D.clauseLiterals = new List<Literal>
            {
                new Literal("c"),
            };

            E.clauseLiterals = new List<Literal>
            {
                new Literal("d"),
            };

            return new List<Clause> {
                A, B, C, D, E
            };
        }

    }
}
