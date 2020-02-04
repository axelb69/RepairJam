using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private string[] tipsList;

    [SerializeField]
    private Text scoreTextHolder;

    // Start is called before the first frame update
    void Start()
    {
        //AudioManager.Instance.audioSouce.Play(AudioManager.Instance.clips[])
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
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
        scoreTextHolder.transform.parent.gameObject.SetActive(true);
        int quote = Random.Range(0, tipsList.Length -1 );
        scoreTextHolder.text = tipsList[quote];
    }

}
