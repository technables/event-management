using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : Controller
    {
        private string GetHeaderValue(string headerName)
        {
            return HttpContext.Request?.Headers[headerName].ToString();
        }



        private async void AddRequestLog()
        {
            HttpContext context = HttpContext.Request.HttpContext;


            string bodyStr = string.Empty;
            StringBuilder headerValue = new StringBuilder();
            var req = HttpContext.Request;

            //req.Body.Position = 0;
            string referralURL = string.Empty;
            string useragent = string.Empty;
            foreach (var head in req.Headers)
            {
                string key = head.Key;
                string value = head.Value.ToString();
                switch (key)
                {
                    case "Referer":
                        referralURL = value;
                        break;
                    case "User-Agent":
                        useragent = value;
                        break;
                    default:
                        break;
                }
                headerValue.AppendFormat("{0} = {1}{2}", key, value, Environment.NewLine);
            }

            bodyStr = await FormatRequest(req);

            string requestURL = RequestURL(req);
            string urlPath = context.Request.Path;
            string browser = useragent;
            string sessionID = context.Request.Path;
            var remoteIpAddress = req.HttpContext.Connection.RemoteIpAddress;

            //APIRequestInfo objRequestInfo = new APIRequestInfo()
            //{
            //    RequestUrl = requestURL,
            //    UrlPath = urlPath,
            //    Useragent = useragent,
            //    HeaderString = headerValue.ToString(),
            //    BodyString = bodyStr,
            //    RemoteIpAddress = remoteIpAddress.ToString()
            //};

            //SystemDataController objDataController = new SystemDataController();
            //objDataController.AddAPIRequestLog(objRequestInfo);


        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            string body = string.Empty;

            //This line allows us to set the reader for the request back at the beginning of its stream.

            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: Convert.ToInt32(request.ContentLength),
                leaveOpen: true))
            {
                body = await reader.ReadToEndAsync();
                // Do some processing with body…

                // Reset the request body stream position so the next middleware can read it
                request.Body.Position = 0;
            }

            //We now need to read the request stream.  First, we create a new byte[] with the same length as the request stream...


            ////...Then we copy the entire request stream into the new buffer.
            //await request.Body.ReadAsync(buffer, 0, buffer.Length);

            ////We convert the byte[] into a string using UTF8 encoding...
            //var bodyAsText = Encoding.UTF8.GetString(buffer);

            ////..and finally, assign the read body back to the request body, which is allowed because of EnableRewind()
            //request.Body = body;

            return $"{body}";
        }

        private string RequestHost()
        {
            HttpContext context = HttpContext.Request.HttpContext;

            var req = HttpContext.Request;

            return $"{req.Scheme}://{req.Host}";
        }

        private static string RequestURL(HttpRequest req)
        {
            return $"{req.Scheme}://{req.Host}{req.Path} {req.QueryString}";
        }


        private string GetParamValueFromJObject(JObject obj, string param)
        {
            string value = string.Empty;
            value = obj.ContainsKey(param) ? obj[param].ToString() : "";
            return value;
        }

        private bool GetBooleanValueFromJObject(JObject obj, string param)
        {
            string value = GetParamValueFromJObject(obj, param);
            return (value.ToLower() == "true" || value.ToLower() == "1");
        }

        private int GetIntValueFromJObject(JObject obj, string param)
        {
            string value = GetParamValueFromJObject(obj, param);
            return value.Length > 0 ? int.Parse(value) : 0;
        }

        /*
          API List 
        */

        [HttpGet]
        [Route("{domainsecret}/campaign")]
        public IActionResult Get(string domainSecret, JObject jObject)
        {
            int offset = GetIntValueFromJObject(jObject, "offset");
            int limit = GetIntValueFromJObject(jObject, "limit");
            int type = GetIntValueFromJObject(jObject, "type");
            string name = GetParamValueFromJObject(jObject, "name");

            return Ok();
        }


        [HttpPost]
        [Route("subscribe")]
        public IActionResult Subscribe(SiteConfig obj)
        {
            return Ok(obj);
        }


        #region "Create Campaign"

        [HttpGet]
        [Route("{domainsecret}/campaigntype")]
        public IActionResult GetCampaignType(string domainSecret)
        {
            return Ok(domainSecret);
        }

        [HttpPost]
        [Route("{domainsecret}/campaigntype")]
        public IActionResult SetCampaignType(string domainSecret)
        {
            return Ok(domainSecret);
        }

        [HttpPost]
        [Route("{domainsecret}/campaignname")]
        public IActionResult SetCampaignNanme(string domainSecret, Campaign name)
        {
            return Ok(name);
        }

        [HttpGet]
        [Route("{domainsecret}/campaign/{campaignid}/postdesign")]
        public IActionResult GetPostService(string domainSecret, string campaignid)
        {
            return Ok(campaignid);
        }

        [HttpPost]
        [Route("{domainsecret}/campaign/{campaignid}/postdesign")]
        public IActionResult SavePostDesign(string domainSecret, string campaignid, JObject jObject)
        {
            AddRequestLog();
            string post = GetParamValueFromJObject(jObject, "message");
            string services = GetParamValueFromJObject(jObject, "services");

            var postObj = new
            {
                campaignid = campaignid,
                post = post,
                services = services
            };

            return Ok(postObj);
        }

        /// <summary>
        /// get list of campaign post for each service
        /// </summary>
        /// <param name="campaignid"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("{domainsecret}/campaign/{campaignid}/servicepost")]
        public IActionResult GetServicePosts(string domainSecret, string campaignid)
        {

            return Ok(campaignid);
        }

        [HttpPost]
        [Route("{domainsecret}/campaign/{campaignid}/servicepost/{servicepostid}")]
        public IActionResult SaveServicePosts(string domainSecret, string campaignid, string servicepostid)
        {
            AddRequestLog();
            var postObj = new
            {
                campaignid = campaignid,
                servicepostid = servicepostid
            };

            return Ok(postObj);

        }

        [HttpPost]
        [Route("{domainsecret}/campaign/{campaignid}/schedule")]
        public IActionResult ScheduleCampaign(string domainSecret, string campaignID, JObject jObject)
        {
            bool publishNow = GetBooleanValueFromJObject(jObject, "publish");
            string scheduleTime = GetParamValueFromJObject(jObject, "scheduleOn");

            return Ok();
        }


        #endregion

        #region "Connect Accounts"
        [HttpGet]
        [Route("{domainsecret}/accounts")]
        public IActionResult GetAccounts(string domainsecret)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{domainsecret}/connect/facebook")]
        public RedirectResult ConnectFacebook(string domainSecret)
        {
            string appid = "2868752979905873";
            string requestHost = RequestHost();
            string redirectUrl = $"{requestHost}/api/Campaign/{domainSecret}/update/facebook";
            string firstUrl = $"https://www.facebook.com/v6.0/dialog/oauth?client_id={appid}&redirect_uri={redirectUrl}&scope=manage_pages,pages_show_list,publish_pages";


            return RedirectPermanent(firstUrl);
            // return response;
        }

        [HttpGet]
        [Route("{domainsecret}/update/facebook")]
        public RedirectResult SaveFacebookCredential(string domainSecret, [FromQuery]string code)
        {

            string appid = "2868752979905873";

            string appsecret = "6c0ec64c9d558fb3754ed065b18e4e11";
            string requestHost = RequestHost();
            string redirectUrl = $"{requestHost}/api/Campaign/{domainSecret}/update/facebook"; 
            string secondUrl = $"https://graph.facebook.com/v6.0/oauth/access_token?client_id={appid}&client_secret={appsecret}&redirect_uri={redirectUrl}&code={code}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(secondUrl).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            JObject acessObj = JObject.Parse(responseBody);
            string accessToken = acessObj["access_token"].ToString();

            string profileUrl = $"https://graph.facebook.com/v6.0/me?access_token={accessToken}";
            response = client.GetAsync(profileUrl).Result;
            response.EnsureSuccessStatusCode();
            responseBody = response.Content.ReadAsStringAsync().Result;
            JObject profileObj = JObject.Parse(responseBody);
            string profileId = profileObj["id"].ToString();

            string finalUrl = $"https://graph.facebook.com/v6.0/{profileId}/accounts?access_token={accessToken}";
            response = client.GetAsync(finalUrl).Result;
            response.EnsureSuccessStatusCode();
            responseBody = response.Content.ReadAsStringAsync().Result;

            string extended_token = (JObject.Parse(responseBody) as JObject)["data"][0]["access_token"].ToString();

            string client_url = "http://localhost:5000/";
            return RedirectPermanent(client_url);
        }


        #endregion




    }

    public class SiteConfig
    {
        public string Domain { get; set; }
        public string Key { get; set; }
    }

    public class Campaign
    {
        public Guid CampaignID { get; set; }
        public string Name { get; set; }
    }
}
