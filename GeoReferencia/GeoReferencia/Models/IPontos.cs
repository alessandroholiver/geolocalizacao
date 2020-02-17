using GeoReferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoReferencia.Controllers
{
   public interface IPontos
    {
        IEnumerable<Pontos_Interesse> GetAll();
        Pontos_Interesse Get(int id);
        bool Add(Pontos_Interesse ponto);
        void Remove(int id);
        bool Update(Pontos_Interesse ponto);


    }
}
