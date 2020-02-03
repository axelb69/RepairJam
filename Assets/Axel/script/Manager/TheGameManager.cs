using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class TheGameManager : Singleton<TheGameManager>
{
    private Controler _controler;
    public Controler controler { get { return _controler; } set { _controler = value; } }

    private EnnemisNavemesh _ennemyNM;
    public EnnemisNavemesh ennemyNM { get { return _ennemyNM; } set { _ennemyNM = value; } }

    private Repair _repair;
    public Repair repair { get { return _repair; } set { _repair = value; } }

    private int _scor=0;
    public int scor { get { return _scor; } set { _scor = value; } }
}
