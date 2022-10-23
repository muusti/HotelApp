namespace AppCore.DataAccsess.Results.Bases
{
     public abstract class Result
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

        protected Result(bool isSuccessful, string message) //Consractır
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

    }
}

/* Result result = new Result ()
{
     IsSuccessful = true,
     Message = "Operation successful."
}

Result result = new Result (true, "Operation successul"); bu kullanım önerilir
 */




