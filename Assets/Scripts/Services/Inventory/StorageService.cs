using IdleOfTheAgesLib;
using IdleOfTheAgesLib.Inventory;

using System;
using System.Collections.Generic;

namespace IdleOfTheAges.Inventory {
    [Service(typeof(IStorageService), serviceLevel: ServiceAttribute.ServiceLevelEnum.Public)]
    public class StorageService : IStorageService {
        private readonly Dictionary<Type, Dictionary<string, IItemStack>> storageGroups = new();
        private readonly IItemService itemService;

        public StorageService(IItemService itemService) {
            this.itemService = itemService;
        }

        public Result AddItem<TGroup>(string itemID, int count = 1) where TGroup : IStorageGroup {
            if (!storageGroups.TryGetValue(typeof(TGroup), out var group)) {
                group = new Dictionary<string, IItemStack>() {
                    { itemID, new ItemStack(itemID, itemService.GetItemData(itemID).Value) }
                };
                storageGroups[typeof(TGroup)] = group;
            }

            group[itemID].StackSize += count;

            return true;
        }

        public Result ContainsItem<TGroup>(string itemID) where TGroup : IStorageGroup {
            return storageGroups.TryGetValue(typeof(TGroup), out var group) && group.ContainsKey(itemID);
        }

        public Result<IItemStack> GetItem<TGroup>(string itemID) where TGroup : IStorageGroup {
            if (storageGroups.TryGetValue(typeof(TGroup), out var group)) {
                if (group.TryGetValue(itemID, out var item)) {
                    return (Result<IItemStack>)item;
                }

                return (null, $"No item with ID {itemID} exists within the group.");
            }

            return (null, $"No group of type {typeof(TGroup).FullName} exists");
        }

        public IEnumerable<IItemStack> GetItems() {
            foreach (var group in storageGroups.Values) {
                foreach (var item in group.Values) {
                    yield return item;
                }
            }
        }

        public IEnumerable<IItemStack> GetItems<TGroup>() where TGroup : IStorageGroup {
            if (storageGroups.TryGetValue(typeof(TGroup), out var group)) {
                foreach (var item in group.Values) {
                    yield return item;
                }
            }
        }
    }
}
