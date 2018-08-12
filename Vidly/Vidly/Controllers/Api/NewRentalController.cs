using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        public IHttpActionResult CreateNewRental(NewRentalDTO newRentalDTO)
        {

            return Created("",newRentalDTO);
        }
    }
}
