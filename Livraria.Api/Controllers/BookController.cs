﻿using Livraria.Api.Models;
using Livraria.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Livraria.Common.Resources;
using Livraria.Api.Attributes;
using WebApi.OutputCache.V2;

namespace Livraria.Api.Controllers
{
    public class BookController : ApiController
    {
        #region Injeção de Dependencia
        private IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        #endregion

        #region GetAll Method
        [DeflateCompression]
        [CacheOutput(ClientTimeSpan =100, ServerTimeSpan =100)]
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

        #region Resgister Method
        [HttpPost]
        public Task<HttpResponseMessage> Post(RegisterBookModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage(); 

            try
            {
                _service.Register(model.Title, model.ISBN, model.StorageQty,
                    model.AuthorId, model.CategoryId, model.PublisherId);
                response = Request.CreateResponse(HttpStatusCode.OK, new { Title = model.Title });
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
        public Task<HttpResponseMessage> Put(ChangeBookModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(model.Id, model.Title, model.ISBN,
                    model.StorageQty, model.AuthorId, model.CategoryId, model.PublisherId);
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
        public Task<HttpResponseMessage> Delete(DeleteBookModel model)
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
