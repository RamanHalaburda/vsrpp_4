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
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Создать  приложение  для  поиска  файлов  с  заданным 
            именем/расширением из указанного места. Вывести полный путь найденных 
            файлов.  Предусмотреть  возможность  группового  переименования.  В 
            процессе работы приложения вести текстовый файл с результатами работы. 
         */

        private void Form1_Load(object sender, EventArgs e)
        {
            string a = @"C:\Каталог 1\Каталог 2\Каталог 3\Файл.exe";
            if (Path.HasExtension(a))
            {
                MessageBox.Show("Есть расширение, скорей всего это файл.");
            }
            else
            {
                MessageBox.Show("Нет расширения, возможно это не файл.");
            }

            MessageBox.Show(File.GetAttributes(@"C:\Windows").ToString());
            MessageBox.Show(File.GetAttributes(@"C:\Windows\notepad.exe").ToString()); 




            string с = @"C:\Каталог 1\Каталог 2\Каталог 3\Файл.exe";
            string p = Path.GetDirectoryName(с);
            MessageBox.Show(p); 



            string b = @"C:\Каталог 1\Каталог 2\Каталог 3\Файл.exe";
            string fileName = Path.GetFileNameWithoutExtension(b);
            string fileExtension = Path.GetExtension(b);
            MessageBox.Show(String.Format("Путь:  {0}\r\nИмя  файла: {1}\r\nТип файла: {2}", b, fileName, fileExtension)); 
        }
    }
}
