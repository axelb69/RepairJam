using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class TerrainManager : Singleton<TerrainManager>
{
    private List<Transform> _builds = new List<Transform>();
    public List<Transform> builds { get { return _builds; } set { _builds = value; Debug.Log("new build");} }
}
