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
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        private readonly Prn221_DB_SE1747Context _context;

        private readonly Student student;

        public UpdateStudent(Prn221_DB_SE1747Context _context, Student student)
        {
            InitializeComponent();
            this.student = student;
            this._context = _context;
            FillDataToAttribute(student);
            LoadDepartment();
        }

        private void FillDataToAttribute(Student student)
        {
            txtName.Text = student.Name;
            txtGpa.Text = student.Gpa.ToString();
            rbMale.IsChecked = student.Gender == true ? rbMale.IsChecked = true : rbFemale.IsChecked = true;
            dpBirthday.SelectedDate = student.Dob;
            cbDepartment.SelectedValue = student.Depart.Name;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(student == null)
            {
                MessageBox.Show("Error when update student");
                return;
            }

            student.Name = txtName.Text;
            student.Dob = dpBirthday.SelectedDate;
            student.Gpa = double.Parse(txtGpa.Text);
            student.DepartId = _context.Departments.Where(x => x.Name == cbDepartment.SelectedItem.ToString())?.Select(x => x.Id)?.FirstOrDefault();
            student.Gender = rbMale.IsChecked == true ? true : false;

            try
            {
                _context.Update(student);
                _context.SaveChanges();
                MessageBox.Show("Update student successfully");
                this.Close();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
