using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DateApriori
{
    internal class Table
    {

        private List<string> transactedItems;
        private List<List<bool>> transactionTable;
        private List<int> numberOfTransactions;

        private int lines;
        private int columns;

        private List<string> transactedItemsL2;
        private List<List<int>> transactedItemsPosition;
        private List<int> numberOfTransactionsL2;

        private string formattedTablePath = @"D:\School\Data Mining\Lab1\DateApriori\OutputTables\FormattedTable.csv";
        private string outputFilePathL1 = @"D:\School\Data Mining\Lab1\DateApriori\OutputTables\OutputTableL1.csv";
        private string outputFilePathL2 = @"D:\School\Data Mining\Lab1\DateApriori\OutputTables\OutputTableL2.csv";
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
                transactionTable = new List<List<bool>>();
                numberOfTransactions = new List<int>();

                transactedItemsL2 = new List<string>();
                transactedItemsPosition = new List<List<int>>();
                numberOfTransactionsL2 = new();

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
                                    transactionTable.Add(new List<bool>());
                                }
                                if (item == "?" || item == "-")
                                {
                                    transactionTable[lineIndex - 1].Add(false);
                                }
                                else
                                {
                                    transactionTable[lineIndex - 1].Add(true);
                                }
                            }
                        }
                        columnIndex++;
                    }
                    lineIndex++;
                }

                lines = transactionTable.Count;
                columns = transactionTable[0].Count;
            }
        }

        public void CalculateL1()
        {
            if (numberOfTransactions.Count == 0)
            {
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0)
                        {
                            numberOfTransactions.Add(0);
                        }
                        if (transactionTable[i][j] == true)
                        {
                            numberOfTransactions[j]++;
                        }
                    }
                }
            }

            if (minimumThresholdIsNumber)
            {
                OutputResults(transactedItems, numberOfTransactions, outputFilePathL1);
            }
        }

        public void CalculateL2()
        {
            if (numberOfTransactionsL2.Count == 0)
            {
                transactedItemsPosition.Add(new List<int>());
                transactedItemsPosition.Add(new List<int>());

                int transactedItemsCount = 0;

                for (int i = 0; i < columns; i++)
                {
                    for (int j = i + 1; j < columns; j++)
                    {
                        transactedItemsL2.Add(transactedItems[i] + " & " + transactedItems[j]);
                        transactedItemsPosition[0].Add(i);
                        transactedItemsPosition[1].Add(j);
                        numberOfTransactionsL2.Add(0);

                        transactedItemsCount++;
                    }
                }

                for (int i = 0; i < transactedItemsCount; i++)
                {
                    for (int j = 0; j < lines; j++)
                    {
                        if ((transactionTable[j][transactedItemsPosition[0][i]] == true)
                            && (transactionTable[j][transactedItemsPosition[1][i]] == true))
                        {
                            numberOfTransactionsL2[i]++;
                        }
                    }
                }
            }

            if (minimumThresholdIsNumber)
            {
                OutputResults(transactedItemsL2, numberOfTransactionsL2, outputFilePathL2);
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

        public void OutputTable()
        {
            using (StreamWriter writer = new StreamWriter(formattedTablePath))
            {

                for (int i = 0; i < lines; i++)
                {
                    string line = "";
                    if (transactionTable[i][0] == true)
                    {
                        line += transactedItems[0];
                    }
                    else
                    {
                        line += "-";
                    }
                    for (int j = 1; j < columns; j++)
                    {
                        line += ", ";
                        if (transactionTable[i][j] == true)
                        {
                            line += transactedItems[j];
                        }
                        else
                        {
                            line += "-";
                        }
                    }
                    writer.WriteLine(line);
                }
            }
        }

        public void OutputResults(List<string> transactedItems, List<int> numberOfTransactions, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int numberOfElements = numberOfTransactions.Count;
                string header = "";
                string data = "";
                bool firstItem = true;

                if (numberOfTransactions[0] >= minimumThreshold)
                {
                    header += transactedItems[0];
                    data += numberOfTransactions[0];
                    firstItem = false;
                }

                for (int i = 1; i < numberOfElements; i++)
                {
                    if (numberOfTransactions[i] >= minimumThreshold)
                    {
                        if (!firstItem)
                        {
                            header += ", ";
                            data += ", ";
                        }
                        else
                        {
                            firstItem = false;
                        }
                        header += transactedItems[i];
                        data += numberOfTransactions[i];
                    }
                }
                writer.WriteLine(header);
                writer.WriteLine(data);
            }
        }

    }
}
