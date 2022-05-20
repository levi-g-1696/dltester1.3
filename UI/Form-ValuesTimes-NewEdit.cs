using System;
using System.Drawing;
using System.Windows.Forms;
using Entities.Models;
using System.Text.RegularExpressions;
using Entities;

namespace UI
{

    public delegate void ValuesTimesSaveEventHandler(string m, string f, string t);
    public delegate void ValuesTimesSaveEventHandler1(ValuesTime valuesTime, Entities.Editmode savemode);
    public delegate string ValuesTimesReadEventHandler1(int id);
    public partial class Form_ValuesTimes_NewEdit : Form, IForm
    {
        public static event ValuesTimesSaveEventHandler SaveAction;
        public static event ValuesTimesSaveEventHandler1 SaveToDB;
        public static event ValuesTimesReadEventHandler1 GetFromDBMonitorNames;
        string monitorNames;
        string monitorsFromValues;
        string monitorsToValues;
        Editmode savemode;
        Form_ValuesTimesView fatherForm;
        ValuesTime valuesTime;
        public bool globalValid = true;


        public Form_ValuesTimes_NewEdit(Editmode editmode, Form_ValuesTimesView fatherFormArg)
        {
            InitializeComponent();
            savemode = editmode;
            fatherForm = fatherFormArg;
            bool globalValid = true;
            if (editmode == Editmode.New) // empty form
            {
                valuesTime = new ValuesTime();
                monitorNames = UISessionValue.MonitorList.MonitorNames;  //zagluska1
                                                                         //string monitorNames = UISessionValue.MonitorList.MonitorNames;
                valuesTime.MonNames = monitorNames;
                valuesTime.MonListId = UISessionValue.MonitorList.MonListId;
                txtMonlist.Text = UISessionValue.MonitorList.MonListId + " # " + UISessionValue.MonitorList.Name;
                //  *********  fill table  ************** 
                string[] monNamesArr = monitorNames.Split(',');
                gridValTimes.Rows.Add(monNamesArr.Length);
                for (int i = 0; i < monNamesArr.Length; i++)
                {
                    gridValTimes.Rows[i].Cells[0].Value = monNamesArr[i];
                }
                //****************************************

            }
            else  // edit an exist
            {


                txtMonlist.Text = UISessionValue.ValTimes.MonListId + " # " + UISessionValue.MonitorList.Name;
                txtName.Text = UISessionValue.ValTimes.Name;
                if (UISessionValue.ValTimes.DuringTime != null)
                {
                    txtDuration.Text = Math.Round((decimal)UISessionValue.ValTimes.DuringTime, 1) + "";
                }
                else txtDuration.Text = "??";

                //  *********  fill table  ************** 
                string[] monNamesArr = UISessionValue.MonitorList.MonitorNames.Split(',');

                string[] monValuesFrom = UISessionValue.ValTimes.MonFrom.Split(',');
                string[] monValuesTo = UISessionValue.ValTimes.MonTo.Split(',');

                gridValTimes.Rows.Add(monNamesArr.Length);
                for (int i = 0; i < monNamesArr.Length; i++)
                {
                    gridValTimes.Rows[i].Cells[0].Value = monNamesArr[i];
                }
                for (int i = 0; i < monValuesFrom.Length; i++)
                {
                    gridValTimes.Rows[i].Cells[1].Value = monValuesFrom[i];
                    gridValTimes.Rows[i].Cells[2].Value = monValuesTo[i];
                }
                //****************************************
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            monitorsFromValues = string.Empty;

            for (int rows = 0; rows < gridValTimes.Rows.Count-1; rows++)
            {

              if (GridCellValidation(gridValTimes, rows, 1))
                {
                    monitorsFromValues += gridValTimes.Rows[rows].Cells[1].Value;
                    if (rows < gridValTimes.Rows.Count - 2) monitorsFromValues += ",";
                }
                            }
            monitorsToValues = string.Empty;

            for (int rows = 0; rows < gridValTimes.Rows.Count-1; rows++)
            {
                if (GridCellValidation(gridValTimes, rows, 2))
                {
                    monitorsToValues += gridValTimes.Rows[rows].Cells[2].Value;
                    if (rows < gridValTimes.Rows.Count - 2) monitorsToValues += ",";
                }
               
                
            }
            if (UIinputValidation())
            {
                UISessionValue.ValTimes.Name = txtName.Text;
                UISessionValue.ValTimes.MonFrom = monitorsFromValues;
                UISessionValue.ValTimes.MonTo = monitorsToValues;
                UISessionValue.ValTimes.DuringTime = double.Parse(txtDuration.Text);
                UISessionValue.ValTimes.MonListId = UISessionValue.MonitorList.MonListId;
             //   UISessionValue.ValTimes.ValTimesId = 0;
                Save();
                RefreshPreviousWindow();
                this.Close();
            }
            globalValid= true;
        }
        public bool GridCellValidation(DataGridView valtimes, int row, int cell)
        {
            double d;
            if (!double.TryParse((string)valtimes.Rows[row].Cells[cell].Value, out d))
            {
                valtimes.Rows[row].Cells[cell].Value = "???";
              
                globalValid = false;
            }

            return globalValid;
        }
        public bool UIinputValidation()
        {
            double d;
            
            string regexName = "^([a-zA-Z][a-zA-Z0-9' ]{0,49})$";
            if (!Regex.Match(txtName.Text, regexName).Success)
            {
                txtName.BackColor = Color.Salmon;
               
                globalValid = false;
            }

            if (!double.TryParse(txtDuration.Text, out d))
            {
                txtDuration.BackColor = Color.Salmon;
                globalValid = false;
            }
            return globalValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void Save()
        {
            SaveToDB(UISessionValue.ValTimes, savemode);
        }

        public void RefreshPreviousWindow()
        {
            fatherForm.GridViewRefresh();
        }
    }
}
