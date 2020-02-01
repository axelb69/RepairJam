using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisMoves : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private float _speedSteep = 0.1f;
    [SerializeField] private float _speedWalk = 1;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {          
            StartCoroutine(WaitForSec());
            transform.position = GetNewPostion();
            canMove = false;
        }
    }
    private Vector3 GetNewPostion()
    {
        if (Mathf.Abs(transform.position.x - target.position.x) == Mathf.Abs(transform.position.z - target.position.z))
        {
            return transform.position - new Vector3((transform.position.x - target.position.x)/Mathf.Abs((transform.position.x - target.position.x) * 4) ,
                0,
                (transform.position.z - target.position.z) / Mathf.Abs((transform.position.z - target.position.z) * 4));
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.position.x) < Mathf.Abs(transform.position.z - target.position.z))
            {
                if (transform.position.z <= target.position.z)
                {
                    return transform.position + new Vector3(0, 0, _speedSteep);
                }
                else
                {
                    return transform.position - new Vector3(0, 0, _speedSteep);
                }
            }
            else
            {
                if (transform.position.x <= target.position.x)
                {
                    return transform.position + new Vector3(_speedSteep, 0, 0);
                }
                else
                {
                    return transform.position - new Vector3(_speedSteep, 0, 0);
                }
            }
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(_speedWalk);
        canMove = true;
    }
}
