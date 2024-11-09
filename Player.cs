using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ОТУ_РГР
{
    internal class Player
    {
        private (int?, int?)[,] Reaction = new (int?, int?)[27, 5] //реализация поведения игрока по принципу Текущая точка: реакция согласия, реакция отрицицания
                                               { {(null,null), (null, null),(null, null), (null, null), (null, null)}, //затычка
                                                 {(2,4),(4,2),(null,null),(null,null),(null,null) }, //1
                                                 {(3,5),(5,3),(1,10),(10,1),(null,null) }, //2
                                                 {(4,6),(6,4),(8,2),(2,8),(null,null) },//3
                                                 {(1,11),(11,1),(9,3),(3,9),(null,null) }, //4
                                                 {(2,20),(20,2),(null,null),(null,null),(null,null) }, //5
                                                 {(3,12),(12,3),(10,7),(7,10), (null,null) }, //6
                                                 {(6,14),(13,6),(8,12),(12,8), (14,6) },  //7
                                                 {(3, 14), (14, 3), (11, 7), (7, 11),(null,null) }, //8
                                                 {(4,19),(19,4),(null,null),(null,null),(null,null) },  //9
                                                 {(2,15),(6,20),(15,2),(20,6),(null,null) }, //10
                                                 {(4,18),(18,4),(19,8),(8,19),(null,null) }, //11
                                                 {(6,16),(7,15),(13, 6),(16,6),(15,7) }, //12
                                                 {(7,11),(12,14),(14,6),(16,7),(17,12) }, //13
                                                 {(7,18),(8,17),(13,18),(17,8),(18,7) }, //14
                                                 {(10,16),(16,10),(12,21),(21,12),(null,null) }, //15
                                                 {(12,22),(13,15),(15,13),(17,15),(22,12) }, //16
                                                 {(13,22),(14,22),(16,18),(18,16),(22,14) }, //17
                                                 {(11,17),(14,23),(17,11),(23,14),(null,null) }, //18
                                                 {(9,23),(11,26),(23,9),(26,11),(null,null) }, //19
                                                 {(5, 21), (10, 24), (21, 5), (24, 10),(null,null) }, //20
                                                 {(15,25),(20,22),(22,20),(25,15),(null,null) }, //21
                                                 {(16,23),(17,21),(21,17),(23,16),(null, null) }, //22
                                                 {(18,25),(19,22),(22,19),(25,18),(null,null) }, //23
                                                 {(20,25),(25,20),(null,null),(null,null),(null,null) }, //24
                                                 {(21,26),(23,24),(24,23),(26,21),(null,null) }, //25
                                                 {(25,19),(19,25),(null,null),(null,null),(null,null) } }; //26
        internal List<bool> Yes_No = new List<bool>();
        internal int Current_location = 13;
        private int Moves = 0;

        public Player(List<int> Smth)
        {
            for (int i = 0; i < Smth.Count(); i++)
            {
                if (Smth[i] == 1)
                    Yes_No.Add(true);
                else
                    Yes_No.Add(false);
            }
        }

        public int To_react(int Number) // ну тут очевидно
        {
            for (int i = 0; i < 5; i++)
            {
                if (Reaction[Current_location,i] == (null, null))
                    break;
                if ((int)(Reaction[Current_location, i].Item1) == Number)
                {
                    if (Yes_No[Moves])
                        Current_location = Number;
                    else
                        Current_location = (int)(Reaction[Current_location, i].Item2);
                    Moves++;
                    break;
                }
            }
            return Current_location;
        }
    }
}
