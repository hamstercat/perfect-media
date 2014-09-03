using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using PerfectMedia.UI.Actors;

namespace PerfectMedia.UI.Validations
{
    public class ActorsValidAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var actorManager = (ActorManagerViewModel)value;
            return actorManager.Actors.All(ActorIsValid);
        }

        private static bool ActorIsValid(IActorViewModel actor)
        {
            return PropertyIsValid(actor, "Name") && PropertyIsValid(actor, "Role");
        }

        private static bool PropertyIsValid(IActorViewModel actor, string propertyName)
        {
            PropertyInfo nameProperty = actor.GetType().GetProperty(propertyName);
            object value = nameProperty.GetValue(actor);
            return nameProperty
                .GetCustomAttributes(true)
                .OfType<ValidationAttribute>()
                .All(va => va.IsValid(value));
        }
    }
}
