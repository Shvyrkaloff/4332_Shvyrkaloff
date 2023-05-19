using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using Template_4332.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;
using Window = System.Windows.Window;

namespace Template_4332
{
    /// <summary>
    /// Логика взаимодействия для _4332_Shvyrkaloff.xaml
    /// </summary>
    public partial class _4332_Shvyrkaloff : Window
    {
        private readonly AutoService _skiServiceService;

        public _4332_Shvyrkaloff(ApplicationContext context)
        {
            ExcelApplication excel = new ExcelApplication();

            _skiServiceService = new AutoService(context, excel);

            InitializeComponent();
        }

        private void ExportForExcelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Workbook workbook = _skiServiceService.ExportEntities();

            string fileName = Directory.GetCurrentDirectory() + $"{Guid.NewGuid()}.xls";

            try
            {
                workbook.SaveAs(fileName, ".xls");
            }
            catch { }
        }

        private void ImportButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                DefaultExt = "*.xls;*.xlsx",
                Filter = "файл Excel (Spisok.xlsx)|*.xlsx",
                Title = "Выберите файл для импорта"
            };

            bool? showDialogResult = openFileDialog.ShowDialog();

            if (!showDialogResult.HasValue)
                return;

            if (!showDialogResult.Value)
                return;

            string fileName = openFileDialog.FileName;

            (bool importResult, int count) = _skiServiceService.ImportEntitiesFromWorkbook(fileName);

            if (!importResult)
            {
                MessageBox.Show("Неудача при импорте. Смотрите правильность", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            MessageBox.Show($"Импорт успешен, загружено {count} сущностей", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
