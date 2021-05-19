using AzureFunctionWithEF.Class.Domain;
using AzureFunctionWithEF.Utils;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace AzureFunctionWithEF
{
    public class MyTimerFunction
    {
        private readonly MyDbContext dbContext;
        public MyTimerFunction(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [FunctionName("MyTimerFunction")]
        public void Run([TimerTrigger("0 * * * * *"
            #if DEBUG
            ,RunOnStartup=true
            #endif
            )] TimerInfo myTimer, [DurableClient] IDurableOrchestrationClient starter,
            ILogger log, ExecutionContext context)
        {
            try
            {
                //Get the CSV contents
                var csv = GetCSVDetails.GetCSVContent(Path.Combine(context.FunctionAppDirectory + "\\Resources\\new_user_credentials.csv"));
                foreach (var line in csv)
                {
                    var test = new Data { Username = line.Username, Password = line.Password , AccesskeyID = line.AccesskeyID , Secretaccesskey = line.Secretaccesskey , Consoleloginlink = line.Consoleloginlink};
                    dbContext.Test.Add(test);
                    dbContext.SaveChanges();
                }

                log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            }
            catch (Exception e)
            {
                log.LogCritical(e.Message);
                log.LogCritical(e.StackTrace);
            }
        }
    }
}
