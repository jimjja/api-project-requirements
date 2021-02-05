using System;
using System.Collections.Generic;

namespace ShalekKavy.Api
{
    public class Beverage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BeverageType BeverageType { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

}
