using Microsoft.AspNetCore.Identity;

namespace FairWorks.Models.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {

        private DateTime _createdDate = DateTime.Now;
        public DateTime CreateDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status { get => _status; set => _status = value; }

    }
}
