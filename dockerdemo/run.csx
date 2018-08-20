using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    // Parsing query parameters
	string name = req.Query["name"];
	log.Info("name = " + name);
		
		//Here begins the magic :)
        string factorial = req.Query["factorial"];
            log.Info+("factorial = " + factorial);

    // Validating the parameters received
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(factorial))
            {
                return new BadRequestObjectResult("Please pass a name and the value you want to calculate factorial");
            }  

    return name == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Hello " + name + "you requested the factorial of " + factorial +  calculateFactorial(Int32.Parse(factorial)));
}
public static string calculateFactorial(int value) {
            int result = 0;
            for (int i = 1; i <= value; i++) {
                result = result * i;
            }
            return "the result is: " + result;
        } 