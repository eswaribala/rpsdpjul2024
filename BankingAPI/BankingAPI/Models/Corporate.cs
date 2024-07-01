
using BankingAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;

/// <summary>
/// @author Parameswari
/// </summary>
[Table("Corporate")]
public class Corporate : Customer {
    [Column("CompanyType")]
    [EnumDataType(typeof(CompanyType))]
    [DefaultValue(CompanyType.PRIVATE)]
    [Required]
    public CompanyType CompanyType {  get; set; }
    [Column("OD_Limit")]
    public long ODLimit {  get; set; }

}