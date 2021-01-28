using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataSample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User()
        {

        }

        public User(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
