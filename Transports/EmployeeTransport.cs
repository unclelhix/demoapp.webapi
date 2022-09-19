using DemoApplication.WebAPI.Shared.Attributes;

namespace DemoApplication.WebAPI.Transports
{
    public class EmployeeTransport : BaseTransport
    {
        
        public int EmployeeStatus { get; set; }

        public string EmpNumber { get; set; }

        public string FName { get; set; }
     
        public string? MName { get; set; }      

        public string LName { get; set; }

        public DateTime Bdate { get; set; }

        public  List<EmployeeContactsTransport> EmployeeContacts { get; set; }

        public List<EmployeeGovernmentNumbersTransportcs> EmployeeGovernmentNumbers { get; set; }


    }
}
