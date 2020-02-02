using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));
        GetComponent<Animator>().SetTrigger("Anim");
    }
}
