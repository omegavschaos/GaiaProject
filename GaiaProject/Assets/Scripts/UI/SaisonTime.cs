using UnityEngine;
using System.Collections;

public class SaisonTime : MonoBehaviour {
	private static SaisonTime _instance = null;

	[Range(0,1)]
	public float Position;

	public float TimeYear = 720; //720 sec = 12 minutes // 1 mois = 1 minute

	private int _years = 0;
	private int _month = 0;
	private float _beginTime;
	private RectTransform _trans;
	// Use this for initialization
	void Start () {

		if (_instance)
			Destroy (_instance);
		
		_instance = this;

		_beginTime = Time.time;
		_trans = GetComponent<RectTransform> ();
	}

	public static SaisonTime GetInstance(){
		return _instance;
	}

	// Update is called once per frame
	void Update () {
	}

	private void CalcTime(){
		_years = Mathf.FloorToInt((Time.time - _beginTime) / 720f);
		_month = Mathf.FloorToInt((Time.time - _beginTime) % 720f /720f * 12f);
	
		_trans.anchorMin = new Vector2(Position - 0.03f * (Position), 0);
		_trans.anchorMax = new Vector2(Position + 0.03f * (1 - Position), 1);
	}

	public int GetYear(){
		return _years;
	}

	public int GetMonth(){
		return _month;
	}
}
