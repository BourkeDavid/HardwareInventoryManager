﻿using AutoMapper;
using HardwareInventoryManager.Filters;
using HardwareInventoryManager.Helpers;
using HardwareInventoryManager.Helpers.User;
using HardwareInventoryManager.Models;
using HardwareInventoryManager.Repository;
using HardwareInventoryManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;



namespace HardwareInventoryManager.Controllers.Api
{
    [CustomAuthorize]
    public class QuoteRequestsController : ApiController
    {
        // GET: api/QuoteRequests
        public IEnumerable<QuoteRequestViewModel> Get()
        {
            IList<QuoteRequest> quoteRequests = new List<QuoteRequest>();

            for(int i = 0; i < 100; i++)
            {
                quoteRequests.Add(
                new QuoteRequest
                {
                    QuoteRequestId = i,
                    DateRequired = DateTime.Now,
                    SpecificationDetails = "A new computer",
                    Quantity = i * 10
                });
            }

            Mapper.CreateMap<QuoteRequest, QuoteRequestViewModel>();
            var l = Mapper.Map<IList<QuoteRequest>, IList<QuoteRequestViewModel>>(quoteRequests);

            return l;
        }

        // GET: api/AssetsApi/5
        [ResponseType(typeof(QuoteRequestViewModel))]
        public IHttpActionResult Get(int id)
        {
            CustomApplicationDbContext db = new CustomApplicationDbContext();
            IQueryable<Lookup> itemTypes = db.Lookups.Where(l => l.Type.Description == EnumHelper.LookupTypes.Category.ToString());
            IQueryable<Tenant> tenants = db.Tenants.Where(t => t.Users.Where(u => u.UserName == User.Identity.Name).Any());
            
            var quoteRequestViewModel = new QuoteRequestViewModel
            {
                ItemTypes = itemTypes,
                Tenants = tenants
            };
            return Ok(quoteRequestViewModel);
        }

        // POST: api/QuoteRequests
        [ResponseType(typeof(Asset))]
        public IHttpActionResult Post([FromBody]QuoteRequestViewModel value)
        {
            if(ModelState.IsValid)
            {
                IRepository<QuoteRequest> quoteRepository = new Repository<QuoteRequest>();
                Mapper.CreateMap<QuoteRequestViewModel, QuoteRequest>();
                QuoteRequest quoteRequestToCreate = Mapper.Map<QuoteRequest>(value);
                quoteRequestToCreate.TenantId = value.SelectedTenant.TenantId;
                quoteRepository.SetCurrentUserByUsername(User.Identity.Name);
                quoteRepository.Create(quoteRequestToCreate);
                quoteRepository.Save();
            }
            else
            {

                //IEnumerable<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage));
                return BadRequest(ModelState);
            }
            return Ok("success");
            //return CreatedAtRoute("DefaultApi", "success",  value);
        }




        // PUT: api/QuoteRequests/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuoteRequests/5
        public void Delete(int id)
        {
        }
    }
}
