using System;
using UnityEngine;
using System.Collections;

public class LegumeManager : MonoBehaviour
{

    private static LegumeManager _instance = null;

    public enum Type
    {
        Tomate,Radis,Absynthe,Aromatique,Fraise, Abricot, PommeDeTerre
    } 


	// Use this for initialization
	void Start ()
	{
        if(_instance)
            Destroy(_instance);
	    _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public static LegumeManager GetInstance()
    {
        return _instance;
    }
}
