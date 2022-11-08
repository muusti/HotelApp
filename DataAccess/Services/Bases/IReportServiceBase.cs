using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services.Bases
{
    public interface IReportServiceBase
    {
        List<ReportModel> GetListJoin(ReportFilterModel filter);
    }
}
