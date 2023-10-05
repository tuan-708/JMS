﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Entity
{
    public class JobPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }
        public virtual User? User { get; set; }
        public string? Title { get; set; }
        public string? LevelRequired { get; set; }
        public string? JobType { get; set; }
        public virtual Category? Category { get; set; }
        public string? Address { get; set; }
        [Required]
        [StringLength(800)]
        public string JobDescription { get; set; }
        [StringLength(800)]
        [Required]
        public string JobRequirement { get; set; }
        public string? SalaryMin { get; set; }
        public string? SalaryMax { get; set; }
        public string? EmailConnect { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExipredDate { get; set; }
        public string? Detail { get; set; }
        public StatusJob status { get; set; }
        public string? Summary { get; set; }
        public bool IsDelete { get; set; }
    }
}
