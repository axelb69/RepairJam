using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisNavemesh : MonoBehaviour
{
    private NavMeshAgent _angent;
    private Vector3 _destination = Vector3.zero;
    private float _wait;
    // Start is called before the first frame update
    void Start()
    {
        _wait = Time.time;
        _angent = GetComponent<NavMeshAgent>();
        float _size = TerrainManager.Instance.size;
        foreach (Transform t in TerrainManager.Instance.builds)
        {
            Repair build = t.GetComponent<Repair>();
            if (!build.caseTake[0])
            {
                build.caseTake[0] = true;
                _destination = t.position + Vector3.left * _size;
            }
            else if (!build.caseTake[1])
            {
                build.caseTake[1] = true;
                _destination = t.position + Vector3.back * _size;
            }
            else if (!build.caseTake[2])
            {
                build.caseTake[2] = true;
                _destination = t.position + Vector3.right * _size;
            }
            if (_destination != Vector3.zero)
            {
                break;
            }
        }
        _angent.SetDestination(_destination);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
