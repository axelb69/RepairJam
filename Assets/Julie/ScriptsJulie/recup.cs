using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class recup : MonoBehaviour
{
    [SerializeField] private int _waves = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WavesManager.Instance.houseConstructTime.Evaluate(_waves));
    }
}
