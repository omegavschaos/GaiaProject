using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Grille : MonoBehaviour
{


    [SerializeField]
    private GameObject _prefabTerrain;

    public int Largeur = 5;
    public int Longueur = 5;

    private int _taille = 10;

    private Cellule[,] _matrice;  

    // Use this for initialization
    void Start () {

	    GenerateTerrain();
	}

    private void GenerateTerrain()
    {
        _matrice = new Cellule[Largeur,Longueur];
        for (int i = 0; i < Largeur; i++)
        {
            for (int j = 0; j < Longueur; j++)
            {
                GameObject cell = Instantiate(_prefabTerrain);
                cell.transform.SetParent(gameObject.transform,false);
                cell.transform.localScale = new Vector3(x: 1/(float)Largeur, y: 1, z: 1/(float)Longueur);
                cell.name = "cellule " + i + " " + j;
                _matrice[i,j] = cell.GetComponent<Cellule>();
                //cell.transform.;
            }
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
