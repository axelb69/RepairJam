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
    private int _maxPv = 2;
    private int _lifePoints = 2;
    private List<bool> _caseTake = new List<bool> { false, false, false };
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
        TheGameManager.Instance.repair = this;
        SetAsset();
    }

    // Update is called once per frame
    public void Upgrade()
    {
        _maxPv = TerrainManager.Instance.pointDeVie;
        _lifePoints = 0;
        _lifePoints = _maxPv;
        TerrainManager.Instance.builds.Add(transform);

        SetAsset();
    }
    private void SetAsset()
    {
        _render.sprite = _statSprite[_stat];
    }
    public void kill(int damage)
    {
        _caseTake = new List<bool> { false, false, false };
        _lifePoints -= damage;
        if (_lifePoints < _maxPv)
        {
            _stat = 1;
            SetAsset();
        }
        if (_lifePoints <= 0)
        {
            _stat = 0;
            SetAsset();
            TerrainManager.Instance.builds.Remove(transform);
        }
    }
}