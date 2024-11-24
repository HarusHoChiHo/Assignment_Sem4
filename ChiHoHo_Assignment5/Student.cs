using Microsoft.ML.Data;

namespace ChiHoHo_Assignment5_Q3
{
    public class Student
    {
        [LoadColumn(0)]
        public float STG;

        [LoadColumn(1)]
        public float SCG;

        [LoadColumn(2)]
        public float STR;

        [LoadColumn(3)]
        public float LPR;

        [LoadColumn(4)]
        public float PEG;

        //[LoadColumn(5)]
        //public String UNS;
    }

    public class CluesterPrediction
    {
        [ColumnName("PredictedLabel")]
        public uint PredictedClusterId;

        [ColumnName("Score")]
        public float[]? Distances;
    }
}
