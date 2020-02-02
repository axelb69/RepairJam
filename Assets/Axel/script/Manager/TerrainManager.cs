using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class TerrainManager : Singleton<TerrainManager>
{
    [SerializeField] private float _size = 7;
    public float size { get { return _size; } }
    private List<Transform> _builds = new List<Transform>();
    public List<Transform> builds { get { return _builds; } set { _builds = value; Debug.Log("new build");} }
    private List<bool> _full = new List<bool>();
    public List<bool> full { get { return _full; } set { _full = value; } }   
}

