using System.Collections;
using System.Collections.Generic;
using Engine.Utils;
using UnityEngine;

public class WavesManager : Singleton<WavesManager>
{
    [SerializeField] private int _wave = 1;

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
    [SerializeField] private float _mobsDeathTime = 0f;

    //PV - MAX huttes
    [SerializeField] private AnimationCurve _maxPVHouse = AnimationCurve.Linear(0, 2, 15, 30);
    public AnimationCurve maxPVHouse { get { return _maxPVHouse; } set { _maxPVHouse = value; } }

    //PV - MAX barrière
    [SerializeField] private AnimationCurve _maxPVBarriere = AnimationCurve.Linear(0, 2, 15, 30);
    public AnimationCurve maxPVBarriere { get { return _maxPVBarriere; } set { _maxPVBarriere = value; } }

    // HUTTE 1 - Prix & Loot Bois
    [SerializeField] private AnimationCurve _h1PriceWood = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h1PriceWood { get { return _h1PriceWood; } set { _h1PriceWood = value; } }

    // HUTTE 1 - Prix & Loot Pierre
    [SerializeField] private AnimationCurve _h1PriceStone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h1PriceStone { get { return _h1PriceStone; } set { _h1PriceStone = value; } }

    // HUTTE 1 - Prix & Loot Os
    [SerializeField] private AnimationCurve _h1PriceBone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h1PriceBone { get { return _h1PriceBone; } set { _h1PriceBone = value; } }

    // HUTTE 2 - Prix & Loot Bois
    [SerializeField] private AnimationCurve _h2PriceWood = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h2PriceWood { get { return _h2PriceWood; } set { _h2PriceWood = value; } }

    // HUTTE 2 - Prix & Loot Pierre
    [SerializeField] private AnimationCurve _h2PriceStone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h2PriceStone { get { return _h2PriceStone; } set { _h2PriceStone = value; } }

    // HUTTE 2 - Prix & Loot Os
    [SerializeField] private AnimationCurve _h2PriceBone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h2PriceBone { get { return _h2PriceBone; } set { _h2PriceBone = value; } }

    // HUTTE 3 - Prix & Loot Bois
    [SerializeField] private AnimationCurve _h3PriceWood = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h3PriceWood { get { return _h3PriceWood; } set { _h3PriceWood = value; } }

    // HUTTE 3 - Prix & Loot Pierre
    [SerializeField] private AnimationCurve _h3PriceStone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h3PriceStone { get { return _h3PriceStone; } set { _h3PriceStone = value; } }

    // HUTTE 3 - Prix & Loot Os
    [SerializeField] private AnimationCurve _h3PriceBone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve h3PriceBone { get { return _h3PriceBone; } set { _h3PriceBone = value; } }

    // BARRIERE - Prix & Loot Os
    [SerializeField] private AnimationCurve _bPriceBone = AnimationCurve.Linear(0, 1, 15, 20);
    public AnimationCurve bPriceBone { get { return _bPriceBone; } set { _bPriceBone = value; } }
}

