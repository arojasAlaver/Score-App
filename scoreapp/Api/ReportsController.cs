using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoreapp.data;
using scoreapp.data.Data_Objects;
using scoreapp.data.Services.Interfaces;
using scoreapp.model.database.tables;
using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace scoreapp.Api
{
    [Route("api/2f8629c9-45ac-433c-aa97-8bf50b86d2f6")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailNotify _emailService;
        public ReportsController(Context db, IDataProtectionProvider provider, IWebHostEnvironment env, IEmailNotify emailService)
        {
            _db = db;
            _allSettings = _db.Settings.ToList();
            _provider = provider;
            _env = env;
            _emailService = emailService;
        }

        [HttpPost]
        [Authorize(Policy = "Application")]
        [Route("Post")]
        [AjaxOnly]
        public async Task<IActionResult> Post([FromBody] Reports report)
        {
            switch (report.Report.ToLower())
            {
                case "asignación por ejecutivo":
                    return Ok(await _db.Applications.Where(x => x.ExecutiveAssigned !=null && 
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom,"yyyyMMdd", CultureInfo.CurrentCulture) 
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.ExecutiveAssigned.DisplayName).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new 
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11,'0'),
                            Ejecutivo = x.ExecutiveAssigned.DisplayName,
                            Oficial = x.OfficialAssignTo.DisplayName,
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());
                case "asignación por oficina":
                    return Ok(await _db.Applications.Where(x => x.ExecutiveAssigned != null &&
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom, "yyyyMMdd", CultureInfo.CurrentCulture)
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.Office).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11, '0'),
                            Ejecutivo = x.ExecutiveAssigned.DisplayName,
                            Oficial = x.OfficialAssignTo.DisplayName,
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());
                case "asignación por oficial":
                    return Ok(await _db.Applications.Where(x => x.ExecutiveAssigned != null &&
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom, "yyyyMMdd", CultureInfo.CurrentCulture)
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.OfficialAssignTo.DisplayName).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11, '0'),
                            Ejecutivo = x.ExecutiveAssigned.DisplayName,
                            Oficial = x.OfficialAssignTo.DisplayName,
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());

                case "solicitudes rechazadas":
                    return Ok(await _db.Applications.Where(x => x.Status == Application_Status.Rechazado &&
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom, "yyyyMMdd", CultureInfo.CurrentCulture)
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.OfficialAssignTo.DisplayName).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11, '0'),
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());
                case "solicitudes aprobadas":
                    return Ok(await _db.Applications.Where(x => x.Status == Application_Status.Aprobado &&
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom, "yyyyMMdd", CultureInfo.CurrentCulture)
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.OfficialAssignTo.DisplayName).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11, '0'),
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());
                case "solicitudes monto menor":
                    return Ok(await _db.Applications.Where(x => x.Amount>x.AproveAmount &&
                    x.CreatedAt >= DateTime.ParseExact(report.DateFrom, "yyyyMMdd", CultureInfo.CurrentCulture)
                    && x.CreatedAt <= DateTime.ParseExact(report.DateTo, "yyyyMMdd", CultureInfo.CurrentCulture))
                        .OrderBy(x => x.OfficialAssignTo.DisplayName).Include(x => x.ExecutiveAssigned).Include(x => x.OfficialAssignTo)
                        .Select(x => new
                        {
                            No_Solicitud = x.Id.ToString().PadLeft(11, '0'),
                            Estado = ((Application_Status)x.Status).ToString(),
                            Monto_Solicitado = x.Amount.ToString("N2"),
                            Monto_Aprobado = x.AproveAmount.ToString("N2")
                        })
                        .ToListAsync());
            }
            return null;
        }
    }
}
