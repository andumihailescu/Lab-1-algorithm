using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApriori
{
    internal class Table
    {

        private List<string> transactedItems;
        private List<List<string>> transactionTable;
        private List<int> numberOfTransactions;

        private string outputFilePath = @"D:\School\Data Mining\Lab1\DateApriori\OutputTables\OutputTable.csv";
        private int minimumThreshold;
        private bool minimumThresholdIsNumber = false;

        public Table()
        {

        }

        public void OpenTable()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"D:\School\Data Mining\Lab1\DateApriori\Tables";
            openFileDialog1.ShowDialog();

            string filePath = openFileDialog1.FileName;

            StreamReader reader = null;
            if (File.Exists(filePath))
            {
                reader = new StreamReader(File.OpenRead(filePath));
                transactedItems = new List<string>();
                transactionTable = new List<List<string>>();
                numberOfTransactions = new List<int>();
                int lineIndex = 0;
                int columnIndex;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    columnIndex = 0;

                    foreach (var item in values)
                    {
                        if (columnIndex != 0)
                        {
                            if (lineIndex == 0)
                            {
                                transactedItems.Add(item);
                            }
                            else
                            {
                                if (columnIndex == 1)
                                {
                                    transactionTable.Add(new List<string>());
                                }
                                transactionTable[lineIndex - 1].Add(item);
                            }
                        }
                        columnIndex++;

                    }
                    lineIndex++;
                }
            }
        }

        public void CountTransactions()
        {
            int lines = transactionTable.Count;
            int columns = transactionTable[0].Count;
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        numberOfTransactions.Add(0);
                    }
                    if (transactionTable[i][j] == transactedItems[j])
                    {
                        numberOfTransactions[j]++;
                    }
                }
            }
        }
        
        public void CalculateL1()
        {
            if (numberOfTransactions.Count == 0)
            {
                CountTransactions();
            }
            if (minimumThresholdIsNumber)
            {
                OutputL1();
            }
        }

        public void SetMinimumThreshold(string minimumThreshold)
        {
            if (int.TryParse(minimumThreshold, out this.minimumThreshold))
            {
                minimumThresholdIsNumber = true;
            }
            else
            {
                minimumThresholdIsNumber = false;
            }
        }

        public void OutputL1()
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int numberOfElements = numberOfTransactions.Count;
                string header = "";
                string data = "";

                if (numberOfTransactions[0] >= minimumThreshold)
                {
                    header = transactedItems[0];
                    data = $"{numberOfTransactions[0]}";
                }

                for (int i = 1; i < numberOfElements; i++)
                {
                    if (numberOfTransactions[i] >= minimumThreshold)
                    {
                        header += $", {transactedItems[i]}";
                        data += $", {numberOfTransactions[i]}";
                    }
                }
                writer.WriteLine(header);
                writer.WriteLine(data);
            }
        }

    }
}
