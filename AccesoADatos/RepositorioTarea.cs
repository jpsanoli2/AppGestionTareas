using LogicaDeNegocios.Entidades;
using LogicaDeNegocios.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class RepositorioTarea : RepositorioGenerico<Tarea>, IRepositorioTarea
    {
        public RepositorioTarea(DbContext contexto) : base(contexto) 
        { 
        
        }
        public IEnumerable<Tarea> GetAllTareas()
        {
            return _contexto.Set<Tarea>();
        }
    }
}
