using ChiHoHo_Assignment5_Q3;
using Microsoft.ML;

namespace ChiHoHo_Assignment5;

class  Program
{
    static void Main(string[] args)
    {
        string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "Student.csv");
        string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "StudentClusteringModel.zip");
        var mlContext = new MLContext(seed: 0);

        IDataView dataView = mlContext.Data.LoadFromTextFile<Student>(_dataPath, hasHeader: true, separatorChar: ',');

        string featureColumnName = "Features";

        var pipeline = mlContext.Transforms
            .Concatenate(featureColumnName, "STG", "SCG", "STR", "LPR", "PEG")
            .Append(mlContext.Clustering.Trainers.KMeans(featureColumnName, numberOfClusters: 4));

        var model = pipeline.Fit(dataView);

        using (var fileStream = new FileStream(_modelPath, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            mlContext.Model.Save(model, dataView.Schema, fileStream);
        }
        var predictor = mlContext.Model.CreatePredictionEngine<Student, CluesterPrediction>(model);

        foreach (var item in TestStudentData.student)
        {
            var prediction = predictor.Predict(item);

            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances ?? Array.Empty<float>())}");
        }
    }
}