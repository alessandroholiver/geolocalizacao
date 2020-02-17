using GeoReferencia.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoReferencia.Models
{
    public class PontosRepositorio : IPontos
    {

        private List<Pontos_Interesse> pontos = new List<Pontos_Interesse>();
        private int nextId = 1;


        public IEnumerable<Pontos_Interesse> GetAll()
        {
            return pontos;
        }



        public bool Add(Pontos_Interesse ponto)
        {
            bool addResult = false;
            if (ponto == null)
            {
                return addResult;
            }

            int index = pontos.FindIndex(p => p.id == ponto.id);
            if (index == -1)
            {
                pontos.Add(ponto);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;

            }
        }

        public Pontos_Interesse Get(int id)
        {
            return pontos.Find(p => p.id == id);
        }

      

        public void Remove(int id)
        {
            pontos.RemoveAll(p => p.id == id);
        }

        public bool Update(Pontos_Interesse ponto)
        {
            if (ponto == null)
            {
                throw new ArgumentNullException("estudante");
            }
            int index = pontos.FindIndex(s => s.id == ponto.id);
            if (index == -1)
            {
                return false;
            }
            pontos.RemoveAt(index);
            pontos.Add(ponto);
            return true;
        }
    }
}