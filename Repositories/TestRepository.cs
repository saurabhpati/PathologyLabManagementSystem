using Models;
using System.Data;

namespace Repositories
{
    public interface ITestRepository
    {
        int AddTest(Test tstObj);
    }
    public class TestRepository: ITestRepository
    {
        public int AddTest(Test tstObj)
        {
            var dbConnect = new DataAccess();
            using (dbConnect.con)
            {

            }
                return 1;
        }
    }
}
