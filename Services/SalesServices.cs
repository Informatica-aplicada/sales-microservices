using apiSalesNet.Database;
using apiSalesNet.Models;
using apiSalesNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Urls;
using System.Collections.Generic;
using RestClient.Net;

namespace apiSalesNet.Services
{
    public class SalesServices
    {
        public SalesServices() { }

        DataSales ds = new DataSales();


        public List<Sales1> getSales1(int[] year)
        {
            return ds.Sales1(year);
        }

        public List<Sales1> getSales2(int[] year)
        {
            return ds.Sales2(year);
        }

        public async Task<List<PersonInfo>> getInfoUsers(List<Sales1> sales1)
        {

            //string Baseurl = "http://localhost:5401/api/person/";
            string person_Baseurl = "https://person-microservices.azurewebsites.net/";

            List<int> ids = new List<int>();

            // obtengo los id y los agrego a una lista
            for (int i = 0; i < sales1.Count; i++)
            {
                Sales1 s = new Sales1();
                s = sales1.ElementAt(i);
                ids.Add(s.BusinessEntityID);
            }

            //convierto la lista  de id json
            var json_ids = JsonConvert.SerializeObject(ids);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(person_Baseurl + "api/person/ids"),
                Content = new StringContent(json_ids)
                {
                    Headers ={
                        ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };

            List<PersonInfo> listusers = new List<PersonInfo>();

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                listusers = JsonConvert.DeserializeObject<List<PersonInfo>>(body);
            }

            return listusers;

        }

        public List<Register1> ReportGetAlls1(List<Sales1> sales1, List<PersonInfo> listusers){

            List<Register1> registerList = new List<Register1>();

            for (int i = 0; i < sales1.Count; i++)
            {
                if (sales1.ElementAt(i).BusinessEntityID == listusers.ElementAt(i).BusinessEntityID)
                {

                    Register1 register = new Register1();
                    register.BusinessEntityID = listusers.ElementAt(i).BusinessEntityID;
                    register.name = listusers.ElementAt(i).name;
                    register.lastName = listusers.ElementAt(i).lastName;
                    register.jan = sales1.ElementAt(i).jan;
                    register.feb = sales1.ElementAt(i).feb;
                    register.mar = sales1.ElementAt(i).mar;
                    register.apr = sales1.ElementAt(i).apr;
                    register.may = sales1.ElementAt(i).may;
                    register.jun = sales1.ElementAt(i).jun;
                    register.jul = sales1.ElementAt(i).jul;
                    register.aug = sales1.ElementAt(i).aug;
                    register.sep = sales1.ElementAt(i).sep;
                    register.oct = sales1.ElementAt(i).oct;
                    register.nov = sales1.ElementAt(i).nov;
                    register.dec = sales1.ElementAt(i).dec;

                    registerList.Add(register);

                }

            }

            return registerList;
        }

        public List<Register1> ReportGetAlls2(List<Sales1> sales1, List<PersonInfo> listusers)
        {

            List<Register1> registerList = new List<Register1>();

            for (int i = 0; i < sales1.Count; i++)
            {
                if (sales1.ElementAt(i).BusinessEntityID == listusers.ElementAt(i).BusinessEntityID)
                {

                    Register1 register = new Register1();
                    register.BusinessEntityID = listusers.ElementAt(i).BusinessEntityID;
                    register.name = listusers.ElementAt(i).name;
                    register.lastName = listusers.ElementAt(i).lastName;
                    register.jan = sales1.ElementAt(i).jan;
                    register.feb = sales1.ElementAt(i).feb;
                    register.mar = sales1.ElementAt(i).mar;
                    register.apr = sales1.ElementAt(i).apr;
                    register.may = sales1.ElementAt(i).may;
                    register.jun = sales1.ElementAt(i).jun;
                    register.jul = sales1.ElementAt(i).jul;
                    register.aug = sales1.ElementAt(i).aug;
                    register.sep = sales1.ElementAt(i).sep;
                    register.oct = sales1.ElementAt(i).oct;
                    register.nov = sales1.ElementAt(i).nov;
                    register.dec = sales1.ElementAt(i).dec;

                    registerList.Add(register);

                }
            }

            return registerList;
        }
    }
}