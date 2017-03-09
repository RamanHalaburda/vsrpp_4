using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace vsrpp_4
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        /*
           Создать  приложение  для  поиска  файлов  с  заданным 
            именем/расширением из указанного места. Вывести полный путь найденных 
            файлов.  Предусмотреть  возможность  группового  переименования.  В 
            процессе работы приложения вести текстовый файл с результатами работы. 
         */

        private String folder = null;
        private String logFile = "logfile.txt";
        private DirectoryInfo d;
        private FileInfo[] finfo;

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            label1.Visible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 350;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    label1.Visible = true;
                    folder = fbd.SelectedPath;
                    label1.Text = Path.GetFileName(folder);
                    groupBox2.Enabled = true;
                }
            }
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FileStream file = new FileStream(logFile, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("\n");

            String template;
            if (checkBox1.Checked)
                template = textBox1.Text;
            else
                template = "*.*";

            var fnames = Directory.GetFiles(folder, template).Select(Path.GetFileName);
            d = new DirectoryInfo(folder);
            finfo = d.GetFiles(template);

            UInt16 i = 0;
            foreach (var f in fnames)
            {                
                sw.WriteLine(String.Concat("The number of the searched file is: ", i));

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                dataGridView1.Rows[i].Cells[1].Value = f;
                i++;
            }
            sw.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(logFile, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine("\n");

            String template;
            if (checkBox1.Checked)
                template = textBox1.Text;
            else
                template = "*.*";

            String renameTemplate;
            if (checkBox2.Checked)
                renameTemplate = textBox1.Text;
            else
                renameTemplate = "defaultname";

            var fnames = Directory.GetFiles(folder, template).Select(Path.GetFileName);
            d = new DirectoryInfo(folder);
            finfo = d.GetFiles(template);

            UInt16 i = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    String oldFileName = Path.Combine(folder, row.Cells[1].Value.ToString());
                    String newFileName = Path.Combine(folder, String.Concat(renameTemplate,i.ToString()));
                    File.Delete(newFileName); // Delete the existing file if exists
                    File.Move(
                        oldFileName, 
                        newFileName);
                    sw.WriteLine(String.Concat("File is renemed. oldname(", oldFileName, "), newname(", newFileName, ")"));
                }
                else
                {
                    sw.WriteLine(String.Concat("File is not checked ", folder));
                }
                ++i;
            }
            
            sw.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                textBox2.Visible = true;
            else
                textBox2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox1.Visible = true;
            else
                textBox1.Visible = false;
        }

        public static void Rename(FileInfo fileInfo, string newName)
        {
            fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + newName);
        }
    }
}