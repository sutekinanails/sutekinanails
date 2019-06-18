using System;

namespace suteservice.domain.SeedWork {
    /// <summary>
    /// The custom Entity base class.
    /// The following code is an example of an Entity base class where you can place code 
    /// that can be used the same way by any domain entity, such as the entity ID, 
    /// equality operators, a domain event list per entity, etc.
    /// </summary>
    /// <seeref="https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces">
    public abstract class Entity {

        //int? _requestedHashCode;
        string _Id;
        //private List<INotification> _domainEvents;

        //[BsonId] //[Key]
        //[BsonRepresentation (BsonType.ObjectId)]
        public virtual string Id {
            get {
                return _Id;
            }
            protected set {
                _Id = value;
            }
        }

        public override bool Equals (object obj) {
            if (obj == null || !(obj is Entity))
                return false;
            if (Object.ReferenceEquals (this, obj))
                return true;
            if (this.GetType () != obj.GetType ())
                return false;
            Entity item = (Entity) obj;

            return item.Id.Equals (this.Id);
        }

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public static bool operator == (Entity left, Entity right) {
            if (Object.Equals (left, null))
                return (Object.Equals (right, null));
            else
                return left.Equals (right);
        }
        
        public static bool operator != (Entity left, Entity right) {
            return !(left == right);
        }
    }
}