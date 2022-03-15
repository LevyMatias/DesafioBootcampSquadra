using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoCursos.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public TypesStatus Status { get; set; }

        public enum TypesStatus
        {
            Foreseen = 0,
            InProgress = 1,
            Completed = 2
        }

        public Courses(string title, string duration, TypesStatus status )
        {
            Title = title;
            Duration = duration;
            Status = status;
        }
    }
}
