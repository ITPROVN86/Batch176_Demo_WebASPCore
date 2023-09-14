using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyStockLibrary.Common
{
    public class ReCaptcha
    {
        private readonly HttpClient captchaClient;

        public ReCaptcha(HttpClient captchaClient)
        {
            this.captchaClient = captchaClient;
        }

        public async Task<bool> IsValid(string captcha)
        {
            try
            {
                var postTask = await captchaClient
                    .PostAsync($"?secret=SECRET_KEY&response={captcha}", new StringContent(""));
                var result = await postTask.Content.ReadAsStringAsync();
                var resultObject = JsonObject.Parse(result);
                dynamic success = resultObject["success"];
                return (bool)success;
            }
            catch (Exception e)
            {
                // TODO: log this (in elmah.io maybe?)
                return false;
            }
        }
    }
}
