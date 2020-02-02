using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField] private Sprite[] _statSprite;
    [SerializeField] private SpriteRenderer _render;
    private int _stat = 0;
    public int stat
    {
        get
        {
            return _stat;
        }
        set
        {
            _stat = value;
        }
    }
    private int _lifePoints = 0;
    private List<bool> _caseTake = new List<bool> { false,  false,  false};
    public List<bool> caseTake
    {
        get
        {
            return _caseTake;
        }
        set
        {
            _caseTake = value;
        }
    }
    private Transform[] statePos;
    void Start()
    {
        SetAsset();
    }

    // Update is called once per frame
    public void Upgrade()
    {
        TerrainManager.Instance.builds.Add(transform);
        EnnemisManager.Instance.destination = transform;
        SetAsset();
    }
    private void SetAsset()
    {
        _render.sprite = _statSprite[_stat];                 
    }

}
