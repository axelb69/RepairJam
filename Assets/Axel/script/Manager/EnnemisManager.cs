using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class EnnemisManager : Singleton<EnnemisManager>
{
    private float _speed;
    public float speed { get { return _speed; } set { _speed = value; } }
    private List<EnnemisNavemesh> _ennemis = new List < EnnemisNavemesh > { };
    public List<EnnemisNavemesh> ennemis { get { return _ennemis; } set { _ennemis = value; } }
}
