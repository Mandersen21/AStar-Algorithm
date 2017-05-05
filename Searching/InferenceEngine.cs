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
        // KB (knowledgebase, Alpha
        public void inferens_proofer(List<Clause> KB, Clause a)
        {
            SimplePriorityQueue<Clause> openList = new SimplePriorityQueue<Clause>();
            List<Clause> closedList = new List<Clause>();

            // Cost to be calculted from start to current node
            double tentative_g_score = 0;

            // Put starting node into openList
            openList.Enqueue(a, Convert.ToSingle(a.f_score));

            // Inizialize currentNode object
            Clause currentClause = a;

            while (openList.Count > 0)
            {
                var value = check_knowledgebase(KB, currentClause);
                Console.WriteLine("Current position in KB: " + value);
                break;
            }


            Console.WriteLine("\n\n\n\n");
        }

        public int check_knowledgebase(List<Clause> KB, Clause target)
        {
            var letterToSearchFor = "";
            var clausePosition = 0;

            if (target.clause.Last().Contains("~"))
            {
                letterToSearchFor = target.clause[0].Substring(1);
            }
            else
            {
                letterToSearchFor = target.clause[0];
            }

            Console.WriteLine("letterToSearchFor " + letterToSearchFor);

            // Search through the knowledgebase to find if a clause has a negation of target
            foreach (var clause in KB)
            {
                foreach (var letter in clause.clause)
                {
                    if (letter == letterToSearchFor)
                    {
                        break;
                    }
                }
                clausePosition++;
            }

            return clausePosition;
        }

        // Unit resolution
        public Clause Unit_Resolution(Clause target, Clause KB)
        {
            // Form clause



            // Factoring process

            return null;
        }

        public double calculate_heuristic(Clause target)
        {
            return 2;
        }
    }
}
