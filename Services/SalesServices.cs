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
    public class SalesServices:ISales
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

        public List<Sales3> getSales3(int[] year)
        {
            return ds.Sales3(year);
        }

        public async Task<List<PersonInfo>> getInfoUsers(List<Sales1> sales1)
        {

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
                RequestUri = new Uri("https://person-microservices.azurewebsites.net/api/person/ids"),
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



        public List<Register1> ReportGetAlls1(List<Sales1> sales1, List<PersonInfo> listusers)
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

        public List<table3> ReportGetAlls3(List<Sales3> sales3, List<PersonInfo> listusers)
        {
            Console.WriteLine("naeee");
            List<table3> report = new List<table3>();
            int controlInputs = 0;

            for (int i = 0; i < listusers.Count; i++)
            {
                List<int> listSales = new List<int>();
                List<int> listYears = new List<int>();
                table3 objetT = new table3();
                controlInputs = 0;

                for (int j = 0; j < sales3.Count; j++)
                {

                    if (listusers.ElementAt(i).BusinessEntityID == sales3.ElementAt(j).Id)
                    {

                        listSales.Add(sales3.ElementAt(j).sales);

                        objetT.id = listusers.ElementAt(i).BusinessEntityID;
                        objetT.name = listusers.ElementAt(i).name + " " + listusers.ElementAt(i).lastName;

                        listYears.Add(sales3.ElementAt(j).year);

                        controlInputs = 1;

                    }

                    Console.WriteLine("\n el que está " + sales3.ElementAt(j).year + "\n");


                    if (j < sales3.Count - 1)
                    {
                        if (sales3.ElementAt(j).year != sales3.ElementAt(j + 1).year)
                        {
                            Console.WriteLine("eL DE ANTES= " + sales3.ElementAt(j + 1).year + "\n el que está despues" + sales3.ElementAt(j).year + "\n");

                            if (controlInputs == 0)
                            {
                                listSales.Add(0);
                                listYears.Add(sales3.ElementAt(j).year);

                            }
                            else
                            {
                                controlInputs = 0;

                            }
                        }
                    }
                }
                objetT.sales = listSales;
                objetT.years = listYears;
                report.Add(objetT);

            }

            return report;

        }
    }
}