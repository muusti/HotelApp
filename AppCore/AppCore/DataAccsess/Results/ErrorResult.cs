using AppCore.DataAccsess.Results.Bases;

namespace AppCore.DataAccsess.Results
{
    public class ErrorResult : Result
    {
        // constraktır oluştururken constraktırların isimlşeri classın ismi ile aynı olmalıdır 
        public ErrorResult(string message) : base(false, message)// Base demek Result demek dir 
        {

        }

        public ErrorResult() : base(false, "") // Defult class Constrıraktıra input göndermez isek her zaman bu çalışır 
        {

        }
    }

    /* Result result = new ErrorResult("Record exist in database!");
     * if(result.IsSuccessful )// result.IsSuccessful: false
     * 
     * {
     *   ......
     * }
     * else 
     * {
     *   ....(Burası Çalışacak )
     * } */
}
