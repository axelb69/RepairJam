using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class EnnemisManager : Singleton<EnnemisManager>
{
    private float _speed;
    public float speed { get { return _speed; } set { _speed = value; } }
}
