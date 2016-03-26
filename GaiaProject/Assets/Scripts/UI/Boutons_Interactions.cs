using UnityEngine;
using System.Collections;

public class Boutons_Interactions : MonoBehaviour {

	void Jouer () {
		Debug.Log ("aaa");
		Application.LoadLevel("Ecran_Jeu");
	}

	void A_propos () {
		Debug.Log ("bbb");
		Application.LoadLevel("Ecran_Propos");
	}

	void Quitter () {
		Debug.Log ("ccc");
		Application.Quit();
	}
}
