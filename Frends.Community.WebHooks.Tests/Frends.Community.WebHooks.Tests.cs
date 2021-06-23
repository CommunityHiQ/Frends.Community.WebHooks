using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

namespace Frends.Community.WebHooks.Tests
{
    [TestFixture]
    class TestClass
    {
        [Test]
        public void GivenStandardInputForWebHookWhenCreatingNewEntityInstanceThenSynchronizerTokenMustBeIncludedIntoTheMessage()
        {
            WebHookBasicInformation webHookBasicInformation = new WebHookBasicInformation();
            webHookBasicInformation.App = "Supply Chain Portal";
            webHookBasicInformation.Description = "This is a test description";
            webHookBasicInformation.Domain = "Order";
            webHookBasicInformation.Endpoint = "order/content";
            webHookBasicInformation.Tenant = "hiq";
            webHookBasicInformation.ContentType = "application/json";
            webHookBasicInformation.CorrelationId = Guid.NewGuid().ToString();
            webHookBasicInformation.DeviceId = "134-134-345-435";
            webHookBasicInformation.ServerTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            webHookBasicInformation.ServerGuid = Guid.NewGuid().ToString();


            WebHookAttributeDescription webHookAttributeDescription1 = new WebHookAttributeDescription();
            webHookAttributeDescription1.Format = "28{28,0}";
            webHookAttributeDescription1.Name = "Address";
            webHookAttributeDescription1.Value = "Demo address";
            webHookAttributeDescription1.Base64 = true;
            webHookAttributeDescription1.Crypt = true;
            webHookAttributeDescription1.ValidationPattern = "yyyy-MM-DD";
            webHookAttributeDescription1.DomTreeId = "body.content.address";

            WebHookAttributeDescription webHookAttributeDescription2 = new WebHookAttributeDescription();
            webHookAttributeDescription2.Format = "This is a format";
            webHookAttributeDescription2.Name = "Mobile";
            webHookAttributeDescription2.Value = "Demo mobile";
            webHookAttributeDescription1.Base64 = true;
            webHookAttributeDescription1.Crypt = true;
            webHookAttributeDescription2.ValidationPattern = "+358{0-9}";
            webHookAttributeDescription2.DomTreeId = "body.content.address";

            WebHookAttributeDescription[] webHookAttributeDescriptions =
            {
                webHookAttributeDescription1, webHookAttributeDescription2
            };

            WebHookAttributes webHookAttributes = new WebHookAttributes();
            webHookAttributes.WebHookBasicInformation = webHookBasicInformation;
            webHookAttributes.WebHookAttributeDescription = webHookAttributeDescriptions;
            
            Options options = new Options();

            options.MaximumLatency = 142;

            Task<Result> result = WebHooks.CreateKeyValueWebHook(webHookAttributes, options, new CancellationToken());
            Console.Out.WriteLine(result.Result.Data);
            Assert.NotNull(result.Result.Data);

            // Assert.That(ret.Replication, Is.EqualTo("foobar, foobar, foobar"));
        }
    }
    
}
