using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace LegumeEngine
{
    public class LegumeManager : MonoBehaviour, ISerializationCallbackReceiver
    {

        private static LegumeManager _instance = null;

        public enum Type
        {
            Tomate,
            Radis,
            Absynthe,
            Aromatique,
            Fraise,
            Abricot,
            Pomme,
            PommeDeTerre,
            Haricot,
            Compost
        }

        [Serializable]
        public class BuffInfo 
        {
            public int Distance;
            public int Effect;
            public List<LegumeManager.Type> Targets;


            public BuffInfo(int effect, int distance, List<LegumeManager.Type> targets)
            {
                Distance = distance;
                Effect = effect;
                Targets = targets;
            }


        }

        public enum State
        {
            Graine = 0,
            Pousse = 1,
            Recolte = 2,
            Pourri = 3
        }

        /*/
        [Serializable]
        public class Calendar : List<State>
        {
            public Calendar(int mGraine, int mPousse, int mRecolte, int mPourri)
            {
                this.Capacity = 12;
                if (mPousse < mGraine)
                {
                    mPousse += 12;
                    mRecolte += 12;
                    mPourri += 12;
                }
                if (mRecolte < mGraine)
                {
                    mRecolte += 12;
                    mPourri += 12;
                }
                if (mPourri < mGraine)
                {
                    mPourri += 12;
                }

                for (int i = mGraine; i < mPousse; i++)
                {
                    this[i % 12] = State.Graine;
                }
                for (int i = mPousse; i < mRecolte; i++)
                {
                    this[i % 12] = State.Recolte;
                }
                for (int i = mRecolte; i < mPourri; i++)
                {
                    this[i % 12] = State.Recolte;
                }
                for (int i = mPourri; i < mGraine; i++)
                {
                    this[i % 12] = State.Pourri;
                }

            }
        }
        //*/

        [Serializable]
        public struct LegumeStruct
        {
            public GameObject m_Prefab;
            public List<Sprite> m_Sprites;
            public int m_Product;
            public List<BuffInfo> m_Buffs;
            public List<State> m_Calendar;
        }

        [Serializable]
        public struct TypeLegumePair
        {
            public Type type;
            public LegumeStruct legume;
        }

        public List<TypeLegumePair> m_LegumesDictionary; 
            

        private Dictionary<Type, LegumeStruct> _legumesDictionary;
        //TODO Stock
        public Dictionary<Type, int> Stock;

        // Use this for initialization
        private void Start()
        {
            if (_instance)
                Destroy(_instance);
            _instance = this;
            if (_legumesDictionary == null)
                _legumesDictionary = new Dictionary<Type, LegumeStruct>();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        /// <summary>
        /// Deprecated
        /// </summary>
        private void Init()
        {
            /*/
            Type type;
            int dist;
            List<Type> targets;
            BuffInfo buff;
            List<Type> deTargets;
            BuffInfo deBuff;
            List<BuffInfo> buffs;
            Calendar calendar;

            //*TOMATE
            type = Type.Tomate;

            dist = 2;
            targets = new List<Type>();
            targets.Add(Type.Radis);

            buff = new BuffInfo(1, dist, targets);
            buffs = new List<BuffInfo>();

            buffs.Add(buff);

            deTargets = new List<Type>();
            deTargets.Add(Type.PommeDeTerre);
            deTargets.Add(Type.Abricot);
            deBuff = new BuffInfo(-1, 2, deTargets);

            buffs.Add(deBuff);

            _legumeProduct.Add(type, 8);
            _legumeBuff.Add(type, buffs);
            //SAISON CLASSIQUE
            _legumeCalendar.Add(type, new Calendar(11, 2, 5, 8));
            //*/
        }

        public LegumeStruct GetLegumeInfo(Type type)
        {
            return _legumesDictionary[type];
        }

        public static LegumeManager GetInstance()
        {
            return _instance;
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {

            if (_legumesDictionary == null)
                _legumesDictionary = new Dictionary<Type, LegumeStruct>();

            foreach (var pair in m_LegumesDictionary)
            {
                _legumesDictionary[pair.type] = pair.legume;
            }
        }
    }
}
