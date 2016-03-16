namespace WebSiteAnalyticsApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    
    public class WSAADB : DbContext
    {
        // Your context has been configured to use a 'WSAADB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebSiteAnalyticsApp.Models.WSAADB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WSAADB' 
        // connection string in the application configuration file.
        public WSAADB()
            : base("name=WSAADB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }

    public class Visit
    {
        Visit()
        { }

        public int VisitID { get; set; }
        public string UserAgent { get; set; }
        public string IPAddress { get; set; }
        public DateTime VisitDateTime { get; set; }
        public Guid TokenID { get; set; }
        public Token Token { get; set; }


    }
    public class Token
    {
        Token()
        { }

        public Guid TokenID { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid UserID { get; set; }
        public User User { get; set; }

        public ICollection<Visit> Visits { get; set; }

    }
    public class User
    {
        User()
        { }
        public Guid UserID;
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime MemberSince { get; set; }

        public ICollection<Token> Tokens { get; set; }

    }
}