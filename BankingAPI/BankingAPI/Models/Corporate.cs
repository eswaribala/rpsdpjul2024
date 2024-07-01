
using BankingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// @author Parameswari
/// </summary>
public class Corporate : Customer {

    public CompanyType companyType {  get; set; }

    public long odLimit {  get; set; }

}