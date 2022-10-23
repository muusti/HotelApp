using AppCore.DataAccsess.Results.Bases;

namespace AppCore.DataAccsess.Results
{
    public class SuccessResult : Result
    {
        // constraktır oluştururken constraktırların isimlşeri classın ismi ile aynı olmalıdır 
        // constraktırlar public olmalıdır
        public SuccessResult(string message) : base(true, message)// Base demek Result demek dir 
        {

        }

        public SuccessResult () : base(true,"") // Defult class Constrıraktıra input göndermez isek her zaman bu çalışır 
        {

        }
    }
}

/*Örnek Kullanım
 * 
 * SuccessResult result = new SuccessResult(true,"Operation successful") // Mesaj paramatresine bir değer gönderirsek "public SuccessResult(string message) : base(true, message)" Bu kod çalışır
 * Result result = new SuccessResult(); //Mesaj paramateresini boş bırakırsak " public SuccessResult () : base(true,"")" bu kod çalişır
 * if(Result.IsSuccessful)
 * {
 *    ... (Burası Çalışacak)
 * }
 * 
 * else 
 * {
 *   .......
 * }
 */