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

        private String folder = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;

            /*
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

            MessageBox.Show(String.Format("Путь  к  временному  каталогу: {0}", Path.GetTempPath()));
            */

            
        
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.UTF8);
                folder = openFileDialog1.FileName;
                label1.Text = Path.GetFileName(openFileDialog1.FileName);
                //sb1.Append(sr.ReadToEnd());
                sr.Close();

                groupBox2.Enabled = true;
            }
        }

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            string[] findFiles = System.IO.Directory.GetFiles(@label1.Text, "*.jpg", System.IO.SearchOption.AllDirectories);
        }
    }
}

/*
 private async void findFiles()
        {
            await Task.Run(() =>
            {
                Action<string> addInListAction = (string text) =>
                {
                    lb.Items.Add(text);
                    tb.Text = "В списке: " + lb.Items.Count.ToString();
                };
                SearchFilesInDirectory("D:\\", new List<string>() { "*.jpg", "*.png" }, addInListAction);
            });
        }
        /// <summary>
        /// Поиск файлов по маске
        /// </summary>
        /// <param name="directory">Директория, в которой осуществляется поиск</param>
        /// <param name="searchPatternList">
        /// Строка поиска, которую необходимо сравнивать с именами файлов в directory. Параметр 
        ///     не должен заканчиваться двумя точками ("..") или содержать две точки ("..") 
        ///     непосредственно перед System.IO.Path.DirectorySeparatorChar или System.IO.Path.AltDirectorySeparatorChar, 
        ///     а также не должен содержать символы, входящие в список System.IO.Path.InvalidPathChars.
        /// </param>
        /// <param name="method">Делегат метода, который принимает параметр типа System.String помещен в очередь событий System.Windows.Threading.Dispatcher.</param>
        /// <exception cref="ArgumentException">
        /// <para>Путь является строкой нулевой длины, содержит только пробелы или содержит недопустимые символы.</para>
        /// <para>Параметр поиска не является допустимым значением.</para>
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">Путь недопустим, например, ссылается на неподключенный диск.</exception>
        /// <exception cref="IOException">
        /// <para>Путь является именем файла.</para>
        /// <para>Длина указанного пути, имени файла или обоих параметров превышает установленный системой предел.</para>
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">Исключение, возникающее в случае запрета доступа операционной системой из-за 
        /// ошибки ввода-вывода или особого типа ошибки безопасности.</exception>
        /// <exception cref="ArgumentNullException">Исключение возникает, если параметр searchPatternList равен null или колличество элементов в нем равно 0.</exception>
        public void SearchFilesInDirectory(String directory, IEnumerable<string> searchPatternList, Delegate method)
        {
            if ((searchPatternList == null) || (searchPatternList.Count<string>() == 0))
                throw new ArgumentNullException("searchPatternList");
            foreach (string searchPattern in searchPatternList)
            {
                using (var iterator = Directory.EnumerateFiles(directory, searchPattern).GetEnumerator())
                {
                    try
                    {
                        while (iterator.MoveNext())
                            Application.Current.Dispatcher.BeginInvoke(method, iterator.Current);
                    }
                    catch (ArgumentException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (IOException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                }
            }
            using (var iterator = Directory.EnumerateDirectories(directory).GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    try
                    {
                        SearchFilesInDirectory(iterator.Current, searchPatternList, method);
                    }
                    catch (ArgumentException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (IOException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Debug.Print(ex.Message);
                    }
                }
            }
        }
 */

/**
 /// <summary>
    /// Предоставляет методы для поиска файлов в директории, включая вложенные.
    /// </summary>
    internal class FileWalker
    {
        #region Ctor

        /// <summary>
        /// Инициализирует новый экземпляр класса FileWalker.
        /// </summary>
        /// <param name="includePath">Список включаемых путей.</param>
        /// <param name="excludePath">Список исключаемых путей.</param>
        /// <param name="includeExtension">Список включаемых расширений.</param>
        /// <param name="excludeExtension">Список исключаемых расширений.</param>
        public FileWalker(IEnumerable<String> includePath, IEnumerable<String> excludePath, IEnumerable<String> includeExtension, IEnumerable<String> excludeExtension)
        {
            IncludePath = includePath;
            ExcludePath = excludePath;
            IncludeExtension = includeExtension;
            ExcludeExtension = excludeExtension;
        }
        
#if DEBUG
        /// <summary>
        /// Полезен для обеспечения того, чтобы объекты должным образом были обработаны сборщиком мусора.
        /// </summary>
        ~FileWalker()
        {
            Debug.WriteLine(string.Format("{0} ({1}) Finalized", GetType().Name, GetHashCode()));
        }
#endif
        
        #endregion

        #region Properties

        /// <summary>
        /// Возвращает или задает список включаемых путей.
        /// </summary>
        private IEnumerable<String> IncludePath { get; set; }

        /// <summary>
        /// Возвращает или задает список исключаемых путей.
        /// </summary>
        private IEnumerable<String> ExcludePath { get; set; }

        /// <summary>
        /// Возвращает или задает список включаемых расширений.
        /// </summary>
        private IEnumerable<String> IncludeExtension { get; set; }

        /// <summary>
        /// Возвращает или задает список исключаемых расширений.
        /// </summary>
        private IEnumerable<String> ExcludeExtension { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// Возвращает имена файлов (включая пути) из указанного каталога.
        /// </summary>
        /// <returns>Массив String содержит имена файлов из указанного каталога.Имена файлов включают полный путь к файлу.</returns>
        public IEnumerable<String> GetFiles()
        {
            // Создаем список
            var list = new List<String>();
            // Проверяем список включаемых папок
            if (IncludePath != null)
            {
                using (var enumerator = IncludePath.GetEnumerator())
                {
                    // Проходим все пути
                    while (enumerator.MoveNext())
                    {
                        // Проверяем список строк поиска
                        if (IncludeExtension != null)
                        {
                            using (var iterator = IncludeExtension.GetEnumerator())
                            {
                                // Проходим все строки поиска
                                while (iterator.MoveNext())
                                {
                                    // Проверяем папку в исключенных
                                    if (!ExcludePath.Contains(enumerator.Current, StringComparer.OrdinalIgnoreCase))
                                    {
                                        // Получаем файлы
                                        list.AddRange(GetFiles(enumerator.Current, iterator.Current));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // Возвращаем результат
            return list;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Возвращает имена файлов (включая пути) из указанного каталога, отвечающие условиям заданного шаблона поиска.
        /// </summary>
        /// <param name="directory">Каталог, в котором необходимо выполнить поиск.</param>
        /// <param name="searchPattern">Строка поиска, которую необходимо сравнить с именами файлов, на которые указывает путь</param>
        /// <returns>Массив String содержит имена файлов из указанного каталога, отвечающие условиям заданного шаблона поиска.Имена файлов включают полный путь к файлу.</returns>
        private IEnumerable<String> GetFiles(String directory, String searchPattern)
        {
            // Создаем список
            var list = new List<String>();
            // Итератор по файлам
            using (var iterator = Directory.EnumerateFiles(directory, searchPattern).GetEnumerator())
            {
                try
                {
                    while (iterator.MoveNext())
                    {
                        // Получаем расширение файла и проверяем его
                        var fileInfo = new FileInfo(iterator.Current);
                        if (!ExcludeExtension.Contains(String.Concat("*", fileInfo.Extension)))
                        {
                            // Добавляем в список
                            list.Add(iterator.Current);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    // Путь является строкой нулевой длины, содержит только пробелы или содержит недопустимые символы.
                    // Параметр поиска не является допустимым значением.
                    Debug.Print(ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    // Путь недопустим, например, ссылается на неподключенный диск.
                    Debug.Print(ex.Message);
                }
                catch (IOException ex)
                {
                    // Путь является именем файла.
                    // Длина указанного пути, имени файла или обоих параметров превышает установленный системой предел.
                    Debug.Print(ex.Message);
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Исключение, возникающее в случае запрета доступа операционной системой 
                    // из-за ошибки ввода-вывода или особого типа ошибки безопасности.
                    Debug.Print(ex.Message);
                }
            }
            // Итератор по директориям
            using (var iterator = Directory.EnumerateDirectories(directory).GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    try
                    {
                        // Проверяем папку в исключенных
                        if (!ExcludePath.Contains(iterator.Current, StringComparer.OrdinalIgnoreCase))
                        {
                            list.AddRange(GetFiles(iterator.Current, searchPattern));
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        // Путь является строкой нулевой длины, содержит только пробелы или содержит недопустимые символы.
                        // Параметр поиска не является допустимым значением.
                        Debug.Print(ex.Message);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        // Путь недопустим, например, ссылается на неподключенный диск.
                        Debug.Print(ex.Message);
                    }
                    catch (IOException ex)
                    {
                        // Путь является именем файла.
                        // Длина указанного пути, имени файла или обоих параметров превышает установленный системой предел.
                        Debug.Print(ex.Message);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        // Исключение, возникающее в случае запрета доступа операционной системой 
                        // из-за ошибки ввода-вывода или особого типа ошибки безопасности.
                        Debug.Print(ex.Message);
                    }
                }
            }
            // Возвращаем результат
            return list;
        }

        #endregion
    }
 * /