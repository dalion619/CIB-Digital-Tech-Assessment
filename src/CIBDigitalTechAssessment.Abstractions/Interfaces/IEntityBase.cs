using System;
using System.ComponentModel.DataAnnotations;

namespace CIBDigitalTechAssessment.Abstractions.Interfaces
{
    public interface IEntityBase
    {
        [Key]
        string Id { get; set; } 
        DateTimeOffset? CreatedAt { get; set; } 
    }
}