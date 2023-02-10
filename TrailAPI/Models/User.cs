/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Model of User Table Holding its Attributes. Further Modifications and descriptions of this entity is found in the DB Context.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrailAPI.Models;

[Table("Users", Schema = "CW2")]
public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
