/* Student Name: Bakkesh Shivakumar Aladahalli
 * Student ID: 20230557
 * Date: 12/10/2020
 * Assignment: 1
 * Assignment: Simple Table Service App - 
 * Create a well-designed application that allows 
 * “Sult Bar & Restaurant” staff to take 
 * table orders from bar customers  
 */


using System;
using System.Windows.Forms;

namespace SultServerApp
{
    public partial class Order : Form
    {
        // Global variables/fields declaration
        private int TotalCompanyTransactions;
        private int CompanyTotalPizza;

        private double TotalCompanyReceipts;

        private const int MARGHERITAPIZZACOST = 9;

        private const double PEPPERONIPIZZACOST = 11.50;
        private const double HAMPINEAPPLECOST = 12.79;
        private const double SURCHARGECOST = 2.49;

        // Class default constructor
        public Order()
        {
            InitializeComponent();

            /* Hiding the controls that need not be shown 
               when the application loads for the first time. */
            OrderSummaryGroupBox.Visible = false;
            PizzaMenuGroupBox.Visible = false;
            OrderSummaryGroupBox.Visible = false;
            LogoPictureBox.Visible = false;
            CompanySummaryGroupBox.Visible = false;
            OrderPanel.Visible = false;

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Form title is changed to display Server Name 
            //along with the table he is serving.
            this.Text = ServerNameTextBox.Text + " @ Table Numer " + TableNoTextBox.Text;

            StartPanel.Visible = false;

            PizzaMenuGroupBox.Visible = true;
            OrderPanel.Visible = true;
            LogoPictureBox.Visible = true;

            OrderButton.Enabled = true;
            PizzaMenuGroupBox.Enabled = true;

            MargheritaPizzaQuantityTextBox.Focus();
            MargheritaPizzaQuantityTextBox.SelectAll();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {

            try
            {
                //taking user input
                int MargheritaPizzaQuantity = int.Parse(
                                              MargheritaPizzaQuantityTextBox.Text);

                try
                {
                    int PepperoniPizzaQuanity = int.Parse(
                                                PepperoniPizzaQuanityTextBox.Text);

                    try
                    {
                        int HamPineappleQuantity = int.Parse(
                                                   HamPineappleQuantityTextBox.Text);

                        // Calculations for transactions
                        double TotalOrderCost = (MARGHERITAPIZZACOST * 
                                                 MargheritaPizzaQuantity) +
                                                (PEPPERONIPIZZACOST * 
                                                 PepperoniPizzaQuanity) +
                                                (HAMPINEAPPLECOST * 
                                                 HamPineappleQuantity) +
                                                SURCHARGECOST;

                        TotalCompanyReceipts += TotalOrderCost;

                        int SumOrderItems = HamPineappleQuantity +
                                            PepperoniPizzaQuanity +
                                            MargheritaPizzaQuantity;

                        CompanyTotalPizza += SumOrderItems;

                        //Output to transaction lables
                        ServerNameDisplayLabel.Text = ServerNameTextBox.Text;
                        TotalPizzasOrderedLabel.Text = SumOrderItems.ToString();
                        TotalTableReceiptsValueLabel.Text = TotalOrderCost.ToString("C");

                        OrderSummaryGroupBox.Visible = true;

                        TotalCompanyTransactions += 1;

                        OrderButton.Enabled = false;
                        PizzaMenuGroupBox.Enabled = false;
                    }
                    catch
                    {
                        MessageBox.Show("Invalid entry, expecting numarical values, " +
                                        "Please try again!!", "Input Error !", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                        HamPineappleQuantityTextBox.Focus();

                        HamPineappleQuantityTextBox.SelectAll();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid entry, expecting numarical values, " +
                                    "Please try again!!", "Input Error !",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                    PepperoniPizzaQuanityTextBox.Focus();

                    PepperoniPizzaQuanityTextBox.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Invalid entry, expecting numarical values, " +
                                "Please try again!!", "Input Error !",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);

                MargheritaPizzaQuantityTextBox.Focus();

                MargheritaPizzaQuantityTextBox.SelectAll();
            }

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Form title is changed to "Welcome to Sult".
            this.Text = "Welcome to Sult";

            //Hiding the controls that are to be hidden from the user.
            PizzaMenuGroupBox.Visible = false;
            OrderSummaryGroupBox.Visible = false;
            LogoPictureBox.Visible = false;
            CompanySummaryGroupBox.Visible = false;
            OrderPanel.Visible = false;

            //showing Start butten Panel 
            StartPanel.Visible = true;

            ServerNameTextBox.Text = "";
            TableNoTextBox.Text = "";

            MargheritaPizzaQuantityTextBox.Text = "0";
            PepperoniPizzaQuanityTextBox.Text = "0";
            HamPineappleQuantityTextBox.Text = "0";

            ServerNameTextBox.Focus();
        }

        private void SummaryButton_Click(object sender, EventArgs e)
        {
            //If there is/are transaction/s to show or not is checked
            if (0 < TotalCompanyTransactions)
            {
                //AvgTransactionValue is calculated by dividing 
                //TotalCompanyReceipts by TotalCompanyTransactions.
                double AvgTransactionValue = TotalCompanyReceipts / 
                                             TotalCompanyTransactions;

                // Respective values are displayed in respective labels
                TotalCompanyTransactionsLabel.Text = TotalCompanyTransactions.ToString();
                CompanyTotalNoPizzasLabel.Text = CompanyTotalPizza.ToString();

                // Round of the TotalCompanyReceipts and 
                //AvgTransactionValue to two decimal points.
                Math.Round(TotalCompanyReceipts, 2);
                Math.Round(AvgTransactionValue, 2);

                TotalCompanyReceiptsLabel.Text = TotalCompanyReceipts.ToString("C");
                AvgTransactionValueLabel.Text = AvgTransactionValue.ToString("C");

                this.Text = "Sult Company Summary Data";

                // hinding and showing respective controls
                PizzaMenuGroupBox.Visible = false;
                OrderSummaryGroupBox.Visible = false;

                CompanySummaryGroupBox.Visible = true;
            }
            else
            {
                //If there is/are no transaction/s to show alert 
                //message is popped up stating the same
                MessageBox.Show("No Company Transactions to Show", "Message !", 
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Application Exits
            this.Close();
        }

        /*Select All region Helps to improve the user experience
         when a user clicks/enters respective text box in the
         application the text inside it will be selected
         so that it will assist the user in changing it.
        */
        #region Select All

        private void MargheritaPizzaQuantityTextBox_Enter(object sender, 
                                                          EventArgs e)
        {
            MargheritaPizzaQuantityTextBox.SelectAll();
        }

        private void PepperoniPizzaQuanityTextBox_Enter(object sender, 
                                                        EventArgs e)
        {
            PepperoniPizzaQuanityTextBox.SelectAll();
        }

        private void HamPineappleQuantityTextBox_Enter(object sender, 
                                                       EventArgs e)
        {
            HamPineappleQuantityTextBox.SelectAll();
        }

        private void MargheritaPizzaQuantityTextBox_MouseClick(object sender, 
                                                               MouseEventArgs e)
        {
            MargheritaPizzaQuantityTextBox.SelectAll();
        }

        private void PepperoniPizzaQuanityTextBox_MouseClick(object sender, 
                                                             MouseEventArgs e)
        {
            PepperoniPizzaQuanityTextBox.SelectAll();
        }

        private void HamPineappleQuantityTextBox_MouseClick(object sender, 
                                                            MouseEventArgs e)
        {
            HamPineappleQuantityTextBox.SelectAll();
        }

        #endregion
    }
}
