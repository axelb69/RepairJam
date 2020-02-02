using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneskip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }
    IEnumerator time()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene(2);
    }
    
}
