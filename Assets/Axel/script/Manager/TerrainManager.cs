using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class TerrainManager : Singleton<TerrainManager>
{
    private List<Transform> _builds;
    public List<Transform> builds { get { return _builds; } set { _builds = value; } }
}
