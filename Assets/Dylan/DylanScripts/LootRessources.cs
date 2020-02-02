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
        AudioManager.Instance.audioSouce.clip = AudioManager.Instance.clips[9];
        AudioManager.Instance.audioSouce.Play();
        InventoryManager.Instance.slots[0] += col.GetComponent<RessourcesInformations>().ressourcesInformations[0];
        InventoryManager.Instance.slots[1] += col.GetComponent<RessourcesInformations>().ressourcesInformations[1];
        InventoryManager.Instance.slots[2] += col.GetComponent<RessourcesInformations>().ressourcesInformations[2];
        
        Destroy(col.gameObject, 0.1f);
    }
}
