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

    [Range(0, 100)]
    public float woodValue = 5;

    [Range(0, 100)]
    public float stoneValue = 5;

    [Range(0, 100)]
    public float boneValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = woodValue.ToString();
        stoneText.text = stoneValue.ToString();
        boneText.text = boneValue.ToString();
    }
}
