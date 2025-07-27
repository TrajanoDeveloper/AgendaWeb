using AgendaWeb.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaWeb.Reports.Interfaces
{
    public interface IEventoReportService
    {
        byte[] Create(DateTime datamin, DateTime datamax, List<Evento> evento);  
    }
}
