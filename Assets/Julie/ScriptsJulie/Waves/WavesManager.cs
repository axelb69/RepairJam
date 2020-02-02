using System.Collections;
using System.Collections.Generic;
using Engine.Utils;
using UnityEngine;

public class WavesManager : Singleton<WavesManager>
{
    [SerializeField] private int _wave = 1;
    public int wave { get { return _wave; } set { _wave = value; } }

    //Tps de constructions des maisons en SECONDES
   [SerializeField] private AnimationCurve _houseConstructTime = AnimationCurve.Linear(0, 1, 15, 10);
   public AnimationCurve houseConstructTime { get { return _houseConstructTime; } set { _houseConstructTime = value; } }

    //Tps entre waves en SECONDES
   [SerializeField] private AnimationCurve _tempsWaves = AnimationCurve.Linear(0, 30, 15, 120);
   public AnimationCurve tempsWaves { get { return _tempsWaves; } set { _tempsWaves = value; } }

    //Nombre des mobs par waves en GOBELIN
    [SerializeField] private AnimationCurve _mobNumber = AnimationCurve.Linear(0, 0, 15, 50);
    public AnimationCurve mobNumber { get { return _mobNumber; } set { _mobNumber = value; } }

    //Tps entre mobs apparitions en SECONDES
    [SerializeField] private AnimationCurve _timeBetweenMobs = AnimationCurve.Linear(0, 0, 15, 2);
    public AnimationCurve timeBetweenMobs { get { return _timeBetweenMobs; } set { _timeBetweenMobs = value; } }

    //Speed mobs --> waves en VITESSE
    [SerializeField] private AnimationCurve _mobSpeed = AnimationCurve.Linear(0, 5, 15, 20);
    public AnimationCurve mobSpeed { get { return _mobSpeed; } set { _mobSpeed = value; } }

    //Speed charac --> waves en VITESSE
    [SerializeField] private AnimationCurve _characSpeed = AnimationCurve.Linear(0, 5, 15, 20);
    public AnimationCurve characSpeed { get { return _characSpeed; } set { _characSpeed = value; } }

    //PV - DEGATS --> ennemis & temps pour mourir en SECONDES
    [SerializeField] private int _mobsPVDmg = 0;
    public int mobsPVDmg { get { return _mobsPVDmg; } set { _mobsPVDmg = value; } } 

    [SerializeField] private float _mobsDeathTime = 0f;
    public float mobsDeathTime { get { return _mobsDeathTime; } set { _mobsDeathTime = value; } }


    //PV - MAX huttes
    [SerializeField] private AnimationCurve _maxPVHouse = AnimationCurve.Linear(0, 2, 15, 30);
    public AnimationCurve maxPVHouse { get { return _maxPVHouse; } set { _maxPVHouse = value; } }

    //PV - MAX barrière
    [SerializeField] private AnimationCurve _maxPVBarriere = AnimationCurve.Linear(0, 2, 15, 30);
    public AnimationCurve maxPVBarriere { get { return _maxPVBarriere; } set { _maxPVBarriere = value; } }

    
}

