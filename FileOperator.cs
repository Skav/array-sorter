using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace projekt_sortowanie
{
    internal class FileOperator
    {
        private string directoryPath;
        public Dictionary<string, string> dataSetFiles = new Dictionary<string, string>();

        public FileOperator()
        {
            this.directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); // getting location of exectuable file
        }

        public FileOperator(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public Dictionary<string, string> GetAllDataSetFiles()
        {
            if (!dataSetFiles.Any())
            {
                foreach (string file in Directory.GetFiles(this.directoryPath, "dataset-*.txt"))
                {
                    dataSetFiles.Add(Path.GetFileName(file), $"{Path.Combine(this.directoryPath, file)}");
                }
            }

            return this.dataSetFiles;
        }

        public string CreateDataSetFile(string data)
        {
            string fileName = $"dataset-{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.txt";
            using (FileStream fs = File.Create(Path.Combine(this.directoryPath, fileName)))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);
            }

            return Path.Combine(this.directoryPath, fileName);
        }

        public int[] ReadDataSetFromFile(string fileName)
        {
            string fileContent = File.ReadAllText(Path.Combine(this.directoryPath, fileName)); 
            var dataSet = Array.ConvertAll(fileContent.Split(';'), s => int.Parse(s));

            return dataSet;
        }

        public string CreateResultsFile(string projectPart, List<string> results)
        {
            string fileName = $"results-{projectPart}-{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.csv";
            using (FileStream fs = File.Create(Path.Combine(this.directoryPath, fileName)))
            {
                var data = "projectPart;algorithm;tableType;tableLenght;time\n"; // setting columns names as 1st line in .csv file
                foreach (var item in results) //adding actual data to file
                    data += $"{item}\n";

                byte[] bytes = Encoding.UTF8.GetBytes(data);
                fs.Write(bytes, 0, bytes.Length);
            }

            return Path.Combine(this.directoryPath, fileName);
        }

    }
}
