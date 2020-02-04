using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strat : MonoBehaviour
{   
    void Start()
    {
        WavesManager.Instance.wave = 0;
        TheGameManager.Instance.scor = 0;
        InventoryManager.Instance.slots[0] = 0;
        InventoryManager.Instance.slots[1] = 0;
        InventoryManager.Instance.slots[2] = 0;
    }
}
