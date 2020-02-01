using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawn : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn = 1;
    [SerializeField] private GameObject _ennemisObject = null;

    private float _reachTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        _reachTime = Time.time + _timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= _reachTime && _ennemisObject != null)
        {
            _reachTime = Time.time + _timeBetweenSpawn;
            Instantiate(_ennemisObject, transform.position, Quaternion.identity, transform);
        }
    }
}
