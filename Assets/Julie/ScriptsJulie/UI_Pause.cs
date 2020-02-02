using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Pause : MonoBehaviour
{
    private bool _isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
           _isPaused = !_isPaused;

        if (_isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
