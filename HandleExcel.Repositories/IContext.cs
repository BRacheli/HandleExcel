using HandleExcel.Repositories.Entities;

namespace HandleExcel.Repositories
{
    public class IContext
    {
       public List<User> ValidTzs { get; set; }
       public List<User> InvalidTzs { get; set; }

    }
}