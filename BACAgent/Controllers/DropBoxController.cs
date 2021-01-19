using BACAgent.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace BACAgent.Controllers
{
    public class DropBoxController : ApiController
    {
        [HttpGet]
        [Route("api/dropbox")]
        [AllowAnonymous]
        public HttpResponseMessage Dropbox(string challenge)
        //public ActionResult Dropbox(string challenge)
        {
            LogSingleton.Info(challenge);

            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(challenge, System.Text.Encoding.UTF8, "text/plain");
            return resp;

            //return Content(challenge);
          //  return challenge;
        }

        [HttpPost]
        [Route("api/dropbox")]
        [AllowAnonymous]
        // public async Task<ActionResult> Dropbox()
        public HttpResponseMessage Dropbox()
        {
            LogSingleton.Info("dropbox start");

            // Get the request signature
            var signatureHeader = Request.Headers.GetValues("X-Dropbox-Signature");
            if (signatureHeader == null || !signatureHeader.Any())
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return this.Request.CreateResponse(HttpStatusCode.BadRequest);

            // Get the signature value
            string signature = signatureHeader.FirstOrDefault();

            // Extract the raw body of the request
            string body = null;
            body = Request.Content.ReadAsStringAsync().Result;

            //using (StreamReader reader = new StreamReader(Request.InputStream))
            //{
            //    body = await reader.ReadToEndAsync();
            //}

            // Check that the signature is good
            string appSecret = ConfigurationManager.AppSettings["Dropbox_AppSecret"];
            using (HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(appSecret)))
            {
                if (!VerifySha256Hash(hmac, body, signature))
               //     return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            LogSingleton.Info(body);

            // Do your thing here... e.g. store it in a queue to process later
            // ...

            // Return A-OK :)
  //          return new HttpStatusCodeResult(HttpStatusCode.OK);
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }








        private string GetSha256Hash(HMACSHA256 sha256Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            var stringBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            foreach (byte t in data)
            {
                stringBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string. 
            return stringBuilder.ToString();
        }

        private bool VerifySha256Hash(HMACSHA256 sha256Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetSha256Hash(sha256Hash, input);

            if (String.Compare(hashOfInput, hash, StringComparison.OrdinalIgnoreCase) == 0)
                return true;

            return false;
        }

    }
}