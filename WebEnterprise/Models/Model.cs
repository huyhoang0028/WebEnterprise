using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebEnterprise.Models
{
    public class Idea
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Text { get; set; }
        public string? FilePath { get; set; }
        public DateTime Datatime { get; set; }
        public string? CategoryId { get; set; }
        public byte[]? Data { get; set; }


        public string? UserId { get; set; }
        public virtual CUser? User { get; set; }


        public int SubmissionId { get; set; }
        public virtual Submission? Submission { get; set; }


        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<React>? Reacts { get; set; }
        public virtual ICollection<CView>? Views { get; set; }

    }



    public class Catogory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Idea>? Ideas { get; set; }

    }

    public class CUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? StaffNumber { get; set; }
        public string? Fullname_ { get; set; }
        public string? Address { get; set; }
        public string? HomeTown { get; set; }
        public string? SocialMedia { get; set; }
        

        [Column(TypeName = "varbinary(max)")]
        public byte[]? Images { get; set; }

        public virtual ICollection<Idea>? Ideas { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<React>? Reacts { get; set; }
        public virtual ICollection<CView>? Views { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        

        public virtual ICollection<CUser>? Users { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CUser>? Users { get; set; }
    }


    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? Datetime { get; set; }

        public string? UserId { get; set; }
        public virtual CUser? User { get; set; }

        public int? IdeaId { get; set; }
        public virtual Idea? Idea { get; set; }

    }

    public class CView
    {
        public int Id { get; set; }
        public DateTime VisitTime { get; set; }

        public string? UserId { get; set; }
        public virtual CUser? User { get; set; }

        public int? IdeaId { get; set; }
        public virtual Idea? Idea { get; set; }

    }
    public class React
    {
        public int Id { get; set; }
        public int Reaction { get; set; }

        public string? UserId { get; set; }
        public virtual CUser? User { get; set; }

        public int? IdeaId { get; set; }
        public virtual Idea? Idea { get; set; }

    }



    public class Submission
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? ClosureDate { get; set; }
        public DateTime? FinalClosureTime { get; set; }


        public virtual ICollection<Idea>? Ideas { get; set; }
    }

}
