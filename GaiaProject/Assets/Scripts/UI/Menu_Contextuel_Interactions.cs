using UnityEngine;
using System.Collections;

public class Menu_Contextuel_Interactions : MonoBehaviour {

	GameObject Menu1;
	GameObject Menu2;
	GameObject Menu3;

	// Use this for initialization
	void Start () {
		Menu1 = GameObject.Find ("/UI/Canvas/MenuContextuel/MenuContextuelJauge");
			Menu2 = GameObject.Find ("/UI/Canvas/MenuContextuel/MenuContextuelStock");
			Menu3 = GameObject.Find ("/UI/Canvas/MenuContextuel/MenuContextuelTerrain");
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/



		void Jauges () {

			Menu1.SetActive(true);
			Menu2.SetActive(false);
			Menu3.SetActive(false);
		}

		void InfoTerrain () {
		Menu1.SetActive(false);
		Menu2.SetActive(false);
		Menu3.SetActive(true);
		}

		void Stock () {
		Menu1.SetActive(false);
		Menu2.SetActive(true);
		Menu3.SetActive(false);

	}
}
