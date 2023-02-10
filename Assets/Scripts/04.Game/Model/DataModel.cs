using System;
using System.Collections.Generic;

namespace _04.Game.Model
{
    [Serializable]
    public class DataModel
    {
        public List<Item> Level;
    }

    public class Item
    {
        public List<int> row_0;
        public List<int> row_1;
        public List<int> row_2;
        public List<int> row_3;
        public List<int> row_4;
        public List<int> row_5;
        public List<int> row_6;
        public List<int> row_7;
        public List<int> row_8;
    }
}