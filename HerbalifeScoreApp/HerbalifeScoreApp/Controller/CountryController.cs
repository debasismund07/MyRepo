using HerbalifeScoreApp.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HerbalifeScoreApp.Controller
{
    public class CountryController : ApiController
    {
        Country country = new Country();
        public HttpResponseMessage GetCountries()
        {
            try
            {
                var result = country.SelectCountries();
                return result.Count > 0
? Request.CreateResponse(HttpStatusCode.OK, (result))
: Request.CreateResponse(HttpStatusCode.NoContent, "Country data not added yet");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong.Try again later");
            }

        }
    }
}
