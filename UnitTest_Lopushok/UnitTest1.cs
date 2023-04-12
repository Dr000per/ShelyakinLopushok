using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ShelyakinLopushok;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;

namespace UnitTest_Lopushok
{
    [TestClass]
    public class UnitTest_Lopushka
    {
        [TestMethod]
        public void Cmd_executesqlnonquery()
        {
            string querystring = $"update product set articlenumber = '555512' where articlenumber = '442634';";
            bool expected = true;

            DataBase db = new DataBase();
            bool actual = db.ExecuteNonQuery(querystring);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Open_con()
        {
            bool expected = true;
            DataBase db = new DataBase();
            bool actual = db.OpenConnection();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Close_con()
        {
            bool expected = true;
            DataBase db = new DataBase();
            bool actual = db.CloseConnection();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Delete_butt()
        {
            bool expected = true;
            MainForm frm = new MainForm();
            bool actual = frm.Delete_Button(11, "444337");
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Upd_form_open()
        {
            bool expected = true;
            MainForm frm = new MainForm();
            bool actual = frm.UpdForm_open();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Add_form_open()
        {
            bool expected = true;
            MainForm frm = new MainForm();
            bool actual = frm.FormAdd_open();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Insert_button()
        {
            bool expected = true;
            FormAdd formAdd = new FormAdd();
            bool actual = formAdd.Insert_But("Аа", "Ааа", 24500, "dgs.png", 2, 4, "Пп");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Select_page_dff()
        {
            bool expected = false;
            MainForm frm = new MainForm();
            bool actual = frm.SelectPageData("ава", "ВЫАва", "23", "ffs");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Button_Go()
        {
            bool expected = true;
            MainForm frm = new MainForm();
            bool actual = frm.But_Go(1, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Button_Back()
        {
            bool expected = true;
            MainForm frm = new MainForm();
            bool actual = frm.But_Back(-3);
            Assert.AreEqual(expected, actual);
        }
    }
}
