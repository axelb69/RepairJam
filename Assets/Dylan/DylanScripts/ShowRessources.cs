using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRessources : MonoBehaviour
{
    [SerializeField]
    private Text woodText;

    [SerializeField]
    private Text stoneText;

    [SerializeField]
    private Text boneText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = InventoryManager.Instance.slots[0].ToString();
        stoneText.text = InventoryManager.Instance.slots[1].ToString();
        boneText.text = InventoryManager.Instance.slots[2].ToString();
    }
}
