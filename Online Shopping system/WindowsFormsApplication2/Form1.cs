using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        String operation;
        Double firstnum;
        Double secondnum;
        Double answer;
        Double iTax = 17.5;

        Double oven;
        Double refrig;
        Double washing;

        Double Nigerian_Naira = 302.96;
        Double US_Dollar = 1.52;
        Double Kenyan_Shilling = 156.21;
        Double Brazalian_Real = 5.86;
        Double Canadian_Dollar = 2.03;
        Double Indian_Rupee = 100.68;
        Double Philippine_Peso = 71.74;
        Double Indonesian_Rupiah = 20746.75;

        public string refno;
        public string cname;
        public string ph;
        public string odate;
        public string otime;
        public string ov;
        public string re;
        public string wa;
        public string qt1;
        public string qt2;
        public string qt3;
        public string up1;
        public string up2;
        public string up3;
        public string st1;
        public string st2;
        public string st3;
        public string tx;
        public string nst;
        public string nt;




        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Srushti\\Desktop\\WindowsFormsApplication2\\WindowsFormsApplication2\\db.mdf;Integrated Security=True;Connect Timeout=30");
        private void label16_Click(object sender, EventArgs e)
        {

        }
        public void accept()
        {
            cname = customer_NameTextBox.Text;
            ph = customer_PhoneTextBox.Text;
            refno = order_Ref_NoTextBox.Text;
            odate = order_DateTextBox.Text;
            otime = order_TimeTextBox.Text;
            qt1 = qty1TextBox.Text;
            qt2 = qty2TextBox.Text;
            qt3 = qty3TextBox.Text;
            up1 = unit_Price1TextBox.Text;
            up2 = unit_Price2TextBox.Text;
            up3 = unit_Price3TextBox.Text;
            st1 = sub_Total1TextBox.Text;
            st2 = sub_Total2TextBox.Text;
            st3 = sub_Total3TextBox.Text;
            nst = net_Sub_TotalTextBox.Text;
            nt = net_TotalTextBox.Text;
            tx = taxTextBox.Text;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Order_Systems values('" + refno + "','" + cname + "','" + ph + "','" + odate + "','" + otime + "','" + ov + "','" + re + "','"+wa+"','"+qt1+"','"+qt2+"','"+qt3+"','"+up1+"','"+up2+"','"+up3+"','"+st1+"','"+st2+"','"+st3+"','"+tx+"','"+nst+"','"+nt+"')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("inserted success");
            con.Close();

        }
        private void button18_Click(object sender, EventArgs e)
        {
            button18.Visible = false;

        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            Calculator.SelectedTab = tabPage1;
        }

        private void order_SystemsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.order_SystemsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dbDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.Order_Systems' table. You can move, or remove it, as needed.
            this.order_SystemsTableAdapter.Fill(this.dbDataSet.Order_Systems);
            comboBox1.Text = "Choose One........";
            comboBox1.Items.Add("USA");
            comboBox1.Items.Add("Nigerian");
            comboBox1.Items.Add("Kenyan");
            comboBox1.Items.Add("Canada");
            comboBox1.Items.Add("Brazil");
            comboBox1.Items.Add("Phillippine");
            comboBox1.Items.Add("Indonesia");
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/mm/yyyy");
            order_TimeTextBox.Text = iDate.ToString("HH:mm:ss");
            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            unit_Price1TextBox.Text= "0";
            unit_Price2TextBox.Text = "0";
            unit_Price3TextBox.Text = "0";
        }

        private void order_Ref_NoLabel_Click(object sender, EventArgs e)
        {

        }

        private void order_Ref_NoTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void order_TimeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void net_TotalTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (label15.Text == "0")
                label15.Text = num.Text;
            else
                label15.Text = label15.Text + num.Text;

                    
         }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Cal_Operator(object sender, EventArgs e)
        {
            Button ops = (Button)sender;
            firstnum = Double.Parse(label15.Text);
            label15.Text = "";
            operation = ops.Text;
            label18.Text = System.Convert.ToString(firstnum)+" "+operation;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            label18.Text = "";
            secondnum = Double.Parse(label15.Text);
            switch(operation)
            {
                case "+" :
                    answer = (firstnum + secondnum);
                    label15.Text = System.Convert.ToString(answer);
                    break;

                case "-":
                    answer = (firstnum - secondnum);
                    label15.Text = System.Convert.ToString(answer);
                    break;
                case "*":
                    answer = (firstnum * secondnum);
                    label15.Text = System.Convert.ToString(answer);
                    break;
                case "/":
                    answer = (firstnum / secondnum);
                    label15.Text = System.Convert.ToString(answer);
                    break;
                default:
                    break;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label15.Text.Length > 0)
                label15.Text = label15.Text.Remove(label15.Text.Length - 1, 1);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if(num.Text==".")
            {
                if (!label15.Text.Contains("."))
                    label15.Text = label15.Text + num.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            label18.Text = "";
            label15.Text = "0";
        }

        private void currencyConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button18.Visible = false;
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button18.Visible = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            button18.Visible = true;

        }

        private void button20_Click(object sender, EventArgs e)
        {
            qty1TextBox.Text = "0";
            qty2TextBox.Text = "0";
            qty3TextBox.Text = "0";
            unit_Price1TextBox.Text = "0";
            unit_Price2TextBox.Text = "0";
            unit_Price3TextBox.Text = "0";
            sub_Total1TextBox.Text = "";
            sub_Total2TextBox.Text = "";
            sub_Total3TextBox.Text = "";
            net_Sub_TotalTextBox.Text = "";
            taxTextBox.Text = "";
            net_TotalTextBox.Text = "";
            customer_NameTextBox.Text = "";
            customer_PhoneTextBox.Text = "";
            order_Ref_NoTextBox.Text = "";

        }

        private void sub_Total1TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void taxTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void customer_NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Calculator.SelectedTab = tabPage2;
            


        }

        private void button24_Click(object sender, EventArgs e)
        {
            Calculator.SelectedTab = tabPage3;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Calculator.SelectedTab = tabPage2;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            order_DateTextBox.Text = iDate.ToString("dd/mm/yyyy");
            order_TimeTextBox.Text = iDate.ToString("HH:mm:ss");
             accept();
            Calculator.SelectedTab = tabPage3;
            this.Validate();
            this.order_SystemsBindingSource.EndEdit();
            accept();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Double o;
            Double r;
            Double w;
            Double unitprice1;
            Double unitprice2;
            Double unitprice3;
            Double NetTax;
            Double SubTotal;
            Double NetTotal;

            o = Double.Parse(qty1TextBox.Text);
            r= Double.Parse(qty2TextBox.Text);
            w= Double.Parse(qty3TextBox.Text);

            unitprice1 = Double.Parse(unit_Price1TextBox.Text);
            unitprice2 = Double.Parse(unit_Price2TextBox.Text);
            unitprice3 = Double.Parse(unit_Price3TextBox.Text);


            oven = o * unitprice1;
            refrig = r * unitprice2;
            washing = w * unitprice3;

            sub_Total1TextBox.Text = System.Convert.ToString(oven);
            sub_Total2TextBox.Text = System.Convert.ToString(refrig);
            sub_Total3TextBox.Text = System.Convert.ToString(washing);

            NetTax = ((oven + refrig + washing)) / 100;
            taxTextBox.Text = System.Convert.ToString(NetTax);
            net_Sub_TotalTextBox.Text = System.Convert.ToString(oven + refrig + washing);
            net_TotalTextBox.Text = System.Convert.ToString(NetTax + (oven + refrig + washing));


            unit_Price1TextBox.Text=String.Format("{0:C}",Double.Parse(unit_Price1TextBox.Text));
            unit_Price2TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price2TextBox.Text));
            unit_Price3TextBox.Text = String.Format("{0:C}", Double.Parse(unit_Price3TextBox.Text));
            sub_Total1TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total1TextBox.Text));
            sub_Total2TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total2TextBox.Text));
            sub_Total3TextBox.Text = String.Format("{0:C}", Double.Parse(sub_Total3TextBox.Text));
            taxTextBox.Text = String.Format("{0:C}", Double.Parse(taxTextBox.Text));
            net_TotalTextBox.Text = String.Format("{0:C}", Double.Parse(net_TotalTextBox.Text));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Double Nigerian_Naira = 302.96;
            //Double US_Dollar = 1.52;
            //Double Kenyan_Shilling = 156.21;
            //Double Brazalian_Real = 5.86;
            //Double Canadian_Dollar = 2.03;
            //Double Indian_Rupee = 100.68;
            //Double Philippine_Peso = 71.74;
            //Double Indonesian_Rupiah = 20746.75;


            //comboBox1.Items.Add("USA");
            //comboBox1.Items.Add("Nigerian");
            //comboBox1.Items.Add("Kenyan");
            //comboBox1.Items.Add("Canada");
            //comboBox1.Items.Add("Brazil");
            //comboBox1.Items.Add("Phillippine");
            //comboBox1.Items.Add("Indonesia");

            Double British_Pound = Double.Parse(textBox1.Text);

            if (comboBox1.Text == ("Nigerian"))
            {
                label16.Text = System.Convert.ToString((British_Pound * Nigerian_Naira));
            }
            if (comboBox1.Text == ("USA"))
            {
                label16.Text = System.Convert.ToString((British_Pound * US_Dollar));
            }
            if (comboBox1.Text == ("Kenyan"))
            {
                label16.Text = System.Convert.ToString((British_Pound * Kenyan_Shilling));
            }
            if (comboBox1.Text == ("Brazil"))
            {
                label16.Text = System.Convert.ToString((British_Pound * Brazalian_Real));
            }
            if (comboBox1.Text == ("Canada"))
            {
                label16.Text = System.Convert.ToString((British_Pound * Canadian_Dollar));
            }
            if (comboBox1.Text == ("Phillippine"))
            { 
                label16.Text = System.Convert.ToString((British_Pound * Philippine_Peso));
            }
            if (comboBox1.Text == ("Indonesia"))
            {
                label16.Text = System.Convert.ToString((British_Pound * Indonesian_Rupiah));
            }



        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
