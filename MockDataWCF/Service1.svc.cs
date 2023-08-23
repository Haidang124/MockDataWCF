using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MockDataWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public FakeData GetData(int value)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string apiUrl = "https://64e6520609e64530d17fdea9.mockapi.io/api/dataWcf";
                //HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                //string jsonContent = await response.Content.ReadAsStringAsync();
                string jsonContent = response.Content.ReadAsStringAsync().Result;
                var dataObject = JsonConvert.DeserializeObject<FakeData[]>(jsonContent);
                return dataObject[0];
            }
        }

        public class FakeData
        {
            public string name { get; set; }
            public string avatar { get; set; }
            public string id { get; set; }
        }

            public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
