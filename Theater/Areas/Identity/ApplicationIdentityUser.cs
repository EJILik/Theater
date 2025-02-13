using Microsoft.AspNetCore.Identity;

namespace Theater.Areas.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long ApplicationId { get; set; }
        public int OrderId { get; set; }
        public string FIO { get; set; }
    }
}