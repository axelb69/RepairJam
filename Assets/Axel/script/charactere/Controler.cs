using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb = null;
    void Update()
    {
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movePos = Vector3.Normalize(movePos);
        movePos *= _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movePos);
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && other.gameObject.layer == 8)
        {
            InventoryManager.Instance.slots[1] += 2;
           Debug.Log(InventoryManager.Instance.slots[1]);
            TerrainManager.Instance.builds[TerrainManager.Instance.builds.IndexOf(other.gameObject.transform)].transform.position +=  Vector3.up;
        }
    }
}
