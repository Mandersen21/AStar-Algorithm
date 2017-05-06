using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class InferenceEngine
    {
        //A* search for the empty clause
        public void inferens_proofer(List<Clause> KB, Clause a)
        {
            SimplePriorityQueue<Clause> openList = new SimplePriorityQueue<Clause>();
            List<Clause> closedList = new List<Clause>();
            Clause currentClause = a;

            //Add negation clause to openList
            openList.Enqueue(currentClause, Convert.ToSingle(a.f_score));

            while (openList.Count > 0)
            {
                //Dequeue clause from openList
                currentClause = openList.Dequeue();

                Console.Write("generated clause: ");
                printClause(currentClause);

                //Find clauses from KB that can be merged with current clause
                var clausesFromKB = find_clauses_from_knowledgebase(KB, currentClause);

                //Calculate huristic
                foreach (var clausePosition in clausesFromKB)
                {
                    calculate_heuristic(KB, clausePosition);
                }

                //Add currentClause into closedList
                closedList.Add(currentClause);

                //Generate new clause based on found KB clauses
                var clause = Unit_Resolution(currentClause, clausesFromKB, KB);
                openList.Enqueue(clause, Convert.ToSingle(clause.h_score));
                
            }

            Console.WriteLine("\n\n");
        }

        // Unit resolution
        public Clause Unit_Resolution(Clause target, List<int> clausesFromKB, List<Clause> KB)
        {
            SimplePriorityQueue<Clause> KBList = new SimplePriorityQueue<Clause>();
            var literal = "";
            var newClause = new Clause("");
            newClause.clauseLiterals = new List<Literal>
            {

            };

            Console.WriteLine("");
            foreach (var position in clausesFromKB)
            {
                KBList.Enqueue(KB[position], Convert.ToSingle(KB[position].h_score));
            }

            var clauseToBeMerged = KBList.Dequeue();

            // Form clause
            Console.Write("  Resolution "); printClause(target); Console.Write("and "); printClause(clauseToBeMerged);
            Console.Write("and resolves: ");
            Console.Write("\n");

            // Factoring process
            literal = literalConverter(target);
            Console.WriteLine("  Literal to search for: " + literal);

            foreach (var l in clauseToBeMerged.clauseLiterals)
            {
                if (!l.name.Equals(literal))
                {
                    //Add to new clause
                    newClause.clauseLiterals.Add(l);
                }
            }

            return newClause;
        }

        public void calculate_heuristic(List<Clause> KB, int position)
        {
            var heuristic = KB[position].clauseLiterals.Count();
            KB[position].h_score = heuristic;
        }

        public List<int> find_clauses_from_knowledgebase(List<Clause> KB, Clause target)
        {
            var letterToSearchFor = "";
            var list = new List<int>();
            var counter = 0;

            if (target.clauseLiterals.Last().name.Contains("~"))
            {
                letterToSearchFor = target.clauseLiterals[0].name.Substring(1);
            }
            else
            {
                letterToSearchFor = target.clauseLiterals[0].name;
            }

            // Search through the knowledgebase to find if a clause has a negation of target
            foreach (var clause in KB)
            {
                foreach (var literal in clause.clauseLiterals)
                {
                    if (literal.name == letterToSearchFor)
                    {
                        list.Add(counter);
                    }
                }
                counter++;
            }

            return list;
        }

        public void printClause(Clause target)
        {
            foreach (var literal in target.clauseLiterals)
            {
                Console.Write(literal.name + " ");
            }
        }

        public string literalConverter(Clause target)
        {
            var literal = "";

            if (target.clauseLiterals.Last().name.Contains("~"))
            {
                literal = target.clauseLiterals[0].name.Substring(1);
            }
            else
            {
                literal = target.clauseLiterals[0].name;
            }

            return literal;
        }
    }
}
