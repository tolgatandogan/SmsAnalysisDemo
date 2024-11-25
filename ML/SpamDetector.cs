using Microsoft.ML;
using SmsAnalysisDemo.ML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsAnalysisDemo.ML
{
    public class SpamDetector : ISpamDetector
    {
        private static readonly string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ML", "Data", "spam_sms_data.csv");
        private static readonly string ModelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ML", "Data", "spam_sms_data.zip");

        public bool Check(string text, bool chkZip)
        {
            var mlContext = new MLContext();

            //Step 1: Load Data 👇
            IDataView dataView = mlContext.Data.LoadFromTextFile<AnalyzeInput>(DataPath, hasHeader: true, separatorChar: ',');

            //Step 2: Split data to train-test data 👇
            DataOperationsCatalog.TrainTestData trainTestSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            IDataView trainingData = trainTestSplit.TrainSet; //80% of the data.
            IDataView testData = trainTestSplit.TestSet; //20% of the data.

            //Step 3: Common data process configuration with pipeline data transformations + choose and set the training algorithm 👇
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(AnalyzeInput.Message))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            //Step 4: Train the model 👇
            ITransformer model = estimator.Fit(trainingData);

            #region Advanced: Evaulating the model to see its accuracy and save/persist the trained model to a .ZIP file and use it (like a cache).

            //* Evaluate the model and show accuracy stats 👇
            var predictions = model.Transform(testData);
            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Label", scoreColumnName: "Score");
            var accuracy = metrics.Accuracy; // 0.97 for our test model.
            var f1Score = metrics.F1Score; //0.91 for our test model.

            //* Save/persist the trained model to a .ZIP file. 👇
            mlContext.Model.Save(model, trainingData.Schema, ModelPath);

            //* Load the model from the .ZIP file on production. 👇
            if (chkZip && File.Exists(ModelPath))
            {
                model = mlContext.Model.Load(ModelPath, out DataViewSchema inputSchema);
            }

            #endregion Advanced: Evaulating the model to see its accuracy and save/persist the trained model to a .ZIP file and use it (like a cache).

            //Step 5: Predict 👇
            var analyzeInput = new AnalyzeInput
            {
                Message = text
            };

            var predictionEngine = mlContext.Model.CreatePredictionEngine<AnalyzeInput, AnalyzeResult>(model);
            var result = predictionEngine.Predict(analyzeInput);

            return IsSpam(result) ? true : false;
        }

        private static bool IsSpam(AnalyzeResult result)
        {
            //1 -> spam / 0 -> ham (for 'Prediction' column)
            return result is { Prediction: true, Probability: >= 0.5f };
        }
    }
}