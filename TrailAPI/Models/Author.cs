/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Model of Author Table Holding its Attributes. Further Modifications and descriptions of this entity is found in the DB Context.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailAPI.Models;

[Table("Author", Schema = "CW2")]
public partial class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TrailID { get; set; }

    public string author { get; set; } = null!;
}
