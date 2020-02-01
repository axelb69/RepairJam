using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Animator _anim = null;
    void Update()
    {
        Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movePos = Vector3.Normalize(movePos);
        movePos *= _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movePos);
        if(movePos.x > 0)
        {
            _anim.SetBool("RIGHT", true);
            _anim.SetBool("LEFT", false);
        }
        else 
        {
            _anim.SetBool("LEFT", true);
            _anim.SetBool("RIGHT", false);
        }

        if(movePos.z > 0)
        {
            _anim.SetBool("UP", true);
            _anim.SetBool("DOWN", false);
        }
        else 
        {
            _anim.SetBool("DOWN", true);
            _anim.SetBool("UP", false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.E) && other.gameObject.layer == 8)
        {
            _anim.SetBool("HIT", true);
            InventoryManager.Instance.slots[1] += 2;
            Debug.Log(_anim.GetBool("HIT"));
            //TerrainManager.Instance.builds[TerrainManager.Instance.builds.IndexOf(other.gameObject.transform)].transform.position +=  Vector3.up;
        }
        else _anim.SetBool("HIT", false);
    }
}
