using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

#pragma warning disable 1591

namespace Frends.Community.WebHooks
{
 
    public static class WebHooks
    {
        /// <summary>
        /// This is task
        /// Documentation: https://github.com/CommunityHiQ/Frends.Community.WebHooks
        /// </summary>
        /// <param name="input">What to repeat.</param>
        /// <param name="options">Define if repeated multiple times. </param>
        /// <param name="cancellationToken"></param>
        /// <param name="var"></param>
        /// <returns>{string Replication} </returns>
        public static async Task<Result> CreateKeyValueWebHook([PropertyTab]WebHookAttributes input, [PropertyTab] Options options, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            StringBuilder builder = new StringBuilder();
            builder.Append(input.WebHookBasicInformation.ServerGuid)
                   .Append(input.WebHookBasicInformation.ServerGuid)
                   .Append(input.WebHookBasicInformation.DeviceId);
            input.WebHookAttributeDescription?.ToList().ForEach(entry => builder.Append(entry.Name));
            var synchronizerData = SetSynchronizerData(builder);
            input.WebHookBasicInformation.SynchronizerToken = synchronizerData.ToString();
            Result result = new Result();
            result.Data = JsonConvert.SerializeObject(input);
            result.WebHookAttributeDescription = input.WebHookAttributeDescription;
            return result;
        }

        private static string SetSynchronizerData(StringBuilder builder)
        {
            var data = Encoding.UTF8.GetBytes(builder.ToString());
            byte[] synchronizerData = null;
            SHA512 shaM = new SHA512Managed();
            synchronizerData = shaM.ComputeHash(data);
            string base64EncodedSynchronizerToken = System.Convert.ToBase64String(synchronizerData);
            return base64EncodedSynchronizerToken;
        }
    }
}
