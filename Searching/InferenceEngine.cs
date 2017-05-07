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

        public void inference_proofer_search(List<Clause> KB, Clause root, Clause goal)
        {
            openList.Enqueue(root, Convert.ToSingle(root.f_score));

            // Cost to be calculted from start to current node
            double tentative_g_score = 0;

            while (openList.Count > 0)
            {
                var currentClause = openList.Dequeue();

                //Find clauses from KB that can be merged with current clause
                var clauseFromKB = find_clauses_from_knowledgebase(currentClause, KB);

                //Calculate heuristic
                foreach (var position in clauseFromKB)
                {
                    calculate_heuristic(KB, position);
                }

                

                //Add currentClause into closedList
                closedList.Add(currentClause);

                //Generate new clause based on found KB clauses
                var clause = Resolution(currentClause, clauseFromKB, KB);

                tentative_g_score = currentClause.getG_score() + 1;

                clause.g_score = tentative_g_score;
                calculate_heuristic_for_clause(clause);
                clause.calculate_F_Cost();

                //Add new clause to openList
                openList.Enqueue(clause, Convert.ToSingle(clause.h_score));

                Console.WriteLine("F score: " + currentClause.f_score + " G score: " + currentClause.g_score + " H score: " + currentClause.h_score);
                Console.WriteLine("");

                //Check if empty clause has been found, stop search if found
                var reached = isEmptyClause(goal, clause);
                if (reached) { break; }

                Thread.Sleep(3000);
            }

            Console.WriteLine("\n\n");
        }

        public Clause Resolution(Clause target, List<int> clauseFromKB, List<Clause> KB)
        {
            SimplePriorityQueue<Clause> KBList = new SimplePriorityQueue<Clause>();
            Clause resolutionClause = new Clause("F");
            List<Literal> literalList = new List<Literal>();

            Console.Write("Resolution on: "); printClause(target);
            Console.Write("with ");

            foreach (var position in clauseFromKB)
            {
                if (!KB[position].visited)
                {
                    KBList.Enqueue(KB[position], Convert.ToSingle(KB[position].f_score));
                }
                else
                {
                    target.g_score = target.g_score - 1;
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

                if (resolutionClause.clauseLiterals.Count == 0)
                {
                    //Add empty clause sign to clause
                    resolutionClause.clauseLiterals.Add(new Literal("[]"));
                }

                // Output clause
                Console.Write("generates clause: ");
                printClause(resolutionClause);

                resolutionClause.g_score = 1;

                //Check if generated clause already exist.
                var resolutionClauseAsString = printLiteralAsString(resolutionClause);

                foreach (var clause in closedList)
                {
                    var closeListClauseAsString = printLiteralAsString(clause);

                    if (resolutionClauseAsString.Equals(closeListClauseAsString))
                    {
                        clauseFromKBList.visited = true;
                    }
                }

                Console.WriteLine("");

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

        public void calculate_heuristic_for_clause(Clause target)
        {
            var heuristic = target.clauseLiterals.Count();
            target.h_score = heuristic;
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

        public bool isEmptyClause(Clause goal, Clause current)
        {
            var goalClauseString = printLiteralAsString(goal);
            var currentClauseString = printLiteralAsString(current);

            if (goalClauseString.Equals(currentClauseString))
            {
                Console.WriteLine("Empty clause has been found: " + goalClauseString);
                return true;
            }
            else
            {
                return false;
            }
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
