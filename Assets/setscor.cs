using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setscor : MonoBehaviour
{
    [SerializeField] private Text txt;
    private void Update()
    {
        txt.text = TheGameManager.Instance.scor.ToString();
    }
}
