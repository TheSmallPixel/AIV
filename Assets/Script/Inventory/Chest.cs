using System;
using System.Collections.Generic;

namespace Assets.Script.Inventory
{
    [Serializable]
    public class Chest
    {
        public List<Item> Items;

        public Chest()
        {
            Items = new List<Item>();
        }
    }
}
