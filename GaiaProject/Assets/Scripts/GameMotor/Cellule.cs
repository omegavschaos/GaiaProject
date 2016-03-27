using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cellule : MonoBehaviour
{

    public Legume Legume;
    [SerializeField]
    private GameObject LegumePosition;
    [SerializeField]
    private float _quality;

    public KeyValuePair<int,int> Position;

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

    public void Supprimer()
    {
        Destroy(Legume.gameObject);
    }

    public void Recolter()
    {
        
    }

    public int Distance(Cellule cell)
    {
        int distX = Mathf.Abs(Position.Key - cell.Position.Key);
        int distY = Mathf.Abs(Position.Value - cell.Position.Value);
        return distX + distY;
    }

    public int GetQuality()
    {
        return Mathf.FloorToInt(_quality);
    }

    void OnMouseUp()
    {
    }
}
