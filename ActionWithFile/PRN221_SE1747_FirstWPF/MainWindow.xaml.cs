using Microsoft.EntityFrameworkCore;
using PRN221_SE1747_FirstWPF.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN221_SE1747_FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Student> Students { get; set; }
        private readonly Prn221_DB_SE1747Context _context = new Prn221_DB_SE1747Context();

        public MainWindow()
        {
            InitializeComponent();
            LoadStudent();
            LoadDepartment();
        }

        private void LoadStudent()
        {
            lvStudent.ItemsSource = _context.Students.Include(x => x.Depart).ToList();
        }

        private void lvStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedStudent = lvStudent.SelectedItem as Student;

            if (selectedStudent != null)
            {
                txtID.Text = selectedStudent.Id.ToString();
                txtName.Text = selectedStudent.Name;
                if (selectedStudent.Gender == true)
                {
                    rbMale.IsChecked = true;
                    rbFemale.IsChecked = false;
                }
                else
                {
                    rbMale.IsChecked = false;
                    rbFemale.IsChecked = true;
                }
                txtGpa.Text = selectedStudent.Gpa.ToString();
                dpBirthday.SelectedDate = selectedStudent.Dob;
                cbDepartment.SelectedValue = selectedStudent.Depart.Name;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudent = new AddStudent(_context);
            addStudent.ShowDialog();
            LoadStudent();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(_context, lvStudent.SelectedItem as Student);
            updateStudent.ShowDialog();
            LoadStudent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = lvStudent.SelectedItem as Student;

            if (selectedStudent != null)
            {
                _context.Students.Remove(selectedStudent);
                _context.SaveChanges();
                MessageBox.Show("Delete successfully!");
                LoadStudent();
                return;
            }
            MessageBox.Show("Error when delete student!!!");
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Load(object sender, RoutedEventArgs e)
        {

        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDepartment();
        }

        private void LoadDepartment()
        {
            cbDepartment.ItemsSource = _context.Departments.Select(x => x.Name).ToList();
        }
    }
}