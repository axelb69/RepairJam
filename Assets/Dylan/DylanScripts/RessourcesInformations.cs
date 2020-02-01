using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesInformations : MonoBehaviour
{
    [SerializeField]
    private int[] _ressourcesInformations = new int[]{0,0,0};
    public int[] ressourcesInformations{get{return _ressourcesInformations;} set{_ressourcesInformations = value;}}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
