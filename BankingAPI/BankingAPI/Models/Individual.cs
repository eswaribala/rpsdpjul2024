
using BankingAPI.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

/// <summary>
/// @author Parameswari
/// </summary>
[Table("Individual")]
public class Individual : Customer {


    [Column("Gender")]
    [EnumDataType(typeof(Gender))]
    [DefaultValue(Gender.MALE)]
    [Required]
    public Gender Gender { get; set; }
    [Column("DOB")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MM dd yyyy}")]
    [Required]
    public DateTime DOB { get; set; }


}