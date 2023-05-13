using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AlloServicePFA.ModelView;

namespace AlloServicePFA.Models
{
    public class MyContext:DbContext
    {
        public DbSet<Ouvrier> ouvriers { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<ImgPub> imgPubs { get; set; }
        public DbSet<Inscription> inscriptions { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Publication> publications { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<WebMaster> webmasters { get; set; }
        //public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {
        }
        //public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        public DbSet<AlloServicePFA.ModelView.UserLoginModelView>? UserLoginModelView { get; set; }
        //public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        public DbSet<AlloServicePFA.ModelView.UserRegisterModelView>? UserRegisterModelView { get; set; }
        //public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        public DbSet<AlloServicePFA.ModelView.UserForgotPassword>? UserForgotPassword { get; set; }
        //public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        public DbSet<AlloServicePFA.ModelView.ServiceIndexViewModel>? ServiceIndexViewModel { get; set; }
        ////public DbSet<ServiceCreateModelView> serviceCreateModelViews { get; set; }
        //public DbSet<AlloServicePFA.ModelView.ServiceCreateModelView>? ServiceCreateModelView { get; set; }
    }
}