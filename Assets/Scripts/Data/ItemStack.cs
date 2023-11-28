using IdleOfTheAgesLib.Inventory;
using IdleOfTheAgesLib.Models.ModJsonData;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleOfTheAges.Inventory {
    public class ItemStack : IItemStack {
        public string ItemID { get; }
        public ItemData ItemData { get; }
        public Dictionary<string, string> Metadata { get; } = new Dictionary<string, string>();
        public int StackSize { get; set; }

        public ItemStack(string itemID, ItemData itemData) {
            ItemID = itemID;
            ItemData = itemData;
        }
    }
}
