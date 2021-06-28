using System;
using System.Collections.Generic;
using Dio.Series.Interfaces;

namespace Dio.Series
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();

        public void Atualiza(int id, Series objeto)
        {
           listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Series Objeto)
        {
            listaSerie.Add(Objeto);
        }

        public List<Series> Lista()
        {
          return listaSerie;
        }

        public int ProximoId()
        {
           return listaSerie.Count;
        }

        public Series RetornaPorID(int id)
        {
            return listaSerie[id];
        }
    }
}