using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        transform.GetChild(5).GetChild(1).GetComponent<Text>().text = scoreText.text;
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
