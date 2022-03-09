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
        public byte[] Version { get; set; }
        public List<EntityBase> TrainingMaterials;
        public TrainingLesson()
        {
            TrainingMaterials = new List<EntityBase>();
        }
        public void Add(EntityBase entityBase)
        {
            TrainingMaterials.Add(entityBase);
        }
        public override TrainingLesson Clone()
        {
            var trainingLessonClone = new TrainingLesson();
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
    }
}
