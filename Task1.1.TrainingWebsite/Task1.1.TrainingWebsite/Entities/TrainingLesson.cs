using Task1.One.TrainingWebsite.Entities.TrainingMaterial;
using Task1.One.TrainingWebsite.Enums;
using Task1.One.TrainingWebsite.Extensions;
using Task1.One.TrainingWebsite.Interfaces;

namespace Task1.One.TrainingWebsite.Entities
{
    internal class TrainingLesson : EntityBase, IVersionable
    {
        public List<EntityBase> TrainingMaterials { get; private set; } = new List<EntityBase>();
        private ulong _version;
        public byte[] ReadVersion(ulong version) => BitConverter.GetBytes(_version);
        public ulong SetVersion(ulong version) => _version = version;
        public TrainingLesson(string description, IEnumerable<EntityBase> trainingMaterials, ulong version) : base(description)
        {
            Description = description;
            TrainingMaterials = trainingMaterials.ToList();
            this.AssignGuid();
            _version = version;
        }
        public void Add(EntityBase entityBase) => TrainingMaterials.Add(entityBase);
        public override TrainingLesson Clone()
        {
            var trainingLessonClone = new TrainingLesson(this.Description, this.TrainingMaterials, this._version);
            for (int i = 0; i < TrainingMaterials.Count; i++)
            {
                trainingLessonClone.TrainingMaterials[i] = this.TrainingMaterials[i].Clone() as EntityBase;
            }
            trainingLessonClone.Id = this.Id;
            trainingLessonClone._version = this._version;
            return trainingLessonClone;
        }
        public LessonType GetTrainingType() =>
            TrainingMaterials.Any(i => i is VideoMaterial) ? LessonType.VideoLesson : LessonType.TextLesson;
        public override string ToString() => $"{Description}";
    }
}
