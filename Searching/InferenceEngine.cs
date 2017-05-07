using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Searching
{
    public class InferenceEngine
    {
        //Initialize lists for A* search
        List<Clause> closedList = new List<Clause>();
        SimplePriorityQueue<Clause> openList = new SimplePriorityQueue<Clause>();

        public void inference_proofer(List<Clause> KB, Clause a)
        {
            openList.Enqueue(a, Convert.ToSingle(a.f_score));

            while (openList.Count > 0)
            {
                var currentClause = openList.Dequeue();

                //Find clauses from KB that can be merged with current clause
                var clauseFromKB = find_clauses_from_knowledgebase(currentClause, KB);

                //Calculate huristic
                foreach (var position in clauseFromKB)
                {
                    calculate_heuristic(KB, position);
                }

                //Add currentClause into closedList
                closedList.Add(currentClause);

                //Generate new clause based on found KB clauses
                var clause = Resolution(currentClause, clauseFromKB, KB);

                //Add new clause to openList
                openList.Enqueue(clause, Convert.ToSingle(clause.h_score));

                Thread.Sleep(7000);

                //if (clause.clauseLiterals.Count == 0)
                //{
                //    Console.WriteLine("Empty clause has been found");
                //    break;
                //}
            }

            Console.WriteLine("\n\n");
        }

        public Clause Resolution(Clause target, List<int> clauseFromKB, List<Clause> KB)
        {
            SimplePriorityQueue<Clause> KBList = new SimplePriorityQueue<Clause>();
            Clause resolutionClause = new Clause("F");
            List<Literal> literalList = new List<Literal>();

            var foundInCloseList = false;

            Console.Write("Resoluting "); printClause(target);
            Console.Write("and ");

            foreach (var position in clauseFromKB)
            {
                if (!KB[position].visited)
                {
                    KBList.Enqueue(KB[position], Convert.ToSingle(KB[position].f_score));
                }
                else
                {
                    //Console.WriteLine("Clause has been used, skipping");
                }
                
            }

            while (KBList.Count > 0)
            {
                var clauseFromKBList = KBList.Dequeue();
                printClause(clauseFromKBList);

                literalList = addLiterals(target, clauseFromKBList);

                //Get literal to search for
                var literal = literalConverter(literalList[0].name);

                literalList.RemoveAt(0);
                foreach (var l in literalList)
                {
                    if (!l.name.Equals(literal))
                    {
                        resolutionClause.clauseLiterals.Add(l);
                    }
                }

                //Check if generated clause already exist.
                var resolutionClauseAsString = printLiteralAsString(resolutionClause);
                Console.Write(" resolves: "); printClause(resolutionClause);
                Console.WriteLine("");

                foreach (var clause in closedList)
                {
                    var closeListClauseAsString = printLiteralAsString(clause);

                    if (resolutionClauseAsString.Equals(closeListClauseAsString))
                    {
                        foundInCloseList = true;
                        clauseFromKBList.visited = true;
                    }
                }

                break;
            }

            return resolutionClause;
        }

        public void calculate_heuristic(List<Clause> KB, int position)
        {
            var heuristic = KB[position].clauseLiterals.Count();
            KB[position].h_score = heuristic;

            KB[position].calculate_F_Cost();
        }

        public List<int> find_clauses_from_knowledgebase(Clause target, List<Clause> KB)
        {
            var positionList = new List<int>();
            var counter = 0;

            var literalToSearchFor = literalConverter(target.clauseLiterals[target.clauseLiterals.Count() - 1].name.ToString());

            foreach (var clause in KB)
            {
                foreach (var literal in clause.clauseLiterals)
                {
                    if (literal.name == literalToSearchFor)
                    {
                        positionList.Add(counter);
                    }
                }
                counter++;
            }

            return positionList;
        }

        public void printClause(Clause target)
        {
            foreach (var literal in target.clauseLiterals)
            {
                Console.Write(literal.name + " ");
            }
        }

        public string literalConverter(string target)
        {
            var literal = target;

            if (literal.Contains("~"))
            {
                literal = literal.Substring(1);
            }
            else
            {
                literal = "~" + literal;
            }

            return literal;
        }

        public string printLiteralAsString(Clause target)
        {
            var literal = "";

            foreach (var lit in target.clauseLiterals)
            {
                literal = lit.name + " " + literal;
            }

            return literal;
        }

        public List<Literal> addLiterals(Clause target, Clause KB_clause)
        {
            List<Literal> list = new List<Literal>();

            if (target.clauseLiterals.Count > KB_clause.clauseLiterals.Count)
            {
                //Add KB literal
                foreach (var lit in KB_clause.clauseLiterals)
                {
                    list.Add(lit);
                }

                //Add taget literal
                foreach (var lit in target.clauseLiterals)
                {
                    list.Add(lit);
                }
            }
            else
            {
                //Add taget literal
                foreach (var lit in target.clauseLiterals)
                {
                    list.Add(lit);
                }

                //Add KB literal
                foreach (var lit in KB_clause.clauseLiterals)
                {
                    list.Add(lit);
                }
            }

            return list;
        }
    }
}














//if (target.clauseLiterals.Count > 1)
//{
//    foreach (var lit in target.clauseLiterals)
//    {
//        if (!lit.name.Contains(literal))
//        {
//            //Add to new clause
//            resolutionClause.clauseLiterals.Add(lit);
//        }
//    }
//}
//else
//{
//    foreach (var lit in clauseFromKBList.clauseLiterals)
//    {
//        if (!lit.name.Equals(literal))
//        {
//            //Add to new clause
//            resolutionClause.clauseLiterals.Add(lit);
//        }
//    }
//}

//var count = target.clauseLiterals.Count;

//if (target.clauseLiterals[count - 1].name.Contains("~"))
//{
//    literal = target.clauseLiterals[count - 1].name.Substring(1);
//}
//else
//{
//    literal = "~" + target.clauseLiterals[count - 1].name;
//}
