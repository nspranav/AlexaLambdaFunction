using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
//using Alexa.NET.Request.Type;
using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;
using Amazon.Util;

namespace AlexaHelloSkill.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var upperCase = function.FunctionHandler(GetRequest(), context);
            
            Assert.Equal("Sent message to daddy", ((PlainTextOutputSpeech) upperCase.Response.OutputSpeech).Text);
        }

        private SkillRequest GetRequest()
        {
            return new SkillRequest
            {

                Session = new Session
                {
                    New = true,
                    SessionId = "SessionId.de5aef04-1218-4bcc-b42a-a6c3ccbf4058",
                    Application = new Application
                    {
                        ApplicationId = "amzn1.ask.skill.4320cd87-2196-4cab-a608-431175fd1a84"
                    },
                    Attributes = new Dictionary<string, object> { },
                    User = new User
                    {
                        UserId =
                            "amzn1.ask.account.AHF37SX34WT3GSWLHWPCAREZX6AWL5RM5BE2HU3Y6CELX3VAB7PDMIQHZT3R3OZJHC6BM44NIFBTQ2XKEGPICP4OA5T4JMTNXXVJI6GD3CXGOTYBATWXGIBPN5SYIN6EHOOLRKHSCKRE6POCBFDACIERZJ3WX5IPJJKXYQRTN74XXTUFLYEMR6GH2DWVKHMVLEMMFTWXEJHIUZA"
                    }
                },
                Request = new IntentRequest
                {
                    Type = "IntentRequest",
                    RequestId = "EdwRequestId.ad774ecd-1c84-41f1-80e6-0b334a9927cd",
                    Intent = new Intent
                    {
                        Name = "SendMessageIntent",
                        Slots = new Dictionary<string, Slot>()
                        {
                            {"Name", new Slot {Name = "Name", Value = "daddy"}}
                        }
                    },
                    Locale = "en-US",
                    Timestamp = DateTime.Parse(AWSSDKUtils.FormattedCurrentTimestampISO8601)
                },
                Context = new Context
                {
                    AudioPlayer = new PlaybackState
                    {
                        PlayerActivity = "IDLE"
                    },
                    System = new AlexaSystem
                    {
                        Application = new Application
                        {
                            ApplicationId = "amzn1.ask.skill.4320cd87-2196-4cab-a608-431175fd1a84"
                        },
                        User = new User
                        {
                            UserId =
                                "amzn1.ask.account.AHF37SX34WT3GSWLHWPCAREZX6AWL5RM5BE2HU3Y6CELX3VAB7PDMIQHZT3R3OZJHC6BM44NIFBTQ2XKEGPICP4OA5T4JMTNXXVJI6GD3CXGOTYBATWXGIBPN5SYIN6EHOOLRKHSCKRE6POCBFDACIERZJ3WX5IPJJKXYQRTN74XXTUFLYEMR6GH2DWVKHMVLEMMFTWXEJHIUZA"
                        },
                        Device = new Device
                        {
                            SupportedInterfaces = new Dictionary<string, object>() { }
                        }
                    }
                },
                Version = "1.0",
            };
        }
    }
}
