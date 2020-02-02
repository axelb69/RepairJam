using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesInformations : MonoBehaviour
{
    
    enum _type { Bone ,Stone ,Wood}
    [SerializeField] private _type _materialOf;


    private int _ressourcesInformations = 0;
    public int ressourcesInformations{get{return _ressourcesInformations;} set{_ressourcesInformations = value;}}
    // Start is called before the first frame update

}
