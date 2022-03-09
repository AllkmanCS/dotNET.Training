using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1._1.TrainingWebsite.Entities.TrainingMaterial;
using Task1._1.TrainingWebsite.Enums;
using Task1._1.TrainingWebsite.Interfaces;

namespace Task1._1.TrainingWebsite.Entities
{
    internal class TrainingLesson : EntityBase, IVersionable
    {
        public List<EntityBase> TrainingMaterials = new List<EntityBase>();
        public TrainingLesson(string description, List<EntityBase> trainingMaterials):base(description)
        {
            Description = description;
            TrainingMaterials = trainingMaterials;
        }
        public TrainingLesson(string description):base(description)
        { 
            Description = description;
        }
        public void Add(EntityBase entityBase)
        {
            TrainingMaterials.Add(entityBase);
        }
        public override TrainingLesson Clone()
        {
            var trainingLessonClone = new TrainingLesson(this.Description, this.TrainingMaterials);
            for (int i = 0; i < TrainingMaterials.Count; i++)
            {
                trainingLessonClone.TrainingMaterials[i] = this.TrainingMaterials[i].Clone() as EntityBase;
            }
            return trainingLessonClone;
        }

        public LessonType GetTrainingType()
        {
            if (TrainingMaterials.Any(i => i is VideoMaterial)) return LessonType.VideoLesson;
            else return LessonType.TextLesson;
            //return !TrainingTypes.Any(i => i is VideoMaterial) ? (TextMaterial)trainingType : (VideoMaterial)trainingType;
        }
        public override string ToString()
        {
            return $"{Description}";
        }

        public byte[] ReadVersion()
        {
            throw new NotImplementedException();
        }

        public void SetVersion(byte[] version)
        {
            throw new NotImplementedException();
        }
    }
}
