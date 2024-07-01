
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
#nullable disable
/// <summary>
/// @author Parameswari
/// </summary>
[Table("Customer")]
public class Customer {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Account_No")]
    public long AccountNo { get; set; }

    public FullName Name { get; set; }

    [Column("Contact_No")]
    public long ContactNo { get; set; }
    [Column("Email", TypeName = "varchar(150)")]
    public string Email { get; set; }
    [Column("Password", TypeName = "varchar(10)")]
    public string Password { get; set; }

}