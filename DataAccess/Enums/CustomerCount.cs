using System.ComponentModel;

namespace DataAccess.Enums
{
    public class CustomerCount
    {
        [DisplayName("One Customer")]
        public int OneCustomer { get; set; } = 1;
       
        [DisplayName("Two Customer")]
        public int TwoCustomer { get; set; } = 2;
        
        [DisplayName("There Customer")]
        public int ThirdCustomer { get; set; } = 3;
        
        [DisplayName("Four Customer")]
        public int FourthCustomer { get; set; } = 4;

    }
}
