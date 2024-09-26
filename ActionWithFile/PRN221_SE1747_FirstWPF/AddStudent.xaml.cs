using PRN221_SE1747_FirstWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRN221_SE1747_FirstWPF
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private readonly Prn221_DB_SE1747Context _context;
        public AddStudent(Prn221_DB_SE1747Context _context)
        {
            this._context = _context;
            InitializeComponent();
            LoadDepartment();
        }

        private void LoadDepartment()
        {
            cbDepartment.ItemsSource = _context.Departments.Select(x => x.Name).ToList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var maxStudentId = _context.Students.Max(x => x.Id);

            var student = new Student()
            {
                Id = maxStudentId + 1,
                Name = txtName.Text,
                Gender = rbMale.IsChecked == true ? true : false,
                Dob = dpBirthday.SelectedDate,
                Gpa = double.Parse(txtGpa.Text),
                DepartId = _context.Departments.Where(x => x.Name == cbDepartment.SelectedItem.ToString())?.Select(x => x.Id)?.FirstOrDefault()
            };

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                MessageBox.Show("Add student successfully");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
