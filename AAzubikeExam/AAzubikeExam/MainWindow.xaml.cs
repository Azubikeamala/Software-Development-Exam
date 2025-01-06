using System.Data;
using System.Windows;

namespace AAzubikeExam
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeDataHelper dataHelper;

        public MainWindow()
        {
            InitializeComponent();
            dataHelper = new EmployeeDataHelper();
            LoadAllEmployees();
        }

        // Loads all employees when the application starts
        private void LoadAllEmployees()
        {
            DataTable employees = dataHelper.GetAllEmployees();
            dgEmployees.ItemsSource = employees.DefaultView;
        }

        // Event handler for GotFocus
        private void TxtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "Enter name to search")
            {
                txtSearch.Text = "";
                txtSearch.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        // Event handler for LostFocus
        private void TxtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "To Search, Enter name";
                txtSearch.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        // Search button click event handler
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string name = txtSearch.Text.Trim();
            DataTable result;

            if (string.IsNullOrEmpty(name) || name == "Enter name to search")
            {
                result = dataHelper.GetAllEmployees();
            }
            else
            {
                result = dataHelper.SearchEmployees(name);
            }

            dgEmployees.ItemsSource = result.DefaultView;
        }
    }
}
