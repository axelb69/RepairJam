using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Animator _anim = null;

    private Repair _focus = null;
    enum State{Normal, Build}
    State state;
    private float _newtime;

    private void Start()
    {
        TheGameManager.Instance.controler = this;
    }

    void Update()
    {
        switch(state)
        {
            case State.Normal:
                Vector3 movePos = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                movePos = Vector3.Normalize(movePos);
                movePos *= _speed * Time.deltaTime;
                _rb.MovePosition(transform.position + movePos);
                if(movePos != Vector3.zero)
                {
                    if(movePos.x > 0)
                    {
                        _anim.SetBool("RIGHT", true);
                        _anim.SetBool("LEFT", false);
                        //_anim.SetBool("Idle", false);
                    }
                    else 
                    {
                        _anim.SetBool("LEFT", true);
                        _anim.SetBool("RIGHT", false);
                        //_anim.SetBool("Idle", false);
                    }

                    if(movePos.z > 0)
                    {
                        _anim.SetBool("UP", true);
                        _anim.SetBool("DOWN", false);
                    //_anim.SetBool("Idle", false);
                    }
                    else 
                    {
                        _anim.SetBool("DOWN", true);
                        _anim.SetBool("UP", false);
                    //_anim.SetBool("Idle", false);
                    }
                    _anim.SetBool("Idle", false);
                }
                else {_anim.SetBool("Idle", true); _anim.SetBool("UP", false); _anim.SetBool("DOWN", false); _anim.SetBool("LEFT", false); _anim.SetBool("RIGHT", false);}
                /*else if(movePos.x > 0 && movePos.y > 0)
                {_anim.SetBool("Idle", true); _anim.SetBool("UP", false); _anim.SetBool("DOWN", false); _anim.SetBool("LEFT", false); _anim.SetBool("RIGHT", false);}*/
            break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if((Input.GetKeyDown(KeyCode.E)|| Input.GetButtonDown("Fire1")&& other.gameObject.layer == 8))
        {
            ChangeState(State.Build);
            //_anim.SetBool("HIT", true);
            //InventoryManager.Instance.slots[1] += 2;
            //Debug.Log(_anim.GetBool("HIT"));
            //Debug.Log(other.gameObject.GetComponent<Repair>());
            _focus = other.gameObject.GetComponent<Repair>();
            
            
        }
        //else _anim.SetBool("HIT", false);
    }

    void ChangeState(State newState)
    {
        switch(newState)
        {
            case State.Normal:
            _anim.SetBool("HIT", false);
                if(_focus != null)
                {
                    if (_focus.stat==0)
                    {
                        _focus.stat = 2;
                        _focus.Upgrade();
                        _focus = null;
                    }
                   
                }
            break;

            case State.Build:
            StartCoroutine("RepairTimer", 1);
            break;
        }
        state = newState;
    }

    IEnumerator RepairTimer(float time)
    {
        _anim.SetBool("HIT", true);
        yield return new WaitForSeconds(_newtime);
        ChangeState(State.Normal);
    }

    public void OnNewWave ()
    {
        int wave = WavesManager.Instance.wave;
        _newtime = WavesManager.Instance.houseConstructTime.Evaluate(wave);
        _speed = WavesManager.Instance.characSpeed.Evaluate(wave);
    }

}
