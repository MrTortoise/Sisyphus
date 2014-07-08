namespace Sisyphus.Core.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;

    using Sisyphus.Web.Models;

    public class Session
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public virtual Story Story { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}