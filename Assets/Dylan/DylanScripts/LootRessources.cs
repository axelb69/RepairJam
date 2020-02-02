using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRessources : MonoBehaviour
{


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 9)
        {
            AudioManager.Instance.audioSouce.clip = AudioManager.Instance.clips[9];
            AudioManager.Instance.audioSouce.Play();
            if (col.gameObject.GetComponent<bone>() != null)
            {
                InventoryManager.Instance.slots[0] += col.GetComponent<bone>().cunt;
            }
            else if (col.gameObject.GetComponent<stone>() != null)
            {
                InventoryManager.Instance.slots[1] += col.GetComponent<stone>().cunt;
            }
            else if (col.gameObject.GetComponent<Wood>() != null)
            {
                InventoryManager.Instance.slots[2] += col.GetComponent<Wood>().cunt;
            }
            Destroy(col.gameObject, 0.1f);
        }
       
    }
}
