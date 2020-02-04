using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject OptionPanel;
    [SerializeField] private GameObject CreditPanel;

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
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Options()
    {
        OptionPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void GoToMainMenu()
    {
        OptionPanel.SetActive(false);
        CreditPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Credits()
    {
        CreditPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
