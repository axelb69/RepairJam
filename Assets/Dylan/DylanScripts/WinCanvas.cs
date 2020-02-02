using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCanvas : MonoBehaviour
{
    [SerializeField]
    private Text quoteTextHolder;

    [SerializeField]
    private string[] quoteList;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start()
    {
        GenerateTip();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void OnEnable()
    {
        /*if(transform.GetChild(5).GetChild(1).GetComponent<Text>())
        {
            transform.GetChild(5).GetChild(1).GetComponent<Text>().text = scoreText.text;
        }*/
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GenerateTip()
    {
        int quote = Random.Range(0, quoteList.Length - 1);
        quoteTextHolder.text = quoteList[quote];
    }
}
