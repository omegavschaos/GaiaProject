using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragAndDropPlant : MonoBehaviour {


	public GameObject DragSlot;

	void Start () {

	}

	void Update () {

	}

	public void OnDrag(){ 

	
			transform.position = Input.mousePosition;










	}

	public void OnDrop(){ 


			GameObject DragObject = Instantiate (DragSlot);
			DragObject.transform.SetParent (transform.parent, false);
		DragObject.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0, 0);

	
			Destroy (this.gameObject);


	}


}

