using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class BuildStreetGraph
    {
        public List<StreetCorner> MapStreetGraph()
        {
            StreetCorner A = new StreetCorner("A", 10, 70);
            StreetCorner B = new StreetCorner("B", 20, 50);
            StreetCorner C = new StreetCorner("C", 25, 100);
            StreetCorner D = new StreetCorner("D", 35, 80);
            StreetCorner E = new StreetCorner("E", 35, 35);
            StreetCorner F = new StreetCorner("F", 45, 70);
            StreetCorner G = new StreetCorner("G", 55, 55);
            StreetCorner H = new StreetCorner("H", 50, 90);
            StreetCorner I = new StreetCorner("I", 35, 120);
            StreetCorner J = new StreetCorner("J", 60, 150);
            StreetCorner K = new StreetCorner("K", 65, 110);
            StreetCorner L = new StreetCorner("L", 65, 100);
            StreetCorner M = new StreetCorner("M", 70, 85);
            StreetCorner N = new StreetCorner("N", 80, 70);

            // Set edges to all the nodes
            A.neighbors = new List<AbstractEdge>
            {
                new Road(B, "Vestervoldgade"),
                new Road(D, "SktPedersStraede"),
                new Road(C, "Noerrevoldgade")
            };

            B.neighbors = new List<AbstractEdge>
            {
                new Road(A, "Vestervoldgade"),
                new Road(F, "Studiestraede"),
                new Road(E, "Vestervoldgade"),
            };

            C.neighbors = new List<AbstractEdge>
            {
                new Road(A, "Vestervoldgade"),
                new Road(D, "TeglgaardsStraede"),
                new Road(I, "Noerrevoldgade")
            };

            D.neighbors = new List<AbstractEdge>
            {
                new Road(H, "SktPedersStraede")
            };

            E.neighbors = new List<AbstractEdge>
            {
                new Road(B, "Vestervoldgade"),
                new Road(G, "Vestergade")
            };

            F.neighbors = new List<AbstractEdge>
            {
                new Road(D, "Larsbjoernsstraede"),
                new Road(G, "Larsbjoernsstraede"),
            };

            G.neighbors = new List<AbstractEdge>
            {
                new Road(N, "Vestergade")
            };

            H.neighbors = new List<AbstractEdge>
            {
                new Road(I, "LarslejStraede")
            };

            I.neighbors = new List<AbstractEdge>
            {
                new Road(C, "Noerrevoldgade"),
                new Road(J, "Noerrevoldgade")
            };

            J.neighbors = new List<AbstractEdge>
            {
                new Road(I, "Noerrevoldgade"),
                new Road(K, "Noerregade")
            };

            K.neighbors = new List<AbstractEdge>
            {
                new Road(J, "Noerregade"),
                new Road(L, "Noerregade")
            };

            L.neighbors = new List<AbstractEdge>
            {
                new Road(K, "Noerregade"),
                new Road(H, "SktPedersStraede"),
                new Road(M, "Noerregade")
            };

            M.neighbors = new List<AbstractEdge>
            {
                new Road(L, "Noerregade"),
                new Road(N, "Noerregade"),
                new Road(F, "Studiestraede")
            };

            N.neighbors = new List<AbstractEdge>
            {
                
            };

            return new List<StreetCorner> {
                A, // 0
                B, // 1
                C, // 2
                D, // 3
                E, // 4
                F, // 5
                G, // 6
                H, // 7
                I, // 8
                J, // 9
                K, // 10
                L, // 11
                M, // 12
                N, // 13
            };
        }

    }

    // Data used

    // Node A (10,70)
    //10 70 Vestervoldgade 20 50
    //10 70 SktPedersStraede 35 80
    //10 70 Noerrevoldgade 25 100

    // Node B (20,50)
    //20 50 Vestervoldgade 10 70
    //20 50 Vestervoldgade 35 35
    //20 50 Studiestraede 45 70

    // Node C (25,100)
    //25 100 Noerrevoldgade 10 70
    //25 100 Noerrevoldgade 35 120
    //25 100 TeglgaardsStraede 35 80

    // Node D (35,80)
    //35 80 SktPedersStraede 50 90

    // Node E (35,35)
    //35 35 Vestervoldgade 20 50
    //35 35 Vestergade 55 55

    // Node F (45,70)
    //45 70 Larsbjoernsstraede 35 80
    //45 70 Larsbjoernsstraede 55 55

    // Node G (55,55)
    //55 55 Vestergade 80 70

    // Node H (50,90)
    //50 90 LarslejStraede 35 120

    // Node I (35,120)
    //35 120 Noerrevoldgade 25 100
    //35 120 Noerrevoldgade 60 150

    // Node J (60,150)
    //60 150 Noerrevoldgade 35 120
    //60 150 Noerregade 65 110

    // Node K (65,110)
    //65 110 Noerregade 60 150
    //65 110 Noerregade 65 100

    // Node L (65,100)
    //65 100 Noerregade 65 110
    //65 100 SktPedersStraede 50 90
    //65 100 Noerregade 70 85

    // Node M (70,85)
    //70 85 Noerregade 65 100
    //70 85 Noerregade 80 70'
    //70 85 Studiestraede 45 70

    // Node N (80,70)
    //80 70 Noerregade 70 85
}
