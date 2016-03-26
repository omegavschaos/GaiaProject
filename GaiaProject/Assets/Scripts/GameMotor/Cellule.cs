using System;
using UnityEngine;
using System.Collections;

public class Cellule : MonoBehaviour
{

    public Legume Legume;
    [SerializeField]
    private float _quality;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Planter(Legume legume)
    {
        Legume = legume;
    }

    public int GetQuality()
    {
        return Mathf.FloorToInt(_quality);
    }
}
