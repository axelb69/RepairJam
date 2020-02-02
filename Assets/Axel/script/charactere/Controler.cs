using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Animator _anim = null;

    private Repair _focus = null;
    enum State{Normal, Build, Pause, Dead}
    State state;
    private bool contruct = false;
    private float _newtime;
    bool showInteraction;
    GameObject rien;

    [SerializeField] private GameObject interactionLogo;

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
        if(other.gameObject.layer == 8 && !showInteraction)
        {
            Destroy(rien);
            rien = Instantiate(interactionLogo);
            rien.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 5, other.transform.position.z - 5);
            showInteraction = true;

            if ((Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire1")))
            {
                if (other.gameObject.GetComponent<Repair>() != null)
                {
                    if (InventoryManager.Instance.slots[0] >= other.gameObject.GetComponent<Repair>().price[0] &&
                    InventoryManager.Instance.slots[1] >= other.gameObject.GetComponent<Repair>().price[1] &&
                    InventoryManager.Instance.slots[2] >= other.gameObject.GetComponent<Repair>().price[2]&& ! contruct)
                    {
                        contruct = true;
                        InventoryManager.Instance.slots[0] -= other.gameObject.GetComponent<Repair>().price[0];
                        InventoryManager.Instance.slots[1] -= other.gameObject.GetComponent<Repair>().price[1];
                        InventoryManager.Instance.slots[2] -= other.gameObject.GetComponent<Repair>().price[2];
                        ChangeState(State.Build);
                        //_anim.SetBool("HIT", true);
                        //InventoryManager.Instance.slots[1] += 2;
                        //Debug.Log(_anim.GetBool("HIT"));
                        //Debug.Log(other.gameObject.GetComponent<Repair>());
                        _focus = other.gameObject.GetComponent<Repair>();
                    }
                }
            }
        }
        //else _anim.SetBool("HIT", false);
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            Destroy(rien);
        }
    }
    void ChangeState(State newState)
    {
        switch(newState)
        {
            case State.Normal:
                contruct = false;
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
        AudioManager.Instance.audioSouce.clip = AudioManager.Instance.clips[6];
        AudioManager.Instance.audioSouce.Play();
        ChangeState(State.Normal);
    }

    public void OnNewWave ()
    {
        int wave = WavesManager.Instance.wave;
        _newtime = WavesManager.Instance.houseConstructTime.Evaluate(wave);
        _speed = WavesManager.Instance.characSpeed.Evaluate(wave);
    }

}
