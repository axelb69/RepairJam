using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField] private bool goodHouse;
    [SerializeField] private Sprite[] _statSprite;
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private GameObject[] _clone = null;
    [SerializeField] private int[] _price;

    [SerializeField] private int _osLoot = 0;
    [SerializeField] private int _stoneLoot = 0;
    [SerializeField] private int _woodLoot = 0;
    private ParticleSystem ps = null;

    public int[] price { get { return _price; } }
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
        if (goodHouse) { _stat = 2; TerrainManager.Instance.builds.Add(transform); } else { loot(); }
        ps = GetComponent<ParticleSystem>();
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
        ps.Play();
        SetAsset();
    }

    private void SetAsset()
    {
        _render.sprite = _statSprite[_stat];
    }
    public void kill(int damage)
    {
        if (  _stat > 0)
        { 
            _caseTake = new List<bool> { false, false, false };
            _lifePoints -= damage;
            if (_lifePoints < _maxPv)
            {
            _stat = 1;
                ps.Play();
                SetAsset();
            }
            if (_lifePoints <= 0)
            {
                _stat = 0;
                ps.Play();
                SetAsset();
                TerrainManager.Instance.builds.Remove(transform);
                loot();
                foreach (EnnemisNavemesh e in EnnemisManager.Instance.ennemis)
                {
                    e.checkFocusExist();
                }   
           
            }
        }
    }
    private void loot()
    {
        GameObject loot;
        loot = Instantiate(_clone[0], transform.position + Vector3.right * TerrainManager.Instance.size, Quaternion.identity, transform);
        loot.GetComponent<bone>().cunt = _osLoot;
        loot = Instantiate(_clone[1], transform.position + Vector3.left * TerrainManager.Instance.size, Quaternion.identity, transform);
        loot.GetComponent<stone>().cunt = _stoneLoot;
        loot = Instantiate(_clone[2], transform.position + Vector3.back * TerrainManager.Instance.size, Quaternion.identity, transform);
        loot.GetComponent<Wood>().cunt = _woodLoot;
    }
}