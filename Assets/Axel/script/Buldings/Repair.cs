using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    private List<bool> _caseTake = new List<bool> { false,  false,  false};
    public List<bool> caseTake
    {
        get
        {
            return _caseTake;
        }
        set
        {
            _caseTake = value;
        }
    }
    private Transform[] statePos;
    void Start()
    {
        //Debug.Log(TerrainManager.Instance.builds);
        TerrainManager.Instance.builds.Add(transform);
        EnnemisManager.Instance.destination = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
