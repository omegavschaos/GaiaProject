using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Boutons_Interactions : MonoBehaviour {


	///////////////////////////////////////////////////////////////
	/// Menu Principal

	void Jouer () {
		SceneManager.LoadScene("EcranJeu");
	}

	void A_propos () {
		SceneManager.LoadScene("EcranPropos");
	}

	void Quitter () {
		Application.Quit();
	}

	///////////////////////////////////////////////////////////////
	/// A propos

	void Retour () {
		SceneManager.LoadScene("MenuPrincipal");
	}


}
