using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlsAffichage : MonoBehaviour
{
    [SerializeField]
    private GameObject proController;
    [SerializeField]
    private GameObject Keyboard;
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == 0)
        {Keyboard.SetActive(true); proController.SetActive(false);}
        else
        {Keyboard.SetActive(false); proController.SetActive(true);}
    }

    public void CheckController()
    {
        /*if(type == 0)
        {Keyboard.SetActive(true); proController.SetActive(false);}
        else
        {Keyboard.SetActive(false); proController.SetActive(true);}*/
    }
}
