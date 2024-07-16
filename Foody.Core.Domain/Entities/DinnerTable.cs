using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Enums;

namespace Foody.Core.Domain.Entities
{
    public class DinnerTable : Entity
    {
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public TableState State { get; set; }
    }
}
