using System;
using System.Collections.Generic;
using System.Linq;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MembershipType { get; set; } // Basic/Premium/Platinum
    public DateTime JoinDate { get; set; }
    public DateTime ExpiryDate { get; set; }
}
