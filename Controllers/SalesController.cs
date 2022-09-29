using apiSalesNet.Models;
using apiSalesNet.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestClient;
using System.Net.Http.Headers;

namespace apiSalesNet.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // string Baseurl = "http://localhost:5401/api/person/";
        SalesServices services = new SalesServices();

        [HttpPost("sales1")]
        public async Task<List<Register1>> Sales1([FromBody] int[] year)
        {

            Console.WriteLine("api/sales/sales1");
            List<Sales1> sales1 = services.getSales1(year);
            List<PersonInfo> listusers = await services.getInfoUsers(sales1);
            List<Register1> registerList = services.ReportGetAlls1(sales1, listusers);

            return registerList;
        }

        [HttpPost("sales2")]
        public async Task<List<Register1>> Sales2([FromBody] int[] year)
        {
            List<int> ids = new List<int>();
            List<Sales1> sales1 = services.getSales2(year);
            List<PersonInfo> listusers = await services.getInfoUsers(sales1);
            List<Register1> registerList = services.ReportGetAlls1(sales1, listusers);

            return registerList;
        }

        [HttpPost("sales3")]
        public async Task<List<PersonInfo>> Sales3([FromBody] int[] year)
        {

            Console.WriteLine(year);
            List<int> ids = new List<int>();
            List<Sales3> sales3 = services.getSales3(year);
            List<PersonInfo> listusers = await services.getInfoUsers(sales3);
            // List<table3> report = services.ReportGetAlls3(sales3, listusers);
            return listusers;
        }


        [HttpGet("/")]
        public string index()
        {
            string info = "Api sales online test!!";
            return info;
        }
    }
}
