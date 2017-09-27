using System.Linq;

using Amazon.Lambda.Core;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AlexaHelloSkill
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            var resp = new SkillResponse {Version = "1.0"};
            if (input.GetRequestType() == typeof(LaunchRequest))
            {
                resp.Response = new ResponseBody
                {
                        Card = new SimpleCard
                        {
                            Title = "Welcome",
                            Content = "Postman welcomes you"
                        },
                        OutputSpeech = new PlainTextOutputSpeech
                        {
                            Text = "Postman Welcomes You."
                        },
                        ShouldEndSession = true
                };
            }
            else if (input.GetRequestType() == typeof(IntentRequest))
            {
                var intentRequest = (IntentRequest)input.Request;
                var value = intentRequest.Intent.Slots.Values.FirstOrDefault(x => x.Name == "Name").Value;
                if (value != null)
                {
                    var slot = value;
                    switch (intentRequest.Intent.Name)
                    {
                        case "SendMessageIntent":

                            resp.Response = new ResponseBody
                            {
                                Card = new SimpleCard
                                {
                                    Title = "Sent Message",
                                    Content = "Sent Message to "+slot
                                },
                                OutputSpeech = new PlainTextOutputSpeech
                                {
                                    Text = "Sent message to "+slot
                                },
                                ShouldEndSession = true
                            };
                            break;
                        case "HelloIntent":
                            resp.Response = new ResponseBody
                            {
                                Card = new SimpleCard
                                {
                                    Title = "Hello",
                                    Content = "Postman welcomes you"
                                },
                                OutputSpeech = new PlainTextOutputSpeech
                                {
                                    Text = "Postman welcomes you"
                                },
                                ShouldEndSession = true
                            };
                            break;
                    }
                }
            }
            return resp;
        }
    }
}
