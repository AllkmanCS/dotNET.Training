using Task1.One.TrainingWebsite.Entities;

namespace Task1.One.TrainingWebsite.Extensions
{
    internal static class IdentifierExtension
    {
        internal static void AssignGuid(this EntityBase entity)
        {
            Guid guid = Guid.NewGuid();
            if (entity.Id == null) entity.Id = guid;
            else throw new InvalidOperationException();

        }
    }
}
