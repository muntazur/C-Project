using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isCopy = false,isCut = false;
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string chosenFile = "";

            openFd.InitialDirectory = "C:";
            openFd.Title = "Open a File";
            openFd.FileName = "";
            openFd.Filter = "Text Files|*.txt|word Documents|*.doc|All Files|*.*";
            //openFd.Filter = "Text Files|*.txt|Word Documents|*.doc";
             //openFd.ShowDialog();
            if (openFd.ShowDialog() != DialogResult.Cancel)
            {
                chosenFile = openFd.FileName;
                richTextBox1.LoadFile(chosenFile, RichTextBoxStreamType.PlainText);
            }

        }

        public void mnuSave_Click(object sender, EventArgs e)
        {
            string saveFile = "";
            saveFd.InitialDirectory = "C:";
            saveFd.Title = "Open a File";
            saveFd.FileName = "";
            if (saveFd.ShowDialog() != DialogResult.Cancel)
            {
                saveFile = saveFd.FileName;
                richTextBox1.SaveFile(saveFile, RichTextBoxStreamType.PlainText);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.Copy();
                isCopy = true;
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (isCopy || isCut) richTextBox1.Paste();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.Cut();
                isCut = true;
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void mnuClearSelectedTexts_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "") richTextBox1.SelectedText = "";
        }

      

    

      
       

       // private void viewToolStripMenuItem_Click(object sender, EventArgs e)
       // {

        //}

      

        private void mnuHideTextBoxes_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
        }

        private void mnuUnhideTextBoxes_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
        }

        private void viewTextBoxesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (MessageBox.Show("Do you Want to Save Changes to untitled..?", "Muntaz's NotePad", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string save = "";
                    saveFd.InitialDirectory = "C:";
                    saveFd.Title = "Save a File";
                    saveFd.FileName = "";
                    saveFd.Filter = "Text Files|*.Txt|Words Documents|*.doc|All Files|*.*";

                    if (saveFd.ShowDialog() != DialogResult.Cancel)
                    {
                        save = saveFd.FileName;
                        richTextBox1.SaveFile(save, RichTextBoxStreamType.PlainText);
                    }
                   
                }
                else richTextBox1.Clear();
            }
        }

        private void mnuAboutNotePad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Microsoft Windows\n Version 100.001\n","About Notepad");
        }

        private void mnuAboutDeveloper_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creted By: Md Muntazur Rahman\nCountry: Bangladesh\nDivision: Khulna\nDistrict: Chuadanga\nUnion: Juranpur\nVillage: Bishnupur\n","Address Of Developer..>");
        }

     
    }
}
