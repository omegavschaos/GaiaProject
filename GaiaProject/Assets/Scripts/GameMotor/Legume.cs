using UnityEngine;
using System.Collections;

public class Legume : MonoBehaviour
{

    [SerializeField]
    private float _catalyse = 1;

    [SerializeField]
    private int _nbMaxRecolte = 3;
    [SerializeField]
    private int _nbRecolte;
    [SerializeField]
    private int _recolte = 5;

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

    private float _timeState;

	// Use this for initialization
	void Start ()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Reset();
    }

    void Reset()
    {
        _nbRecolte = _nbMaxRecolte;
        _timeState = 0;
        _spriteRenderer.sprite = State0;
    }

	// Update is called once per frame
	void Update ()
	{
	    _timeState += _catalyse*Time.deltaTime;
        StateManage();
	}

    void StateManage()
    {

        if (_state < 1)
        {
            if (_timeState > LittleLife)
            {
                _spriteRenderer.sprite = State1;
                _timeState = 0;
                _state ++;
                return;
            }
            return;
        }

        if (_state < 2)
        {
            if (_timeState > MidLife)
            {
                _spriteRenderer.sprite = State2;
                _timeState = 0;
                _state ++;
                return;
            }
            return;
        }

        if (_state < 3)
        {
            if (_timeState > FullLife)
            {
                _spriteRenderer.sprite = State3;
                _timeState = 0;
                _state++;
                return;
            }
            return;
        }

        if (_timeState > Death)
        {
            _spriteRenderer.sprite = State0;
            _timeState = 0;
            _state = 0;
        }
    }

    public int Recolter()
    {
        if (_state == 2)
        {
            Destroy(gameObject);
            return Mathf.FloorToInt(_catalyse*_recolte);
        }
        else
            return -1;
    }

}
