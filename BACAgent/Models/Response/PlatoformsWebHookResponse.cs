using System;

namespace BACAgent.Models.Response
{
    public class PlatoformsWebHookResponse
    {
        public PFClass[] PFProperty { get; set; }
    }

    public class PFClass
    {
        public string id { get; set; }
        public DateTime submit_date { get; set; }
        public int submit_revision { get; set; }
        public int published_form_revision { get; set; }
        public string submit_form_sharing_creator_url { get; set; }
        public string submit_form_url { get; set; }
        public Form form { get; set; }
        public object[] attachments { get; set; }
        public string workflow_id { get; set; }
        public string workflow_step_id { get; set; }
        public object workflow_next_step_url { get; set; }
        public object workflow_next_step_api_url { get; set; }
        public Pdf[] pdf { get; set; }
        public Submit_Data[] submit_data { get; set; }
    }

    public class Form
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Pdf
    {
        public string id { get; set; }
        public string template_id { get; set; }
        public string display_name { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string sharing_creator_url { get; set; }
    }

    public class Submit_Data
    {
        public string id { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string value { get; set; }
        public object raw { get; set; }
    }

}