using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisNavemesh : MonoBehaviour
{
    private NavMeshAgent _angent;
    private Transform _destination;
    // Start is called before the first frame update
    void Start()
    {
        _angent = GetComponent<NavMeshAgent>();
        _angent.SetDestination(_destination.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
