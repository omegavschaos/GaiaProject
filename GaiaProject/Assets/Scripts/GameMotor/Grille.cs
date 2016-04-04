using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using LegumeEngine;

public class Grille : MonoBehaviour
{

    private static Grille _instance = null;


    [SerializeField]
    private GameObject _prefabTerrain;

    public int Largeur = 6;
    public int Longueur = 5;
    


    private Cellule[,] _matrice;  

    // Use this for initialization
    void Start () {

        if (_instance)
            Destroy(_instance);
        _instance = this;

        GenerateTerrain();
	}

	public static Grille GetInstance(){
		return _instance;
	}

    private void GenerateTerrain()
    {
        Vector3 diffVector3 = new Vector3(-0.5f + 1/(float)Largeur/2,0,-0.5f+1/(float)Longueur/2);
        _matrice = new Cellule[Largeur,Longueur];
        for (int i = 0; i < Largeur; i++)
        {
            for (int j = 0; j < Longueur; j++)
            {
                GameObject cell = Instantiate(_prefabTerrain);
                cell.transform.SetParent(gameObject.transform,false);
                cell.transform.localScale = new Vector3(x: 1/(float)Largeur, y: 0.1f, z: 1/(float)Longueur);
                cell.name = "cellule " + i + " " + j;
                
                _matrice[i,j] = cell.GetComponent<Cellule>();
                _matrice[i,j].Position = new KeyValuePair<int, int>(i,j);
                cell.transform.localPosition += diffVector3 + i * 1/(float)Largeur * cell.transform.right + j * 1/(float)Longueur * cell.transform.forward;
            }
        }

    }

    public Cellule GetCellule(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < Largeur && y < Longueur)
            return _matrice[x, y];
        return null;
    }

    // Update is called once per frame
	void Update () {
	
	}
}
