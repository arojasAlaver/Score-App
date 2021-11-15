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
using System.Linq;
using System.Threading.Tasks;

namespace scoreapp.Api
{
    [Route("api/4039b714-caeb-4c65-9eb9-621ac530813f")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly Context _db;
        private readonly IDataProtectionProvider _provider;
        private readonly List<Config> _allSettings;
        private readonly IWebHostEnvironment _env;
        private readonly IEmailNotify _emailService;
        public ApplicationsController(Context db, IDataProtectionProvider provider, IWebHostEnvironment env, IEmailNotify emailService)
        {
            _db = db;
            _allSettings = _db.Settings.ToList();
            _provider = provider;
            _env = env;
            _emailService = emailService;
        }

        [HttpGet]
        [Authorize(Policy = "Application")]
        [Route("Get")]
        [AjaxOnly]
        public async Task<IActionResult> Get()
        {
            var Id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);

            User user = _db.Users.AsNoTracking().SingleOrDefault(x => x.Id == Id);

            if (user.TypeUser == Type_User.Ejecutivo)
            {
                return Ok(new object[]{await _db.Applications.Where(x => x.ExecutiveAssigned == null && x.OfficialAssignTo == null)
                    .Include(x => x.Person).Select(x => new
            {
                Id = x.Id,
                ClientId = x.Person.Id,
                ClientName = $"{x.Person.Names} {x.Person.LastNames}",
                Score = x.Score,
                Amount = x.Amount,
                Status = ((Application_Status)x.Status).ToString(),
                Created = x.CreatedAt
            }).ToListAsync() ,await _db.Users.Where(x => x.TypeUser == Type_User.Oficial)
            .Select(x => new { Id = x.Id,Oficial = x.DisplayName})
           .ToListAsync()});
            }
            else
            {
                return Ok(new object[]{await _db.Applications.Where(x => x.OfficialAssignTo == user)
                    .Include(x => x.Person).Select(x => new
            {
                Id = x.Id,
                ClientId = x.Person.Id,
                ClientName = $"{x.Person.Names} {x.Person.LastNames}",
                Cel1 = x.Person.cel1,
                Cel2 = x.Person.cel2,
                Mail = x.Person.Email,
                Score = x.Score,
                Amount = x.Amount,
                Status = ((Application_Status)x.Status).ToString(),
                Created = x.CreatedAt
            }).OrderBy(x => x.Created).ToListAsync() }) ;
            }


        }

        [HttpPost]
        [Authorize(Policy = "Application")]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] ApplicationOficialDto App)
        {
            var Id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            User Executive = await _db.Users.AsNoTracking().
                SingleOrDefaultAsync(x => x.Id == Id);
            User Oficial = await _db.Users.AsNoTracking().
                SingleOrDefaultAsync(x => x.Id == App.OficialId);


            var app = await _db.Applications.Include(x => x.Person).SingleOrDefaultAsync(x => x.Id == App.ApplicationId);

            app.OfficialAssignTo = Oficial;
            app.ExecutiveAssigned = Executive;

            _db.Applications.Update(app);

            bool result = Convert.ToBoolean(await _db.SaveChangesAsync());


            if (result && App.Notify)
                _emailService.SendEmail(app);

            return Ok(app);
        }


        [HttpPost]
        [Authorize(Policy = "Application")]
        [Route("Status")]
        public async Task<IActionResult> Status([FromBody] StatusDto status)
        {
            var Id = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == "Id").Value);
            
            User Oficial = await _db.Users.AsNoTracking().
                SingleOrDefaultAsync(x => x.Id == Id);


            var app = await _db.Applications.Include(x => x.Person).SingleOrDefaultAsync(x => x.Id == status.ApplicationId);

            app.Description = status.Description;
            app.Status = status.Status;
            if (status.Amount > 0)
            {
                app.AproveAmount = status.Amount;
            }
            else
            {
                app.AproveAmount = app.Amount;
            }

            _db.Applications.Update(app);

            bool result = Convert.ToBoolean(await _db.SaveChangesAsync());


            return Ok(app);
        }


        [HttpGet]
        //[Authorize(Policy = "Applications")]
        [AllowAnonymous]
        [Route("Applications")]
        [AjaxOnly]
        public async Task<IActionResult> Applications()
        {
            var group = new[] {
                new { Month = 1,Total=0},
                new { Month = 2,Total=0},
                new { Month = 3,Total=0},
                new { Month = 4,Total=0},
                new { Month = 5,Total=0},
                new { Month = 6,Total=0},
                new { Month = 7,Total=0},
                new { Month = 8,Total=0},
                new { Month = 9,Total=0},
                new { Month = 10,Total=0},
                new { Month = 11,Total=0},
                new { Month = 12,Total=0} 
            };

            var groupMoney = new[] {
                new { Month = 1,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 2,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 3,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 4,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 5,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 6,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 7,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 8,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 9,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 10,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 11,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)},
                new { Month = 12,Total = Convert.ToDecimal(0),TotalAproved=Convert.ToDecimal(0)}
            };

            _db.Applications.GroupBy(x => x.CreatedAt.Month)
                .Select(y => new
                {
                    Month = y.Key,
                    Total = y.Count()
                }).ToList().ForEach(x =>
                {
                    group[x.Month-1] = x;
                });

            _db.Applications.GroupBy(x => x.CreatedAt.Month)
                .Select(y => new
                {
                    Month = y.Key,
                    Total = y.Sum(x => x.Amount),
                    TotalAproved = y.Sum(x => x.AproveAmount)
                }).ToList().ForEach(x =>
                {
                    groupMoney[x.Month - 1] = x;
                });

            return Ok(new object[] { await _db.Applications.ToListAsync(), group,groupMoney});
        }
    }
}
