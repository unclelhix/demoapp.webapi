using DemoApplication.WebAPI.Shared.Attributes;

namespace DemoApplication.WebAPI.Transports
{
    public class EmployeeTransport : BaseTransport
    {
        
        public int EmployeeStatus { get; set; }

        [DbColumn("EmployeeNumber")]
        public string EmpNumber { get; set; }
        [DbColumn("FirstName")]

        public string FName { get; set; }
        [DbColumn("MiddleName")]

        public string? MName { get; set; }
        [DbColumn("LastName")]

        public string LName { get; set; }
        [DbColumn("BirthDate")]

        public DateTime Bdate { get; set; }

        public  List<EmployeeContactsTransport> EmployeeContacts { get; set; }

        public List<EmployeeGovernmentNumbersTransportcs> EmployeeGovernmentNumbers { get; set; }


    }
}
