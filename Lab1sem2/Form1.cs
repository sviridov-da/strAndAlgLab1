using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab1sem2
{
    public partial class Form1 : Form
    {
        ITrieTree trieTree;
        ViewTree viewTree;
        string current_file;
        static string extension = "tt";
        static string base_file_name = "untitled";
        public Form1()
        {
            InitializeComponent();
            trieTree = new TrieTree();
            viewTree = new ViewTree(trieTree, treeView);
            current_file = base_file_name+"."+extension;
            Text = current_file;
            saveFileDialog1.Filter = "Файлы дерева|*." + extension;
            openFileDialog1.Filter = "Файлы дерева|*." + extension;
        }


        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        void NewFile()
        {
            current_file = base_file_name + "." + extension;
            Text = current_file;
            Clear();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        void AddWord()
        {
            GetWordForm addForm = new GetWordForm("Какое слово добавить?");
            addForm.ShowDialog();
            if (addForm.DialogResult == DialogResult.OK)
                try
                {
                    trieTree.AddElement(addForm.textBox1.Text);
                    viewTree.GetView();
                }
                catch(Exception exception)
                {
                    TextForm errorForm = new TextForm(exception.Message);
                    errorForm.ShowDialog();
                }
        }

        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            FindWord();
        }

        void FindWord()
        {
            GetWordForm findForm = new GetWordForm("Какое слово найти?");
            findForm.ShowDialog();
            if (findForm.DialogResult == DialogResult.OK)
                try
                {
                    TextForm messege;
                    if (trieTree.isElementExists(findForm.textBox1.Text))
                        messege = new TextForm("Слово найдено");
                    else
                        messege = new TextForm("Слово не найдено");
                    messege.ShowDialog();
                }
                catch (Exception exception)
                {
                    TextForm errorForm = new TextForm(exception.Message);
                    errorForm.ShowDialog();
                }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            DeleteWord();
        }

        void DeleteWord()
        {
            GetWordForm deleteForm = new GetWordForm("Какое слово удалить?");
            deleteForm.ShowDialog();
            if (deleteForm.DialogResult == DialogResult.OK)
                try
                {
                    trieTree.DeleteElement(deleteForm.textBox1.Text);
                    viewTree.GetView();
                }
                catch (Exception exception)
                {
                    TextForm errorForm = new TextForm(exception.Message);
                    errorForm.ShowDialog();
                }
        }

        private void toolStripButtonTask_Click(object sender, EventArgs e)
        {
            Task();
        }

        void Task()
        {
            GetWordForm taskForm = new GetWordForm("Введите подстроку:");
            taskForm.ShowDialog();
            if (taskForm.DialogResult == DialogResult.OK)
                try
                {
                    trieTree.deleteWordsContainsSubstr(taskForm.textBox1.Text);
                    viewTree.GetView();
                }
                catch (Exception exception)
                {
                    TextForm errorForm = new TextForm(exception.Message);
                    errorForm.ShowDialog();
                }
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        void Clear()
        {
            trieTree = new TrieTree();
            viewTree = new ViewTree(trieTree, treeView);
            viewTree.GetView();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (current_file == base_file_name + "." + extension)
                SaveFile();
            else
                SaveFile(current_file);
        }

        void SaveFile()
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                SaveFile(saveFileDialog1.FileName);
            }
        }

        void SaveFile(string file_name)
        {
            StreamWriter streamWriter = new StreamWriter(file_name);
            List<string> words = trieTree.Words;
            foreach (string word in words)
                streamWriter.WriteLine(word);
            streamWriter.Close();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileName != "")
            {
                current_file = openFileDialog1.FileName;
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                trieTree = new TrieTree();
                while (!streamReader.EndOfStream)
                    trieTree.AddElement(streamReader.ReadLine());
                viewTree = new ViewTree(trieTree, treeView);
                viewTree.GetView();
                Text = current_file;
                streamReader.Close();
            }
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(current_file);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
            current_file = base_file_name + "." + extension;
            Text = current_file;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void добавитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddWord();
        }

        private void удалитьСловоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteWord();
        }

        private void очиститьДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindWord();
        }

        private void задачаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task();
        }

    }
}
