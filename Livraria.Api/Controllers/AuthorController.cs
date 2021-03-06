﻿using Livraria.Api.Attributes;
using Livraria.Api.Models.Author;
using Livraria.Common.Resources;
using Livraria.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Livraria.Api.Controllers
{
    public class AuthorController : ApiController
    {
        #region Injeção de Dependencia
        private IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        #endregion

        #region GetAll Method
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var data = _service.GetAll();
                response = Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region GetById Method
        [HttpGet]
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan = 100, ServerTimeSpan = 100)]
        public Task<HttpResponseMessage> Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var data = _service.GetById(id);
                response = Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion


        #region Resgister Method
        [HttpPost]
        public Task<HttpResponseMessage> Post(RegisterAuthorModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, new { Title = model.Name });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region Update Method
        [HttpPut]
        public Task<HttpResponseMessage> Put(ChangeAuthorModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(model.Id, model.Name);
                response = Request.CreateResponse(HttpStatusCode.OK, Msgs.SuccessfulyChanges);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region Delete Method
        [HttpDelete]
        public Task<HttpResponseMessage> Delete(DeleteAuthorModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Delete(model.Id);
                response = Request.CreateResponse(HttpStatusCode.OK, Msgs.SuccessfulyDelete);
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }
        #endregion

        #region Dispose Method
        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }
        #endregion
    }
}
