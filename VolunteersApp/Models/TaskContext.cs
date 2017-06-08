﻿using System;
using Microsoft.EntityFrameworkCore;

namespace VolunteersApp.Models
{
    public class TaskContext : DbContext
    {
       
		public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
		}

		public DbSet<Task> Task { get; set; }

    }
}
