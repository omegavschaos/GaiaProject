using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;


namespace LegumeEngine
{
    public class Legume : MonoBehaviour
    {

        [SerializeField] private float _catalyse = 1;

        /*/
        [SerializeField]
        private int _recolte = 5;

	    public int LittleLife = 5;
	    public int MidLife = 5;
	    public int FullLife = 5;
	    public int Death = 5;
        //*/

        public LegumeManager.Type Type;

        public Engine.StateEvent OnState;


        [SerializeField]
        private LegumeManager.State _state = LegumeManager.State.Graine;

        public Cellule M_Cellule;
        private SpriteRenderer _spriteRenderer;
        private List<Cellule.Buff> _activeBuffs;
        /*/
        [SerializeField] private Sprite State1;
        [SerializeField] private Sprite State2;
        [SerializeField] private Sprite State3;
        //*/

        //private float _timeState;

        // Use this for initialization
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SaisonTime.GetInstance().SaisonChangeMonthChangeEvent.AddListener(ChangeMonth);

            _activeBuffs = new List<Cellule.Buff>();

            Reset();
        }


        private void ChangeMonth(int month)
        {
            LegumeManager.State requestState= LegumeManager.GetInstance().GetLegumeInfo(Type).m_Calendar[month];
            
            switch (requestState)
            {
                case LegumeManager.State.Graine:
                    if (_state == LegumeManager.State.Pourri)
                        OnGrow(1);
                    break;
                case LegumeManager.State.Pousse:
                    if (_state == LegumeManager.State.Graine)
                        OnGrow(1);
                    break;
                case LegumeManager.State.Recolte:
                    if(_state == LegumeManager.State.Pousse)
                        OnGrow(1);
                    break;
                case LegumeManager.State.Pourri:
                    if (_state == LegumeManager.State.Graine)
                    {
                        M_Cellule.Supprimer();
                    }
                    else if (_state == LegumeManager.State.Pousse)
                    {
                        OnGrow(2);
                    }
                    else if (_state == LegumeManager.State.Recolte)
                    {
                        OnGrow(1);
                        M_Cellule.Fertiliser(1);
                    }
                    break;
            }
            
        }

        private void OnGrow(int nb)
        {
            StopAllCoroutines();

            LegumeManager.State currentState = _state;
            _state = (LegumeManager.State)((int)(_state + nb) % 4);
            Debug.Log(M_Cellule + " OnGrow : " + currentState + " => " +  _state);
            _spriteRenderer.sprite = LegumeManager.GetInstance().GetLegumeInfo(Type).m_Sprites[(int) _state];

            switch (_state)
            {
                case LegumeManager.State.Graine:
                    OnChangeStateGraine();
                    break;
                case LegumeManager.State.Pousse:
                    OnChangeStatePousse();
                    break;
                case LegumeManager.State.Recolte:
                    OnChangeStateRecolte();
                    break;
                case LegumeManager.State.Pourri:
                    OnChangeStatePourri();
                    break;
            }
             //OnState.Invoke(_state);
        }

        private void OnChangeStateGraine()
        {
            Bufferise(false);
            StartCoroutine(UpdateGraine());
        }
        IEnumerator UpdateGraine()
        {
            yield return true;
        }

        private void OnChangeStatePousse()
        {
            Bufferise(true);
            StartCoroutine(UpdatePousse());
        }
        IEnumerator UpdatePousse()
        {
            yield return true;
        }

        private void OnChangeStateRecolte()
        {
            StartCoroutine(UpdateRecolte());

        }
        IEnumerator UpdateRecolte()
        {
            yield return true;
        }
        private void OnChangeStatePourri()
        {
            StartCoroutine(UpdatePourri());
        }
        IEnumerator UpdatePourri()
        {
            yield return true;
        }


        private void Reset()
        {
            //_nbRecolte = _nbMaxRecolte;
            //_state = LegumeManager.State.Graine;
            //_spriteRenderer.sprite = State0;
        }

        private void OnDestroy()
        {
            Bufferise(false);
            SaisonTime.GetInstance().SaisonChangeMonthChangeEvent.RemoveListener(ChangeMonth);
        }

        // Update is called once per frame
        private void Update()
        {
            //_timeState += _catalyse*Time.deltaTime;
            //StateManage();
        }

        private void Bufferise(bool active)
        {
            if(active)
                foreach (var buffInfo in LegumeManager.GetInstance().GetLegumeInfo(Type).m_Buffs)
                {
                    Cellule.Buff buff = new Cellule.Buff(buffInfo, this);
                    _activeBuffs.Add(buff);
                    M_Cellule.Bufferise(buff);
                }
            else
            {
                foreach (var buff in _activeBuffs)
                {
                    M_Cellule.UnBufferise(buff);
                }
                _activeBuffs.Clear();
            }
        }

        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="state"></param>
        private void StateManage(LegumeManager.State state)
        {
            //Sprite sp = LegumeManager.GetInstance()._LegumeSprites[state];
            OnState.Invoke(state);
        }

        public int Recolter()
        {
            //*/
            if (_state == LegumeManager.State.Recolte)
            {
                OnGrow(-1);
                return Mathf.FloorToInt(_catalyse*LegumeManager.GetInstance().GetLegumeInfo(Type).m_Product);
            }
            return 0;
        }

    }
}
