using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class EnnemisManager : Singleton<EnnemisManager>
{
    private Transform _destination = null;
    public Transform destination { get { return _destination; } set { _destination = value; } }  
}
