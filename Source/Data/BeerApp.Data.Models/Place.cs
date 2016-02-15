﻿namespace BeerApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Place : BaseModel<int>
    {
        private ICollection<Beer> beers;

        public Place()
        {
            this.beers = new HashSet<Beer>();
        }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public PlaceType Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser Creator { get; set; }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }
    }
}
