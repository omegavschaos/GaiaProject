using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LegumeEngine
{
    public class Cellule : MonoBehaviour
    {

        public Legume Legume;
        [SerializeField] private Transform LegumePosition;
        [SerializeField] private float _quality = 1;
        //[SerializeField] private int _buff = 0;


        [SerializeField]
        public KeyValuePair<int, int> Position;

        [Serializable]
        public class Buff
        {
            public LegumeManager.BuffInfo Info;
            public Legume Origin;

            public Buff(LegumeManager.BuffInfo info, Legume origin)
            {
                Info = info;
                Origin = origin;
            }
        }

        public List<Buff> buffList;


        // Use this for initialization
        private void Start()
        {
            buffList = new List<Buff>();
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void Planter(LegumeManager.Type type)
        {
            if (!Legume)
            {
                GameObject legumePrefab = LegumeManager.GetInstance().GetLegumeInfo(type).m_Prefab;
                GameObject legume = Instantiate(legumePrefab);
                legume.name = type.ToString();
                legume.transform.SetParent(LegumePosition, false);

                Legume = legume.GetComponent<Legume>();
                Legume.M_Cellule = this;
            }
        }

        public void Supprimer()
        {
            Destroy(Legume.gameObject);
            Legume = null;
        }

        public void Recolter()
        {
            int recolte = Legume.Recolter(); //TODO Recolte
            if (recolte < 0)
            {
                Fertiliser(-recolte);
            }
        }

        public void Fertiliser(int buff)
        {
            if (buff > 1)
            {
                int x = Position.Key;
                int y = Position.Value;

                Cellule cell = Grille.GetInstance().GetCellule(x + 1, y);
                if (cell)
                    cell.Fertiliser(buff - 1);

                cell = Grille.GetInstance().GetCellule(x - 1, y);
                if (cell)
                    cell.Fertiliser(buff - 1);

                cell = Grille.GetInstance().GetCellule(x, y + 1);
                if (cell)
                    cell.Fertiliser(buff - 1);

                cell = Grille.GetInstance().GetCellule(x, y - 1);
                if (cell)
                    cell.Fertiliser(buff - 1);
            }
        }

        public int Distance(Cellule cell)
        {
            int distX = Mathf.Abs(Position.Key - cell.Position.Key);
            int distY = Mathf.Abs(Position.Value - cell.Position.Value);
            return distX + distY;
        }


        public void Bufferise(Buff buff)
        {
            int distance = buff.Info.Distance;

            var celluleList = GetInRadius(distance);

            foreach (var cell in celluleList)
            {
                cell.NewBuff(buff);
            }
        }

        public void UnBufferise(Buff buff)
        {
            UnBuff(buff);
            int distance = buff.Info.Distance;

            var celluleList = GetInRadius(distance);

            foreach (var cell in celluleList)
            {
                cell.UnBuff(buff);
            }
        }

        public void NewBuff(Buff buff)
        {
            buffList.Add(buff);
            GetComponentInChildren<SpriteRenderer>().color = Color.blue;
        }

        public void UnBuff(Buff buff)
        {
            buffList.Remove(buff);
        }

        public HashSet<Cellule> GetInRadius(int radius)
        {
            Cellule cellule;
            HashSet<Cellule> resultList = new HashSet<Cellule> {this};

            if (radius < 1)
            {
                return resultList;
            }

            cellule = Grille.GetInstance().GetCellule(Position.Key +1, Position.Value);
            if (cellule)
                resultList.UnionWith(cellule.GetInRadius(radius - 1));

            cellule = Grille.GetInstance().GetCellule(Position.Key, Position.Value + 1);
            if (cellule)
                resultList.UnionWith(cellule.GetInRadius(radius - 1));

            cellule = Grille.GetInstance().GetCellule(Position.Key - 1, Position.Value);
            if (cellule)
                resultList.UnionWith(cellule.GetInRadius(radius - 1));

            cellule = Grille.GetInstance().GetCellule(Position.Key, Position.Value - 1);
            if (cellule)
                resultList.UnionWith(cellule.GetInRadius(radius - 1));

            return resultList;
        }

        

        public int GetQuality()
        {
            return 1;
        }

        private void OnMouseUp()
        {
            if (Legume)
                Recolter();
            //else 
            //	Planter (LegumeManager.Type.Tomate);
        }


        public void OnDrop_Fertiliser()
        {



            _quality++;

        }
    }
}
