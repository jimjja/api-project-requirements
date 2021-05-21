using ShalekKavy.Api.Models.Enums;
using ShalekKavy.Api.Models.Shared;

namespace ShalekKavy.Api.Models
{
    public class AddOns : BaseClass
    {
        public string BeverageId { get; set; }
        public AddOnType Type { get; set; }
    }
}
