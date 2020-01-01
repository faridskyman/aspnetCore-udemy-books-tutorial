using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace udemy_web_project_01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("you requested a index page.");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5)
                        throw new Exception("this is an invoked exception thrown");
                    else
                        //_logger.LogInformation($"the value of {i}"); 
                        _logger.LogInformation("the value of {loopCountVal}", i); //this is better in logging with var syntax highlight and more readable
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "an exception is caught in index page");
            }
        }
    }
}
