using LogicaDeNegocios.InterfacesEntidades;
using LogicaDeNegocios.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class, IIdentity
    {
        protected DbContext _contexto;
        public RepositorioGenerico(DbContext contexto)
        {
            _contexto = contexto;
        }

        public T Alta(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
            return entity;
        }

        public void Eliminar(T entity)
        {
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }

        public T Get(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public T Modificar(T entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
            _contexto.SaveChanges();
            return entity;
        }
    }
}
