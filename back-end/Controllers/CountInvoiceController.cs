using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountInvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;
        public CountInvoiceController(TestContext testContext)
        {
            _invoiceService = new InvoiceService(testContext);
        }

        [HttpGet]
        public ActionResult<int> Count()
        {
            var response = _invoiceService.Count();
            if (response.Error) return BadRequest(response.Message);

            int result = (++response.Object);

            return Ok(result);
        }

    }
}