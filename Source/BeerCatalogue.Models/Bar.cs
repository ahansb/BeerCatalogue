﻿namespace BeerCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Bar
    {
        private ICollection<Beer> beers;

        public Bar()
        {
            this.beers = new HashSet<Beer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        [MaxLength(40)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(40)]
        public string Phone { get; set; }

        [Required]
        public string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public virtual ICollection<Beer> Beers { get { return this.beers; } set { this.beers = value; } }

    }
}