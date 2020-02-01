using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movePos = Vector3.Normalize(movePos);
        movePos *= _speed * Time.deltaTime;
        transform.Translate(movePos);
    }
}
