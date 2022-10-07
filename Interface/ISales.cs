using System;
using apiSalesNet.Models;

public interface ISales
{
    List<Sales1> getSales1(int[] year);
    List<Sales1> getSales2(int[] year);
    List<Sales3> getSales3(int[] year);
    Task<List<PersonInfo>> getInfoUsers(List<Sales1> sales1);
    List<Register1> ReportGetAlls1(List<Sales1> sales1, List<PersonInfo> listusers);
    List<Register1> ReportGetAlls2(List<Sales1> sales1, List<PersonInfo> listusers);
    List<table3> ReportGetAlls3(List<Sales3> sales3, List<PersonInfo> listusers);

}

