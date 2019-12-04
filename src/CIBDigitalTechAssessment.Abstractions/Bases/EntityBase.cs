using System;
using System.ComponentModel.DataAnnotations.Schema;
using CIBDigitalTechAssessment.Abstractions.Interfaces;

namespace CIBDigitalTechAssessment.Abstractions.Bases
{
    [NotMapped]
    public class EntityBase: IEntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTimeOffset.UtcNow;
        }

        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; } 
    }
}