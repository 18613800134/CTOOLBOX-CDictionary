
namespace CDictionary.Model.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using CAM.Core.Model.Entity;

    public class CDictIdValue : BaseEntityNormal
    {
        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        public long OrganizationId { get; set; }

        [Required]
        [Index(IsClustered = false, IsUnique = false)]
        [MaxLength(50)]
        public string Key { get; set; }

        [Required]
        [MaxLength(20)]
        public string Value { get; set; }
    }
}
