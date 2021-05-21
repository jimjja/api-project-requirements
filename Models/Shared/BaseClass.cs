using ShalekKavy.Api.Models.Enums;
using System;

namespace ShalekKavy.Api.Models.Shared
{
    public class BaseClass
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public BeverageAvailability Availability { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
