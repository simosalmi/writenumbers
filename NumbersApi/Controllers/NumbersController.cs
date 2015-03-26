using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NumbersApi.Models;
using NumbersApi.Models.Interfaces;
using NumbersApi.Models.Exceptions;

namespace NumbersApi.Controllers
{
    public class NumbersController : ApiController
    {
        [HttpPost]
        public IHttpActionResult WriteNumber([FromBody]NumberWriterOptions options)
        {
            try
            {
                if (options == null)
                {
                    return BadRequest(Resources.Numbers.EmptyContentErrorMessage);
                }
                NumberWriterService writerService = NumberWriterFactory.Create(options.CultureName);

                string value = writerService.Write(options);

                var result = new NumberWriterResult()
                {
                    Value = value,
                    Error = writerService.Error,
                    CultureName = writerService.Culture.Name
                };

                return Ok(result);
            }
            catch (UnsupportedCultureException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (OverflowException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
