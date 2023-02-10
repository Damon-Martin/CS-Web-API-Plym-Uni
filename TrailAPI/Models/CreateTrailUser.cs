/* 
 * University Of Plymouth: COMP 2001 Information Management & Retrieval
 * Student ID: 10729705
 * 
 * Description: Custom Object used for Collecting Data from the HTTP Body
 */

using Microsoft.EntityFrameworkCore;

namespace TrailAPI.Models
{
    [Keyless]
    public partial class CreateTrailUser
    {
        //TrailID and UserID Form a Compound Key
        public int TrailId { get; set; }

        public int UserId { get; set; }

        public string Geohash { get; set; } = null!;
    }
}