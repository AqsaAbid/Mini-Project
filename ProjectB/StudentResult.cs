using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectB
{
    class StudentResult
    {
        private int StudentId;
        private int AssessmentComponentId;
        private int RubricMeasurementId;
        private DateTime EvaluationDate;

        public int StudentId1
        {
            get
            {
                return StudentId;
            }

            set
            {
                StudentId = value;
            }
        }

        public int AssessmentComponentId1
        {
            get
            {
                return AssessmentComponentId;
            }

            set
            {
                AssessmentComponentId = value;
            }
        }

        public int RubricMeasurementId1
        {
            get
            {
                return RubricMeasurementId;
            }

            set
            {
                RubricMeasurementId = value;
            }
        }

        public DateTime EvaluationDate1
        {
            get
            {
                return EvaluationDate;
            }

            set
            {
                EvaluationDate = value;
            }
        }
    }
}
