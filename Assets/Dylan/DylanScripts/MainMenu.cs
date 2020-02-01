using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        EditorSceneManager.LoadScene(1);
    }

    public void Restart()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        EditorSceneManager.LoadScene(0);
    }
}
