using suteservice.domain.SeedWork;

namespace suteservice.domain.AggregatesModel.UserAgregate {
    public class User : Entity, IAggregateRoot {

        public string Name { get; set; }
        public string FamilyName { get; set; }

    }
}