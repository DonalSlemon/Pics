using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxServiceReference;

namespace PicsToShow.Controllers
{
    [Produces("application/json")]
    [Route("api/Taxes")]
    public class TaxesController : Controller
    {
        TaxServiceClient TaxSvc = new TaxServiceClient();
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Taxes/5
        [HttpGet("{id}", Name = "GetTaxCalculation")]
        public async Task<YourTaxDetailsResponse> GetTaxCalculation(decimal earnings, decimal racontribamount, int ageinyears, bool med, short dep, bool isannual)
        {
            var medicaldtls = new MedicalDetails { Dependants = dep, HaveMedicalAid = med };
            var taxdtls = new YourTaxDetails { Earnings = earnings, RaContrib = racontribamount, AgeInYears = (short)ageinyears, Medical = medicaldtls, TimePeriod = "Monthly" };

            var taxresult = await TaxSvc.ShowTaxPayableAsyncAsync(taxdtls, (short)ageinyears, isannual, med);
            decimal mytax = taxresult.TaxPayable;

            return taxresult;// as IActionResult;
        }

        // POST: api/Taxes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Taxes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
