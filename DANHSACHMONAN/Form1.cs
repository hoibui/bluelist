using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DANHSACHMONAN
{
    public partial class Form1 : Form
    {
        class MonAn
        {

            public string Ten { get; set; }

            public string Hinh { get; set; }

            public string Mien { get; set; }
        }
        const string BAC = "BẮC";
        const string TRUNG = "MIENTRUNG";
        const string NAM = "MIENNAM"; 
        const string TATCA = "TẤT CẢ";
        SortedList<String, MonAn> monan;
        public Form1()
        {
            InitializeComponent();
            DanhSachMon();
        }

        private void DanhSachMon()
        {
            monan = new SortedList<string, MonAn>
            {
            { "BC001", new MonAn{Ten = "Bánh Chưng",Hinh="banh_chung.jpg", Mien = BAC }},
            
         
           
        };
        //    monan = new SortedList<string, MonAn>
        //    {
            
        //    { "BL001", new MonAn{Ten = "Bánh Bột Lọc",Hinh="banh-bot-loc.jpg", Mien = TRUNG }},
         
           
        //};

        }

        private void cboChonMien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboChonMien.Items.Add(BAC);
            cboChonMien.Items.Add(TRUNG);
            cboChonMien.Items.Add(NAM);
            cboChonMien.Items.Add(TATCA);
            cboMien.Items.Add(BAC);
            cboMien.Items.Add(TRUNG);
            cboMien.Items.Add(NAM);
            cboMien.Items.Add(TATCA);
            cboMien.SelectedIndex = cboChonMien.SelectedIndex = 0;

            XuatDanhSach();
            //lsbDanhSach.SelectedIndex = 0;

        }

        private void XuatDanhSach()
        {
            lsbDanhSach.Items.Clear();
            foreach(KeyValuePair<string, MonAn>pair in monan)
            {
                if (cboChonMien.Text == TATCA||pair.Value.Mien==cboChonMien.Text)
                    lsbDanhSach.Items.Add(pair.Key + " - " + pair.Value.Ten);
            }
        }

        private void lsbDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbDanhSach.SelectedIndex < 0) return;
            int index = lsbDanhSach.Text.IndexOf('-');
            string key = lsbDanhSach.Text.Substring(0, index).Trim();
            MonAn mon;
            bool KetQua = monan.TryGetValue(key, out mon);
            if(!KetQua)
            {
                MessageBox.Show("Lỗi");
                return;
            }

            txtMa.Text = key;
            txtTen.Text = mon.Ten;
            txtHinh.Text = mon.Hinh;
            pictureBox1.ImageLocation = @"Image\" + mon.Hinh;
            cboMien.Text = cboChonMien.Text;
        }
    }
}
