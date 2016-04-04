using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace LegumeEngine
{
    public class DragAndDropPlant : MonoBehaviour
    {

        public LegumeManager.Type Type;

        public GameObject DragSlot;


        private void Start()
        {

        }

        private void Update()
        {

        }

        public void OnDrag()
        {
            GetComponent<Image>().color = new Color(1, 1, 1, 1);

            transform.position = Input.mousePosition;








        }

        public void OnDrop()
        {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Cellule toPlant = hit.collider.gameObject.GetComponent<Cellule>();
                toPlant.Planter(Type);
            }


            GameObject DragObject = Instantiate(DragSlot);
            DragObject.transform.SetParent(transform.parent, false);

            DragObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            DragObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

            Destroy(this.gameObject);


        }


    }
}
