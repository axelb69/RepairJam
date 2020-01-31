using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotateVector = Input.mousePosition;
        rotateVector.z = 50;
        rotateVector = Camera.main.ScreenToWorldPoint(rotateVector);
        mousePosition.position = rotateVector;
        //_transcenter.LookAt(rotateVector);
        /*RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            mousePosition.position = hit.transform.position;
            // Do something with the object that was hit by the raycast.
        }*/
    }
}
