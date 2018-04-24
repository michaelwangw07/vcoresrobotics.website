using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using vcoresrobotics.website.Authorization.Roles;
using vcoresrobotics.website.Authorization.Users;
using vcoresrobotics.website.MultiTenancy;
using vcoresrobotics.website.Events;
using vcoresrobotics.website.Posts;

namespace vcoresrobotics.website.EntityFrameworkCore
{
    public class websiteDbContext : AbpZeroDbContext<Tenant, Role, User, websiteDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public websiteDbContext(DbContextOptions<websiteDbContext> options)
            : base(options)
        {
        }
    }
}
