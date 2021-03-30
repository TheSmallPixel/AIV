using Assets.Script.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using File = System.IO.File;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject _item;
    [SerializeField] private GameObject _slot;

    [SerializeField] private List<ItemGameobject> _itemGameobjects;


    [SerializeField] private RectTransform _root;

    [SerializeField] [Range(0, 40)] private int _slotNumber;

    private Dictionary<string, ItemGameobject> _itemReference = new Dictionary<string, ItemGameobject>();


    private Chest _chest = new Chest();
    private List<Item> _items => _chest.Items;


    private List<Slot> _slots = new List<Slot>();

    void Start()
    {
        _itemReference = _itemGameobjects.ToDictionary(x => x.Id, x => x);
        for (int i = 0; i < _slotNumber; i++)
        {
            var slot = Instantiate(_slot, _root);
            slot.GetComponent<Slot>().Setup(i, OnDrop);
            _slots.Add(slot.GetComponent<Slot>());
        }
    }

    void OnDrop(int id, GameItem gm, Slot slot)
    {
        bool isFree = !_items.Any(x => x.Position == slot.Id);
        if (isFree)
        {
            gm.Item.Position = slot.Id;
            gm.gameObject.transform.SetParent(slot.transform);
        }
    }

    public void Save()
    {
        string data = JsonUtility.ToJson(_chest);
        File.WriteAllText(Application.persistentDataPath + "/inv.json", data);
        Debug.Log(Application.persistentDataPath + "/inv.json");
    }

    public void Load()
    {
        var data = File.ReadAllText(Application.persistentDataPath + "/inv.json");
        _chest = JsonUtility.FromJson<Chest>(data);
        foreach (var item in _chest.Items)
        {
            var usableSlot = _slots[item.Position];
            var itemObject = Instantiate(_item, usableSlot.transform);
            itemObject.GetComponent<GameItem>().Setup(_itemReference[item.Type], item);
        }
    }

    public void AddRandom()
    {
        int index = Random.Range(0, _itemReference.Count);
        CreateItem(_itemGameobjects[index].Id);
    }

    Slot GetFirstFreeSlot()
    {
        if (_items.Count == 0)
        {
            return _slots.FirstOrDefault();
        }
        return _slots.FirstOrDefault(x => !_items.Any(i => i.Position == x.Id));
    }



    void CreateItem(string id)
    {
        var usableSlot = GetFirstFreeSlot();
        if (usableSlot == null) return;

        var itemObject = Instantiate(_item, usableSlot.transform);
        var itemData = new Item(id, usableSlot.Id);
        _items.Add(itemData);
        itemObject.GetComponent<GameItem>().Setup(_itemReference[id], itemData);
    }
}
