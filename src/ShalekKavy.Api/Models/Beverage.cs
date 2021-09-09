using ShalekKavy.Api.Models;
using ShalekKavy.Api.Models.Enums;
using ShalekKavy.Api.Models.Shared;
using System.Collections.Generic;

namespace ShalekKavy.Api
{
    public class Beverage : BaseClass
    {
        public string Description { get; set; }
        public BeverageType BeverageType { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }
        public BeverageSize Size { get; set; }
        public List<AddOns> AddOns { get; set; }
    }

}
