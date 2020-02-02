using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wave_count : MonoBehaviour
{

    public int _waveCount = 0;
    [SerializeField] private TextMeshProUGUI _printWave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _printWave.text = WavesManager.Instance.wave.ToString();
    }
}
