
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
#nullable disable
/// <summary>
/// @author Parameswari
/// </summary>
[Table("Address")]
public class Address {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Address_Id")]

    public long AddressId { get; set; }

    [Column("Door_No", TypeName = "varchar(5)")]
    
    [DefaultValue("")]

    public string DoorNo {  get; set; }
    [Column("Street_Name", TypeName = "varchar(100)")]

    [DefaultValue("")]
    public string StreetName {  get; set; }
    [Column("City", TypeName = "varchar(100)")]

    [DefaultValue("")]
    public string City {  get; set; }
    [Column("State", TypeName = "varchar(100)")]

    [DefaultValue("")]
    public string State {  get; set; }
    [Column("Pincode")]

    public long Pincode {  get; set; }

    [ForeignKey("Customer")]
    [Column("Account_No_FK")]
    public long AccountNo { get; set; }
    [JsonIgnore]
    public Customer Customer { get; set; }


}