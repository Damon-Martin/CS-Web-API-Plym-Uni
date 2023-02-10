/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Model of TrailUsers Table Holding its Attributes. Further Modifications and descriptions of this entity is found in the DB Context.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailAPI.Models;

[Table("TrailUsers", Schema = "CW2")]
public partial class TrailUser
{
    //TrailID and UserID Form a Compound Key
    public int TrailId { get; set; }

    public int UserId { get; set; }

    public string Geohash { get; set; } = null!;
}
