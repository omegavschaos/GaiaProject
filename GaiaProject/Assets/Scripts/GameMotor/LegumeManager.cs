using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LegumeManager : MonoBehaviour
{

    private static LegumeManager _instance = null;

    public enum Type
    {
        Tomate,Radis,Absynthe,Aromatique,Fraise, Abricot, Pomme, PommeDeTerre
    }

    [SerializeField]
    private List<GameObject> _legumesPrefab;

    private Dictionary<Type, GameObject> _legumesDictionary; 

	// Use this for initialization
	void Start ()
	{
        if(_instance)
            Destroy(_instance);
	    _instance = this;

        _legumesDictionary = new Dictionary<Type, GameObject>();
	    foreach (var legume in _legumesPrefab)
	    {
	        Type type = legume.GetComponent<Legume>().Type;
            _legumesDictionary.Add(type,legume);
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetLegumePrefab(Type type)
    {
        return _legumesDictionary[type];
    }

    public static LegumeManager GetInstance()
    {
        return _instance;
    }
}
