using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSpawn : MonoBehaviour
{
    [SerializeField] private float _TimebetweenWave = 30;
    [SerializeField] private float _timeBetweenSpawn = 6;
    [SerializeField] private GameObject _ennemisObject = null;
    [SerializeField] private Transform[] _spawnerPoint = null;
    [SerializeField] private int _ennemySpawnnumber = 3;
    private int _ennemySpawn = 0;
    private bool _onWave = false;
    private bool _preparNewWave = true;
    private float _reachTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        OnNewWave();
        _reachTime = Time.time + _timeBetweenSpawn;
    }

    // Update is called once per frame
    private void Update()
    {

        if (_preparNewWave)
        {
            _preparNewWave = false;
            StartCoroutine(Timer());
        }
        if (_onWave)
        {
            Onwave();
        }
    }

    void Onwave()
    {
        if (Time.time >= _reachTime && _ennemisObject != null )
        {
            if (_ennemySpawnnumber > _ennemySpawn)
            {
                _ennemySpawn++;
                int index = Random.Range(0, _spawnerPoint.Length - 1);
                Vector3 spawnPos = _spawnerPoint[index].position;
                _reachTime = Time.time + _timeBetweenSpawn;
                Instantiate(_ennemisObject, spawnPos, Quaternion.identity, transform);
            }
            else
            {
                _onWave = false;
                _ennemySpawn = 0;
            }
        }
        
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_TimebetweenWave);
        Debug.Log("a");
        WavesManager.Instance.wave++;
        OnNewWave();
        
        _onWave = true;
        _preparNewWave = true;
    }

    public void OnNewWave()
    {
        int wave = WavesManager.Instance.wave;
        _TimebetweenWave = WavesManager.Instance.tempsWaves.Evaluate(wave);
        _ennemySpawnnumber = (int) WavesManager.Instance.mobNumber.Evaluate(wave);
        _timeBetweenSpawn = WavesManager.Instance.timeBetweenMobs.Evaluate(wave);
        TheGameManager.Instance.controler.OnNewWave();
        TerrainManager.Instance.pointDeVie = (int)WavesManager.Instance.maxPVHouse.Evaluate(wave);
        EnnemisManager.Instance.speed = WavesManager.Instance.mobSpeed.Evaluate(wave);

    }
}
