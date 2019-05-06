using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMDemo.Model;
using System.Collections.ObjectModel;
using System.Timers;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        private System.Timers.Timer timer1;
        private ObservableCollection<Student> students;

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        public void OnTimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (students!=null) 
                    students.Add(new Student { FirstName = "Mark", LastName = "Allain" + RandomString(10,true)});
        }

        public StudentViewModel()
        {
            students = new ObservableCollection<Student>();
            timer1 = new Timer (2000);
            timer1.Enabled = false;        
            timer1.Elapsed += OnTimerEvent;
        }

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
           
            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });

            Students = students;

            timer1.Enabled = true;
        }
    }
}
