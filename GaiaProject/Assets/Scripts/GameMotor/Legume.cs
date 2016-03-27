using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Legume : MonoBehaviour
{

    [SerializeField]
    private float _catalyse = 1;

    [SerializeField]
    private int _recolte = 5;

	public int LittleLife = 5;
	public int MidLife = 5;
	public int FullLife = 5;
	public int Death = 5;

    public LegumeManager.Type Type;

	public Engine.IntEvent OnState;

	

    [SerializeField]
	private LegumeManager.State _state = LegumeManager.State.Graine;

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
        //_nbRecolte = _nbMaxRecolte;
		_state = LegumeManager.State.Graine;
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
		
		/*/
		if (_state == LegumeManager.State.Graine)
        {
            if (_timeState > LittleLife)
            {
                _spriteRenderer.sprite = State1;
                _timeState = 0;
				OnState.Invoke(++_state);
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
				OnState.Invoke(++_state);
                return;
            }
            return;
        }
		//*
        if (_state < 3)
        {
            if (_timeState > FullLife)
            {
                _spriteRenderer.sprite = State3;
				_timeState = 0;
				OnState.Invoke(++_state);
                return;
            }
            return;
        }

        if (_timeState > Death)
        {
            _spriteRenderer.sprite = State0;
			_timeState = 0;
			OnState.Invoke(0);
            _state = 0;
        }
		//*/
    }

    public int Recolter()
    {
		/*/
        if (_state == 2)
		{
			if (_nbRecolte > 0) {
				_nbRecolte--;
				_spriteRenderer.sprite = State1;
				_state = 1;
				OnState.Invoke (1);
			} else {
				_spriteRenderer.sprite = State3;
				_state = 3;
				OnState.Invoke (3);
			}

			_timeState = 0;

            return Mathf.FloorToInt(_catalyse*_recolte);
        }
        else
			if(_state == 3)
				return -Mathf.FloorToInt(_catalyse*_recolte);
		//*/
		return 0;
    }

}
