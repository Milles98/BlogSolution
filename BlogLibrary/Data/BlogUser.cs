using BlogLibrary.Data;

namespace BlogLibrary.Models;

public class BlogUser
{
    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public bool IsAdmin { get; set; }
    public bool IsAuthor { get; set; }
    public bool IsModerator { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime MemberSince { get; set; }
    public List<BlogPost> Posts { get; set; } = new();
}