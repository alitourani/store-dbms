using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Store
{

    public partial class Form1 : Form
    {
        static SqlConnection conn = new SqlConnection("Server=(local);AttachDbFilename=C:\\Program Files\\Microsoft SQL Server\\MSSQL10.MSSQLSERVER\\MSSQL\\DATA\\ShopDB.mdf;Database=ShopDB" + " ;Trusted_Connection=Yes");

        public Form1()
        {
            InitializeComponent();
        }


        public int Checker(string cmd , int number) {
            
            int counter = 0;
            // Check Duplicates
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand(cmd + number, conn);
                SqlDataReader readd = com.ExecuteReader();
                if (readd.HasRows)
                {
                    counter++;
                }
                readd.Close();
                conn.Close();
            }
            catch (Exception)
            {
                textBox10.Text = "Error Checking Duplicate Records";
            }

            return counter;
        }


        // ____________________________________ Show on DataGridView
        public void Show(string input)
        {
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                Da.SelectCommand = new SqlCommand(input, conn);
                Da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception) { textBox10.Text = "Error Showing in Table"; }
        }


        public void Exec(string sqlst) { 
        try{
        conn.Open();
        SqlCommand com = new SqlCommand(sqlst , conn);
        SqlDataReader readd = com.ExecuteReader();
        readd.Close();
        conn.Close();
        }
        catch (Exception)
        {
            textBox10.Text = "Error Executing Query!";
        }
        }

        //______________________________________________________ textfields __________________________________________
        
        // National Code Change
        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (textBox31.Text != "")
            {
                Show("Exec Search_Costumer @SID = " + textBox31.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("Select * from Costumer");
                textBox10.Text = "";
            }
        }

        // Commodity Type Change
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            Show("Exec ShowAll_ComType");
            textBox10.Text = "";
        }

        // Clerck ID Change
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Show("Exec Search_Clerk @SID = " + textBox1.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("Exec SearchAll_Clerk");
                textBox10.Text = "";
            }
        }
        
        // Company ID Change
        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.Text != "")
            {
                Show("Exec Search_Company @SID = " + textBox27.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("Exec ShowAll_Company");
                textBox10.Text = "";
            }
        }

        // Commodity ID Change
        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text != "")
            {
                Show("Exec Search_Commodity @SID = " + textBox17.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("Exec ShowAll_Commodity");
                textBox10.Text = "";
            }
        }

        // Delivery Change
        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            if (textBox37.Text != "")
            {
                Show("Exec Search_Delivery @SID = " + textBox37.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("select * from Delivery");
                textBox10.Text = "";
            }
        }

        // Buy Change
        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (textBox43.Text != "")
            {
                Show("Exec Search_Buy @SID = " + textBox43.Text + " ");
                textBox10.Text = "";
            }
            else
            {
                Show("select * from Buy");
                textBox10.Text = "";
            }
        }


        // ______________________________________________________ Buttons _____________________________________________


        // Delete Costumer
        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox31.Text == "")
                textBox10.Text = "Fill the National Code Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox31.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Costumer @SID=" + test);
                    Show("Select * from Costumer ");
                    textBox31.Text = textBox29.Text = textBox30.Text = textBox28.Text = textBox25.Text = textBox19.Text = "";
                }
                else
                    MessageBox.Show("National Code Must Be a Number!");
            }
        }

        // Delete Clerck
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox10.Text = "Fill the Clerck_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox1.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Clerk @SID=" + test + "");
                    Show("select * from Clerck ");
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                }
                else
                    MessageBox.Show("Clerck_ID Must Be a Number!");
            }
        }

        // Delete Company
        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox27.Text == "")
                textBox10.Text = "Fill the Company_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox27.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Company @SID=" + test + "");
                    Show("select * from Company");
                    textBox20.Text = textBox21.Text = textBox23.Text = textBox24.Text = textBox22.Text = textBox26.Text = textBox27.Text = "";
                }
                else
                    MessageBox.Show("Company_ID Must Be a Number!");
            }
        }

        // Delete Commodity
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "")
                textBox10.Text = "Fill the Commodity_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox17.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Commidity @SID=" + test + "");
                    Show("select * from Commodity");
                    textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox16.Text = textBox17.Text= "";
                }
                else
                    MessageBox.Show("Commidity_ID Must Be a Number!");
            }
        }

        // Delete CommodityType
        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
                textBox10.Text = "Fill the Commodity_Type_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox18.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_ComType @SID=" + test + "");
                    Show("select * from Commodity_Type");
                    textBox18.Text = textBox15.Text = "";
                }
                else
                    MessageBox.Show("Commidity_Type_ID Must Be a Number!");
            }
        }


        // Delete Dilivery List
        private void button28_Click(object sender, EventArgs e)
        {
            if (textBox37.Text == "")
                textBox10.Text = "Fill the Delivery_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox37.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Delivery @SID=" + test + "");
                    Show("select * from Delivery");
                    textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                }
                else
                    MessageBox.Show("Delivery_ID Must Be a Number!");
            }
        }

        // Delete Buy
        private void button31_Click(object sender, EventArgs e)
        {
            if (textBox43.Text == "")
                textBox10.Text = "Fill the Buy_ID Field And Try Again!";
            else
            {
                textBox10.Text = "";
                int test;
                bool ok = int.TryParse(textBox43.Text, out test);
                if (ok)
                {
                    Exec("Exec Del_Buy @SID=" + test );
                    textBox38.Text = textBox39.Text = textBox40.Text = textBox41.Text = textBox42.Text = textBox43.Text = textBox44.Text = "";
                    Show("select * from Buy");
                }
                else
                    MessageBox.Show("Buy_ID Must Be a Number!");
            }
        }


        // Add Costumer
        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "" || textBox30.Text == "" || textBox31.Text == "")
                textBox10.Text = "NationalCode , Name And Surname Are Neccessary!";
            else
            {


                textBox10.Text = "";
                int nc, ag, ph = 0;
                bool ok1 = int.TryParse(textBox31.Text, out nc);
                bool ok2 = int.TryParse(textBox28.Text, out ag);
                if (textBox19.Text != "") int.TryParse(textBox19.Text, out ph);

                string checkcmd = "Select * from Costumer where National_Code = ";
                int ans = Checker(checkcmd,nc);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {

                    if (ok1 && ok2)
                    {
                        //SQL Code : Use ShopDB Exec Add_Costumer 7,'A','B',26,'Address',5
                        try
                        {
                            Exec("Use ShopDB Exec Add_Costumer " + nc + ",'" + textBox30.Text + "','" + textBox29.Text + "'," + ag + ",'" + textBox25.Text + "'," + ph);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Used!");
                        }
                        Show("select * from Costumer");
                        textBox31.Text = textBox29.Text = textBox30.Text = textBox28.Text = textBox25.Text = textBox19.Text = "";
                    }
                    else
                        MessageBox.Show("NationalCode , Age And PhoneNumber Must be Natural Integers!");
                }
            }
        }


        // Add Clerck
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox9.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int cid, ag=0, pid, m;
                bool ok1 = int.TryParse(textBox1.Text, out cid);
                if (textBox4.Text != "") int.TryParse(textBox4.Text, out ag);
                bool ok3 = int.TryParse(textBox5.Text, out pid);
                bool ok4 = int.TryParse(textBox9.Text, out m);

                string checkcmd = "Select * from Clerck where C_ID = ";
                int ans = Checker(checkcmd, cid);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1 && ok3 && ok4)
                    {
                        //SQL Code : Use ShopDB Exec Add_Clerk 80,'A','B',26,4,'Clothes','Address','5',1
                        Exec("Use ShopDB Exec Add_Clerk " + cid + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + ag + "," + pid + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "'," + m);
                        Show("Select * from Clerck");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                    }
                    else
                        MessageBox.Show("ClerckID , Age , PostID & Manager Must be Natural Integers!");
                }
            }
        }

        // Add Company
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox27.Text == "" || textBox26.Text == "" || textBox24.Text == "" || textBox20.Text == "" )
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int cid, ph=0, type, m=-1;
                bool ok1 = int.TryParse(textBox27.Text, out cid);
                bool ok3 = int.TryParse(textBox20.Text, out type);
                
                if (textBox23.Text != "") int.TryParse(textBox23.Text, out ph);
                if (textBox22.Text != "") int.TryParse(textBox22.Text, out m);

                string checkcmd = "Select * from Company where Company_Code = ";
                int ans = Checker(checkcmd, cid);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1 && ok3)
                    {
                        //SQL Code : Use ShopDB Exec Add_Company 234,'Grea','US',2,2,'222',1
                        Exec("Use ShopDB Exec Add_Company " + cid + ",'" + textBox26.Text + "','" + textBox24.Text + "'," + ph + "," + type + ",'" + textBox21.Text + "'," + m);
                        textBox20.Text = textBox21.Text = textBox23.Text = textBox24.Text = textBox22.Text = textBox26.Text = textBox27.Text = "";
                        Show("select * from Company");
                    }
                    else
                        MessageBox.Show("CompanyID , Phone Number , Produce Type & ManagerID Must be Natural Integers!");
                }
            }
        }

        
        private void button20_Click(object sender, EventArgs e)
        {

        }

        

        // Update Costumer
        private void button22_Click(object sender, EventArgs e)
        {
            if (textBox29.Text == "" || textBox30.Text == "" || textBox31.Text == "")
                textBox10.Text = "Red Fields Cannot be Empty!";
            else
            {
                textBox10.Text = "";
                int nc,ag,ph=0;
                bool ok1 = int.TryParse(textBox31.Text, out nc);
                bool ok2 = int.TryParse(textBox28.Text, out ag);
                if (textBox19.Text != "") int.TryParse(textBox19.Text, out ph);
                if (ok1)
                {
                    //SQL Code : Use ShopDB Exec Update_Costumer 99,'Ali2','T2',22,'Add2',2
                    Exec("Use ShopDB Exec Update_Costumer " + nc + ",'" + textBox30.Text + "','" + textBox29.Text + "'," + ag + ",'" + textBox25.Text + "'," + ph);
                    Show("select * from Costumer");
                    textBox31.Text = textBox29.Text = textBox30.Text = textBox28.Text = textBox25.Text = textBox19.Text = "";
                }
                else
                    MessageBox.Show("NationalCode , Age And PhoneNumber Must be Natural Integers!");
                
            }
        }

        // Update Clerk
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox9.Text == "")
                textBox10.Text = "Red Colored Lables Cannot be Empty!";
            else
            {
                textBox10.Text = "";
                int cid, ag=0, pid, m;
                bool ok1 = int.TryParse(textBox1.Text, out cid);
                if (textBox4.Text != "") int.TryParse(textBox4.Text, out ag);
                bool ok3 = int.TryParse(textBox5.Text, out pid);
                bool ok4 = int.TryParse(textBox9.Text, out m);
                if (ok1 && ok3 && ok4)
                {
                    //SQL Code : Use ShopDB Exec Update_Clerk 21,'Q','Q',21,1,'S','Addresss','222',1
                    Exec("Use ShopDB Exec Update_Clerk " + cid + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + ag + "," + pid + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "'," + m);
                    textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = "";
                    Show("Select * from Clerck");
                }
                else
                    MessageBox.Show("ClerckID , Age , PostID & Manager Must be Natural Integers!");
            }
        }

        // Update Company
        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox27.Text == "" || textBox26.Text == "" || textBox24.Text == "" || textBox20.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary And Should't be Empty!";
            else
            {
                textBox10.Text = "";
                int cid, ph = 0, type, m = -1;
                bool ok1 = int.TryParse(textBox27.Text, out cid);
                bool ok3 = int.TryParse(textBox20.Text, out type);

                if (textBox23.Text != "") int.TryParse(textBox23.Text, out ph);
                if (textBox22.Text != "") int.TryParse(textBox22.Text, out m);

                if (ok1 && ok3)
                {
                    //SQL Code : Use ShopDB Exec Update_Company 810,'Grea','US',2,2,'222',1
                    Exec("Exec Update_Company " + cid + ",'" + textBox26.Text + "','" + textBox24.Text + "'," + ph + "," + type + ",'" + textBox21.Text + "'," + m);
                    textBox20.Text = textBox21.Text = textBox23.Text = textBox24.Text = textBox22.Text = textBox26.Text = textBox27.Text = "";
                    Show("select * from Company");
                }
                else
                    MessageBox.Show("CompanyID , Phone Number , Produce Type & ManagerID Must be Natural Integers!");
            }
        }

        // Update Commodity
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox16.Text == "" || textBox17.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id, typid, cid, res, money;
                bool ok1 = int.TryParse(textBox17.Text, out id);
                bool ok2 = int.TryParse(textBox14.Text, out typid);
                bool ok3 = int.TryParse(textBox12.Text, out cid);
                bool ok4 = int.TryParse(textBox11.Text, out res);
                int.TryParse(textBox13.Text, out money);

                if (ok1 && ok2 && ok3 && ok4)
                {
                    //SQL Code : Exec Update_Commodity 37,'Name',2,200,1,1
                    Exec("Use ShopDB Exec Update_Commodity " + id + ",'" + textBox16.Text + "'," + typid + "," + money + "," + cid + "," + res);
                    textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox16.Text = textBox17.Text = "";
                    Show("select * from Commodity");
                }
                else
                    MessageBox.Show("CommodityID , CommodityType , CompanyID & Responsible Must be Natural Integers!");
            }
        }

        // Commodity Type Update
        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "" || textBox15.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id;
                bool ok1 = int.TryParse(textBox18.Text, out id);

                if (ok1)
                {
                    //SQL Code : Exec Update_ComType 45,'x'
                    Exec("Use ShopDB Exec Update_ComType " + id + ",'" + textBox15.Text + "'");
                    textBox18.Text = textBox15.Text = "";
                    Show("select * from Commodity_Type");
                }
                else
                    MessageBox.Show("CommodityTypeID Must be Natural Integers!");
            }
        }

        // Update Delivery
        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox37.Text == "" || textBox35.Text == "" || textBox36.Text == "" || textBox33.Text == "" || textBox32.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id, com, res, date, n, cty;
                bool ok1 = int.TryParse(textBox37.Text, out id);
                bool ok2 = int.TryParse(textBox36.Text, out com);
                bool ok3 = int.TryParse(textBox35.Text, out res);
                //bool ok4 = int.TryParse(textBox34.Text, out date);
                bool ok5 = int.TryParse(textBox33.Text, out n);
                bool ok6 = int.TryParse(textBox32.Text, out cty);

                if (ok1 && ok2 && ok3 && ok5 && ok6)
                {
                    //SQL Code : Exec Add_Delivery 55,2,3,'2012-08-20',5,3
                    Exec("Use ShopDB Exec Update_Delivery " + id + "," + com + "," + res + ",'" + textBox34.Text + "'," + n + "," + cty);
                    textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                    Show("select * from Delivery");
                }
                else
                    MessageBox.Show("DeliveryID , CompanyID , ResponsibleID , Numberof And CommodityTypeID Must be Natural Integers!");
            }
        }

        // Update Buy
        private void button29_Click(object sender, EventArgs e)
        {
            if (textBox38.Text == "" || textBox39.Text == "" || textBox40.Text == "" || textBox41.Text == "" || textBox42.Text == "" || textBox43.Text == "" || textBox44.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int pid, co, ctye, comm, n;
                bool ok1 = int.TryParse(textBox43.Text, out pid);
                bool ok2 = int.TryParse(textBox42.Text, out co);
                bool ok3 = int.TryParse(textBox41.Text, out ctye);
                bool ok5 = int.TryParse(textBox44.Text, out n);
                bool ok6 = int.TryParse(textBox40.Text, out comm);

                if (ok1 && ok2 && ok3 && ok5 && ok6)
                {
                    //SQL Code : Exec Add_Buy 34,4,4,4,'13:05','2012-12-12',4
                    Exec("Use ShopDB Exec Update_Buy " + pid + "," + co + "," + ctye + "," + comm + ",'" + textBox39.Text + "','" + textBox38.Text + "'," + n);
                    textBox38.Text = textBox39.Text = textBox40.Text = textBox41.Text = textBox42.Text = textBox43.Text = textBox44.Text = "";
                    Show("select * from Buy");
                }
                else
                    MessageBox.Show("PurchaseID , Costumer ID , CommodityType , CommodityID & NumberOf Must be Natural Integers!");
            }
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity_Type ");
            textBox10.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

            Show("Select * from Manager");
            textBox10.Text = "";
        }

        

        // 
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity_Type");
            textBox10.Text = "";
        }

        // Add Commodity
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox16.Text == "" || textBox17.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id,typid,cid,res,money;
                bool ok1 = int.TryParse(textBox17.Text, out id);
                bool ok2 = int.TryParse(textBox14.Text, out typid);
                bool ok3 = int.TryParse(textBox12.Text, out cid);
                bool ok4 = int.TryParse(textBox11.Text, out res);
                int.TryParse(textBox13.Text, out money);

                string checkcmd = "Select * from Commodity where ID = ";
                int ans = Checker(checkcmd, id);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1 && ok2 && ok3 && ok4)
                    {
                        //SQL Code : Exec Add_Commodity 37,'Name',2,200,1,1
                        Exec("Use ShopDB Exec Add_Commodity " + id + ",'" + textBox16.Text + "'," + typid + "," + money + "," + cid + "," + res);
                        textBox11.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox16.Text = textBox17.Text = "";
                        Show("select * from Commodity");
                    }
                    else
                        MessageBox.Show("CommodityID , CommodityType , CompanyID & Responsible Must be Natural Integers!");
                }
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity_Type");
            textBox10.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Company");
            textBox10.Text = "";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Clerck");
            textBox10.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "" || textBox15.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id;
                bool ok1 = int.TryParse(textBox18.Text, out id);

                string checkcmd = "Select * from Commodity_Type where ID = ";
                int ans = Checker(checkcmd, id);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1)
                    {
                        //SQL Code : Exec Add_ComType 45,'x'
                        Exec("Use ShopDB Exec Add_ComType " + id + ",'" + textBox15.Text + "'");
                        textBox18.Text = textBox15.Text = "";
                        Show("select * from Commodity_Type");
                    }
                    else
                        MessageBox.Show("CommodityTypeID Must be Natural Integers!");
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (textBox37.Text == "" || textBox35.Text == "" || textBox36.Text == "" || textBox33.Text == "" || textBox32.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int id,com,res,date,n,cty;
                bool ok1 = int.TryParse(textBox37.Text, out id);
                bool ok2 = int.TryParse(textBox36.Text, out com);
                bool ok3 = int.TryParse(textBox35.Text, out res);
                //bool ok4 = int.TryParse(textBox34.Text, out date);
                bool ok5 = int.TryParse(textBox33.Text, out n);
                bool ok6 = int.TryParse(textBox32.Text, out cty);


                string checkcmd = "Select * from Delivery where Del_ID = ";
                int ans = Checker(checkcmd, id);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1 && ok2 && ok3 && ok5 && ok6)
                    {
                        //SQL Code : Exec Add_Delivery 55,2,3,'2012-08-20',5,3
                        Exec("Use ShopDB Exec Add_Delivery " + id + "," + com + "," + res + ",'" + textBox34.Text + "'," + n + "," + cty);
                        textBox32.Text = textBox33.Text = textBox34.Text = textBox35.Text = textBox36.Text = textBox37.Text = "";
                        Show("select * from Delivery");
                    }
                    else
                        MessageBox.Show("DeliveryID , CompanyID , ResponsibleID , Numberof And CommodityTypeID Must be Natural Integers!");
                }
            }
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Company");
            textBox10.Text = "";
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Clerck");
            textBox10.Text = "";
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity_Type");
            textBox10.Text = "";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (textBox38.Text == "" || textBox39.Text == "" || textBox40.Text == "" || textBox41.Text == "" || textBox42.Text == "" || textBox43.Text == "" || textBox44.Text == "")
                textBox10.Text = "Red Colored Lables Are Neccessary!";
            else
            {
                textBox10.Text = "";
                int pid , co , ctye , comm , n;
                bool ok1 = int.TryParse(textBox43.Text, out pid);
                bool ok2 = int.TryParse(textBox42.Text, out co);
                bool ok3 = int.TryParse(textBox41.Text, out ctye);
                bool ok5 = int.TryParse(textBox44.Text, out n);
                bool ok6 = int.TryParse(textBox40.Text, out comm);

                string checkcmd = "Select * from Buy where Pur_Number = ";
                int ans = Checker(checkcmd, pid);

                if (ans > 0) MessageBox.Show("Duplicate Record is Unacceptable");
                else
                {
                    if (ok1 && ok2 && ok3 && ok5 && ok6)
                    {
                        //SQL Code : Exec Add_Buy 34,4,4,4,'13:05','2012-12-12',4
                        Exec("Use ShopDB Exec Add_Buy " + pid + "," + co + "," + ctye + "," + comm + ",'" + textBox39.Text + "','" + textBox38.Text + "'," + n);
                        textBox38.Text = textBox39.Text = textBox40.Text = textBox41.Text = textBox42.Text = textBox43.Text = textBox44.Text = "";
                        Show("select * from Buy");
                    }
                    else
                        MessageBox.Show("PurchaseID , Costumer ID , CommodityType , CommodityID & NumberOf Must be Natural Integers!");
                }
            }
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Costumer");
            textBox10.Text = "";
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity_Type");
            textBox10.Text = "";
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            Show("Select * from Commodity");
            textBox10.Text = "";
        }

        
        


    }
}
