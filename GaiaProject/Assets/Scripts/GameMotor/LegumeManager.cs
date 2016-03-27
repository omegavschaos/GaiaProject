using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LegumeManager : MonoBehaviour
{

    private static LegumeManager _instance = null;

    public enum Type
    {
        Tomate,Radis,Absynthe,Aromatique,Fraise, Abricot, Pomme, PommeDeTerre, Haricot, Compost
	}

	public class Buff{
		public int Distance;
		public int Effect;
		public List<LegumeManager.Type> Targets;

		public Buff(int effect, int distance, List<LegumeManager.Type> targets){
			Distance = distance;
			Effect = effect;
			Targets = targets;
		}
	}

	public enum State{
		Pourri, Recolte, Graine, Pousse
	}

	public class Calendar : List<State>{
		public Calendar(int mGraine,int mPousse,int mRecolte, int mPourri){
			this.Capacity = 12;
			if(mPousse<mGraine){
				mPousse += 12;
				mRecolte += 12;
				mPourri += 12;
			}
			if(mRecolte<mGraine){
				mRecolte += 12;
				mPourri += 12;
			}
			if(mPourri<mGraine){
				mPourri += 12;
			}
			
			for(int i = mGraine;i<mPousse; i++){
				this[i%12] = State.Graine;
			}
			for(int i = mPousse;i<mRecolte; i++){
				this[i%12] = State.Recolte;
			}
			for(int i = mRecolte;i<mPourri; i++){
				this[i%12] = State.Recolte;
			}
			for(int i = mPourri;i<mGraine; i++){
				this[i%12] = State.Pourri;
			}

		}
	}


	public Dictionary<Type, int> _legumeProduct;
	public Dictionary<Type, List<Buff>> _legumeBuff;
	public Dictionary<Type, Calendar> _legumeCalendar;

    [SerializeField]
    private List<GameObject> _legumesPrefab;

    private Dictionary<Type, GameObject> _legumesDictionary; 
	public Dictionary<Type, int> Stock;

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

	void Init(){
		Type type;
		int dist;
		List<Type> targets;
		Buff buff;
		List<Type> deTargets;
		Buff deBuff;
		List<Buff> buffs;
		Calendar calendar;

		//TOMATE
		type = Type.Tomate;

		dist = 2;
		targets = new List<Type> ();
		targets.Add (Type.Radis);

		buff = new Buff (1, dist, targets);
		buffs = new List<Buff> ();

		buffs.Add (buff);

		deTargets = new List<Type> ();
		deTargets.Add (Type.PommeDeTerre);
		deTargets.Add (Type.Abricot);
		deBuff = new Buff (-1, 2, deTargets);

		buffs.Add (deBuff);

		_legumeProduct.Add (type, 8);
		_legumeBuff.Add (type, buffs);
		//_legumeCalendar.Add (type,new Calendar ());
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
