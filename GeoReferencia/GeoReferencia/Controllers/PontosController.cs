using GeoReferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeoReferencia.Controllers
{
    public class PontosController : ApiController
    {
        static readonly IPontos pontoRepositorio = new PontosRepositorio();

       // private static List<Pontos_Interesse> pontos = new List<Pontos_Interesse>();

        public HttpResponseMessage GetAllPontos()
        {
            List<Pontos_Interesse> listaPontos = pontoRepositorio.GetAll().ToList();
            return Request.CreateResponse<List<Pontos_Interesse>>(HttpStatusCode.OK, listaPontos);
        }

        public HttpResponseMessage GetPonto(int id)
        {
            Pontos_Interesse ponto = pontoRepositorio.Get(id);
            if (ponto == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "O ponto não localizado para o Id informado");
            }
            else
            {
                return Request.CreateResponse<Pontos_Interesse>(HttpStatusCode.OK, ponto);
            }
        }

        public IEnumerable<Pontos_Interesse> GetPontoPorNome(string nome)
        {
            return pontoRepositorio.GetAll().Where(
                e => string.Equals(e.Nome,nome, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Pontos_Interesse> GetPontoPorLatitude(double latitude)
        {
            return pontoRepositorio.GetAll().Where(
                e => string.Equals(e.Latitude.ToString(), latitude.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostPonto(Pontos_Interesse ponto)
        {
            bool result = pontoRepositorio.Add(ponto);
            if (result)
            {
                var response = Request.CreateResponse<Pontos_Interesse>(HttpStatusCode.Created, ponto);
                string uri = Url.Link("DefaultApi", new { id = ponto.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "O ponto não foi incluído com sucesso");
            }
        }

        public HttpResponseMessage PutPonto(int id, Pontos_Interesse ponto)
        {
            ponto.id = id;
            if (!pontoRepositorio.Update(ponto))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
               "Não foi possível atualizar o ponto para o id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
        public HttpResponseMessage DeletePonto(int id)
        {
            pontoRepositorio.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}