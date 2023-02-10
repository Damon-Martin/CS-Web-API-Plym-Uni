/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Custom Object used for Collecting Data from the HTTP Body
 */

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrailAPI.Models;

[Keyless]
public partial class CreateAuthor
{
    public string author { get; set; } = null!;

}
