﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemisNavemesh : MonoBehaviour
{
    private NavMeshAgent _angent;
    private Vector3 _destination = Vector3.zero;

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
        _wait = Time.time;
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

    void ChangeState(State newState)
    {
        switch(newState)
        {
            case State.GoToTarget:
            break;

            case State.Destruct:
            _angent.isStopped = true;
            animator.SetBool("Hit", true);
            break;
        }
        state = newState;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.01f);
        ChangeState(State.GoToTarget);
    }
}
