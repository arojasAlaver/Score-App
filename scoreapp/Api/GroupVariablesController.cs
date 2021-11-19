using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoreapp.data;
using scoreapp.data.Data_Objects;
using scoreapp.model.database.tables;
using scoreapp.model.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scoreapp.Api
{
    [Route("api/c89e734b-4f1d-41d9-b071-5ef07773cd0b")]
    [ApiController]
    public class GroupVariablesController : ControllerBase
    {
        private readonly Context _db;
        public GroupVariablesController(Context db)
        {
            _db = db;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Get")]
        [AjaxOnly]
        public async Task<IActionResult> Get()
        {
            return Ok(new object[] { await _db.Groups.Include(x => x.Variables)
                .Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description.Replace("_"," "),
                    Variables = x.Variables.Select(y => new
                    {
                        Id = y.Id,
                        Description = y.Description.Replace("_"," "),
                        Score = y.Score
                    })
                }).ToListAsync()});
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Post")]
        [AjaxOnly]
        public async Task<IActionResult> Post([FromBody] VariableDto _var)
        {
            Variable update = await _db.Variables.SingleOrDefaultAsync(x => x.Id == _var.VariableId);
            update.Score = _var.Score;
            _db.Variables.Update(update);
            await _db.SaveChangesAsync();
                return Ok(new object[] { await _db.Groups.Include(x => x.Variables)
                .Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description,
                    Variables = x.Variables.Select(y => new
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Score = y.Score
                    })
                }).ToListAsync()});

        }

        [HttpPost]
        [Authorize(Policy = "GroupVariables")]
        [Route("PostAdd")]
        [AjaxOnly]
        public async Task<IActionResult> PostAdd([FromBody] NewVariable _var)
        {

            if (_var.Variable == null)
                return null;
            
            var verify =  await _db.Variables.SingleOrDefaultAsync(x => x.Description.ToLower() == _var.Variable.ToLower());
            var group = await _db.Groups.SingleOrDefaultAsync(x => x.Id == _var.Id);
            if ( verify == null)
            {
                Variable NewVariable = new Variable
                {
                    Group = group,
                    Description = _var.Variable.Replace(" ","_"),
                    Score = _var.Score

                };
                _db.Variables.Add(NewVariable);

                await _db.SaveChangesAsync();
            }

            return Ok(new object[] { await _db.Groups.Include(x => x.Variables)
                .Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description,
                    Variables = x.Variables.Select(y => new
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Score = y.Score
                    })
                }).ToListAsync()});



        }

        [HttpPost]
        [Authorize(Policy = "GroupVariables")]
        [Route("PostDelete")]
        [AjaxOnly]
        public async Task<IActionResult> PostDelete([FromBody] VariableDto _var)
        {


            var variable = await _db.Variables.SingleOrDefaultAsync(x => x.Id == _var.VariableId);
            _db.Variables.Remove(variable);

            await _db.SaveChangesAsync();

            return Ok(new object[] { await _db.Groups.Include(x => x.Variables)
                .Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description,
                    Variables = x.Variables.Select(y => new
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Score = y.Score
                    })
                }).ToListAsync()});



        }

        [HttpPost]
        [Authorize(Policy = "GroupVariables")]
        [Route("PostGroup")]
        [AjaxOnly]
        public async Task<IActionResult> PostGroup([FromBody]string group)
        {
            var d = HttpContext;
            if (group == null)
                return null;
            await _db.Groups.AddAsync(new Group
            {
                Description = group.Replace(" ","_"),
                Status = Group_Status.Active
                
            });
            await _db.SaveChangesAsync();
            return Ok(new object[] { await _db.Groups.Include(x => x.Variables)
                .Select(x => new
                {
                    Id = x.Id,
                    Description = x.Description,
                    Variables = x.Variables.Select(y => new
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Score = y.Score
                    })
                }).ToListAsync()});

        }
    }
}
