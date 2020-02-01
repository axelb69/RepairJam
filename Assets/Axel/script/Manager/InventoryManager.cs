using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class InventoryManager : Singleton<InventoryManager>
{
    private List<int> _slots = new List<int> { 0, 0, 0 };
    public List<int> slots {
        get {
            return _slots; }
        set {
            FillDictionary();
            Debug.Log(value);
            _slots = value;
        } }
    public Dictionary<string, int> _inventory = new Dictionary<string, int>();

    private void FillDictionary()
    {
        _inventory.Clear();
        _inventory.Add("bone", _slots[0]);
        _inventory.Add("stone", _slots[1]);
        _inventory.Add("wood", _slots[2]);
    }
}
