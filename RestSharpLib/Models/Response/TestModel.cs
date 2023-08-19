using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpLib.Models.Response
{
    

    public class PetResult : List<Pet>
    {
        
    }

    public class Pet
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public Tag[] tags { get; set; }
        public string status { get; set; }
    }

    public class Category
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    public class Tag
    {
        public long id { get; set; }
        public string name { get; set; }
    }

    
}
