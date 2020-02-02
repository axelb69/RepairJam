using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRessources : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {

            if (col.gameObject.GetComponent<bone>() != null) { InventoryManager.Instance.slots[0] += col.gameObject.GetComponent<bone>().cunt; }
            if (col.gameObject.GetComponent<stone>() != null) { InventoryManager.Instance.slots[1] += col.gameObject.GetComponent<stone>().cunt; }
            if (col.gameObject.GetComponent<Wood>() != null) { InventoryManager.Instance.slots[2] += col.gameObject.GetComponent<Wood>().cunt; }
            Destroy(col.gameObject);
        }
                             
    }
}
