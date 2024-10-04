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
            if(lvStudent.SelectedItem == null)
            {
                MessageBox.Show("Please select a student to update!");
                return;
            }
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
            this.Close();
        }

        private void btn_Load(object sender, RoutedEventArgs e)
        {
            LoadStudent();
        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDepartment();
        }

        private void LoadDepartment()
        {
            cbDepartment.ItemsSource = _context.Departments.Select(x => x.Name).ToList();
        }

        private void tbSeachContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBy = cbSearchBy.Text;

            switch (searchBy)
            {
                case "Name": 
                    lvStudent.ItemsSource = _context.Students.Include(x => x.Depart).Where(x => x.Name.Contains(tbSeachContent.Text)).ToList();
                    break;

                case "GPA":
                    var gpa = tbSeachContent.Text;
                    double gpaParse;

                    if (string.IsNullOrWhiteSpace(gpa))
                    {
                        LoadStudent();
                        return;
                    }

                    try
                    {
                        gpaParse = double.Parse(gpa);
                    } catch(Exception ex)
                    {
                        MessageBox.Show("GPA must be a number");
                        return;
                    }
                    lvStudent.ItemsSource = _context.Students.Include(x => x.Depart).Where(x => x.Gpa == gpaParse).ToList();
                    break;
            }
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedFilterItem = (cbFilter.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (selectedFilterItem == "Gender")
            {
                var genders = new List<string> { "Male", "Female" };
                cbFilterValue.ItemsSource = genders;
                cbFilterValue.SelectionChanged += CbFilterValue_SelectionChanged_Gender;
            }
            else if (selectedFilterItem == "Department")
            {
                var departments = _context.Departments.Select(d => d.Name).ToList();
                cbFilterValue.ItemsSource = departments;
                cbFilterValue.SelectionChanged += CbFilterValue_SelectionChanged_Department;
            }
        }

        private void CbFilterValue_SelectionChanged_Gender(object sender, SelectionChangedEventArgs e)
        {
            var selectedGender = cbFilterValue.SelectedItem as string;

            bool? genderValue = selectedGender == "Male" ? true : selectedGender == "Female" ? false : (bool?)null;

            if (genderValue.HasValue)
            {
                lvStudent.ItemsSource = _context.Students.Include(s => s.Depart)
                    .Where(s => s.Gender == genderValue).ToList();
            }
        }

        private void CbFilterValue_SelectionChanged_Department(object sender, SelectionChangedEventArgs e)
        {
            var selectedDepartment = cbFilterValue.SelectedItem as string;

            lvStudent.ItemsSource = _context.Students.Include(s => s.Depart)
                .Where(s => s.Depart.Name == selectedDepartment).ToList();
        }

    }
}
