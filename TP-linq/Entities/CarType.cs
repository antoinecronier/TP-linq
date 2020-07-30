using System.Collections.Generic;

namespace TP_linq.Entities
{
    public class CarType
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public List<EquipmentType> EquipmentTypes { get; set; }
    }
}