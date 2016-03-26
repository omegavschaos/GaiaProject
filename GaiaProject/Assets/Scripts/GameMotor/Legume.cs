using UnityEngine;
using System.Collections;

public class Legume : MonoBehaviour
{

    [SerializeField]
    private float _catalyse = 1;

    public float LittleLife = 5;
    public float MidLife = 5;
    public float FullLife = 10;
    public float Death = 5;

    public LegumeManager.Type Type;
    [SerializeField]
    private int _state = 0;

    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private Sprite State0;
    [SerializeField]
    private Sprite State1;
    [SerializeField]
    private Sprite State2;
    [SerializeField]
    private Sprite State3;

    private float TimeSeed;

	// Use this for initialization
	void Start ()
	{
	    TimeSeed = Time.time;
	    _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = State0;
    }
	
	// Update is called once per frame
	void Update () {
        StateManage();
	}

    void StateManage()
    {

        if (_state < 1)
        {
            if (TimeSeed + LittleLife < Time.time)
            {
                _spriteRenderer.sprite = State1;
                _state ++;
                return;
            }
            return;
        }

        if (_state < 2)
        {
            if (TimeSeed + LittleLife + MidLife < Time.time)
            {
                _spriteRenderer.sprite = State2;
                _state ++;
                return;
            }
            return;
        }

        if (_state < 3)
        {
            if (TimeSeed + LittleLife + MidLife + FullLife < Time.time)
            {
                _spriteRenderer.sprite = State3;
                _state++;
                return;
            }
            return;
        }
        
        if (TimeSeed + LittleLife + MidLife + FullLife +Death < Time.time)
        {
            _spriteRenderer.sprite = State0;
            TimeSeed = Time.time;
            _state = 0;
        }
    }
}
