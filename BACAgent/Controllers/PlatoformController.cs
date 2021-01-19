using BACAgent.Models.Context;
using BACAgent.Models.Response;
using BACAgent.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BACAgent.Controllers
{
    public class PlatoformController : ApiController
    {
        [HttpPost]
        [Route("api/platoformswh")]
        [AllowAnonymous]
        public HttpResponseMessage GetFormWebhook()
        {
            string body = Request.Content.ReadAsStringAsync().Result;
            
            LogSingleton.Info(body);

            var platoformparser = new PlatoformParser();

            try
            {
                PlatoformsWebHookResponse response =  JsonConvert.DeserializeObject<PlatoformsWebHookResponse>(body);

                using(var context = new ApplicationDbContext())
                {
                    platoformparser.AddToDB(context, 1, "id", response.PFProperty[0].id);
                    platoformparser.AddToDB(context, 1, "submit_date", response.PFProperty[0].submit_date);
                    platoformparser.AddToDB(context, 1, "submit_revision", response.PFProperty[0].submit_revision);
                    platoformparser.AddToDB(context, 1, "published_form_revision", response.PFProperty[0].published_form_revision);
                    platoformparser.AddToDB(context, 1, "submit_form_sharing_creator_url", response.PFProperty[0].submit_form_sharing_creator_url);
                    platoformparser.AddToDB(context, 1, "submit_form_url", response.PFProperty[0].submit_form_url);
                    platoformparser.AddToDB(context, 1, "form.id", response.PFProperty[0].form.id);
                    platoformparser.AddToDB(context, 1, "form.name", response.PFProperty[0].form. name);
                    platoformparser.AddToDB(context, 1, "workflow_id", response.PFProperty[0].workflow_id);
                    platoformparser.AddToDB(context, 1, "workflow_step_id", response.PFProperty[0].workflow_step_id);
                    platoformparser.AddToDB(context, 1, "workflow_next_step_url", response.PFProperty[0].workflow_next_step_url);
                    platoformparser.AddToDB(context, 1, "workflow_next_step_api_url", response.PFProperty[0].workflow_next_step_api_url);
                    platoformparser.AddToDB(context, 1, "pdf.id", response.PFProperty[0].pdf[0]?.id);
                    platoformparser.AddToDB(context, 1, "pdf.template_id", response.PFProperty[0].pdf[0]?.template_id);
                    platoformparser.AddToDB(context, 1, "pdf.display_name", response.PFProperty[0].pdf[0]?.display_name);
                    platoformparser.AddToDB(context, 1, "pdf.name", response.PFProperty[0].pdf[0]?.name);
                    platoformparser.AddToDB(context, 1, "pdf.url", response.PFProperty[0].pdf[0]?.url);

                    foreach(var data in response.PFProperty[0].submit_data)
                    {
                        platoformparser.AddToDB(context, 1, data.id, data.value);
                    }
                }

            }
            catch (Exception)
            {
                LogSingleton.Error($"Platoforms body didn't deserialize..... {body}");
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
