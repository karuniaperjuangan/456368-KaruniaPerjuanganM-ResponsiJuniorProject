using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiJuniorProject
{
    public abstract class User
    {

        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        public User(string name)
        {
            _name = name;
        }
    }

    public class Karyawan : User
    {
        private string id_dept;

        public string IdDept{ get { return id_dept; } set { id_dept = value; } }
        public Karyawan(string name, string id_dept) : base(name)
        {
            this.id_dept = id_dept;
        }
    }
}
