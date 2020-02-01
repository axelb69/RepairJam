using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseConstructionTime : MonoBehaviour
{
    [SerializeField] private AnimationCurve _houseConstructionTime = AnimationCurve.Linear(0, 10, 15, 500);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
