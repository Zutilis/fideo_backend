﻿namespace Fideo.DTO
{
    public class BusinessCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public int PointsPerEuro {  get; set; }
        public DateTime CreatedAt { get; set; }
        public string OwnerId { get; set; }
    }
}
