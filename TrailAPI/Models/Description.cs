/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Model of Description Table Holding its Attributes. Further Modifications and descriptions of this entity is found in the DB Context.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailAPI.Models;

[Table("Description", Schema = "CW2")]
public partial class Description
{
    public string Geohash { get; set; } = null!;

    public string Info { get; set; } = null!;

    public string Difficulty { get; set; } = null!;

    public double Distance { get; set; }

    public int Duration { get; set; }

    public string? PointAgeohash { get; set; }

    public string? PointBgeohash { get; set; }

    public string? PointCgeohash { get; set; }

    public string? PointDgeohash { get; set; }
}
