namespace DateApriori
{
    public partial class Form1 : Form
    {
        Table table = new Table();

        public Form1()
        {
            InitializeComponent();
        }

        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            table.OpenTable();
        }
        private void CalculateL1Button_Click(object sender, EventArgs e)
        {
            table.SetMinimumThreshold(minimumThresholdInputField.Text);
            table.CalculateL1();
        }

    }
}