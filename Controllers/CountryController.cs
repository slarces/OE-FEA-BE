using Microsoft.AspNetCore.Mvc;

namespace Flag_Explorer_App.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        public CountryController(ILogger<CountryController> logger)
        {
            _logger = logger;
        }

        //countrydashboard

        //getallcountries

        //getcountrybyid


    }
}
