using System.Collections;
using System.Collections.Generic;
using Engine.Utils;
using UnityEngine;

public class WavesManager : Singleton<WavesManager>
{
    //Tps de constructions des maisons en SECONDES
   [SerializeField] private AnimationCurve _houseConstructionTime = AnimationCurve.Linear(0, 1, 15, 10);
   public AnimationCurve houseConstructionTime { get { return _houseConstructionTime; } set { _houseConstructionTime = value; } }

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


}
