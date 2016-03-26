using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour
{

    private Transform _target;

	// Use this for initialization
	void Start ()
	{
	    _target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_target)
	    {
	        transform.LookAt(_target,_target.up);
	        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,0,0);
	    }
	}
}
