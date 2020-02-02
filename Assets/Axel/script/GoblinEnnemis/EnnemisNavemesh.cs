using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisNavemesh : MonoBehaviour
{
    private NavMeshAgent _angent;
    private Transform _destTrans = null;
    private Vector3 _destination = Vector3.zero;
    private float _timeTodestroy = 1;
    private int _damage = 1;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float _wait;

    public enum State{FindATarget, GoToTarget, Destruct}
    public State state;

    Rigidbody rb;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        EnnemisManager.Instance.ennemis.Add(this);
        TheGameManager.Instance.ennemyNM = this;
        _damage = WavesManager.Instance.mobsPVDmg;
        _timeTodestroy = WavesManager.Instance.mobsDeathTime;
        _wait = Time.time;
        findfocus();
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(state)
        {
            case State.GoToTarget:
            if(_angent.remainingDistance < 0.1f)
            {
                ChangeState(State.Destruct);
            }
            break;
        }
    }

    void Update()
    {
        if(_angent.velocity.z >= 0)
        {
            animator.SetBool("WalkUp", true);
            animator.SetBool("WalkDown", false);
        }
        else if(_angent.velocity.z < 0)
        {
            animator.SetBool("WalkDown", true);
            animator.SetBool("WalkUp", false);
        }

        if(_angent.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(_angent.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    public void checkFocusExist()
    {
       
        if (TerrainManager.Instance.builds.IndexOf(_destTrans) == -1)
        {
            
            findfocus();
        }
    }
    void ChangeState(State newState)
    {
        switch(newState)
        {
            case State.GoToTarget:
            break;

            case State.Destruct:
            _angent.isStopped = true;
            animator.SetBool("Hit", true);
                StartCoroutine(Timer2());
            break;
        }
        state = newState;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.01f);
        ChangeState(State.GoToTarget);
    }
    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(_timeTodestroy);
        if (_destTrans != null)
        {
            _destTrans.GetComponent<Repair>().kill(_damage);
        }
        EnnemisManager.Instance.ennemis.Remove(this);
        Destroy(gameObject);

    }
    private void findfocus()
    {
        _destination = Vector3.zero;
        _angent = GetComponent<NavMeshAgent>();
        float _size = TerrainManager.Instance.size;
        rb = GetComponent<Rigidbody>();
        foreach (Transform t in TerrainManager.Instance.builds)
        {
            Repair build = t.GetComponent<Repair>();
            if (!build.caseTake[0])
            {
                build.caseTake[0] = true;
                _destination = t.position + Vector3.left * _size;
                _destTrans = t;
            }
            else if (!build.caseTake[1])
            {
                build.caseTake[1] = true;
                _destination = t.position + Vector3.back * _size;
                _destTrans = t;
            }
            else if (!build.caseTake[2])
            {
                build.caseTake[2] = true;
                _destination = t.position + Vector3.right * _size;
                _destTrans = t;
            }
            if (_destination != Vector3.zero)
            {
                break;
            }
        }
        _angent.SetDestination(_destination);
    }
    
}
