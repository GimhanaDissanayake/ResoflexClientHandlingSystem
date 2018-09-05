﻿using MySql.Data.MySqlClient;
using ResoflexClientHandlingSystem.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResoflexClientHandlingSystem
{
    public partial class MemberListForm : MetroFramework.Forms.MetroForm
    {
        public MemberListForm()
        {
            InitializeComponent();
        }

        private void closeForm()
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            StaffForm frm = new StaffForm();
            frm.ShowDialog();
        }

        private void MembersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MemberListForm_Load(object sender, EventArgs e)
        {

        }
        
        public void loadMembersToGrid()
        {
            MySqlDataReader reader = DBConnection.getData("select s.staff_id, s.first_name as First_name, s.last_name as Last_name, " +
                "s.nic as NIC, d.designation_name as Designation, s.p_address as Address1, s.s_address as Address2, s.tel1 as Moblie, s.tel2 as Landline, s.email as Email, s.facebook as Facebook, " +
                "s.linkedin as LinkedIn, s.basic_salary as Basic_salary, s.ot_rate as OT_rate " +
                "from staff s inner join designation d on s.desig_id=d.desig_id");

            DataTable table = new DataTable();

            table.Load(reader);

            MembersGrid.DataSource = table;
        }

        private void MemberListForm_Shown(object sender, EventArgs e)
        {
            loadMembersToGrid();

            MembersGrid.Columns[0].Visible = false;
        }

        private void DelMemBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = MembersGrid.CurrentCell.RowIndex;
            MembersGrid.Rows.RemoveAt(rowIndex);
        }

        private void UpdateMemBtn_Click(object sender, EventArgs e)
        {

            int staffId = Int32.Parse(MembersGrid.CurrentRow.Cells[0].Value.ToString());
            string fn = MembersGrid.CurrentRow.Cells[1].Value.ToString();
            string ln = MembersGrid.CurrentRow.Cells[2].Value.ToString();
            string nic = MembersGrid.CurrentRow.Cells[3].Value.ToString();
            string desig = MembersGrid.CurrentRow.Cells[4].Value.ToString();
            string pa = MembersGrid.CurrentRow.Cells[5].Value.ToString();
            string sa = MembersGrid.CurrentRow.Cells[6].Value.ToString();
            string tel1 = MembersGrid.CurrentRow.Cells[7].Value.ToString();
            string tel2 = MembersGrid.CurrentRow.Cells[8].Value.ToString();
            string email = MembersGrid.CurrentRow.Cells[9].Value.ToString();
            string fb = MembersGrid.CurrentRow.Cells[10].Value.ToString();
            string link = MembersGrid.CurrentRow.Cells[11].Value.ToString();
            float bsal = float.Parse (MembersGrid.CurrentRow.Cells[12].Value.ToString());
            float ot = float.Parse (MembersGrid.CurrentRow.Cells[13].Value.ToString());

            StaffForms.UpdateMemberForm up = new StaffForms.UpdateMemberForm(staffId, fn, ln, nic, pa, sa, tel1, tel2, email, fb, link, bsal, ot, desig);
            up.ShowDialog();
        }

        private void StaffEvaBtn_Click(object sender, EventArgs e)
        {
            //StaffEvalutionForm

            StaffEvalutionForm stEva = new StaffEvalutionForm();
            this.Hide();
            stEva.ShowDialog();
            this.Close();
        }

        private void RecordAtteBtn_Click(object sender, EventArgs e)
        {
            //RecordAttendanceForm

            RecordAttendanceForm reAtt = new RecordAttendanceForm();
            this.Hide();
            reAtt.ShowDialog();
            this.Close();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.ShowDialog();
            this.Close();
        }
    }
}
