using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОТУ_РГР
{
    internal class Master
    {
        private (int?,int?)[,] Maze = new (int?, int?)[27, 5] //реализация лабиринта по принципу Номер точки: (доступная точка, отношение к текущей по уровню)
                                               { {(null,null), (null, null),(null, null), (null, null), (null, null)}, //затычка
                                                 {(2,0),(4,0),(null, null),(null,null),(null,null) }, //1
                                                 {(1,0),(3,-1),(5,0),(10,-1),(null,null) }, //2
                                                 {(4,1),(6,0),(8,0),(null,null),(null,null) },//3
                                                 {(1,0),(3,-1),(9,0),(11,-1),(null,null) }, //4
                                                 {(2,0),(20,0),(null,null),(null,null),(null,null) }, //5
                                                 {(3,0),(7,-1),(10,0),(12,-1), (null,null) }, //6
                                                 {(6,1),(8,1),(12,0),(14,0), (13,-1) },  //7
                                                 {(3,0),(7,-1),(11,0),(14,-1),(null,null) }, //8
                                                 {(4,0),(19,0),(null,null),(null,null),(null,null) },  //9
                                                 {(2,1),(6,0),(15,0),(20,1),(null,null) }, //10
                                                 {(4,1),(8,0),(18,0),(19,1),(null,null) }, //11
                                                 {(6,1),(7,0),(13, -1),(15,1),(16,0) }, //12
                                                 {(7,1),(12,1),(14,1),(16,1),(17,1) }, //13
                                                 {(7,0),(8,1),(13,-1),(17,0),(18,1) }, //14
                                                 {(10,0),(12,-1),(16,-1),(21,0),(null,null) }, //15
                                                 {(12,0),(13,-1),(15,1),(17,0),(22,1) }, //16
                                                 {(13,-1),(14,0),(16,0),(18,1),(22,1) }, //17
                                                 {(11,0),(14,-1),(17,-1),(23,0),(null,null) }, //18
                                                 {(9,0),(11,-1),(23,-1),(26,0),(null,null) }, //19
                                                 {(5,0),(10,-1),(21,-1),(24,0),(null,null) }, //20
                                                 {(15,0),(20,1),(22,0),(25,1),(null,null) }, //21
                                                 {(16,-1),(17,-1),(21,0),(23,0),(null, null) }, //22
                                                 {(18,0),(19,1),(22,0),(25,1),(null,null) }, //23
                                                 {(20,0),(25,0),(null,null),(null,null),(null,null) }, //24
                                                 {(21,-1),(23,-1),(24,0),(26,0),(null,null) }, //25
                                                 {(19,0),(25,0),(null,null),(null,null),(null,null) } }; //26
        private int[] Winners = new int[5] {1,5,9,24,26 }; //победные точки
        private int Current_point = 13;
        private int Current_level = 0;
        private int Current_move = 0;
        private Random R = new Random();
        public double HintToExit;
        internal int Max_moves;
        public void StartGame(double A)
        {
            HintToExit = A;
        }
        public int Hint(int Point)
        {
            Current_point = Point;
            List<(int,int)> A = new List<(int, int)> (); //Список вершин на уровень выше и соседних, если уровень максимален
            List<(int,int)> B = new List<(int, int)>(); // список вершин на уровень ниже и соседних, если уровень не максимален
            List<(int, int)> C = new List<(int, int)>(); //список соседних вершин, если подняться на уровень выше нельзя
            (int, int) Kostyl;
            for (int i = 0; i < 5; i++)
            {
                if (Maze[Current_point, i] == (null, null))
                    break;
                else 
                {
                    if ( (Maze[Current_point, i].Item2 == 1) || (Current_level == 5) )
                        A.Add( ((int)((Maze[Current_point, i]).Item1), (int)((Maze[Current_point, i]).Item2)) );
                    if ((Maze[Current_point, i].Item2 == 0))
                        C.Add(((int)((Maze[Current_point, i]).Item1), (int)((Maze[Current_point, i]).Item2)));
                    else
                        B.Add(( (int)((Maze[Current_point, i]).Item1), (int)((Maze[Current_point, i]).Item2)));
                }
            }
            if (R.NextDouble() <= HintToExit) //выдаём ДОБРУЮ подсказку
            {
                if (A.Count > 0)
                {
                    Kostyl = A[R.Next(A.Count())];
                    Current_level += Kostyl.Item2;
                    return Kostyl.Item1;
                }
                else
                {
                    Kostyl = C[R.Next(C.Count())];
                    Current_level += Kostyl.Item2;
                    return Kostyl.Item1;
                }
            }
            else // выдаём ЗЛОБНУЮ подсказку
            {
                Kostyl = B[R.Next(B.Count())];
                Current_level += Kostyl.Item2;
                return Kostyl.Item1;
            }
        }
    }
}
