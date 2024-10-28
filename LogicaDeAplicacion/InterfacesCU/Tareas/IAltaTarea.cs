using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Tareas
{
    public interface IAltaTarea
    {
        TareaDto Ejecutar(TareaDto tDto);
    }
}
