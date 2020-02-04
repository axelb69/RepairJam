using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneskip : MonoBehaviour
{
    // Start is called before the first frame update
    public void openscene()
    {
        SceneManager.LoadScene(2);
    }
}
